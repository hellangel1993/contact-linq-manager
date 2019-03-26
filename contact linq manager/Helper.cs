using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contact_linq_manager
{
    class Helper
    {
        public  string Connectionstring
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["contact_linq_manager.Properties.Settings.AddressbookConnectionString"].ConnectionString;
            }
        }
    }
}
