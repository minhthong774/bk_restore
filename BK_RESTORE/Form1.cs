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
	public partial class Form1 : Form
	{
		private List<String> listBackupDevice = new List<string>();
		private string sqlQuery = "";

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (Program.KetNoi() == 0)
				return;

			// TODO: This line of code loads data into the 'dS.databases' table. You can move, or remove it, as needed.
			this.databasesTableAdapter.Fill(this.dS.databases);

			// Load GridView position_backup 
			Program.dbName = ((DataRowView)databasesBindingSource[0])["name"].ToString().Trim();
			//MessageBox.Show(Program.dbName);
			try
			{
				this.position_backupTableAdapter.Fill(this.dS.position_backup, Program.dbName);
			}catch(Exception exc)
			{
				MessageBox.Show(exc.Message);
			}

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

		}


		private void menuTaoDevice_Click(object sender, EventArgs e)
		{
			sqlQuery = "USE master EXEC sp_addumpdevice 'disk', " +
				       "'" + "DEVICE_" + Program.dbName + "', "+
					   "'" + Program.defaultPath + "DEVICE_" + Program.dbName + ".bak'";
	
			Program.myReader = Program.ExecSqlDataReader(sqlQuery);
			Program.myReader.Close();
			hideMenuDevice(Program.dbName);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			listBackupDevice.ForEach(item => MessageBox.Show(item));
		}

		private void menuSaoLuu_Click(object sender, EventArgs e)
		{
			sqlQuery = "USE master BACKUP DATABASE " + Program.dbName +
					   " TO DEVICE_" + Program.dbName+" WITH INIT";
			MessageBox.Show(sqlQuery);
			Program.myReader = Program.ExecSqlDataReader(sqlQuery);
			Program.myReader.Close();

			this.position_backupTableAdapter.Fill(this.dS.position_backup, Program.dbName);
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
				menuThamSoPhucHoi.Enabled = true;
			}
			else
			{
				menuTaoDevice.Enabled = true;

				menuSaoLuu.Enabled = false;
				menuPhucHoi.Enabled = false;
				chbThamSo.Enabled = false;
				menuThamSoPhucHoi.Enabled = false;
			}
		}

	}
}
