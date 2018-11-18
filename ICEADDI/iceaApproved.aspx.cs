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
    public partial class WebForm3 : System.Web.UI.Page
    {
        //string sqlconnstr = @"Data Source = ugsybsvr; Integrated Security = SSPI; Initial Catalog = SYBUGANIC";
        //string sqlconnstr = @"Data Source=EMUW-NB\SQL2008;Initial Catalog=SYBUGANC;Integrated Security=True";
        string sqlconnstr=ConfigurationManager.ConnectionStrings["ICEA"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

               ApprovedGridLoad();
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

        private void ApprovedGridLoad()
        {
            try
            {
                string query = "select  idx2 as [Originator Bank Code],idx4 as [ICEA Debit Account], idx5 as [Commencement Date] ,idx6 as [Expiry Date],idx7 as [Amount Limit],idx8 as [Entry Date],idx9 as Frequency,idx11 as [Client Bank Code],idx13 as [Client Account Number],idx23 as [Due Day],idx26 as [Policy Number],IceaBatchNumber as [Batch], IceaStatus as [Queue] from eftDDInstructICEA where iceastatus='APPROVED'";
                //SqlDataReader readers = QueryDatabase(sqlconnstr, query);
                //ApprovedGrid.DataSource = readers;
                ApprovedGrid.DataBind();
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

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            /**ENW: Reads into Sybrin Direct Debits Table ***/
            try
            {
                string query = @"SET ANSI_WARNINGS off
                              Delete from eftDDInstructOUTCLR where idx16='ONLINE'
                              INSERT INTO eftDDInstructOUTCLR(DocNo,idx1,idx2,idx3,idx4,idx5,
                              idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15,idx16,idx20,idx21,idx23,idx26,idx27,idx22,idx24,idx25)
                              Select DocNo,idx1,idx2,idx3,idx4,idx5,idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15,
                               idx16,idx20,idx21,idx23,idx26,idx27,idx22,idx24,idx25 from(
                              select  *,ROW_NUMBER() OVER(PARTITION BY idx26 order by idx1) rn
                              from eftDDInstructICEA where IceaStatus='APPROVED' 
                              )a WHERE rn = 1";
                /*string query = "SET ANSI_WARNINGS off; INSERT INTO eftDDInstructOUTCLR(DocNo,idx1,idx2,idx3,idx4,idx5," +
                               "idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15,idx16,idx20,idx21,idx23,idx26,idx27)" +
                               "select  DocNo,idx1,idx2,idx3,idx4,idx5,idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15," +
                               "idx16,idx20,idx21,idx23,idx26,idx27 from eftDDInstructICEA where iceastatus='APPROVED'";*/
                SqlDataReader readers = QueryDatabase(sqlconnstr, query);
                Display.BackColor = System.Drawing.Color.Green;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Batch has been sent for Processing";
                ApprovedGridLoad();
            }
            catch (Exception ex)
            {
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Failed to Connect to Bank Database. Please Contact Administrator" + ex;
                ApprovedGridLoad();
            }
        }
        protected void ApprovedGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //ApprovedGrid.EditIndex = e.NewEditIndex;
            //ApprovedGridLoad();
           
        }
        protected void ApprovedGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int inde = ApprovedGrid.EditIndex;
            GridViewRow row = ApprovedGrid.Rows[inde];

            TextBox commdt = (TextBox)row.FindControl("cdate");
            TextBox idx2 = (TextBox)row.FindControl("origbank");
            TextBox idx4 = (TextBox)row.FindControl("origacc");
            TextBox idx6 = (TextBox)row.FindControl("expdate");
            TextBox idx7 = (TextBox)row.FindControl("amt");
            TextBox idx8 = (TextBox)row.FindControl("credate");
            TextBox idx9 = (TextBox)row.FindControl("fq");
            TextBox idx11 = (TextBox)row.FindControl("pbank");
            //TextBox idx13 = (TextBox)row.FindControl("origbank");
            //TextBox idx15 = (TextBox)row.FindControl("origbank");
            TextBox idx23 = (TextBox)row.FindControl("ddue");
            // TextBox idx26= (TextBox)row.FindControl("origbank");

            Display.BackColor = System.Drawing.Color.Green;
            Display.ForeColor = System.Drawing.Color.White;
            Display.Text = "Data has been edited successfully.";

            e.NewValues["idx5"] = commdt.Text;
            e.NewValues["idx2"] = idx2.Text;
            e.NewValues["idx4"] = idx4.Text;
            e.NewValues["idx6"] = idx6.Text;
            e.NewValues["idx7"] = idx7.Text;
            e.NewValues["idx8"] = idx8.Text;
            e.NewValues["idx9"] = idx9.Text;
            e.NewValues["idx11"] = idx11.Text;
            //e.NewValues["idx13"] = idx13.Text;
            //e.NewValues["idx15"] = idx15.Text;
            e.NewValues["idx23"] = idx23.Text;
            //e.NewValues["idx26"] = idx26.Text;
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
                    query = "update eftDDInstructICEA set IceaStatus='ARCHIVE' where idx26='" + autoId + "' and IceaStatus='APPROVED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Archive";
                    ApprovedGridLoad();
                    break;
                case "MarkAsApproved":
                    query = "update eftDDInstructICEA set IceaStatus='APPROVED' where idx26='" + autoId + "' and IceaStatus='APPROVED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Approval";
                    ApprovedGridLoad();
                    break;
                case "MarkAsDenied":
                    query = "update eftDDInstructICEA set IceaStatus='CHECKER' where idx26='" + autoId + "' and IceaStatus='APPROVED'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been returned to checker";
                    ApprovedGridLoad();
                    break;
            }


        }
}
}