using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contact_linq_manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // variable 
        public string CountryName
        {
            get
            {
                return txtCountryName.Text;
            }
            set
            {
                txtCountryName.Text = value;
            }
        }

        public long ZipCodeStart
        {
            get
            {
                return Convert.ToInt64(txtZipCodeStart.Text);
            }
            set
            {
                txtZipCodeStart.Text = value.ToString();
            }
        }

        public long ZipCodeEnd
        {
            get
            {
                return Convert.ToInt64(txtZipCodeEnd.Text);
            }
            set
            {
                txtZipCodeEnd.Text = value.ToString();
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

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            using (Contact_managerDataContext dc = new Contact_managerDataContext())
            {
                Country country = new Country();
                country.CountryName = CountryName;
                country.ZipCodeStart = ZipCodeStart;
                country.ZipCodeEnd = ZipCodeEnd;
                country.IsActive = IsActive;
                dc.Countries.InsertOnSubmit(country);
                dc.SubmitChanges();
            }
            
        }
    }
}
