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
    public partial class StateDialog : Form
    {
        public StateDialog()
        {
            InitializeComponent();
            BindCountries();
        }

        //comdining the data of the country in the combo box
        private void BindCountries()
        {
            CountryBO objCountryBO = new CountryBO();
            //bind country NAme using object
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "PKCountryId";
            cmbCountry.DataSource = CountryBO.GetCountries();
        }
        public int countryId
        {
            get
            {
                return (int)cmbCountry.SelectedValue;
            }
            set
            {
                cmbCountry.SelectedValue = value;
            }
        }

        public string CountryName
        {
            get
            {
                return cmbCountry.SelectedItem.ToString();
            }
            set
            {
                cmbCountry.SelectedItem = value;
            }
        }

        public string stateName
        {
            get
            {
                return txtStateName.Text;
            }
            set
            {
                txtStateName.Text = value;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool errorFlag = false;
            epStateDialog.Clear();
            if (txtStateName.Text.Trim()=="")
            {
                errorFlag = true;
                epStateDialog.SetError(txtStateName, "Please provide the state Name");
            }
            if (errorFlag==false)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            countryId = (int)cmbCountry.SelectedValue;
            stateName = txtStateName.Text;
            CountryName = cmbCountry.Text;
        }

        private void StateDialog_Load(object sender, EventArgs e)
        {
            cmbCountry.SelectedValue = countryId;
            txtStateName.Text = stateName;
            chkIsActive.Checked = IsActive;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
