using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_linq_manager.Data
{
    class AddressData
    {
        //default constructor
        public AddressData()
        { }
        //constructor with addressid
        public AddressData(int pKAddressId, int fkStateId, int fkUserId, string firstName,String lastName,string emailId,string phoneNo,string address1,string address2,string street,string city,long zipCode,bool isActive)
        {
            this.PKAddressId = PKAddressId;
            this.FKStateId = fkStateId;
            this.FKUserId = fkUserId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Street = street;
            this.City = city;
            this.ZipCode = zipCode;
            this.IsActive = isActive;
        }
        //construtor without AddressId
        public AddressData(int fkStateId,int fkUserId, string firstName, String lastName, string emailId, string phoneNo, string address1, string address2, string street, string city, long zipCode, bool isActive)
        {
            this.FKStateId = fkStateId;
            this.FKUserId = fkUserId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailId = emailId;
            this.PhoneNo = phoneNo;
            this.Address1 = address1;
            this.Address2 = address2;
            this.Street = street;
            this.City = city;
            this.ZipCode = zipCode;
            this.IsActive = isActive;

        }

        //variable
        private int _PKAddressId;
        public int PKAddressId
        {
            get
            {
                return _PKAddressId;
            }
            set
            {
                _PKAddressId = value;
            }
        }
        private int _FKStateId;
        public int FKStateId
        {
            get
            {
                return _FKStateId;
            }
            set
            {
                _FKStateId = value;
            }
        }
        private int _FKUserId;
        public int FKUserId
        {
            get
            {
                return _FKUserId;
            }
            set
            {
                _FKUserId = value;
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
                _PhoneNo = value;
            }
        }
        private string _Address1;
        public string Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                _Address1 = value;
            }
        }
        private string _Address2;
        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = value;
            }
        }
        private string _Street;
        public string Street
        {
            get
            {
                return _Street;
            }
            set
            {
                _Street = value;
            }
        }
        private string _City;
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        private long _ZipCode;
        public long ZipCode
        {
            get
            {
                return _ZipCode;
            }
            set
            {
                _ZipCode = value;
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
