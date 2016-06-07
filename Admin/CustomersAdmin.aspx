<%@ Page Title="Store Front- Customers Admin" Language="C#" AutoEventWireup="true" CodeBehind="CustomersAdmin.aspx.cs" MasterPageFile="Admin.Master" Inherits="Store_Front.Admin.CustomersAdmin" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">Store Front - Customers Admin </asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="UserID" DataSourceID="SqlDataSource1" AutoGenerateEditButton="True" OnRowEditing="GridView1_RowEditing" BorderColor="#999999" PageSize="50">
        <AlternatingRowStyle BackColor="#E9E9E9" />
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="UserID" InsertVisible="False" ReadOnly="True" SortExpression="UserID" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
        </Columns>
        <HeaderStyle  Font-Size="Large" ForeColor="Black" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" InsertCommand="spAddUser" InsertCommandType="StoredProcedure" SelectCommand="spGetUsers" SelectCommandType="StoredProcedure">
        <InsertParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="EmailAddress" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Side" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CssClass="table table-striped table-bordered table-condensed" DataKeyNames="UserID" DataSourceID="spAddUser" DefaultMode="Insert" Height="50px" Width="125px" BorderColor="#999999" Caption="Add New User" CaptionAlign="Top" OnItemInserted="DetailsView1_ItemInserted">
        <Fields>
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="EmailAddress" HeaderText="EmailAddress" SortExpression="EmailAddress" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="spAddUser" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" InsertCommand="spAddUser" InsertCommandType="StoredProcedure" SelectCommand="spGetUsers" SelectCommandType="StoredProcedure">
        <InsertParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="EmailAddress" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>





