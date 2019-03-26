using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.Data;
using contact_linq_manager.BO;
using contact_linq_manager;
using System.Data;

namespace contact_linq_manager.DB
{
    class CountryDB
    {
        //to get filtered list
        public static IList<Country> FilteredResultCountries(bool status)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var ds = dc.Countries.Where(e1 => e1.IsActive == status).ToList();
            return ds;
        }

        //to get all the country
        public static IList<Country> GetAllCountry()
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var  ds =  dc.Countries.ToList();
            return ds;
        }
        //for inserting 
        public static void InsertNewCountry(Countrydata objcountryData)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            Country country = new Country();
            country.CountryName = objcountryData.CountryName;
            country.ZipCodeStart = objcountryData.ZipCodeStart;
            country.ZipCodeEnd = objcountryData.ZipCodeEnd;
            country.IsActive = objcountryData.IsActive;
            dc.Countries.InsertOnSubmit(country);
            dc.SubmitChanges();
        }
        //for updating 
        public static void UpdateCountry(Countrydata objCountryData)
        {
            int countryId = objCountryData.PKCountry;
            Contact_managerDataContext dc = new Contact_managerDataContext();
            Country country = dc.Countries.First(e1=>e1.PKCountryId==countryId);
            country.CountryName = objCountryData.CountryName;
            country.ZipCodeStart = objCountryData.ZipCodeStart;
            country.ZipCodeEnd = objCountryData.ZipCodeEnd;
            country.IsActive = objCountryData.IsActive;
            //dc.Countries.InsertOnSubmit(country);
            dc.SubmitChanges();

        }
        //for deleting 
        public static void DeleteCountry(int countryId)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            Country country = dc.Countries.First(e1 => e1.PKCountryId == countryId);
            dc.Countries.DeleteOnSubmit(country);
            dc.SubmitChanges();
        }

    }
}
