<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankCodes.aspx.cs" Inherits="ICEADDI.BankCodes" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
     <title>Direct Debits Portal</title>
     <link rel="SHORTCUT ICON" href="Images/favicon.ico"/>
     <link  rel="stylesheet" href="css/style.css" type="text/css" />
     <link  rel="stylesheet" href="Content/bootstrap.css" type="text/css" />
</head>
<body style="font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif">
    <asp:Panel runat="server" ID="authPanel" Visible="False">
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
   <div class="panel panel-primary" style="width:100%" >
         <div class="panel-heading">Bank Codes</div>
        <asp:GridView ID="DeniedGrid" CssClass="table table-hover table-striped" DataSourceID="readers" runat="server"  AutoGenerateColumns="True" >
       </asp:GridView>
        <asp:SqlDataSource runat="server" ID="readers" ConnectionString="<%$ConnectionStrings:ICEA %>" 
                 SelectCommand="select * from BankBranchView">

        </asp:SqlDataSource>
        <asp:Label ID="Display" runat="server" Width="100%" ></asp:Label>
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