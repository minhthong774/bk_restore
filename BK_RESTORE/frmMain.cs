using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_RESTORE
{
    public partial class frmMain : Form
    {
        private List<String> listBackupDevice = new List<string>();
        private String position = "";
        private string sqlQuery = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            // TODO: This line of code loads data into the 'dS.databases' table. You can move, or remove it, as needed.
            this.databasesTableAdapter.Fill(this.dS.databases);

            // Load GridView position_backup 
            Program.dbName = ((DataRowView)databasesBindingSource[0])["name"].ToString().Trim();

            //MessageBox.Show(Program.dbName);
            //try
            //{
            this.position_backupTableAdapter.Fill(this.dS.position_backup, Program.dbName);
            //position = ((DataRowView)position_backupBindingSource[position_backupBindingSource.Position])["position"].ToString();
            //}catch(Exception exc)
            //{
            //	MessageBox.Show(exc.Message);
            //}

            // Ẩn menu "Tạo device đã lưu" nếu DB đã có device
            hideMenuDevice(Program.dbName);
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            Program.dbName = ((DataRowView)databasesBindingSource[databasesBindingSource.Position])["name"].ToString().Trim();
            hideMenuDevice(Program.dbName);
            this.position_backupTableAdapter.Fill(this.dS.position_backup, Program.dbName);

        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            position = ((DataRowView)position_backupBindingSource[position_backupBindingSource.Position])["position"].ToString();

        }


        private void menuTaoDevice_Click(object sender, EventArgs e)
        {
            sqlQuery = "USE master EXEC sp_addumpdevice 'disk', " +
                       "'" + "DEVICE_" + Program.dbName + "', " +
                       "'" + Program.defaultPath + "DEVICE_" + Program.dbName + ".bak'";

            Program.myReader = Program.ExecSqlDataReader(sqlQuery);
            if (Program.myReader != null)
            {
                MessageBox.Show("Tạo Device thành công.");
            }
            else
            {
                MessageBox.Show("Tạo Device thất bại!");
            }
            Program.myReader.Close();
            hideMenuDevice(Program.dbName);
        }

        private void menuSaoLuu_Click(object sender, EventArgs e)
        {
            sqlQuery = "USE master BACKUP DATABASE " + Program.dbName +
                       " TO DEVICE_" + Program.dbName;
            if (chkXoaBackup.Checked)
            {
                sqlQuery += " WITH INIT";
                chkXoaBackup.Checked = false;
            }
            Program.myReader = Program.ExecSqlDataReader(sqlQuery);
            if (Program.myReader != null)
            {
                MessageBox.Show("Sao lưu thành công.");
            }
            else
            {
                MessageBox.Show("Sao lưu thất bại!");
            }
            Program.myReader.Close();

            this.position_backupTableAdapter.Connection.ConnectionString = Program.connstr;
            this.position_backupTableAdapter.Fill(this.dS.position_backup, Program.dbName);
        }

        private void menuPhucHoi_Click(object sender, EventArgs e)
        {
            if (chbThamSo.Checked)
            {
                position_backupBindingSource.MoveFirst();   // Đưa position trong gridView lên trên cùng
                DateTime timeBackup = (DateTime)((DataRowView)position_backupBindingSource[position_backupBindingSource.Position])["backup_start_date"];
                int lessNow = (timeBackup - dtpDateTime.Value).Minutes;
                if (lessNow < -5)
                {



                    DialogResult dialogResult = MessageBox.Show(
                        "Backup gần nhất: " + timeBackup + "\nThời gian phục hồi: " + dtpDateTime.Value,
                        "",
                        MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        /*
                        ALTER DATABASE SINHVIEN SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                        USE MASTER
                        GO
                        BACKUP LOG SINHVIEN TO DISK='D:SINHVIEN.TRN' WITH NORECOVERY
                        RESTORE DATABASE SINHVIEN FROM DISK='D:SINHVIEN.BAK' WITH NORECOVERY
                        RESTORE DATABASE SINHVIEN FROM DISK='D:SINHVIEN.TRN' WITH STOPAT='2020-04-24 08:20:00'
                        ALTER DATABASE SINHVIEN SET MULTI_USER
                     */
                        String path = Program.defaultPath + Program.dbName;
                        sqlQuery = "ALTER DATABASE " + Program.dbName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                                    "USE MASTER " +
                                    "BACKUP LOG " + Program.dbName + " TO DISK = '" + path + ".TRN' WITH NORECOVERY " +
                                    "RESTORE DATABASE " + Program.dbName + " FROM DISK = '" + path + ".BAK' WITH NORECOVERY " +
                                    "RESTORE DATABASE " + Program.dbName + " FROM DISK = '" + path + ".TRN' WITH STOPAT = " + dtpDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss ") + "'";

                        txbSQL.Text = sqlQuery;
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Thời gian cách bản Backup gần nhất ít nhất 5 phút");
                    return;
                }
            }
            else
            {
                sqlQuery = "USE master \n" +
                       "ALTER DATABASE " + Program.dbName + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE \n" +
                       "USE tempdb \n" +
                       "RESTORE DATABASE " + Program.dbName + " FROM DEVICE_" + Program.dbName + " WITH FILE= " + position + ", REPLACE \n" +
                       "ALTER DATABASE " + Program.dbName + " SET MULTI_USER";
                txbSQL.Text = sqlQuery;
            }
            Program.myReader = Program.ExecSqlDataReader(sqlQuery);
            if (Program.myReader != null)
            {
                MessageBox.Show("Phục hồi thành công.");
            }
            else
            {
                MessageBox.Show("Phục hồi thất bại!");
            }
            Program.myReader.Close();



        }
        // ==========================================================================================

        // Liệt kê toàn bộ tên backup devices có trong sql server
        private List<String> getListBackUpDevice()
        {
            List<String> list = new List<string>();
            String name = "";
            sqlQuery = "USE master SELECT name FROM sys.backup_devices";
            Program.myReader = Program.ExecSqlDataReader(sqlQuery);
            while (Program.myReader.Read())
            {
                name = Program.myReader["name"].ToString().Substring(7);
                list.Add(name);
            }
            Program.myReader.Close();
            return list;
        }

        // Ẩn hiện menu "Tạo device sao lưu"
        private void hideMenuDevice(String nameDB)
        {
            listBackupDevice = getListBackUpDevice();
            if (listBackupDevice.Contains(nameDB))
            {
                menuTaoDevice.Enabled = false;

                menuSaoLuu.Enabled = true;
                menuPhucHoi.Enabled = true;
                chbThamSo.Enabled = true;
                chkXoaBackup.Enabled = true;
                position_backupGridControl.Enabled = true;
            }
            else
            {
                menuTaoDevice.Enabled = true;

                menuSaoLuu.Enabled = false;
                menuPhucHoi.Enabled = false;
                chbThamSo.Enabled = false;
                chkXoaBackup.Enabled = false;
                position_backupGridControl.Enabled = false;
            }
        }

        private void chbThamSo_Click(object sender, EventArgs e)
        {
            if (chbThamSo.Checked)
            {
                dtpDateTime.Visible = true;
            }
            else
            {
                dtpDateTime.Visible = false;
            }
        }

        private void chbThamSo_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateTime.MaxDate = DateTime.Now;
        }
    }
}
