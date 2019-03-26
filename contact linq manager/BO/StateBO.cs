using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using contact_linq_manager.DB;
using contact_linq_manager.Data;

namespace contact_linq_manager.BO
{
    class StateBO
    {
        //Getting the filtered data of the state
        public static object FilteredResultState(int id,bool status)
        {
            return StateDB.FilteredResultState(id, status);
        }
        //getting data from the  tables
        public static object GetStates()
        {
            return StateDB.GetCountryAndState();
        }
        //inserting the data
        public void InsertInState(int fKCountryId,string stateName,bool isActive)
        {
            StateData objstateData = new StateData(fKCountryId, stateName, isActive);
            objstateData.Validate();
            StateDB.InsertInState(objstateData);
        }
        //for updating the state table
        public void UpdateInState(StateData objStateData)
        {
            try
            {
                objStateData.Validate();
                StateDB.UpdateInState(objStateData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //for delete the data
        public void DeleteInState(int StateId)
        {
            StateDB.DeleteInSatte(StateId);
        }
    }
}
