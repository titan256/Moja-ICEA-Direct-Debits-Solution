<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iceaApproved.aspx.cs" Inherits="ICEADDI.WebForm3" %>

<!DOCTYPE html>
<script runat="server">

    protected void ApprovedGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void ApprovedGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
         <div class="panel-heading">APPROVED DEBITS</div>
        <asp:GridView ID="ApprovedGrid" DataSourceID="readers" DataKeyNames="idx26" runat="server" Width="" autogeneratecolumns="false" OnRowEditing="ApprovedGrid_RowEditing" OnRowUpdating="ApprovedGrid_RowUpdating" OnRowDeleting="ApprovedGrid_RowDeleting" OnRowCommand="FireRowCommand"  CssClass="table table-hover table-striped"  >
           <Columns>
              <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:LinkButton ID="btnArchived" runat="server" CommandArgument='<%# Eval("idx26") %>'
                            CommandName ="MarkAsArchived" Text="Archive" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:LinkButton ID="btnDeny" runat="server" CommandArgument='<%# Eval("idx26") %>'
                            CommandName ="MarkAsDenied" Text="Checker" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="idx26" HeaderText="Policy ID" ReadOnly="true" />
                <asp:BoundField DataField="IceaBatchNumber" HeaderText="Batch Number" ReadOnly="true" />

                <asp:TemplateField HeaderText="Originator Bank(CR)">
                    <ItemTemplate>
                        <%#Eval("idx2") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="origbank" Text='<%#Eval("idx2") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Originator Account (CR)">
                    <ItemTemplate>
                        <%#Eval("idx4") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="origacc" Text='<%#Eval("idx4") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Amount Limit(CR)">
                    <ItemTemplate>
                        <%#Eval("idx7") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="amt" Text='<%#Eval("idx7") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Commencement Date">
                    <ItemTemplate>
                        <%#Eval("idx5") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="cdate" Text='<%#Eval("idx5") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Expiry Date">
                    <ItemTemplate>
                        <%#Eval("idx6") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="expdate" Text='<%#Eval("idx6") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Creation Date">
                    <ItemTemplate>
                        <%#Eval("idx8") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="credate" Text='<%#Eval("idx8") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Frequency">
                    <ItemTemplate>
                        <%#Eval("idx9") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="fq" Text='<%#Eval("idx9") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Payer Bank">
                    <ItemTemplate>
                        <%#Eval("idx11") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="pbank" Text='<%#Eval("idx11") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <%#Eval("IceaStatus") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="stat" Text='<%#Eval("IceaStatus") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Due Day">
                    <ItemTemplate>
                        <%#Eval("idx23") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="ddue" Text='<%#Eval("idx23") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource runat="server" ID="readers" ConnectionString="<%$ConnectionStrings:ICEA %>" 
                 SelectCommand="select idx2 ,idx4 , idx5 ,idx6 ,idx7,idx8,idx9 ,idx11,idx13,idx15 ,idx23 ,idx26,IceaBatchNumber , IceaStatus from eftDDInstructICEA where iceastatus='APPROVED'"
                 UpdateCommand="update eftDDInstructICEA set idx5=@idx5,idx2=@idx2,idx4=@idx4, idx6=@idx6,idx7=@idx7,idx8=@idx8,idx9=@idx9,idx11=@idx11,idx23=@idx23 where ( eftDDInstructICEA.idx26=@idx26)">

        </asp:SqlDataSource>
        <asp:Label ID="Display" runat="server" Width="100%" ></asp:Label>
    </div>
  
     <div class="panel panel-default">
         <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Justify" Width="400px">
             <asp:TableRow>

                  <asp:TableCell>
                     <asp:Button ID="cmdApproveAll" OnClick="cmdApproveAll_Click" runat="server"   CssClass="btn btn-success" Text="Update All" />
                 </asp:TableCell>
              </asp:TableRow>   

         </asp:Table>
         
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
