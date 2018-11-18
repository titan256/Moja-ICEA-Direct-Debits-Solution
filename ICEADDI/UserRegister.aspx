<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="ICEADDI.UserRegister" %>
<%@ Import Namespace="System.Web.Security" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

public void CreateUser_OnClick(object sender, EventArgs args)
{
  // Create new user and retrieve create status result.

  MembershipCreateStatus status;
  string passwordQuestion =null;
  string passwordAnswer = null;

  if (Membership.RequiresQuestionAndAnswer)
  {
    passwordQuestion = PasswordQuestionTextbox.Text;
    passwordAnswer = PasswordAnswerTextbox.Text;
  }

  try
  {
    MembershipUser newUser = Membership.CreateUser(UsernameTextbox.Text, PasswordTextbox.Text, 
                                                   EmailTextbox.Text, passwordQuestion,
                                                   passwordAnswer, true, out status);
    if (newUser == null)
    {
      Msg.Text = GetErrorMessage(status);
    }
    else
    {
      //Response.Redirect("login.aspx");
        Msg.Text = "User created successfully";
    }
  }
  catch
  {
    Msg.Text = "An exception occurred creating the user.";
  }
}

public string GetErrorMessage(MembershipCreateStatus status)
{
   switch (status)
   {
      case MembershipCreateStatus.DuplicateUserName:
        return "Username already exists. Please enter a different user name.";

      case MembershipCreateStatus.DuplicateEmail:
        return "A username for that e-mail address already exists. Please enter a different e-mail address.";

      case MembershipCreateStatus.InvalidPassword:
        return "The password provided is invalid. Please enter a valid password value.";

      case MembershipCreateStatus.InvalidEmail:
        return "The e-mail address provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidAnswer:
        return "The password retrieval answer provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidQuestion:
        return "The password retrieval question provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.InvalidUserName:
        return "The user name provided is invalid. Please check the value and try again.";

      case MembershipCreateStatus.ProviderError:
        return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

      case MembershipCreateStatus.UserRejected:
        return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

      default:
        return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
   }
}

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
      
                 <div class="panel panel-primary" style="width:70%;padding:10px;" >
                    <div class="panel-heading">Register User</div>              
                 <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />

  <table class="table table-striped">
    <tr>
      <td>Username:</td>
      <td><asp:Textbox id="UsernameTextbox" runat="server" Height="23px" Width="252px"/></td>
      <td><asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                      ControlToValidate="UserNameTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Password:</td>
      <td><asp:Textbox id="PasswordTextbox" runat="server" TextMode="Password" Height="23px" Width="252px" /></td>
      <td><asp:RequiredFieldValidator id="PasswordRequiredValidator" runat="server"
                                      ControlToValidate="PasswordTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Confirm Password:</td>
      <td><asp:Textbox id="PasswordConfirmTextbox" runat="server" TextMode="Password" Height="23px" Width="252px" /></td>
      <td><asp:RequiredFieldValidator id="PasswordConfirmRequiredValidator" runat="server"
                                      ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" />
          <asp:CompareValidator id="PasswordConfirmCompareValidator" runat="server"
                                      ControlToValidate="PasswordConfirmTextbox" ForeColor="red"
                                      Display="Static" ControlToCompare="PasswordTextBox"
                                      ErrorMessage="Confirm password must match password." />
      </td>
    </tr>
    <tr>
      <td>Email Address:</td>
      <td><asp:Textbox id="EmailTextbox" runat="server" Height="23px" Width="252px" /></td>
      <td><asp:RequiredFieldValidator id="EmailRequiredValidator" runat="server"
                                      ControlToValidate="EmailTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>


<% if (Membership.RequiresQuestionAndAnswer) { %>

    <tr>
      <td>Password Question:</td>
      <td><asp:Textbox id="PasswordQuestionTextbox" runat="server" Height="23px" Width="252px"/></td>
      <td><asp:RequiredFieldValidator id="PasswordQuestionRequiredValidator" runat="server"
                                      ControlToValidate="PasswordQuestionTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>
    <tr>
      <td>Password Answer:</td>
      <td><asp:Textbox id="PasswordAnswerTextbox" runat="server" Height="23px" Width="252px" /></td>
      <td><asp:RequiredFieldValidator id="PasswordAnswerRequiredValidator" runat="server"
                                      ControlToValidate="PasswordAnswerTextbox" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" /></td>
    </tr>

<% } %>


    <tr>
      <td></td>
      <td><asp:Button id="CreateUserButton" Text="Create User" OnClick="CreateUser_OnClick" runat="server" CssClass="btn-primary"  /></td>
    </tr>
  </table>
                 </div>
    </form>
</body>
</html>
