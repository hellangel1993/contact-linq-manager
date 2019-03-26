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
    public partial class AddressForm : Form
    {
        public AddressForm()
        {
            InitializeComponent();
            FillCountry();
        }

        //for filling the country 
        private void FillCountry()
        {
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "PKCountryId";
            cmbCountry.DataSource = CountryBO.GetCountries();
            //FillState();
        }
        //for filling the combobox for state
        private void FillState()
        {
            cmbStateId.DisplayMember = "StateName";
            cmbStateId.ValueMember = "PKStateId";
            cmbStateId.DataSource = AddressBO.ListOfState((int)cmbCountry.SelectedValue);
        }

        private void AddressForm_Load(object sender, EventArgs e)
        {
            dgvAddressBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAddressBook.AutoGenerateColumns = false;
            dgvAddressBook.ReadOnly = true;
            dgvAddressBook.AllowUserToAddRows = false;
            dgvAddressBook.AllowUserToDeleteRows = false;
            dgvAddressBook.AllowUserToOrderColumns = false;
            dgvAddressBook.MultiSelect = false;
            dgvAddressBook.DataSource = AddressBO.GetAddress();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddressDialog dlgAddress = new AddressDialog();
            AddressData objAddressdata = new AddressData();
            dlgAddress.FillInCombo();
            if (dlgAddress.ShowDialog()==DialogResult.OK)
            {
                objAddressdata.FKStateId = dlgAddress.FKSatteId;
                objAddressdata.FKUserId = dlgAddress.FKuserID;
                objAddressdata.FirstName = dlgAddress.FirstName;
                objAddressdata.LastName = dlgAddress.LastName;
                objAddressdata.EmailId = dlgAddress.EmailId;
                objAddressdata.PhoneNo = dlgAddress.PhoneNo;
                objAddressdata.Address1 = dlgAddress.Address1;
                objAddressdata.Address2 = dlgAddress.Address2;
                objAddressdata.Street = dlgAddress.Street;
                objAddressdata.City = dlgAddress.City;
                objAddressdata.ZipCode = dlgAddress.ZipCode;
                objAddressdata.IsActive = dlgAddress.IsActive;
                AddressBO.InsertInAddress(objAddressdata);
                dgvAddressBook.DataSource = AddressBO.GetAddress();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddressDialog dlgAddress = new AddressDialog();
            dlgAddress.FillInCombo();
            int AddressId = (int)(dgvAddressBook.SelectedRows[0].Cells[0].Value);
            dlgAddress.StateName = (dgvAddressBook.SelectedRows[0].Cells[2].Value).ToString();
            dlgAddress.UserName = (dgvAddressBook.SelectedRows[0].Cells[4].Value).ToString();
            dlgAddress.FirstName = (dgvAddressBook.SelectedRows[0].Cells[5].Value).ToString();
            dlgAddress.LastName = (dgvAddressBook.SelectedRows[0].Cells[6].Value).ToString();
            dlgAddress.EmailId = (dgvAddressBook.SelectedRows[0].Cells[7].Value).ToString();
            dlgAddress.PhoneNo = (dgvAddressBook.SelectedRows[0].Cells[8].Value).ToString();
            dlgAddress.Address1 = (dgvAddressBook.SelectedRows[0].Cells[9].Value).ToString();
            dlgAddress.Address2 = (dgvAddressBook.SelectedRows[0].Cells[10].Value).ToString();
            dlgAddress.Street = (dgvAddressBook.SelectedRows[0].Cells[11].Value).ToString();
            dlgAddress.City = (dgvAddressBook.SelectedRows[0].Cells[12].Value).ToString();
            dlgAddress.ZipCode = (long)(dgvAddressBook.SelectedRows[0].Cells[13].Value);
            dlgAddress.IsActive = (bool)(dgvAddressBook.SelectedRows[0].Cells[14].Value);
            AddressData objAddressdata = new AddressData();
            if (dlgAddress.ShowDialog()==DialogResult.OK)
            {
                objAddressdata.PKAddressId = AddressId;
                objAddressdata.FKStateId = (int)(dgvAddressBook.SelectedRows[0].Cells[1].Value);
                objAddressdata.FKUserId = (int)(dgvAddressBook.SelectedRows[0].Cells[3].Value);
                objAddressdata.FirstName = dlgAddress.FirstName;
                objAddressdata.LastName = dlgAddress.LastName;
                objAddressdata.EmailId = dlgAddress.EmailId;
                objAddressdata.PhoneNo = dlgAddress.PhoneNo;
                objAddressdata.Address1 = dlgAddress.Address1;
                objAddressdata.Address2 = dlgAddress.Address2;
                objAddressdata.Street = dlgAddress.Street;
                objAddressdata.City = dlgAddress.City;
                objAddressdata.ZipCode = dlgAddress.ZipCode;
                objAddressdata.IsActive = dlgAddress.IsActive;
                AddressBO.UpdateInAddress(objAddressdata);
                
            }
            else
            {
                MessageBox.Show("please check the Details again");
            }
            dgvAddressBook.DataSource = AddressBO.GetAddress();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAddressBook.RowCount!=0)
            {
                DialogResult dr = MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo);
                if (dr==DialogResult.No)
                {
                    return;
                }
                if (dr==DialogResult.Yes)
                {
                    int AddressId = (int)(dgvAddressBook.SelectedRows[0].Cells[0].Value);
                    AddressBO.DeleteInAddress(AddressId);
                }
            }
            dgvAddressBook.DataSource = AddressBO.GetAddress();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int id = (int)(cmbStateId.SelectedValue);
            if (cmbIsActive.SelectedIndex==0)
            {
                dgvAddressBook.DataSource = AddressBO.FilteredAddressbook(id, true);
            }
            if (cmbIsActive.SelectedIndex==1)
            {
                dgvAddressBook.DataSource = AddressBO.FilteredAddressbook(id, false);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvAddressBook.DataSource = AddressBO.GetAddress();
        }

        private void cmbCountry_Click(object sender, EventArgs e)
        {
            FillState();//test condition
        }

        private void cmbCountry_Enter(object sender, EventArgs e)
        {
            FillState();//test condition
        }
    }
}
