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

namespace contact_linq_manager
{
    public partial class Countryform : Form
    {
        public Countryform()
        {
            InitializeComponent();
        }

        

        private void Countryform_Load(object sender, EventArgs e)
        {
            dgvCountry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCountry.AutoGenerateColumns = false;
            dgvCountry.AllowUserToAddRows = false;
            dgvCountry.AllowUserToDeleteRows = false;
            dgvCountry.MultiSelect = false;
            dgvCountry.ReadOnly = true;
            dgvCountry.DataSource = CountryBO.GetCountries();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CountryDialog dlgCountry = new CountryDialog();
            if(dlgCountry.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    CountryBO objCountryBO = new CountryBO();
                    objCountryBO.InsertInCountry(dlgCountry.CountryName, dlgCountry.ZipCodeStart, dlgCountry.ZipCodeEnd, dlgCountry.IsActive);
                    dgvCountry.DataSource = CountryBO.GetCountries();
                }
                catch (Exception)
                {

                    MessageBox.Show("It under testing 1");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCountry.RowCount!=0)
            {
                int countryId=(int)(dgvCountry.SelectedRows[0].Cells[0].Value);
                CountryDialog dlgCountry = new CountryDialog();
                CountryBO objCountryBO = new CountryBO();
                Countrydata objCountryData = new Countrydata();
                dlgCountry.CountryName = (dgvCountry.SelectedRows[0].Cells[1].Value).ToString();
                dlgCountry.ZipCodeStart = (long)(dgvCountry.SelectedRows[0].Cells[2].Value);
                dlgCountry.ZipCodeEnd = (long)(dgvCountry.SelectedRows[0].Cells[3].Value);
                dlgCountry.IsActive = (bool)(dgvCountry.SelectedRows[0].Cells[4].Value);
                if (dlgCountry.ShowDialog()==DialogResult.OK)
                {
                    objCountryData.PKCountry = countryId;
                    objCountryData.CountryName = dlgCountry.CountryName;
                    objCountryData.ZipCodeStart = dlgCountry.ZipCodeStart;
                    objCountryData.ZipCodeEnd = dlgCountry.ZipCodeEnd;
                    objCountryData.IsActive = dlgCountry.IsActive;
                    objCountryBO.UpdateInCountry(objCountryData);
                }
                dgvCountry.DataSource = CountryBO.GetCountries();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCountry.RowCount!=0)
            {
                DialogResult dr;
                dr = MessageBox.Show("Are you sure you want to Delete","Delete", MessageBoxButtons.YesNo);
                if(dr== System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                int countryId = (int)(dgvCountry.SelectedRows[0].Cells[0].Value);
                CountryBO objCountryBO = new CountryBO();
                objCountryBO.DeleteInCountry(countryId);
                dgvCountry.DataSource = CountryBO.GetCountries();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbIsActive.SelectedIndex==0)
            {
                dgvCountry.DataSource=CountryBO.FilteredList(true);
            }
            if (cmbIsActive.SelectedIndex==1)
            {
                dgvCountry.DataSource=CountryBO.FilteredList(false);
            }
        }
       //this is not used in the program
        

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvCountry.DataSource = CountryBO.GetCountries();
        }
    }
}
