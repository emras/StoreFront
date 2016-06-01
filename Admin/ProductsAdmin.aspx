<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsAdmin.aspx.cs" Inherits="Store_Front.Admin.ProductsAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Store Front - Products Admin</title>
    <link href="../Controllers/Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id ="PageWrapper">
        <div id="Header">Store Front - Products Admin</div>
        <div id="Menu"> <a href="../Default.aspx">Store Front - Home</a>&nbsp;&nbsp;&nbsp;&nbsp;|
             &nbsp;&nbsp;&nbsp;&nbsp;<a href="CustomersAdmin.aspx">Store Front - Customers Admin</a>&nbsp;&nbsp;&nbsp;&nbsp;
             |&nbsp;&nbsp;&nbsp;&nbsp;<a href="ProductsAdmin.aspx">Store Front - Products Admin</a></div>
    
        <p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" Height="250px" OnRowEditing="GridView1_RowEditing" PageSize="50" Width="834px">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:TemplateField HeaderText="IsPublished" SortExpression="IsPublished">
                    <ItemTemplate>
                        <asp:Label ID="PublishedLabel" runat="server" Text='<%# GetBooleanText(Eval("IsPublished"))%>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" DataFormatString="{0:c}" />
            </Columns>
        </asp:GridView>
        </p>
        <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="186px" Caption="Add New Product">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CheckBoxField DataField="IsPublished" HeaderText="IsPublished" SortExpression="IsPublished" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"  />
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
        </asp:DetailsView>
        </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" InsertCommand="spAddProduct" InsertCommandType="StoredProcedure" SelectCommand="spGetProducts" SelectCommandType="StoredProcedure" UpdateCommand="spUpdateProduct" UpdateCommandType="StoredProcedure">
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="IsPublished" Type="Boolean" />
                <asp:Parameter Name="Price" Type="Decimal" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="false" Name="PublishedOnly" Type="Boolean" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductID" Type="Int32" />
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="IsPublished" Type="Boolean" />
                <asp:Parameter Name="Price" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
