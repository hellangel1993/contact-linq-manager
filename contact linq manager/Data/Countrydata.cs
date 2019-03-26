using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_linq_manager.Data
{
    
    class Countrydata
    {
        string Validation = "";

        //variables
        private int _PKCountry;
        public int PKCountry
        {
            get
            {
                return _PKCountry;
            }
            set
            {
                _PKCountry = value;
            }
        }

        private string _CountryName;
        public string CountryName
        {
            get
            {
                return _CountryName;
            }
            set
            {
                if (value == "")
                {
                    Validation += "Please provide your Country Name ";
                }
                else
                {
                    _CountryName = value;
                }
            }
        }

        private long _ZIpCodeStart;
        public long ZipCodeStart
        {
            get
            {
                return _ZIpCodeStart;
            }
            set
            {
                if (value == 0)
                {
                    Validation += "Please Provide you Starting of ZipCode";
                }
                else
                {
                    _ZIpCodeStart = value;
                }
            }
        }

        private long _ZipCodeEnd;
        public long ZipCodeEnd
        {
            get
            {
                return _ZipCodeEnd;
            }
            set
            {
                if (value==0)
                {
                    Validation += "Please provide your Ending of range of your Zipcode";
                }
                else
                    _ZipCodeEnd = value;
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

        public void Validate()
        {
            if (!string.IsNullOrEmpty(Validation))
            {
                throw new ApplicationException(Validation);
            }
        }
        // counstructor
        public Countrydata()
        {

        }
        //counstructor with countryid
        public Countrydata(int pKCountry,string countryName,long zipCodeStart,long zipCodeEnd,bool isActive)
        {
            _PKCountry = pKCountry;
            this.CountryName = countryName;
            this.ZipCodeStart = zipCodeStart;
            this.ZipCodeEnd = zipCodeEnd;
            this.IsActive = isActive;
        }
        //construotor without countryid
        public Countrydata(string countryName,long zipCodeStart,long zipCodeEnd,bool isActive)
        {
            this.CountryName = countryName;
            this.ZipCodeStart = zipCodeStart;
            this.ZipCodeEnd = zipCodeEnd;
            this.IsActive = isActive;
        }
    }
}
