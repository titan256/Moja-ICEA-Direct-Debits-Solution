<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="ICEADDI.ContactUs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Direct Debits Portal</title>
     <link rel="SHORTCUT ICON" href="Images/favicon.ico"/>
    <link  rel="stylesheet" href="css/style.css" type="text/css" />
    <link  rel="stylesheet" href="Content/bootstrap.css" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 285px;
        }
    </style>
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
      
                 <div class="panel panel-primary" style="width:70%;padding:10px;" >
                    <div class="panel-heading">Contact Us</div>              
                 <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <table class="table table-striped">
    <tr>
      <td class="auto-style1">Helpdesk Telephone</td>
      <td><span lang="EN-ZA">&nbsp;+27 11 367 6901 </span>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">Helpdesk Email</td>
      <td>Helpdesk@sybrin.co.za</td>
    </tr>
    <tr>
      <td class="auto-style1">Sybrin Support Mobile</td>
      <td><span lang="EN-ZA">+256 793 448 846</span></td>
    </tr>


    <tr>
      <td class="auto-style1">Sybrin Support Email</td>
      <td>eseza.muwanga@sybrin.com</td>
    </tr>
    </table>
                 </div>
    </form>
</body>
</html>
