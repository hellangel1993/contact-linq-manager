using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.Data;
using contact_linq_manager.DB;

namespace contact_linq_manager.BO
{
    class AddressBO
    {
        //filtered list for AddressBook
        public static object FilteredAddressbook(int id,bool status)
        {
            return AddressDB.FilteredAddress(id, status);
        }
        //list of country for state combobox
        public static object ListOfState(int id)
        {
            return AddressDB.ListOfState(id);
        }
        //to get the table from the address table
        public static object GetAddress()
        {
            return AddressDB.GetAddress();
        }

        //to Insert in the address table
        public static void InsertInAddress(AddressData objAddressDate)
        {
            
            AddressDB.InsertInAddress(objAddressDate);
        }

        //to update  in the address table
        public static void UpdateInAddress(AddressData objAddressData)
        {
            AddressDB.UpdateInAddress(objAddressData);
        }

        //to delete in the address table
        public static void DeleteInAddress(int addressId)
        {
            AddressDB.DeleteInAddress(addressId);
        }
    }
}
