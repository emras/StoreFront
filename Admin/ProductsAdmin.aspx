<%@ Page Title="Store Front- Products Admin" Language="C#" AutoEventWireup="true" CodeBehind="ProductsAdmin.aspx.cs" MasterPageFile="Admin.Master" Inherits="Store_Front.Admin.ProductsAdmin" %>

    <asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
            Store Front - Products Admin
</asp:Content>

 <asp:Content ID="Body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" Height="250px" OnRowEditing="GridView1_RowEditing" PageSize="50">
            <AlternatingRowStyle BackColor="#E9E9E9" />
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
            <HeaderStyle ForeColor="Black" Font-Size="Large"/>
  
        </asp:GridView>
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
       </asp:Content>
   <asp:Content ID="Side" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="ProductID" DataSourceID="SqlDataSource2" DefaultMode="Insert" Height="50px" Width="242px" OnItemInserted="DetailsView1_ItemInserted" style="margin-left: 135px" Font-Size="Medium" GridLines="Horizontal" HeaderText="Add New Product">
            <Fields>
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:CheckBoxField DataField="IsPublished" HeaderText="IsPublished" SortExpression="IsPublished" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"  />
                <asp:CommandField ShowInsertButton="True" />
            </Fields>
            <HeaderStyle HorizontalAlign="Center" Font-Size="Large"/>
            <InsertRowStyle BackColor="White" />
        </asp:DetailsView>
                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:StoreFrontConnectionString %>" InsertCommand="spAddProduct" InsertCommandType="StoredProcedure" SelectCommand="spGetProducts" SelectCommandType="StoredProcedure" UpdateCommand="spUpdateProduct" UpdateCommandType="StoredProcedure">
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
     </asp:Content>

    
