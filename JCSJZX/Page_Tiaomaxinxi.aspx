<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Tiaomaxinxi.aspx.cs" Inherits="JCSJZX.Page_Tiaomaxinxi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>条码信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:GridView ID="gdv_tiaoma" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

        <Columns>
            <asp:BoundField HeaderText="ID" DataField="id"></asp:BoundField>
            <asp:BoundField HeaderText="条码" DataField="tiaoma"></asp:BoundField>
            <asp:BoundField HeaderText="款号" DataField="kuanhao"></asp:BoundField>
            <asp:BoundField HeaderText="供应商款号" DataField="gyskuanhao"></asp:BoundField>
            <asp:BoundField HeaderText="类型" DataField="leixing"></asp:BoundField>
            <asp:BoundField HeaderText="品名" DataField="pinming"></asp:BoundField>
            <asp:BoundField HeaderText="颜色" DataField="yanse"></asp:BoundField>
            <asp:BoundField HeaderText="尺码" DataField="chima"></asp:BoundField>
            <asp:BoundField HeaderText="进价" DataField="jinjia"></asp:BoundField>
            <asp:BoundField HeaderText="售价" DataField="shoujia"></asp:BoundField>
            <asp:BoundField HeaderText="买手" DataField="maishou"></asp:BoundField>
            <asp:BoundField HeaderText="备注" DataField="beizhu"></asp:BoundField>
            <asp:BoundField HeaderText="编码人" DataField="caozuoren"></asp:BoundField>
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
