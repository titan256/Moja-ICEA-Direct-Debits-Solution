using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICEADDI
{
    public partial class IceaAmtchanged : System.Web.UI.Page
    {

        //string sqlconnstr = @"Data Source = ugsybsvr; Integrated Security = SSPI; Initial Catalog = SYBUGANIC";
        //string sqlconnstr = @"Data Source=EMUW-NB\SQL2008;Initial Catalog=SYBUGANC;Integrated Security=True";
        string sqlconnstr = ConfigurationManager.ConnectionStrings["ICEA"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            AmtGridLoad();
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

        private SqlDataReader QueryDatabase(string connStr, string cmdStr)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(cmdStr, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
        protected void cmdDeleteAll_Click(object sender, EventArgs e)
        {
            string query = "update eftDDInstructICEA set IceaStatus='DENIED' where IceaStatus='MAKER'";
            SqlDataReader readers = QueryDatabase(sqlconnstr, query);
            Display.BackColor = System.Drawing.Color.Red;
            Display.ForeColor = System.Drawing.Color.White;
            Display.Text = "Items have been Archived";
           AmtGridLoad();
        }


      
        private void AmtGridLoad()
        {
            try
            {

                string query = "select idx2 as [Originator Bank Code],idx4 as [ICEA Debit Account], idx5 as [Commencement Date] ,idx6 as [Expiry Date],idx7 as [Amount Limit],idx8 as [Entry Date],idx9 as Frequency,idx11 as [Client Bank Code],idx13 as [Client Account Number],idx23 as [Due Day],idx26 as [Policy Number],IceaBatchNumber as [Batch], IceaStatus as [Queue] from eftDDInstructICEA where iceastatus='AMTCHANGED'";
                SqlDataReader readers = QueryDatabase(sqlconnstr, query);
                //MakerGrid.DataSource = readers;
                //MakerGrid.DataBind();

            }
            catch (Exception ex)
            {
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Unable to connect to database. Please contact the Administrator" + ex;
            }


        }
        //custom grid commands
        protected void FireRowCommand(object sender, GridViewCommandEventArgs e)
        {

            string command = e.CommandName;
            string autoId = e.CommandArgument.ToString();
            string query;
            SqlDataReader readers;
            switch (command)
            {

                case "MarkAsArchived":
                    query = "update eftDDInstructICEA set IceaStatus='ARCHIVE' where idx26='" + autoId + " 'and IceaStatus='AMTCHANGED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Archive";
                    AmtGridLoad();
                    break;
                case "MarkAsApproved":
                    query = "update eftDDInstructICEA set IceaStatus='APPROVED' where idx26='" + autoId + "' and IceaStatus='AMTCHANGED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Approval";
                    AmtGridLoad();
                    break;
                case "MarkAsDenied":
                    query = "update eftDDInstructICEA set IceaStatus='AMTCHANGED' where idx26='" + autoId + "' and IceaStatus='AMTCHANGED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been Denied";
                    AmtGridLoad();
                    break;
            }


        }
    }
}