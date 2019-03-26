using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.Data;

namespace contact_linq_manager.DB
{
    class AddressDB
    {
        //list of state on country
        public static object ListOfState(int id)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var ds = dc.States.Where(e1 => e1.FKCountryId == id).ToList();
            return ds;
        }
        // filtered value of the Addressbook
        public static object FilteredAddress(int id,bool status)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var da = dc.Addressbooks.Where(e1=>e1.FKStateId==id).Where(e1=>e1.IsActive==status).ToList();
            var du = UserDB.GetUserDetails();
            var ds = dc.States.ToList();
            var qry = da.Join(du, a1 => a1.FKUserId, u1 => u1.PKUserId, (a1, u1) => new
            {
                Addressbook = a1,
                UserDetail = u1
            }).Join(ds, a1 => a1.Addressbook.FKStateId, s1 => s1.PKStateId, (a1, s1) => new
            {
                PKAddressId = a1.Addressbook.PKAddressId,
                FKStateId = s1.PKStateId,
                StateName = s1.StateName,
                FKUserId = a1.UserDetail.PKUserId,
                UserName = a1.UserDetail.UserName,
                FirstName = a1.Addressbook.FirstName,
                LastName = a1.Addressbook.LastName,
                EmailId = a1.Addressbook.EmailId,
                PhoneNo = a1.Addressbook.PhoneNo,
                Address1 = a1.Addressbook.Address1,
                Address2 = a1.Addressbook.Address2,
                Street = a1.Addressbook.Street,
                City = a1.Addressbook.City,
                ZipCode = a1.Addressbook.ZipCode,
                IsActive = a1.Addressbook.IsActive
            }).ToList();
            return qry;

        }
        //for get the details from the address
        public static object GetAddress()
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var q = (from a in dc.Addressbooks
                     join s in dc.States on a.FKStateId equals s.PKStateId
                     join u in dc.UserDetails on a.FKUserId equals u.PKUserId
                     select new
                     {
                         a.PKAddressId,
                         s.PKStateId,
                         s.StateName,
                         u.PKUserId,
                         u.UserName,
                         a.FirstName,
                         a.LastName,
                         a.EmailId,
                         a.PhoneNo,
                         a.Address1,
                         a.Address2,
                         a.Street,
                         a.City,
                         a.ZipCode,
                         a.IsActive
                     });
            return q;
        }
        //for insert in the address
        public static void InsertInAddress(AddressData objAddress)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            Addressbook addressbook = new Addressbook();
            if (dc.States.First(e1 => e1.PKStateId == objAddress.FKStateId) != null && dc.UserDetails.First(e1 => e1.PKUserId == objAddress.FKUserId) != null)
            {


                addressbook.FKStateId = objAddress.FKStateId;
                addressbook.FKUserId = objAddress.FKUserId;
                addressbook.FirstName = objAddress.FirstName;
                addressbook.LastName = objAddress.LastName;
                addressbook.EmailId = objAddress.EmailId;
                addressbook.PhoneNo = objAddress.PhoneNo;
                addressbook.Address1 = objAddress.Address1;
                addressbook.Address2 = objAddress.Address2;
                addressbook.Street = objAddress.Street;
                addressbook.City = objAddress.City;
                addressbook.ZipCode = objAddress.ZipCode;
                addressbook.IsActive = objAddress.IsActive;
                dc.Addressbooks.InsertOnSubmit(addressbook);
                dc.SubmitChanges();
            }
            else
            {
                throw new Exception("Plese Enter the valid Statename and UserName");
            }
        }
        public static void UpdateInAddress(AddressData objAddress)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            Addressbook addressbook = dc.Addressbooks.First(e1 => e1.PKAddressId == objAddress.PKAddressId);
            if (dc.States.First(e1 => e1.PKStateId == objAddress.FKStateId) != null && dc.UserDetails.First(e1 => e1.PKUserId == objAddress.FKUserId) != null)
            {


                addressbook.FKStateId = objAddress.FKStateId;
                addressbook.FKUserId = objAddress.FKUserId;
                addressbook.FirstName = objAddress.FirstName;
                addressbook.LastName = objAddress.LastName;
                addressbook.EmailId = objAddress.EmailId;
                addressbook.PhoneNo = objAddress.PhoneNo;
                addressbook.Address1 = objAddress.Address1;
                addressbook.Address2 = objAddress.Address2;
                addressbook.Street = objAddress.Street;
                addressbook.City = objAddress.City;
                addressbook.ZipCode = objAddress.ZipCode;
                addressbook.IsActive = objAddress.IsActive;
                dc.SubmitChanges();
            }
            else
            {
                throw new Exception("Please check the details ");
            }
        }
        //for deleting 
        public static void DeleteInAddress(int addreessId)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            Addressbook addressbook = dc.Addressbooks.First(e1 => e1.PKAddressId == addreessId);
            dc.Addressbooks.DeleteOnSubmit(addressbook);
            dc.SubmitChanges();
        }
    }
}
