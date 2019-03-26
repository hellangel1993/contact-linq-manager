using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using contact_linq_manager.Dialogbox;
using contact_linq_manager.BO;

namespace contact_linq_manager.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '@';
            txtPassword.MaxLength = 10;
        }

        MdiParentform mdiParentform = new MdiParentform();

        private void lkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserDialog dlguser = new UserDialog();
            if (dlguser.ShowDialog()==DialogResult.OK)
            {
                if (UserBO.IsUserExist(dlguser.UserName))
                {
                    UserBO objUserBO = new UserBO();
                    objUserBO.InsertInUser(dlguser.UserName, dlguser.Password, dlguser.FirstName, dlguser.LastName, dlguser.EmailId, dlguser.PhoneNo, dlguser.IsActive);
                    MessageBox.Show("Ok you are in our system");
                }
                else
                {
                    MessageBox.Show("Someone already exist with this Name.\nSorry try again");
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((txtUserName.Text.Trim()!="")&&(txtPassword.Text.Trim()!=""))
            {
                if (UserBO.AuthenticateUser(txtUserName.Text,txtPassword.Text))//checking the password and user anme
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please Enter the correct password");
                    
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            this.DialogResult = DialogResult.Cancel;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
