<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ICEADDI.Icealogin" %>


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

        <p>
            <br />
        </p>

      <form id="form1" runat="server">
           <div class="row">
               <div class="col-md-1">
                 
                     <asp:Label ID="Label1" runat="server" Text="USERNAME:"></asp:Label>
                   </div>
               <div class="col-md-2">

                   <asp:TextBox ID="UserName" runat="server" Width="207px"></asp:TextBox>                
                   <br />
               </div>
         </div>
           <br />
         <div class="row">
               <div class="col-md-1">
                   <asp:Label ID="Label2" runat="server" Text="PASSWORD:"></asp:Label>
                   </div>
               <div class="col-md-2">
                   <asp:TextBox ID="Password" TextMode="Password" runat="server" Width="207px"></asp:TextBox>
                   </div>
        </div>
           <br />
        <div class="row" id="LoginBtn">
               <div class="col-md-4">
                   <asp:Button ID="SbtBtn" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="SbtBtn_Click" />
                   <br />
                   </div>
        </div>
        <div class="row"  id="Div1">
              
               <div class="col-md-4" style="text-align:left;">
                   <asp:Label ID="Display" runat="server" Visible="False" ForeColor="Red">Invalid Username and Password.</asp:Label>
               </div>
        </div>

    </form>

    </body>
</html>
