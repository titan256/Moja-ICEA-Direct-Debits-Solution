using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace ICEADDI
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        //string sqlconnstr = @"Data Source = ugsybsvr; Integrated Security = SSPI; Initial Catalog = SYBUGANIC";
        //string sqlconnstr = @"Data Source=EMUW-NB\SQL2008;Initial Catalog=SYBUGANC;Integrated Security=True";
        string sqlconnstr = ConfigurationManager.ConnectionStrings["ICEA"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DeniedGridLoad();
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

        private void DeniedGridLoad()
        {
            try
            {

                //string query = "select  idx2 as [Originator Bank Code],idx4 as [ICEA Debit Account], idx5 as [Commencement Date] ,idx6 as [Expiry Date],idx7 as [Amount Limit],idx8 as [Entry Date],idx9 as Frequency,idx11 as [Client Bank Code],idx13 as [Client Account Number],idx23 as [Due Day],idx26 as [Policy Number],IceaBatchNumber as [Batch], IceaStatus as [Queue] from eftDDInstructICEA where iceastatus='DENIED'";
                //SqlDataReader readers = QueryDatabase(sqlconnstr, query);
               // DeniedGrid.DataSource = readers;
                DeniedGrid.DataBind();

            }
            catch (Exception ex)
            {
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Unable to connect to database. Please contact the Administrator" + ex;
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
                    query = "update eftDDInstructICEA set IceaStatus='ARCHIVE' where idx26='" + autoId + "' and IceaStatus='DENIED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Archive";
                   DeniedGridLoad();
                    break;
                case "MarkAsApproved":
                    query = "update eftDDInstructICEA set IceaStatus='CHECKER' where idx26='" + autoId + "'and IceaStatus='DENIED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Approval";
                   DeniedGridLoad();
                    break;
                case "MarkAsDenied":
                    query = "update eftDDInstructICEA set IceaStatus='DENIED' where idx26='" + autoId + "' and IceaStatus='CHECKER'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been Denied";
                    DeniedGridLoad();
                    break;
            }


        }

    }
}