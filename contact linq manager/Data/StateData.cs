using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_linq_manager.Data
{
    class StateData
    {
        //variable 
        private int _StateId;
        public int StateId
        {
            get
            {
                return _StateId;
            }
            set
            {
                _StateId = value;
            }
        }

        private int _FKCOuntryId;
        public int FKCountryId
        {
            get
            {
                return _FKCOuntryId;
            }
            set
            {
                _FKCOuntryId = value;
            }
        }

        private string _StateName;
        public string StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                if (value=="")
                {
                    Validation += "Please provide your state name";
                }
                else
                {
                    _StateName = value;
                }
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

        //default counstrutor
        public StateData()
        { }

        //counstrutor with StateId
        public StateData(int stateId,int fKCountryId,string stateName,bool isActive)
        {
            this.StateId = stateId;
            this.FKCountryId = fKCountryId;
            this.StateName = StateName;
            this.IsActive = isActive;
        }

        //counstrutor without StateId
        public StateData(int fKCountryId,string stateName,bool isActive)
        {
            this.FKCountryId = fKCountryId;
            this.StateName = stateName;
            this.IsActive = isActive;
        }

        //verification
        private string Validation;
        public void Validate()
        {
            if (!string.IsNullOrEmpty(Validation))
            {
                throw new ApplicationException(Validation);
            }
        }
    }
}
