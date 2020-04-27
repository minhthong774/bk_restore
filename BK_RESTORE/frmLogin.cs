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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            txtUser.Text = "sa";
            txtPass.Text = "12345";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.loginname = txtUser.Text;
            Program.password = txtPass.Text;

            if (Program.KetNoi() != 0)
            {
                frmLogin.ActiveForm.Visible = false;
                frmMain main = new frmMain();
                main.Show();
            }



        }
    }
}
