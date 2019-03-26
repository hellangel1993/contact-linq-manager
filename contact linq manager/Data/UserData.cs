using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_linq_manager.Data
{
    class UserData
    {
        string _validation = "";
        public void validation()
        {
            if (!string.IsNullOrEmpty(_validation))
            {
                throw new ApplicationException(_validation);
            }
        }

        // default constructor
        public UserData()
        {

        }

        public UserData(string userName,String password,string firstName,string lastName,string emailId,string phoneNo,bool isActive)
        {
            this.UserName = userName;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
            this.IsActive = isActive;
        }

        //variable
        private int _UserId;
        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
            }
        }

        private string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                if (value == "")
                {
                    _validation += "Please provide a value for UserName" + "\t";
                }
                _UserName = value;
            }
        }

        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                if (value == "")
                {
                    _validation += "Please Provide a Value for Password" + "\t";
                }
                _Password = value;
            }
        }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (value == "")
                {
                    _validation += "Please Provide a Value for FirstName" + "\t";
                }
                _FirstName = value;
            }
        }

        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        private string _EmailId;
        public string EmailId
        {
            get
            {
                return _EmailId;
            }
            set
            {
                if (value == "")
                {
                    _validation += "Please Provide a valid Email address" + "\t";
                }
                _EmailId = value;
            }
        }

        private string _PhoneNo;
        public string PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                if (value == "")
                {
                    _validation += "Please Provide a Phone Number" + "\t";
                }
                _PhoneNo = value;
            }
        }

        private bool _IsActive;
        public bool IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                _IsActive = value;
            }
        }
    }
}
