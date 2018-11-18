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
    public partial class WebForm1 : System.Web.UI.Page
    {

        //string sqlconnstr = @"Data Source = ugsybsvr; Integrated Security = SSPI; Initial Catalog = SYBUGANIC";
        //string sqlconnstr = @"Data Source=EMUW-NB\SQL2008;Initial Catalog=SYBUGANC;Integrated Security=True";
        string sqlconnstr = ConfigurationManager.ConnectionStrings["ICEA"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            MakerGridLoad();
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

        private void MakerGridLoad()
        {
            try
            {

                string query ="select idx2 as [Originator Bank Code],idx4 as [ICEA Debit Account], idx5 as [Commencement Date] ,idx6 as [Expiry Date],idx7 as [Amount Limit],idx8 as [Entry Date],idx9 as Frequency,idx11 as [Client Bank Code],idx13 as [Client Account Number],idx23 as [Due Day],idx26 as [Policy Number],IceaBatchNumber as [Batch], IceaStatus as [Queue] from eftDDInstructICEA where iceastatus='MAKER'";
                SqlDataReader readers =QueryDatabase(sqlconnstr, query);
                //MakerGrid.DataSource = readers;
                //MakerGrid.DataBind();
                
            }
            catch (Exception ex)
            {
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Unable to connect to database. Please contact the Administrator"+ex;
            }


        }

        protected void cmdDenyBatch_Click(object sender, EventArgs e)
        {
            if (txtBatchDeny.Text == "")
            {
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Please Insert A Batch to Delete";
            }
            else
            {
                string btc = txtBatchDeny.Text;
                string query = "update eftDDInstructICEA set IceaStatus='DENIED' where IceaBatchNumber= "+btc;
                SqlDataReader readers = QueryDatabase(sqlconnstr, query);
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Batch has been Denied";
                MakerGridLoad();

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
            MakerGridLoad();
        }

        protected void cmdApproveBatch_Click(object sender, EventArgs e)
        {
            if (txtBatchNumber.Text == "")
            {
                Display.BackColor = System.Drawing.Color.Red;
                Display.ForeColor = System.Drawing.Color.White;
                Display.Text = "Please Insert A Batch to Approve";
            }
            else
            {
                try
                {
                    string btc = txtBatchNumber.Text;
                    string query = "update eftDDInstructICEA set IceaStatus='CHECKER' where IceaBatchNumber= " + btc;
                    SqlDataReader readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Batch has been sent for Approval";
                    MakerGridLoad();
                }
                catch
                {

                    Display.BackColor = System.Drawing.Color.Red;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Failed to Connect to Bank Database. Please Contact Administrator";
                    MakerGridLoad();
                }

            }

        }

        protected void cmdApproveAll_Click(object sender, EventArgs e)
        {
            string query = "update eftDDInstructICEA set IceaStatus='CHECKER' where IceaStatus='MAKER'";
            SqlDataReader readers = QueryDatabase(sqlconnstr, query);
            Display.BackColor = System.Drawing.Color.Green;
            Display.ForeColor = System.Drawing.Color.White;
            Display.Text = "Items have been sent for Approval";
            MakerGridLoad();
        }


        protected void MakerGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int inde = MakerGrid.EditIndex;
            GridViewRow row = MakerGrid.Rows[inde];

            TextBox commdt = (TextBox)row.FindControl("cdate");
            TextBox idx24 = (TextBox)row.FindControl("origbank");
            TextBox idx13 = (TextBox)row.FindControl("origacc");
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
            e.NewValues["idx24"] = idx24.Text;
            e.NewValues["idx13"] = idx13.Text;
            e.NewValues["idx6"] = idx6.Text;
            e.NewValues["idx7"] = idx7.Text;
            e.NewValues["idx8"] = idx8.Text;
            e.NewValues["idx9"] = idx9.Text;
            e.NewValues["idx11"] =idx11.Text;
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
                    query = "update eftDDInstructICEA set IceaStatus='ARCHIVE' where idx26='" + autoId + "' and IceaStatus='MAKER'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Archive";
                    MakerGridLoad();
                break;
                case "MarkAsApproved":
                    query = "update eftDDInstructICEA set IceaStatus='CHECKER' where idx26='"+autoId+"' and IceaStatus='MAKER'" ;
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been sent for Approval";
                    MakerGridLoad();
                break;
                case "MarkAsDenied":
                query = "update eftDDInstructICEA set IceaStatus='DENIED' where idx26='" + autoId + "' and IceaStatus='MAKER'";
                    readers = QueryDatabase(sqlconnstr, query);
                    Display.BackColor = System.Drawing.Color.Green;
                    Display.ForeColor = System.Drawing.Color.White;
                    Display.Text = "Items have been Denied";
                    MakerGridLoad();
                break;
            }
         

        }

        protected void MakerGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
}
}