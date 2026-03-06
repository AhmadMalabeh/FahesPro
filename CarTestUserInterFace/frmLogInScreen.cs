using CarTestLogicalLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarTestUserInterFace
{
    public partial class frmLogInScreen : Form
    {

        public clsUsers LoggedInUser { get; set; }
        public frmLogInScreen()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            clsUsers LoggedInUser = clsUsers.GetUserInfoByUserNameAndPassword(txtUserName.Text.Trim(), txtPassowrd.Text.Trim());

            if (LoggedInUser != null && LoggedInUser.UserID > 0)
            {
                this.LoggedInUser = LoggedInUser;

                MessageBox.Show("Log In Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // هذه أهم خطوة: نخبر البرنامج أن النتيجة هي "موافق" ثم نغلق الشاشة
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Log In Failed! Please check your username and password.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
