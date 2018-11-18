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
using System.Text;
using System.Configuration;
using System.Globalization;
using ICEADDI;

namespace ICEADDI
{

    public partial class maker : System.Web.UI.Page
    {
        //string sqlconnstr = @"Data Source=EMUW-NB\SQL2008;Initial Catalog=SYBUGANC;Integrated Security=True";
        //string sqlconnstr = @"Data Source = ugsybsvr; Integrated Security = SSPI; Initial Catalog = SYBUGANIC";
        string sqlconnstr = ConfigurationManager.ConnectionStrings["ICEA"].ConnectionString;
      
        //Helper hp = new Helper();

        protected void Page_Load(object sender, EventArgs e)
        {
          if (Request.IsAuthenticated)
            {

                //Page.authPanel.Visible = true;
                //AnonPanel.Visible = false;
                string currentUsersName = User.Identity.Name;
                //disp.Console.WriteLine(currentUsersName+"here");
                //disp.Text = currentUsersName + "here";
                wlcmlbl.Text = "Welcome " + currentUsersName + "!";
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
            }
            else
            {
                //authPanel.Visible = false;
                //AnonPanel.Visible = true;
                //disp2.Text = "Please login to access this portal";
            }
           
        }

        protected void CsvUploadBtn_Click(object sender, EventArgs e)
        {
            /**ENW: Uploading Excel CSV file and reading it into the database using batches**/
            //obtaining originator details from database
            SqlConnection conn = new SqlConnection(sqlconnstr);
            string excelpath = " ";
            string originator=ConfigurationManager.AppSettings["OrigID"].ToString();
            string OrigIDQry = "SELECT Originator.OrigName,Originator.OrigChg, OrigAccounts.Origbank,OrigAccounts.OrigBank,OrigAccounts.OrigBranch,OrigAccounts.OrigAccount FROM Originator INNER JOIN origAccounts ON Originator.OrigID=OrigAccounts.OrigID";
            string lvOrigCode =  originator;
            string lvOrigBankCode="";
            string lvOrigBranchCode = "";
            string lvOrigAccNo = ""; 
            string lvOrigName ="";
            SqlCommand sqlCommandOrig = new SqlCommand(OrigIDQry, conn);
            conn.Open();
            sqlCommandOrig.Parameters.Add("@origid", System.Data.SqlDbType.VarChar).Value = originator;
            using (SqlDataReader readerOrig = sqlCommandOrig.ExecuteReader())
            {
                if (readerOrig.Read())
                {
                    lvOrigBankCode = String.Format("{0}", readerOrig["OrigBank"]);
                    lvOrigBranchCode = String.Format("{0}", readerOrig["OrigBranch"]);
                    lvOrigAccNo = String.Format("{0}", readerOrig["OrigAccount"]);
                    lvOrigName = String.Format("{0}", readerOrig["OrigName"]);
                }
            }

            
            if (CsvUpload.FileName != string.Empty)
            {
                string rootPath = Server.MapPath("~");
                excelpath = string.Concat(Server.MapPath("~/uploads/" + CsvUpload.FileName));
                string connPath = string.Concat(Server.MapPath("~/uploads/"));
                if (File.Exists(excelpath))
                {
                    DisplayError("File name has been uploaded");
                }

                else
                {
                    try
                    {

                        CsvUpload.SaveAs(excelpath);

                    }
                    catch (Exception ex)
                    {
                        DisplayError("File Name Error!!!" + ex);

                    }
                    OleDbConnection oconn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + connPath + "; Extended Properties='text; HDR=Yes; FMT=Delimited'");
                    oconn.Open();                 
                    try
                    {
                        OleDbCommand ocmd = new OleDbCommand("SELECT * FROM [" + CsvUpload.FileName + "]", oconn);

                        OleDbDataReader odr = ocmd.ExecuteReader();
                        /***'Reference Number |Originator Bank Branch Account|Amount|Debit Bank Branch Account|Name|Policy Number|Narrative**/
                        string lvCapturedBy = User.Identity.Name;
                        string lvCommenceDate = "";
                        string lvExpiryDate = "";
                        string lvEntryDate = "";
                        string lvFrequency = "";
                        string lvCustBank = "";
                        string lvCustBankBranch = "";
                        string lvCustomerAccount = "";
                        string lvRemarks = "";
                        string lvStatus = "";
                        //string lvCapturedBy = "";
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

                            Boolean fg = false;

                            lvRefNo = valid(odr, 0);

                            lvCommenceDate = valid(odr, 1);
                            DateTime dts = Convert.ToDateTime(lvCommenceDate);
                            string CommenceDate = dts.ToString("yyyy/MM/dd");
                            //idx6
                            lvExpiryDate = valid(odr, 2);
                            DateTime dtse = Convert.ToDateTime(lvExpiryDate);
                            string ExpiryDate = dtse.ToString("yyyy/MM/dd");
                            //idx7 idx22
                            lvAmount = valid(odr, 3);
                            //idx8
                            lvEntryDate = DateTime.Now.ToString("yyyy/MM/dd");
                            //idx9
                            lvFrequency = valid(odr, 4);
                            //idx10
                            lvOnUsCC = ConfigurationManager.AppSettings["OnusCC"].ToString();
                            //idx11
                            lvCustBank = valid(odr, 5);
                            //idx12
                            lvCustBankBranch = valid(odr, 6);
                            //idx13
                            lvCustomerAccount = valid(odr, 7);
                            //idx14, idx24
                            lvRemarks = valid(odr, 8);
                            //idx15
                            lvStatus = lvOrigName;
                            string iceaStatus = "MAKER";
                            //idx16
                            lvCapturedBy = User.Identity.Name;
                            //idx20
                            lvEntryType = "MANUAL";
                            //DocNo
                            lvDocNo = Int32.Parse(ConfigurationManager.AppSettings["DocNo"]); 
                            //idx21
                            lvPaymentType = "";
                            //idx23  
                            //lvDueDay = valid(odr, 9);
                            DateTime dtf = Convert.ToDateTime(lvCommenceDate);
                            //string DueDay = dtf.ToString("yyyy/MM/dd");
                            string DueDay = dtf.Day.ToString();
                            //idx26
                            lvPolicyNum1 = valid(odr, 9);
                            //idx27
                            //lvPolicyNum2 = valid(odr, 11);
                            //Batch Number-Date +OrigCode
                            lvBatchNumber = GenerateNumber();
                            /****Carry Out Validation****/
                            //validate Account

                            //validate branch and bank codes


                            
                            //Check all fields are there:
                            if (lvPolicyNum1 != "" && lvCustomerAccount != "" && lvCustBank != "" && lvFrequency != "" && lvAmount != "" && lvRefNo != "")
                            {

                                if(lvCustomerAccount.Length<10){

                                    DisplayError("invalid account");

                                }
                                else if (lvCustomerAccount.Length > 15)
                                {


                                    DisplayError("invalid account");
                                }
                                else if (lvPolicyNum1=="0")
                                {
                                    DisplayError("Please insert a policy number");
                                }
                                else
                                {

                                    fg = true;
                                }
                            }
                            else
                            {
                                DisplayError(Display.Text + "This Policy:" + lvPolicyNum1 + " is incomplete");

                            }
                            if (fg == true)
                            {
                                //Check policy num
                                //SQL connection
                               
                                string qry = "Select count(*) from eftDDInstructICEA where idx26 = @lvPolicyNum1";
                                using (SqlCommand sqlCommand = new SqlCommand(qry, conn))
                                {
                                    
                                    sqlCommand.Parameters.Add("@lvPolicyNum1", System.Data.SqlDbType.VarChar).Value = lvPolicyNum1;
                           
                                    int userCount = (int)sqlCommand.ExecuteScalar();

                                    if (userCount > 0)
                                    {
                                        fg = false;

                                        string qry2 = "Select count(*) from eftDDInstructICEA where idx26 = @lvPolicyNum1 and idx13=@lvCustomerAcc";                                 
                                       
                                        using ( SqlCommand sqlCommand2 = new SqlCommand(qry2, conn))
                                        {
                                            sqlCommand2.Parameters.Add("@lvPolicyNum1", System.Data.SqlDbType.VarChar).Value = lvPolicyNum1;
                                            sqlCommand2.Parameters.Add("@lvCustomerAcc", System.Data.SqlDbType.VarChar).Value = lvCustomerAccount;
                                            int rowCount = (int)sqlCommand2.ExecuteScalar();
                                            if (rowCount > 0)
                                            {
                                                      
                                                        //policy number and account are the same. This is an update
                                                        try
                                                        {
                                                            SqlConnection con2 = new SqlConnection(sqlconnstr);//SQL connection
                                                            SqlCommand cmd2 = new SqlCommand();//SQL command
                                                            cmd2.Connection = con2;
                                                            cmd2.CommandText = "SET ANSI_WARNINGS off;update eftDDInstructICEA set idx1=@idx1,idx2=@idx2,idx3=@idx3,idx4=@idx4,idx5=@idx5,idx6=@idx6,idx7=@idx7,idx8=@idx8,idx9=@idx9,idx10=@idx10,idx11=@idx11,idx12=@idx12,idx13=@idx13,idx14=@idx14,idx15=@idx15,idx16=@idx16,idx20=@idx20,idx21=@idx21,idx23=@idx23,idx26=@idx26,idx27=@idx27,IceaBatchNumber=@IceaBatchNumber,IceaStatus='AMTCHANGED',idx22=@idx22,idx24=@idx24,idx25=@idx25 where idx26 = @idx26 and idx13=@idx13";
                                                            cmd2.Parameters.Add("@DocNo", System.Data.SqlDbType.Int).Value = lvDocNo;
                                                            cmd2.Parameters.Add("@idx1", System.Data.SqlDbType.VarChar).Value = lvOrigCode;
                                                            cmd2.Parameters.Add("@idx2", System.Data.SqlDbType.Char).Value = lvOrigBankCode;
                                                            cmd2.Parameters.Add("@idx3", System.Data.SqlDbType.Char).Value = lvOrigBranchCode;
                                                            cmd2.Parameters.Add("@idx4", System.Data.SqlDbType.VarChar).Value = lvOrigAccNo;
                                                            cmd2.Parameters.Add("@idx5", System.Data.SqlDbType.Char).Value = CommenceDate;
                                                            cmd2.Parameters.Add("@idx6", System.Data.SqlDbType.Char).Value = ExpiryDate;
                                                            cmd2.Parameters.Add("@idx7", System.Data.SqlDbType.VarChar).Value = lvAmount;
                                                            cmd2.Parameters.Add("@idx22", System.Data.SqlDbType.VarChar).Value = lvAmount;
                                                            cmd2.Parameters.Add("@idx8", System.Data.SqlDbType.Char).Value = lvEntryDate;
                                                            cmd2.Parameters.Add("@idx9", System.Data.SqlDbType.SmallInt).Value = lvFrequency;
                                                            cmd2.Parameters.Add("@idx10", System.Data.SqlDbType.Char).Value = lvOnUsCC;
                                                            cmd2.Parameters.Add("@idx11", System.Data.SqlDbType.Char).Value = lvCustBank;
                                                            cmd2.Parameters.Add("@idx12", System.Data.SqlDbType.Char).Value = lvCustBankBranch;
                                                            cmd2.Parameters.Add("@idx13", System.Data.SqlDbType.VarChar).Value = lvCustomerAccount;
                                                            cmd2.Parameters.Add("@idx14", System.Data.SqlDbType.VarChar).Value = lvRemarks;
                                                            cmd2.Parameters.Add("@idx15", System.Data.SqlDbType.VarChar).Value = lvStatus;
                                                            cmd2.Parameters.Add("@idx16", System.Data.SqlDbType.VarChar).Value = lvCapturedBy;
                                                            cmd2.Parameters.Add("@idx20", System.Data.SqlDbType.VarChar).Value = lvEntryType;
                                                            cmd2.Parameters.Add("@idx21", System.Data.SqlDbType.VarChar).Value = lvPaymentType;
                                                            cmd2.Parameters.Add("@idx24", System.Data.SqlDbType.VarChar).Value = lvRemarks;
                                                            cmd2.Parameters.Add("@idx23", System.Data.SqlDbType.VarChar).Value = DueDay;
                                                            cmd2.Parameters.Add("@idx25", System.Data.SqlDbType.Char).Value = CommenceDate;
                                                            cmd2.Parameters.Add("@idx26", System.Data.SqlDbType.VarChar).Value = lvPolicyNum1;
                                                            cmd2.Parameters.Add("@idx27", System.Data.SqlDbType.VarChar).Value = lvPolicyNum2;
                                                            cmd2.Parameters.Add("@IceaBatchNumber", System.Data.SqlDbType.VarChar).Value = lvBatchNumber;
                                                            cmd2.Parameters.Add("@IceaStatus", System.Data.SqlDbType.VarChar).Value = iceaStatus;
                                                            cmd2.CommandType = System.Data.CommandType.Text;
                                                            con2.Open();
                                                            cmd2.ExecuteNonQuery();
                                                            con2.Close();
                                                            DisplaySuccess(lvPolicyNum1 + " with account number " + lvCustomerAccount + " has been updated");

                                                        }catch(Exception ed){

                                                            DisplayError(ed.ToString());
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //policy number is going to be indicated as a duplicate and set to queue for approval
                                                        try
                                                        {
                                                            SqlConnection con3 = new SqlConnection(sqlconnstr);//SQL connection
                                                            SqlCommand cmd3 = new SqlCommand();//SQL command
                                                            cmd3.Connection = con3;
                                                            cmd3.CommandText = "SET ANSI_WARNINGS off; INSERT INTO eftDDInstructICEA(DocNo,idx1,idx2,idx3,idx4,idx5,idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15,idx16,idx20,idx21,idx23,idx26,idx27,IceaBatchNumber,IceaStatus,idx22,idx24,idx25) VALUES(@DocNo,@idx1,@idx2,@idx3,@idx4,@idx5,@idx6,@idx7,@idx8,@idx9,@idx10,@idx11,@idx12,@idx13,@idx14,@idx15,@idx16,@idx20,@idx21,@idx23,@idx26,@idx27,@IceaBatchNumber,'DUPLICATE',@idx22,@idx24,@idx25)";
                                                            cmd3.Parameters.Add("@DocNo", System.Data.SqlDbType.Int).Value = lvDocNo;
                                                            cmd3.Parameters.Add("@idx1", System.Data.SqlDbType.VarChar).Value = lvOrigCode;
                                                            cmd3.Parameters.Add("@idx2", System.Data.SqlDbType.Char).Value = lvOrigBankCode;
                                                            cmd3.Parameters.Add("@idx3", System.Data.SqlDbType.Char).Value = lvOrigBranchCode;
                                                            cmd3.Parameters.Add("@idx4", System.Data.SqlDbType.VarChar).Value = lvOrigAccNo;
                                                            cmd3.Parameters.Add("@idx5", System.Data.SqlDbType.Char).Value = CommenceDate;
                                                            cmd3.Parameters.Add("@idx6", System.Data.SqlDbType.Char).Value = ExpiryDate;
                                                            cmd3.Parameters.Add("@idx7", System.Data.SqlDbType.VarChar).Value = lvAmount;
                                                            cmd3.Parameters.Add("@idx22", System.Data.SqlDbType.VarChar).Value = lvAmount;
                                                            cmd3.Parameters.Add("@idx8", System.Data.SqlDbType.Char).Value = lvEntryDate;
                                                            cmd3.Parameters.Add("@idx9", System.Data.SqlDbType.SmallInt).Value = lvFrequency;
                                                            cmd3.Parameters.Add("@idx10", System.Data.SqlDbType.Char).Value = lvOnUsCC;
                                                            cmd3.Parameters.Add("@idx11", System.Data.SqlDbType.Char).Value = lvCustBank;
                                                            cmd3.Parameters.Add("@idx12", System.Data.SqlDbType.Char).Value = lvCustBankBranch;
                                                            cmd3.Parameters.Add("@idx13", System.Data.SqlDbType.VarChar).Value = lvCustomerAccount;
                                                            cmd3.Parameters.Add("@idx14", System.Data.SqlDbType.VarChar).Value = lvRemarks;
                                                            cmd3.Parameters.Add("@idx15", System.Data.SqlDbType.VarChar).Value = lvStatus;
                                                            cmd3.Parameters.Add("@idx16", System.Data.SqlDbType.VarChar).Value = lvCapturedBy;
                                                            cmd3.Parameters.Add("@idx20", System.Data.SqlDbType.VarChar).Value = lvEntryType;
                                                            cmd3.Parameters.Add("@idx21", System.Data.SqlDbType.VarChar).Value = lvPaymentType;
                                                            cmd3.Parameters.Add("@idx24", System.Data.SqlDbType.VarChar).Value = lvRemarks;
                                                            cmd3.Parameters.Add("@idx23", System.Data.SqlDbType.VarChar).Value = DueDay;
                                                            cmd3.Parameters.Add("@idx25", System.Data.SqlDbType.Char).Value = CommenceDate;
                                                            cmd3.Parameters.Add("@idx26", System.Data.SqlDbType.VarChar).Value = lvPolicyNum1;
                                                            cmd3.Parameters.Add("@idx27", System.Data.SqlDbType.VarChar).Value = lvPolicyNum2;
                                                            cmd3.Parameters.Add("@IceaBatchNumber", System.Data.SqlDbType.VarChar).Value = lvBatchNumber;
                                                            cmd3.Parameters.Add("@IceaStatus", System.Data.SqlDbType.VarChar).Value = iceaStatus;
                                                            cmd3.CommandType = System.Data.CommandType.Text;
                                                            con3.Open();
                                                            cmd3.ExecuteNonQuery();
                                                            con3.Close();
                                                            CsvUpload.Dispose();

                                                            DisplaySuccess("Direct Debits Batch Has Been Saved to the Database. ");

                                                        }
                                                        catch (Exception es)
                                                        {
                                                            DisplayError("Could not connect to the database." + es);
                                                        }
                                                        DisplaySuccess(lvPolicyNum1 + " is a duplicate with account " + lvCustomerAccount);

                                                    }
                                                
                                                
                                               
                                            }
                                        }
                                  
                                }
                            }


                            //ENM:Validate the dates placed

                            if (ValidateDate(CommenceDate) && ValidateDate(lvEntryDate) && ValidateDate(ExpiryDate))
                            {


                                //Display.Text = "Valid Date";
                            }
                            else
                            {
                                fg = false;
                                DisplayError("This Policy:" + lvPolicyNum1 + " has inValid Date");
                            }

                            //ENM: Validate the frequency     

                            /****Insert  values  into Database if all is well***/
                            if (fg == true)
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection(sqlconnstr);//SQL connection
                                    SqlCommand cmd = new SqlCommand();//SQL command
                                    cmd.Connection = con;
                                    cmd.CommandText = "SET ANSI_WARNINGS off; INSERT INTO eftDDInstructICEA(DocNo,idx1,idx2,idx3,idx4,idx5,idx6,idx7,idx8,idx9,idx10,idx11,idx12,idx13,idx14,idx15,idx16,idx20,idx21,idx23,idx26,idx27,IceaBatchNumber,IceaStatus,idx22,idx24,idx25) VALUES(@DocNo,@idx1,@idx2,@idx3,@idx4,@idx5,@idx6,@idx7,@idx8,@idx9,@idx10,@idx11,@idx12,@idx13,@idx14,@idx15,@idx16,@idx20,@idx21,@idx23,@idx26,@idx27,@IceaBatchNumber,@IceaStatus,@idx22,@idx24,@idx25)";
                                    cmd.Parameters.Add("@DocNo", System.Data.SqlDbType.Int).Value = lvDocNo;
                                    cmd.Parameters.Add("@idx1", System.Data.SqlDbType.VarChar).Value = lvOrigCode;
                                    cmd.Parameters.Add("@idx2", System.Data.SqlDbType.Char).Value = lvOrigBankCode;
                                    cmd.Parameters.Add("@idx3", System.Data.SqlDbType.Char).Value = lvOrigBranchCode;
                                    cmd.Parameters.Add("@idx4", System.Data.SqlDbType.VarChar).Value = lvOrigAccNo;
                                    cmd.Parameters.Add("@idx5", System.Data.SqlDbType.Char).Value = CommenceDate;
                                    cmd.Parameters.Add("@idx6", System.Data.SqlDbType.Char).Value = ExpiryDate;
                                    cmd.Parameters.Add("@idx7", System.Data.SqlDbType.VarChar).Value = lvAmount;
                                    cmd.Parameters.Add("@idx22", System.Data.SqlDbType.VarChar).Value = lvAmount;
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
                                    cmd.Parameters.Add("@idx24", System.Data.SqlDbType.VarChar).Value = lvRemarks;
                                    cmd.Parameters.Add("@idx23", System.Data.SqlDbType.VarChar).Value = DueDay;
                                    cmd.Parameters.Add("@idx25", System.Data.SqlDbType.Char).Value = CommenceDate;
                                    cmd.Parameters.Add("@idx26", System.Data.SqlDbType.VarChar).Value = lvPolicyNum1;
                                    cmd.Parameters.Add("@idx27", System.Data.SqlDbType.VarChar).Value = lvPolicyNum2;
                                    cmd.Parameters.Add("@IceaBatchNumber", System.Data.SqlDbType.VarChar).Value = lvBatchNumber;
                                    cmd.Parameters.Add("@IceaStatus", System.Data.SqlDbType.VarChar).Value = iceaStatus;
                                    cmd.CommandType = System.Data.CommandType.Text;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    CsvUpload.Dispose();
                                   
                                    DisplaySuccess("Direct Debit has been imported to the database. ");

                                }
                                catch (Exception es)
                                {
                                    DisplayError("Could not connect to the database." + es);
                                }
                            }
                        }

                    }
                        
