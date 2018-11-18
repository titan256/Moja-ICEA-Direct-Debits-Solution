﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iceaChecker.aspx.cs" Inherits="ICEADDI.WebForm2" %>

<!DOCTYPE html>

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
         <div class="panel-heading">CHECKER</div>
        <asp:GridView ID="CheckerGrid" CssClass="table table-hover table-striped" DataSourceID="readers" autogeneratecolumns="false" autogenerateeditbutton="true" OnRowEditing="CheckerGrid_RowEditing" OnRowUpdating="CheckerGrid_RowUpdating" OnRowCommand="FireRowCommand"  DataKeyNames="idx26" runat="server" Width="">
           <Columns>
              <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton ID="btnArchived" runat="server" CommandArgument='<%# Eval("idx26") %>'
                            CommandName ="MarkAsArchived" Text="Archive" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:LinkButton ID="btnApprove" runat="server" CommandArgument='<%# Eval("idx26") %>'
                            CommandName ="MarkAsApproved" Text="Approve" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:LinkButton ID="btnDeny" runat="server" CommandArgument='<%# Eval("idx26") %>'
                            CommandName ="MarkAsDenied" Text="Deny" />
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="idx26" HeaderText="Policy ID" ReadOnly="true" />
                <asp:BoundField DataField="IceaBatchNumber" HeaderText="Batch Number" ReadOnly="true" />
                <asp:TemplateField HeaderText="Customer Name">
                    <ItemTemplate>
                        <%#Eval("idx24") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="origbank" Text='<%#Eval("idx24") %>'
                             runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Customer Account (CR)">
                    <ItemTemplate>
                        <%#Eval("idx13") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                         <asp:TextBox ID="origacc" Text='<%#Eval("idx13") %>'
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

                <asp:TemplateField HeaderText="Customer Bank">
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
                 SelectCommand="select  * from  eftDDInstructICEA where iceastatus='CHECKER'"
                 UpdateCommand="update eftDDInstructICEA set idx5=@idx5,idx13=@idx13, idx6=@idx6,idx7=@idx7,idx8=@idx8,idx9=@idx9,idx24=@idx24,idx23=@idx23 where ( eftDDInstructICEA.idx26=@idx26)">

             </asp:SqlDataSource>
        <asp:Label ID="Display" runat="server" Width="100%" ></asp:Label>
    </div>
  
     <div class="panel panel-default">
         <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Justify" Width="400px">
             <asp:TableRow>
                 <asp:TableCell>
                     <asp:TextBox ID="txtBatchNumber" runat="server"></asp:TextBox>
                 </asp:TableCell>
                 <asp:TableCell>
                     <asp:Button ID="cmdApproveBatch" OnClick="cmdApproveBatch_Click" runat="server"  CssClass="btn btn-success" Text="Approve Batch" />
                 </asp:TableCell>
                  <asp:TableCell>
                     <asp:Button ID="cmdApproveAll" OnClick="cmdApproveAll_Click" runat="server"   CssClass="btn btn-success" Text="Approve All" />
                 </asp:TableCell>
                 
             </asp:TableRow>
                          <asp:TableRow>
                 <asp:TableCell>
                     <asp:TextBox ID="txtBatchDeny" runat="server"></asp:TextBox>
                 </asp:TableCell>
                 <asp:TableCell>
                     <asp:Button ID="cmdDenyBatch" OnClick="cmdDenyBatch_Click" runat="server" CssClass="btn btn-danger" Text="Decline Batch" />
                 </asp:TableCell>
                  <asp:TableCell>
                     <asp:Button ID="cmdDeleteAll" OnClick="cmdDeleteAll_Click" runat="server" CssClass="btn btn-danger" Text="Decline All" />
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
