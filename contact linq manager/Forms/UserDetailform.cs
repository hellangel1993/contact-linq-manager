using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using contact_linq_manager.BO;
using contact_linq_manager.Dialogbox;
using contact_linq_manager.Data;

namespace contact_linq_manager.Forms
{
    public partial class UserDetailform : Form
    {
        public UserDetailform()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserDetails_Load(object sender, EventArgs e)
        {
            dgvUserDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserDetail.AutoGenerateColumns = false;
            dgvUserDetail.AllowUserToAddRows = false;
            dgvUserDetail.AllowUserToDeleteRows = false;
            dgvUserDetail.ReadOnly = true;
            dgvUserDetail.MultiSelect = false;
            dgvUserDetail.DataSource = UserBO.GetUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserDialog dlgUser = new UserDialog();
            if (dlgUser.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    UserBO objUserBO = new UserBO();
                    objUserBO.InsertInUser(dlgUser.UserName, dlgUser.Password, dlgUser.FirstName, dlgUser.LastName, dlgUser.EmailId, dlgUser.PhoneNo, dlgUser.IsActive);
                    dgvUserDetail.DataSource = UserBO.GetUser();
                }
                catch (Exception)
                {
                    MessageBox.Show("you are in test 2 user form");
                   
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUserDetail.RowCount != 0)
            {
                int userId = (int)(dgvUserDetail.SelectedRows[0].Cells[0].Value);
                UserDialog dlgUser = new UserDialog();
                UserBO objUserBO = new UserBO();
                UserData objUserData = new UserData();
                dlgUser.UserName = (dgvUserDetail.SelectedRows[0].Cells[1].Value).ToString();
                dlgUser.Password = (dgvUserDetail.SelectedRows[0].Cells[2].Value).ToString();
                dlgUser.FirstName = (dgvUserDetail.SelectedRows[0].Cells[3].Value).ToString();
                dlgUser.LastName = (dgvUserDetail.SelectedRows[0].Cells[4].Value).ToString();
                dlgUser.EmailId = (dgvUserDetail.SelectedRows[0].Cells[5].Value).ToString();
                dlgUser.PhoneNo = (dgvUserDetail.SelectedRows[0].Cells[6].Value).ToString();
                dlgUser.IsActive = (bool)(dgvUserDetail.SelectedRows[0].Cells[7].Value);
                if (dlgUser.ShowDialog()==DialogResult.OK)
                {
                    objUserData.UserId = userId;
                    objUserData.FirstName = dlgUser.FirstName;
                    objUserData.LastName = dlgUser.LastName;
                    objUserData.EmailId = dlgUser.EmailId;
                    objUserData.PhoneNo = dlgUser.PhoneNo;
                    objUserData.Password = dlgUser.Password;
                    objUserData.IsActive = dlgUser.IsActive;
                    objUserBO.UpdateInUser(objUserData);
                }
                dgvUserDetail.DataSource = UserBO.GetUser();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int userId = (int)(dgvUserDetail.SelectedRows[0].Cells[0].Value);
            UserBO objUserBO = new UserBO();
            if (dgvUserDetail.RowCount!=0)
            {
                DialogResult dr;
                dr = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (dr==DialogResult.Yes)
                {
                    objUserBO.DeleteInUser(userId);
                }
            }
            dgvUserDetail.DataSource = UserBO.GetUser();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbIsActive.SelectedIndex==0)
            {
                dgvUserDetail.DataSource = UserBO.FilteredResultUser(true);
            }
            if (cmbIsActive.SelectedIndex==1)
            {
                dgvUserDetail.DataSource = UserBO.FilteredResultUser(false);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvUserDetail.DataSource = UserBO.GetUser();
        }
    }
}
