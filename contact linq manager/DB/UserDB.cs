using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.Data;

namespace contact_linq_manager.DB
{
    class UserDB
    {
        //check if the user exsit or not 
        public static IList<string> CheckInUser(string userName,String password)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var check = dc.UserDetails.Where(e1 => e1.UserName == userName).Where(e2=>e2.Password==password).Select(e3 => e3.Password).ToList();
            return check;
        }
        //checking the user for the login form
        public static int IsUserExist(string userName)
        {
            int userId=0;
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var qry = dc.UserDetails.Where(e1 => e1.UserName == userName).Select(e1 => e1.PKUserId).ToList();
            foreach (var s in qry)
            {
                userId = (int)s;
            }
            return userId;
        }
        //to get a filter list
        public static object FilterReseultUser(bool status)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var ds = dc.UserDetails.Where(e1 => e1.IsActive == status).ToList();
            return ds;
        }
        //to get all the details from the database
        public static IList<UserDetail> GetUserDetails()
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            var ds = dc.UserDetails.ToList();
            return ds;  
        }

        //to get insert data
        public static void InsertInUserDetail(UserData objUserData)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            UserDetail us = new UserDetail();
            us.UserName = objUserData.UserName;
            us.Password = objUserData.Password;
            us.FirstName = objUserData.FirstName;
            us.LastName = objUserData.LastName;
            us.EmailId = objUserData.EmailId;
            us.PhoneNo = objUserData.PhoneNo;
            us.IsActive = objUserData.IsActive;
            dc.UserDetails.InsertOnSubmit(us);
            dc.SubmitChanges();
        }
        //update the user details
        public static void UpdateInUserDetail(UserData objUserData)
        {
            int userId = objUserData.UserId;
            Contact_managerDataContext dc = new Contact_managerDataContext();
            UserDetail us = dc.UserDetails.First(e1 => e1.PKUserId == userId);
            us.UserName = objUserData.UserName;
            us.Password = objUserData.Password;
            us.FirstName = objUserData.FirstName;
            us.LastName = objUserData.LastName;
            us.EmailId = objUserData.EmailId;
            us.PhoneNo = objUserData.PhoneNo;
            us.IsActive = objUserData.IsActive;
            dc.SubmitChanges();
        }

        //delete from the user detail
        public static void DeleteInUserDetail(int userId)
        {
            Contact_managerDataContext dc = new Contact_managerDataContext();
            UserDetail us = dc.UserDetails.First(e1 => e1.PKUserId == userId);
            dc.UserDetails.DeleteOnSubmit(us);
            dc.SubmitChanges();
        }
    }
}
