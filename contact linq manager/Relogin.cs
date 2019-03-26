using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using contact_linq_manager.Forms;

namespace contact_linq_manager
{
    class Relogin
    {
        public static Form Call()
        {
            LoginForm loginForm = new LoginForm();
            Form frm;
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                frm = new MdiParentform();
            }
            else
            {
                frm = new LoginForm();
            }
            return frm;
        }
        public static void Call(int a)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog()==DialogResult.OK)
            {
                MdiParentform mdiParentform = new MdiParentform();
                mdiParentform.ShowDialog();
            }
        }
    }
}
