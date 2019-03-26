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
    public partial class StateForm : Form
    {
        public StateForm()
        {
            InitializeComponent();
            FillCountry();
        }

        private void StateForm_Load(object sender, EventArgs e)
        {
            dgvState.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvState.AutoGenerateColumns = false;
            dgvState.ReadOnly = true;
            dgvState.AllowUserToAddRows = false;
            dgvState.AllowUserToDeleteRows = false;
            dgvState.AllowUserToOrderColumns = false;
            dgvState.MultiSelect = false;
            dgvState.DataSource = StateBO.GetStates();
        }
        private void FillCountry()
        {
            cmbCountryId.DisplayMember = "CountryName";
            cmbCountryId.ValueMember = "PKCountryId";
            cmbCountryId.DataSource = CountryBO.GetCountries();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                StateDialog dlgState = new StateDialog();
                if (dlgState.ShowDialog()==DialogResult.OK)
                {
                    StateBO objstateBO = new StateBO();
                    objstateBO.InsertInState(dlgState.countryId, dlgState.stateName, dlgState.IsActive);
                    dgvState.DataSource = StateBO.GetStates();
                }
            }
            catch
            {

                MessageBox.Show("Error in state form");
            }
        }
        //this is for updating 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvState.RowCount != 0)
                {
                    StateDialog dlgState = new StateDialog();
                    dlgState.CountryName = (dgvState.SelectedRows[0].Cells[2].Value).ToString();
                    dlgState.stateName = (dgvState.SelectedRows[0].Cells[3].Value).ToString();
                    dlgState.IsActive = (bool)(dgvState.SelectedRows[0].Cells[4].Value);
                    int stateId = (int)(dgvState.SelectedRows[0].Cells[0].Value);
                    StateBO objStateBO = new StateBO();
                    StateData objStateData = new StateData();
                    if (dlgState.ShowDialog()==DialogResult.OK)
                    {
                        objStateData.StateId = stateId;
                        objStateData.FKCountryId = dlgState.countryId;
                        objStateData.StateName = dlgState.stateName;
                        objStateData.IsActive = dlgState.IsActive;
                        objStateBO.UpdateInState(objStateData);
                    }
                }
            }
            catch 
            {

                MessageBox.Show("error at edit form");
            }
            dgvState.DataSource = StateBO.GetStates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvState.RowCount!=0)
            {
                DialogResult dr;
                dr = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else
                {
                    int stateId = (int)(dgvState.SelectedRows[0].Cells[0].Value);
                    StateBO objStateBO = new StateBO();
                    objStateBO.DeleteInState(stateId);
                }
            }
            dgvState.DataSource = StateBO.GetStates();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            int id= (int)cmbCountryId.SelectedValue;
            if (cmbIsActive.SelectedIndex==0)
            {
                dgvState.DataSource = StateBO.FilteredResultState(id,true);
            }
            if (cmbIsActive.SelectedIndex==1)
            {
                dgvState.DataSource = StateBO.FilteredResultState(id, false);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvState.DataSource = StateBO.GetStates();
        }
    }
}
