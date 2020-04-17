using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BK_RESTORE
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public static SqlConnection conn = new SqlConnection();
		public static String connstr;
		public static SqlDataReader myReader;

		public static String servername = "DESKTOP-T0NKFJS\\LIEMNGUYEN";
		public static String loginname = "sa";
		public static String password = "12345";
		public static string dbName = "";
		public static String bakdevname;
		public static BindingSource bdsPbs;

		public static String defaultPath = "D:/Code/C#/ChuyenDeCongNghePhanMem/BK_RESTORE/Backup_Restore_DB/";

		public static int KetNoi() //null thì lỗi, không null thì chạy
		{
			if (Program.conn != null && Program.conn.State == System.Data.ConnectionState.Open)
				Program.conn.Close();
			try
			{
				Program.connstr = "Data Source=" + Program.servername + ";User ID=" + Program.loginname + ";password=" + Program.password;
				//Program.conn.ConnectionString = connstr;
				Program.conn = new SqlConnection(Program.connstr);
				Program.conn.Open();
				return 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. \nBạn xem lại username và password.\n" + ex.Message, "Lỗi kết nối!", MessageBoxButtons.OK);
				return 0;
			}
		}

		//truy vấn nhanh, chỉ thích hợp để xem; không cho sửa, thêm, xóa; 
		//nếu nhiều dòng, chỉ cho phép đi xuống, k cho phép đi ngược lại.
		public static SqlDataReader ExecSqlDataReader(String strLenh)
		{
			conn.Close();
			SqlDataReader myreader;
			SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
			sqlcmd.CommandType = CommandType.Text;
			sqlcmd.CommandTimeout = 300; // Đợi lệnh chạy. đơn vị: giây.
			if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
			try
			{
				myreader = sqlcmd.ExecuteReader();
				return myreader;
			}
			catch (SqlException ex)
			{
				Program.conn.Close(); 
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
