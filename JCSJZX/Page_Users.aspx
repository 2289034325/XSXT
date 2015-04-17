<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Users.aspx.cs" Inherits="JCSJZX.Page_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>系统用户</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:GridView ID="grid_users" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField HeaderText="ID" DataField="id"></asp:BoundField>
            <asp:BoundField HeaderText="登录名" DataField="dengluming"></asp:BoundField>
            <asp:BoundField HeaderText="用户名" DataField="yonghuming"></asp:BoundField>
            <asp:BoundField HeaderText="角色" DataField="juese"></asp:BoundField>
            <asp:BoundField HeaderText="状态" DataField="zhuangtai"></asp:BoundField>
            <asp:BoundField HeaderText="备注" DataField="beizhu"></asp:BoundField>
            <asp:BoundField HeaderText="插入时间" DataField="charushijian"></asp:BoundField>
            <asp:BoundField HeaderText="修改时间" DataField="xiugaishijian"></asp:BoundField>
        </Columns>

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
    </asp:GridView>
</asp:Content>
