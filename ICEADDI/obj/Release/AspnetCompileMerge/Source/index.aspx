<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ICEADDI.maker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Direct Debits Portal</title>
     <link rel="SHORTCUT ICON" href="Images/favicon.ico"/>
    <link  rel="stylesheet" href="css/style.css" type="text/css" />
    <link  rel="stylesheet" href="Content/bootstrap.css" type="text/css" />
</head>
<body style="font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif">
   
        <div>
           <div class="row">
               <div class="col-md-4">
                     <asp:Image ID="Image2" runat="server" Height="78px" ImageUrl="~/Images/NC logo.png" Width="97px" />
                     <asp:Image ID="Image3" runat="server" Height="78px" ImageUrl="~/Images/logoug.png" Width="97px" />
 
                    </div>
                <div class="col-md-8">
                                <asp:Image ID="Image1" runat="server" Height="78px" ImageUrl="~/Images/sybrin_logo.jpg" Width="97px" ImageAlign="Right" />

               </div>
           </div>
         </div>
    
        <div id="divider">    
        </div>

        <div class=" navbar navbar-default">        
            <ul class="nav nav-tabs">
              <li class="active"><a href="index.aspx">CREATE</a></li>
              <li class=""><a href="iceaMaker.aspx" >ICEA MAKER</a></li>
              <li><a href="iceaChecker.aspx" >ICEA CHECKER</a></li>
              <li><a href="IceaDuplicates.aspx">DUPLICATES</a></li>
              <li><a href="IceaAmtchanged.aspx">UPDATED</a></li>
              <li><a href="iceaApproved.aspx">APPROVED DEBITS</a></li>
              <li><a href="iceaDenied.aspx" >DENIED DEBITS</a></li>
              <li><a href="UserRegister.aspx" >USER MANAGEMENT</a></li>
              <li><a href="BankCodes.aspx">BANK CODES</a></li>
              <li><a href="ContactUs.aspx" >CONTACT US</a></li>
            </ul>
        </div>
            <form id="form1" runat="server">

                 <asp:Label ID="wlcmlbl" runat="server" Text="Label"></asp:Label> <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/default.aspx"/>  <br />
        <br />
                      <asp:Label ID="Display" runat="server" Text=""></asp:Label>
                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager> <br />
                 <div class="panel panel-primary" style="width:70%;padding:10px; height: 144px;" >
                    <div class="panel-heading">Multiple Mandates</div>
                
                
                       <div class="row">
                           <br />
                            <div class="col-xs-4">

                                <asp:FileUpload ID="CsvUpload" CssClass="form-control" runat="server" Height="37px" />                                         
                            </div>  
                             <div class="col-xs-4">  <asp:Button ID="CsvUploadBtn"  CssClass="btn btn-primary" runat="server" Text="Upload" Width="145px" OnClick="CsvUploadBtn_Click" />
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers> 
                                        <asp:PostBackTrigger ControlID="CsvUploadBtn" /> 
                                    </Triggers> 
                             </asp:UpdatePanel>
                       </div>
                     
                      <br />
                  </div>
                   

               <div class="panel panel-primary" hidden="hidden" style="width:70%;padding:10px" >
                 <div class="panel-heading">Single Mandate</div>
                     <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="Label1" runat="server" Text="Customer Bank"></asp:Label>
                                <asp:DropDownList ID="CustBank" runat="server" Width="214px"></asp:DropDownList>
                            </div>
                         <div class="col-md-4">
                             <asp:Label ID="Label2" runat="server" Text="Branch"></asp:Label>
                             <asp:DropDownList ID="CustBranch" runat="server"  Width="230px"></asp:DropDownList>
                         </div>

                         <div class="col-md-4">
                             <asp:Label ID="Label3" runat="server" Text="Acc. No"></asp:Label>
                             <asp:TextBox ID="AccNo" runat="server" Width="214px"></asp:TextBox>
                         </div>

                  </div>
                  <div class="row">
                         <div class="col-md-4">
                             <asp:Label ID="Label4" runat="server" Text="Commencement Date"></asp:Label> 
                            
                         </div>
                         <div class="col-md-4">
                             
                             <asp:Label ID="Label5" runat="server" Text="Expiry Date"></asp:Label>
                             <asp:TextBox ID="exptxt" runat="server"  Width="230px"></asp:TextBox>
                            
                         </div>

                         <div class="col-md-4">
                             <asp:Label ID="Label6" runat="server" Text="Due Day"></asp:Label>
                             <asp:DropDownList ID="DueDay" runat="server"  Width="214px"></asp:DropDownList>
                         </div>
                  </div>
                  <div class="row">
                         <div class="col-md-4">
                             <asp:Label ID="Label7" runat="server" Text="Frequency"></asp:Label> 
                             <asp:DropDownList ID="freq" runat="server"  Width="214px"></asp:DropDownList>   
                         </div>
                         <div class="col-md-4">
                             <asp:Label ID="Label8" runat="server" Text="Payment Type"></asp:Label>
                             <asp:DropDownList ID="paymenttype" runat="server"  Width="230px"></asp:DropDownList>
                         </div>

                         <div class="col-md-4">
                             <asp:Label ID="Label9" runat="server" Text="Currency"></asp:Label>
                             <asp:DropDownList ID="currency" runat="server"  Width="214px"></asp:DropDownList>
                         </div>

                  </div>

                  <div class="row">
                         <div class="col-md-4">
                             <asp:Label ID="Label10" runat="server" Text="Amount"></asp:Label>  
                             <asp:TextBox ID="Amttxt" runat="server"  Width="214px"></asp:TextBox> 
                         </div>
                         <div class="col-md-4">
                             <asp:Label ID="Label11" runat="server" Text="Batch Number"></asp:Label>
                             <asp:TextBox ID="batchtxt" runat="server" Width="230px"></asp:TextBox>
                         </div>

                         <div class="col-md-4">
                             <asp:Label ID="Label12" runat="server" Text="Remarks"></asp:Label>
                             <asp:TextBox ID="TextBox1" runat="server" Width="214px" TextMode="MultiLine"></asp:TextBox>
                         </div>

                  </div>
                  <div class="row">
                         <div class="col-md-16">
                             &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="createManBtn" CssClass="btn btn-primary" runat="server" Text="Create Single Mandate" />
                         </div>
                </div>
                   
              </div>

              <div class="panel panel-primary" style="width:70%;padding:10px" >
                 <div class="panel-heading">Originator Details</div>
                  <asp:Table runat="server" CssClass="table" >
                      <asp:TableRow>
                          <asp:TableCell>
                              <asp:Label ID="Label13" runat="server" Text="Originator Code"></asp:Label>
                                                        </asp:TableCell>
                          <asp:TableCell> 
                              <asp:TextBox ID="OrigCodeTxt" Text="<%$appSettings:OrigID%>" runat="server"></asp:TextBox>   
                          </asp:TableCell>
                          <asp:TableCell> 
                             <asp:Label ID="Label14" runat="server"  Text="Originator Name"></asp:Label>
                          </asp:TableCell>
                          <asp:TableCell>
                             <asp:TextBox ID="OrigNameTxt" Text="<%$appSettings:OrigName%>"  runat="server"></asp:TextBox>
                          </asp:TableCell>
                          <asp:TableCell>
                             <asp:Label ID="Label15" runat="server" Text="Originator Bank"></asp:Label>
                          </asp:TableCell>
                          <asp:TableCell>
                             <asp:TextBox ID="OrigBankTxt" Text="<%$appSettings:OrigBank%>"  runat="server"></asp:TextBox> 
                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell>
                             <asp:Label ID="Label16" runat="server" Text="Originator Branch"></asp:Label>
                          </asp:TableCell>
                          <asp:TableCell>
                             <asp:TextBox ID="BranchTxt" Text="<%$appSettings:OrigBranch%>"  runat="server"></asp:TextBox>
                          </asp:TableCell>
                          <asp:TableCell> 
                             <asp:Label ID="OrigAccLbl" runat="server" Text="Originator Account"></asp:Label>
                           </asp:TableCell>
                          <asp:TableCell>
                             <asp:TextBox ID="OrigAccTxt" Text="<%$appSettings:OrigAccount%>"  runat="server"></asp:TextBox>
                          </asp:TableCell>
                          <asp:TableCell> 

                          </asp:TableCell>
                          <asp:TableCell> 

                          </asp:TableCell>
                      </asp:TableRow>
                      <asp:TableRow>
                          <asp:TableCell> </asp:TableCell><asp:TableCell> </asp:TableCell><asp:TableCell> </asp:TableCell>
                          <asp:TableCell> </asp:TableCell><asp:TableCell> </asp:TableCell>
                          <asp:TableCell> </asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>
              </div>
           </form>


</body>
</html>
