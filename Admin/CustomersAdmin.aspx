<%@ Page Title="Store Front - Customers Admin" Language="C#" AutoEventWireup="true" CodeBehind="CustomersAdmin.aspx.cs" Inherits="Store_Front.Admin.CustomersAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Controllers/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="PageWrapper">
     <form id="form1" runat="server">
        <div id="Header">Store Front - Customers Admin </div>
         <div id="Menu"> <a href="../Default.aspx">Store Front - Home</a>&nbsp;&nbsp;&nbsp;&nbsp;|
             &nbsp;&nbsp;&nbsp;&nbsp;<a href="CustomersAdmin.aspx">Store Front - Customers Admin</a>&nbsp;&nbsp;&nbsp;&nbsp;
             |&nbsp;&nbsp;&nbsp;&nbsp;<a href="ProductsAdmin.aspx">Store Front - Products Admin</a></div>

         
         <p>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" AutoGenerateEditButton="True" OnRowEditing="GridView1_RowEditing" BorderColor="#999999">
             <Columns>
                 <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
                 <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                 <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
             </Columns>
         </asp:GridView>
        </p>
         <p>
         <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px" BorderColor="#999999" Caption="Add New User" CaptionAlign="Top">
             <Fields>
                 <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                 <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
                 <asp:CommandField ShowInsertButton="True" />
             </Fields>
         </asp:DetailsView>
         </p>
         <asp:SqlDataSource ID="spAddUser" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" InsertCommand="spAddUser" InsertCommandType="StoredProcedure" SelectCommand="spGetUsers" SelectCommandType="StoredProcedure">
             <InsertParameters>
                 <asp:Parameter Name="UserName" Type="String" />
                 <asp:Parameter Name="EmailAddress" Type="String" />
             </InsertParameters>
         </asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" InsertCommand="spAddUser" InsertCommandType="StoredProcedure" SelectCommand="spGetUsers" SelectCommandType="StoredProcedure">
             <InsertParameters>
                 <asp:Parameter Name="UserName" Type="String" />
                 <asp:Parameter Name="EmailAddress" Type="String" />
             </InsertParameters>
         </asp:SqlDataSource>

         

        </form>
    </div>
</body>
</html>
