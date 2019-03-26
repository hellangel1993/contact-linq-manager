using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using contact_linq_manager.DB;
using contact_linq_manager.Data;
using System.DirectoryServices.AccountManagement;//to check the password

namespace contact_linq_manager.BO
{
    class UserBO
    {
        //checking the authentication
        public static bool AuthenticateUser(string userName,string password)
        {
            bool flag;
            string checkPassword="";
            var Password = UserDB.CheckInUser(userName, password);
            foreach (var s in Password)
            {
                checkPassword = s.ToString();
            }
            flag = CheckingPassword(checkPassword, password);
            return flag;
        }
        //this is the place where the password is comparied with the usergiven password and the database password
        private static bool CheckingPassword(string checkPassword,string fromPassword)
        {
            bool flag=false;
            int[] orignalPasword=new int[10];
            foreach (var s in checkPassword)
            {
                int i = 0;
                orignalPasword[i] = Convert.ToInt32(s);
                i++;
            }
            int[] formPassword=new int[10];
            foreach (var s in fromPassword)
            {
                int i = 0;
                formPassword[i] = Convert.ToInt32(s);
                i++;
            }


            if (checkPassword.Length==fromPassword.Length)
            {
                for (int i = 0; i < checkPassword.Length; i++)
                {
                    if (orignalPasword[i]==formPassword[i])
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        //to get a check and get the user id of the username
        public static bool IsUserExist(string userName)
        {
            bool flag;
            if (UserDB.IsUserExist(userName)==0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        //get the filtered list of the user
        public static object FilteredResultUser(bool status)
        {
            return UserDB.FilterReseultUser(status);
        }
        //for get the details only
        public static IList<UserDetail> GetUser()
        {
            return UserDB.GetUserDetails();
        }

        //for insert
        public void InsertInUser(string userName,string password,string firstName,string lastName,string emailId,string phoneNo,bool isActive)
        {
            try
            {
                UserData objUserData = new UserData(userName,password,firstName,lastName,emailId,phoneNo,isActive);
                objUserData.validation();
                UserDB.InsertInUserDetail(objUserData);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //for update
        public void UpdateInUser(UserData objUserData)
        {
            try
            {


                objUserData.validation();
                UserDB.UpdateInUserDetail(objUserData);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //for delate
        public void DeleteInUser(int userId)
        {
            UserDB.DeleteInUserDetail(userId);
        }
    }
}
