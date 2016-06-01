<%@ Page Title="Store Front - Customer Admin - Details" Language="C#" AutoEventWireup="true" CodeBehind="CustomerAdminDetails.aspx.cs" Inherits="Store_Front.Admin.CustomerAdminDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Controllers/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <div id="PageWrapper">
     <form id="form1" runat="server">
        <div id="Header">Store Front - Customers Admin - Details
        </div>
    
        <p>
         <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" Height="50px" Width="316px"  OnItemUpdated="DetailsView1_ItemUpdated" OnItemDeleted="DetailsView1_ItemDeleted">
             <Fields>
                 <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                 <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                 <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
                 <asp:CheckBoxField DataField="IsAdmin" HeaderText="IsAdmin" ReadOnly="True" />
                 <asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated" ReadOnly="True" />
                 <asp:BoundField DataField="CreatedBy" HeaderText="CreatedBy" SortExpression="CreatedBy" ReadOnly="True" />
                 <asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified" ReadOnly="True" />
                 <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy" SortExpression="ModifiedBy" ReadOnly="True" />
                 <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowCancelButton="True" />
             </Fields>
         </asp:DetailsView>
        </p>

         <p>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="AddressID" DataSourceID="spGetUserAddressesSource" PageSize="50">
             <Columns>
                 <asp:BoundField DataField="AddressID" HeaderText="AddressID" InsertVisible="False" ReadOnly="True" SortExpression="AddressID" />
                 <asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="Address1" />
                 <asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="Address2" />
                 <asp:BoundField DataField="Address3" HeaderText="Address3" SortExpression="Address3" />
                 <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                 <asp:BoundField DataField="StateName" HeaderText="StateName" SortExpression="StateName" />
                 <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                 <asp:TemplateField HeaderText="IsBilling" SortExpression="IsBilling">
                     <ItemTemplate>
                         <asp:Label ID="BillingLabel" runat="server" Text='<%# GetBooleanText(Eval("IsBilling")) %>' Enabled="false" />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="IsShipping" SortExpression="IsShipping">
                     <ItemTemplate>
                         <asp:Label ID="ShippingLabel" runat="server" Text='<%# GetBooleanText(Eval("IsShipping")) %>' Enabled="false" />
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>
         </asp:GridView>
        </p>
         <asp:SqlDataSource ID="spGetUserAddressesSource" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" SelectCommand="spGetUserAddresses" SelectCommandType="StoredProcedure">
             <SelectParameters>
                 <asp:QueryStringParameter Name="UserID" QueryStringField="UserID" Type="Int32" />
             </SelectParameters>
         </asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" DeleteCommand="spDeleteUser" DeleteCommandType="StoredProcedure" SelectCommand="spGetUser" SelectCommandType="StoredProcedure" UpdateCommand="spUpdateUser" UpdateCommandType="StoredProcedure">
             <DeleteParameters>
                 <asp:Parameter Name="UserID" Type="Int32" />
             </DeleteParameters>
             <SelectParameters>
                 <asp:QueryStringParameter Name="UserID" QueryStringField="UserID" Type="Int32" />
             </SelectParameters>
             <UpdateParameters>
                 <asp:Parameter Name="UserID" Type="Int32" />
                 <asp:Parameter Name="UserName" Type="String" />
                 <asp:Parameter Name="EmailAddress" Type="String" />
             </UpdateParameters>
         </asp:SqlDataSource>
    
  
    </form>
  </div>
</body>
</html>
