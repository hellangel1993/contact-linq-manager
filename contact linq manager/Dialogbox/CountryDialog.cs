using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contact_linq_manager.Dialogbox
{
    public partial class CountryDialog : Form
    {
        public CountryDialog()
        {
            InitializeComponent();
        }
        //variable
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CountryDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
