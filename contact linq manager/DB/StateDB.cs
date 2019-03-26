using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.Data;

namespace contact_linq_manager.DB
{
    class StateDB
    {
        //get the list of all the state
        //public static IList<State> GetState()
        //{
        //    Contact_managerDataContext dc = new Contact_managerDataContext();
        //    // var ds = dc.States.ToList(dc.States.Select(s=>s.FKCountryId==);
        //    var ds =dc.States.ToList();
        //    return ds;
        //}
        //insert in the state if the coiuntry id exist
        

         //for filtering the states
         public static object FilteredResultState(int id,bool status)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var ds = dc.States.Where(e1 => e1.FKCountryId == id).Where(e2=>e2.IsActive==status).ToList();
            var dco = dc.Countries.ToList();
            var qry = ds.Join(dco, e1 => e1.FKCountryId, c1 => c1.PKCountryId, (State, Country) => new
            {
                PKStateId = State.PKStateId,
                FKCountry = Country.PKCountryId,
                CountryName = Country.CountryName,
                StateName=State.StateName,
                IsActive=State.IsActive
            });
            return qry.ToList();
        }
        public static void InsertInState(StateData objStateData)
        {
            int fKCountryId = objStateData.FKCountryId;
            Contact_managerDataContext dc = new Contact_managerDataContext();
            State state = new State();
            if (dc.Countries.First(e1 => e1.PKCountryId == fKCountryId)!=null)
            {
                state.FKCountryId = fKCountryId;
                state.StateName = objStateData.StateName;
                state.IsActive = objStateData.IsActive;
                dc.States.InsertOnSubmit(state);
                dc.SubmitChanges();
            }
            else
            {
                throw new ApplicationException("PLease inter the valid countryid");
            }
        }

        //get table from the database with country Name
        public static object GetCountryAndState()
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            // IQueryable<State> qry = dc.States;
            var q = (from s in dc.States join c in dc.Countries on s.FKCountryId equals c.PKCountryId select new { s.PKStateId, s.FKCountryId, c.CountryName, s.StateName, s.IsActive }).ToList();
            return q;
            
        }
        //Update the value in state table
        public static void UpdateInState(StateData objStateDate)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            State state = dc.States.First(e1 => e1.PKStateId == objStateDate.StateId);
            if (dc.Countries.First(e1 => e1.PKCountryId == objStateDate.FKCountryId) != null)
            { 
                state.FKCountryId = objStateDate.FKCountryId;
                state.StateName = objStateDate.StateName;
                state.IsActive = objStateDate.IsActive;
                dc.SubmitChanges();
            }
            else
            {
                throw new ApplicationException("please provide a valid country");
            }
        }
        //for delete the state
        public static void DeleteInSatte(int stateId)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            State state = dc.States.First(e1 => e1.PKStateId == stateId);
            dc.States.DeleteOnSubmit(state);
            dc.SubmitChanges();
        }
    }
}
