using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICEADDI
{
    public partial class BankCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {

                authPanel.Visible = true;
                AnonPanel.Visible = false;
                string currentUsersName = User.Identity.Name;
                //disp.Console.WriteLine(currentUsersName+"here");
                //disp.Text = currentUsersName + "here";
                wlcmlbl.Text = "Welcome " + currentUsersName + "!";
            }
            else
            {
                authPanel.Visible = false;
                AnonPanel.Visible = true;
                disp2.Text = "Please login to access this portal";
            }
        }
    }
}