using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.DB;
using contact_linq_manager.Data;


namespace contact_linq_manager.BO
{
    class CountryBO
    {
        //to get filtered result
        public static IList<Country> FilteredList(bool status)
        {
            return CountryDB.FilteredResultCountries(status);
                     
        }
        //to get the list of all countries
        public static IList<Country> GetCountries()
        {
            return CountryDB.GetAllCountry();
        }
        //for new insert only
        public void InsertInCountry(string countryName,long zipCodeStart,long zipCodeEnd,bool isActive)
        {
            try
            {
                 Countrydata objCountry = new Countrydata(countryName,zipCodeStart,zipCodeEnd,isActive);
                objCountry.Validate();
                CountryDB.InsertNewCountry(objCountry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //for update only
        public void UpdateInCountry(Countrydata objCountryData)
        {
            try
            {
                objCountryData.Validate();
                CountryDB.UpdateCountry(objCountryData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //for delete
        public void DeleteInCountry(int CountryId)
        {
            CountryDB.DeleteCountry(CountryId);
        }
    }
}
