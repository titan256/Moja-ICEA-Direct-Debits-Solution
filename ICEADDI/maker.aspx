<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="maker.aspx.cs" Inherits="ICEADDI.maker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Direct Debits Portal</title>
     <link rel="SHORTCUT ICON" href="Images/favicon.ico"/>
    <link  rel="stylesheet" href="css/style.css" type="text/css" />
    <link  rel="stylesheet" href="Content/bootstrap.css" type="text/css" />
</head>
<body>

    <div>
    
        <asp:Image ID="Image1" runat="server" Height="78px" ImageUrl="~/Images/sybrin_logo.jpg" Width="97px" />
    
    </div>

        <div id="divider">
            
        </div>
        <div class=" navbar navbar-default">
            
            <ul class="nav navbar-nav">
              <li class=""><a href="maker.aspx" class="list-group-item list-group-item-success">CREATE</a></li>
                <li class=""><a href="maker.aspx" >ICEA MAKER</a></li>
              <li><a href="#" class="list-group-item list-group-item-info">ICEA CHECKER</a></li>
              <li><a href="#">Approved</a></li>
               <li><a href="#" class="list-group-item list-group-item-danger">Deleted</a></li>
            </ul>

         
        </div>
    <form id="form1" runat="server">
            <div class="panel panel-default">
          <div class="panel-heading">
            <h3 class="panel-title">Upload Direct Debits</h3>
          </div>
          <div class="panel-body">
              <asp:FileUpload ID="CsvUpload" class="form-control" runat="server" />
              
              <br />
              
              <asp:Button ID="CsvUploadBtn" class="btn btn-success" runat="server" Text="Upload" Width="145px" OnClick="CsvUploadBtn_Click" />
              <br />
              <br />
              <asp:Label ID="Display" runat="server" Text=""></asp:Label>
              <br />
          </div>
      </div>
    </form>

</body>
</html>
