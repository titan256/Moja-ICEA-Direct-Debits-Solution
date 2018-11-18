using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

namespace ICEADDI
{
    public partial class maker : System.Web.UI.Page
    {
        string sqlconnstr = @"Data Source=EMUW-NB\SQL2008;Initial Catalog=SYBUGANC;Integrated Security=True";
        //string sqlconnstr = @"Data Source = ugsybsvr; Integrated Security = SSPI; Initial Catalog = SYBUGANIC";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CsvUploadBtn_Click(object sender, EventArgs e)
        {
            /**ENW: Uploading Excel CSV file and reading it into the database using batches**/
            string excelpath = " ";
            if (CsvUpload.HasFile)
            {
                string rootPath = Server.MapPath("~");
                excelpath = string.Concat(Server.MapPath("~/uploads/" + CsvUpload.FileName));
                string connPath = string.Concat(Server.MapPath("~/uploads/"));
                CsvUpload.SaveAs(excelpath);
                OleDbConnection oconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + connPath + "; Extended Properties='text; HDR=Yes; FMT=Delimited'");
          
                try
                {
                    OleDbCommand ocmd = new OleDbCommand("SELECT * FROM [" + CsvUpload.FileName + "]", oconn);
                    oconn.Open();
                    OleDbDataReader odr = ocmd.ExecuteReader();
                   /***'Reference Number |Originator Bank Branch Account|Amount|Debit Bank Branch Account|Name|Policy Number|Narrative**/

                    string lvOrigCode = "";
                    string lvOrigBankCode = "";
                    string lvOrigBranchCode = "";
                    string lvOrigAccNo = "";
                    string lvCommenceDate = "";
                    string lvExpiryDate = "";
                    string lvEntryDate = "";
                    string lvFrequency = "";
                    string lvCustBank = "";
                    string lvCustBankBranch = "";
                    string lvCustomerAccount = "";
                    string lvRemarks = "";
                    string lvStatus = "";
                    string lvCapturedBy = "";
                    string lvEntryType = "";
                    int lvDocNo;
                    string lvPaymentType = "";
                    string lvDueDay = "";
                    string lvPolicyNum1 = "";
                    string lvPolicyNum2 = "";
                    string lvRefNo = "";
                    string lvOnUsCC = "";
                    string lvAmount;
                    string lvBatchNumber;
                    //string lvDebitsTotals = lvDebitsTotals + lvAmount;
                    
                    while (odr.Read())

                    {
                        lvRefNo = valid(odr, 0);
                        //idx1
                        lvOrigCode = "09";
                        //idx2
                        lvOrigBankCode = "35";
                        //idx3
                        lvOrigBranchCode = "01";
                        //idx4
                        lvOrigAccNo = "";
                        //idx5,idx25
                        lvCommenceDate = valid(odr, 1);
                        DateTime dts = Convert.ToDateTime(lvCommenceDate);
                        string CommenceDate = dts.ToString("yyMMdd");
                        //idx6
                        lvExpiryDate = valid(odr, 2);
                        DateTime dtse = Convert.ToDateTime(lvExpiryDate);
                        string ExpiryDate = dtse.ToString("yyMMdd");
                        //idx7 idx22
                        lvAmount = valid(odr, 3);
                        //idx8
                        lvEntryDate = DateTime.Now.ToString("yyMMdd");
                        //idx9
                        lvFrequency = valid(odr, 4);
                        //idx10
                        lvOnUsCC = "";
                        //idx11
                        lvCustBank = valid(odr, 5);
                        //idx12
                        lvCustBankBranch = valid(odr, 6);
                        //idx13
                        lvCustomerAccount = valid(odr, 7);
                        //idx14, idx24
                        lvRemarks = valid(odr, 8);
                        //idx15
                        lvStatus = "ICEA";
                        string iceaStatus = "MAKER";
                        //idx16
                        lvCapturedBy = "ONLINE";
                       //idx20
                        lvEntryType = "MANUAL";
                        //DocNo
                        lvDocNo = 24;
                        //idx21
                        lvPaymentType = "";
                        //idx23  
                        lvDueDay = valid(odr, 9);
                        DateTime dtf = Convert.ToDateTime(lvDueDay);
                        string DueDay = dtf.ToString("yyMMdd");
                        //idx26
                        lvPolicyNum1 = valid(odr,10); ;
                        //idx27
                        lvPolicyNum2 = valid(odr, 11); 
                        //Batch Number-Date +OrigCode
                        string dt = DateTime.Now.ToString();
                        lvBatchNumber = dt + lvOrigCode;
                     
                        /****Carry Out Validation****/
                        /****Insert into Database***/
                        SqlConnection conn = new SqlConnection(sqlconnstr);//SQL connection
                        SqlCommand cmd = new SqlCommand();//SQL command
                        cmd.Connection = conn;
                        cmd.CommandText = "SET ANSI_WARNINGS off; INSERT INTO eftDDInstructICEA(DocNo,idx1,idx2,idx3,idx4,idx5,idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15,idx16,idx20,idx21,idx23,idx26,idx27) VALUES(@DocNo,@idx1,@idx2,@idx3,@idx4,@idx5,@idx6,@idx7,@idx8,@idx9,@idx10,@idx11,@idx12,@idx13,@idx14,@idx15,@idx16,@idx20,@idx21,@idx23,@idx26,@idx27)";
                        cmd.Parameters.Add("@DocNo", System.Data.SqlDbType.Int).Value = lvDocNo;
                        cmd.Parameters.Add("@idx1", System.Data.SqlDbType.VarChar).Value = lvOrigCode;
                        cmd.Parameters.Add("@idx2", System.Data.SqlDbType.Char).Value = lvOrigBankCode;
                        cmd.Parameters.Add("@idx3", System.Data.SqlDbType.Char).Value = lvOrigBranchCode;
                        cmd.Parameters.Add("@idx4", System.Data.SqlDbType.VarChar).Value = lvOrigAccNo;
                        cmd.Parameters.Add("@idx5", System.Data.SqlDbType.Char).Value = CommenceDate;
                        cmd.Parameters.Add("@idx6", System.Data.SqlDbType.Char).Value = ExpiryDate;
                        cmd.Parameters.Add("@idx7", System.Data.SqlDbType.VarChar).Value = lvAmount;
                        cmd.Parameters.Add("@idx8", System.Data.SqlDbType.Char).Value = lvEntryDate;
                        cmd.Parameters.Add("@idx9", System.Data.SqlDbType.SmallInt).Value = lvFrequency;
                        cmd.Parameters.Add("@idx10", System.Data.SqlDbType.Char).Value = lvOnUsCC;
                        cmd.Parameters.Add("@idx11", System.Data.SqlDbType.Char).Value = lvCustBank;
                        cmd.Parameters.Add("@idx12", System.Data.SqlDbType.Char).Value = lvCustBankBranch;
                        cmd.Parameters.Add("@idx13", System.Data.SqlDbType.VarChar).Value = lvCustomerAccount;
                        cmd.Parameters.Add("@idx14", System.Data.SqlDbType.VarChar).Value = lvRemarks;
                        cmd.Parameters.Add("@idx15", System.Data.SqlDbType.VarChar).Value = lvStatus;
                        cmd.Parameters.Add("@idx16", System.Data.SqlDbType.VarChar).Value = lvCapturedBy;
                        cmd.Parameters.Add("@idx20", System.Data.SqlDbType.VarChar).Value = lvEntryType;
                        cmd.Parameters.Add("@idx21", System.Data.SqlDbType.VarChar).Value = lvPaymentType;
                        cmd.Parameters.Add("@idx23", System.Data.SqlDbType.VarChar).Value = DueDay;
                        cmd.Parameters.Add("@idx26", System.Data.SqlDbType.VarChar).Value = lvPolicyNum1;
                        cmd.Parameters.Add("@idx27", System.Data.SqlDbType.VarChar).Value = lvPolicyNum2;
                        cmd.CommandType = System.Data.CommandType.Text;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        CsvUpload.Dispose();
                    }
                        Display.BackColor = System.Drawing.Color.Green;
                        Display.ForeColor = System.Drawing.Color.White;
                        Display.Text = "Direct Debits Batch Has Been Saved to the Database.  " ;
                }
                catch (Exception ex)
                {
                        Display.BackColor = System.Drawing.Color.Red;
                        Display.ForeColor = System.Drawing.Color.White;
                        Display.Text = "Could not save file. Please contact your IT Personnel" + ex;
                }
            }
            else
            {
                        Display.BackColor = System.Drawing.Color.Red;
                        Display.ForeColor = System.Drawing.Color.White;
                        Display.Text = "Please upload file to continue";
            }
        }

        protected string valid(OleDbDataReader myreader, int stval)  //this method checks for null values in the .CSV file, if there are null replace them with 0
        {
            object val = myreader[stval];
            if (val != DBNull.Value)
            {

                return val.ToString();
            }
            else
            {
                return Convert.ToString(0);
            }


        }
           
    }
}