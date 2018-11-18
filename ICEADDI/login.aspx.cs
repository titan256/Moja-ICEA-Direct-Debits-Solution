using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICEADDI
{
    public partial class Icealogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SbtBtn_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(UserName.Text, Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, false);
            }
            else
            {
                Display.Visible = true;
            }
        }
    }
}