                    catch (Exception ex)
                    {
                        DisplayError("Could not import file selected." + ex);

                    }
                    oconn.Close();
                }
            }
            else
            {
                DisplayError("Please upload file to continue");

            }
           
            conn.Close();
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
 
        public void DisplayError(string errmsg)
        {
            Display.BackColor = System.Drawing.Color.Red;
            Display.ForeColor = System.Drawing.Color.White;
            Display.Text = errmsg;

        }

        public void DisplaySuccess(string errmsg)
        {
            Display.BackColor = System.Drawing.Color.Green;
            Display.ForeColor = System.Drawing.Color.White;
            Display.Text = errmsg;

        }
 public string GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 5; i++)
            {
                r += random.Next(0, 13).ToString();
            }
            return r;
        }

        public bool ValidateDate(string stringDateValue)
        {
            try
            {
                CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP");
                DateTime d = DateTime.ParseExact(stringDateValue, "yyyy/MM/dd", CultureInfoDateCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void MoveFiles(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            FileInfo[] Folder1Files = diSource.GetFiles();
            try
            {

                if (Folder1Files.Length > 0)
                {
                    foreach (FileInfo aFile in Folder1Files)
                    {
                        if (File.Exists(targetDirectory + aFile.Name))
                        {
                            File.Delete(targetDirectory + aFile.Name);
                        }
                        aFile.MoveTo(targetDirectory + aFile.Name);
                    }
                }
            }
            catch
            {

            }
        }



           
    }
}