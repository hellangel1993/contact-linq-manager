using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using contact_linq_manager.Forms;

namespace contact_linq_manager
{
    public partial class MdiParentform : Form
    {
        public MdiParentform()
        {
            InitializeComponent();
        }

        private void mnuMenuHorx_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuVertex_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuMenuCascading_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        //object of the form
        UserDetailform objUserDetail;
        Countryform objCountryForm;
        StateForm objstateForm;
        AddressForm objAddressForm;
        LoginForm objLoginForm;

        private void mnuManageCountry_Click(object sender, EventArgs e)
        {
            if (objCountryForm==null)
            {
                objCountryForm = new Countryform();
                objCountryForm.Show();
                objCountryForm.MdiParent = this;
                objCountryForm.FormClosing += ObjCountryForm_FormClosing;
            }
            else
            {
                objCountryForm.Activate();
            }
        }

        private void ObjCountryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objCountryForm=null;
        }

        private void mnuManageUser_Click(object sender, EventArgs e)
        {
            if (objUserDetail==null)
            {
                objUserDetail = new UserDetailform();
                objUserDetail.Show();
                objUserDetail.MdiParent = this;
                objUserDetail.FormClosing += ObjUserDetail_FormClosing;
            }
            else
            {
                objUserDetail.Activate();
            }
        }

        private void ObjUserDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            objUserDetail=null;
        }

        private void mnuManageState_Click(object sender, EventArgs e)
        {
            if (objstateForm==null)
            {
                objstateForm = new StateForm();
                objstateForm.Show();
                objstateForm.MdiParent = this;
                objstateForm.FormClosing += ObjstateForm_FormClosing;
            }
            else
            {
                objUserDetail.Activate();
            }
        }

        private void ObjstateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objstateForm=null;
        }

        private void mnuAddressbook_Click(object sender, EventArgs e)
        {
            if (objAddressForm == null)
            {
                objAddressForm = new AddressForm();
                objAddressForm.Show();
                objAddressForm.MdiParent = this;
                objAddressForm.FormClosing += ObjAddressForm_FormClosing;
            }
            else
            {
                objAddressForm.Activate();
            }
        }

        private void ObjAddressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            objAddressForm=null;
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Relogin.Call(1);
            this.Close();

            // this.Dispose();

        }
    }
}
