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

namespace contact_linq_manager.Dialogbox
{
    public partial class AddressDialog : Form
    {
        public AddressDialog()
        {
            InitializeComponent();
        }
        //filling the combe box in the form 
        public void FillInCombo()
        {
            cmbStateName.DisplayMember = "StateName";
            cmbUserName.DisplayMember = "UserName";
            cmbStateName.ValueMember = "PKStateId";
            cmbUserName.ValueMember = "PKUserId";
            cmbUserName.DataSource = UserBO.GetUser();
            cmbStateName.DataSource = StateBO.GetStates();
        }
        // variable
        private int _FKStateId;
        public int FKSatteId
        {
            get
            {
                return (int)cmbStateName.SelectedValue;
            }
            set
            {
                cmbStateName.SelectedValue = value;
            }
        }
        public string StateName
        {
            get
            {
                return cmbStateName.SelectedItem.ToString();
            }
            set
            {
                cmbStateName.SelectedItem = value;
            }
        }
        
        public int FKuserID
        {
            get
            {
                return (int)cmbUserName.SelectedValue;
            }
            set
            {
                cmbUserName.SelectedValue = value;
            }
        }
        public string UserName
        {
            get
            {
                return cmbUserName.SelectedItem.ToString();
            }
            set
            {
                cmbUserName.SelectedItem = value;
            }
        }
        public string FirstName
        {
            get
            {
                return txtFirstName.Text;
            }
            set
            {
                txtFirstName.Text = value;
            }
        }
        public string LastName
        {
            get
            {
                return txtLastName.Text;
            }
            set
            {
                txtLastName.Text = value;
            }
        }
        public string EmailId
        {
            get
            {
                return txtEmailId.Text;
            }
            set
            {
                txtEmailId.Text = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return txtPhoneNo.Text;
            }
            set
            {
                txtPhoneNo.Text = value;
            }
        }
        public string Address1
        {
            get
            {
                return txtAddress1.Text;
            }
            set
            {
                txtAddress1.Text = value;
            }
        }
        public string Address2
        {
            get
            {
                return txtAddress2.Text;
            }
            set
            {
                txtAddress2.Text = value;
            }
        }
        public string Street
        {
            get
            {
                return txtStreet.Text;
            }
            set
            {
                txtStreet.Text = value;
            }
        }
        public string City
        {
            get
            {
                return txtCity.Text;
            }
            set
            {
                txtCity.Text = value;
            }
        }
        public long ZipCode
        {
            get
            {
                return Convert.ToInt64( txtZipCode.Text);
            }
            set
            {
                txtZipCode.Text = value.ToString();
            }
        }
        public bool IsActive
        {
            get
            {
                return chkIsActive.Checked;
            }
            set
            {
                chkIsActive.Checked = value;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
