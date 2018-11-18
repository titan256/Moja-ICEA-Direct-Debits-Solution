<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ICEADDI.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Direct Debits Portal</title>
     <link rel="SHORTCUT ICON" href="Images/favicon.ico"/>
    <link  rel="stylesheet" href="css/style.css" type="text/css" />
    <link  rel="stylesheet" href="Content/bootstrap.css" type="text/css" />
</head>
<body>

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
<asp:Panel runat="server" ID="authPanel" Visible="False">
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
              
            </ul>
        </div>

    <form id="form1" runat="server">
    <div style="font-family:Trebuchet MS">
    
        <asp:Label ID="wlcmlbl" runat="server" Text="Label"></asp:Label> <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/default.aspx"/>  <br />
        <br />
        User Guide<br />
        <asp:Table ID="Table1" runat="server" CssClass="table table-striped ">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Create</asp:TableCell>
                <asp:TableCell runat="server">Create a New Mandate or upload CSV mandates</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server">Maker</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">Analyses Mandates and Removes unwanted mandates from system</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell ID="TableCell3" runat="server">Checker</asp:TableCell>
                <asp:TableCell ID="TableCell4" runat="server">Edits, Analyses and approves mandates</asp:TableCell>
            </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell ID="TableCell5" runat="server">Approved Debit</asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server">Edits, Analyses and send mandates to the bank</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Label ID="disp" runat="server" Text="Label"></asp:Label>
  
    </div>
    </form>
</asp:Panel>
<asp:Panel runat="server" ID="AnonPanel">
  <form id="form2" runat="server"> 
    <asp:Label ID="disp2" runat="server" Text="Label"></asp:Label>
    <asp:LoginStatus ID="LoginStatus2" runat="server"  LogoutText="Log Out" />
  </form>
</asp:Panel>
</body>
</html>
