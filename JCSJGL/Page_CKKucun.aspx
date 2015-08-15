<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_CKKucun.aspx.cs" Inherits="JCSJGL.Page_CKKucun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>仓库库存记录</title>
    <script type="text/javascript">
        //function Delete(id)
        //{
        //    $("#hid_opt").val("DELETE");
        //    $("#hid_id").val(id);
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <%--<asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />--%>
    <%--<asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />--%>
    <div id="div_sch" class="div_sch">
        <div><label>仓库</label><asp:DropDownList runat="server" ID="cmb_ck"></asp:DropDownList></div>
        <div><asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" /></div>
    </div>
    <asp:GridView ID="grid_kc_total" runat="server" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>
        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <asp:GridView ID="grid_kc_ck" runat="server" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="ckid" HeaderText="仓库ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="cangku" HeaderText="仓库"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="ckid" DataNavigateUrlFormatString="Page_CKKucun.aspx?ckid={0}" Text="查看" HeaderText="历史库存"></asp:HyperLinkField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>
        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <asp:GridView ID="grid_kc" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grid_kc_RowDeleting"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="cangku" HeaderText="仓库"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Page_CKKucunMX.aspx?id={0}" Text="查看" HeaderText="查看明细"></asp:HyperLinkField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_delete" runat="server" OnClientClick="return confirm('确定删除吗?')" Text="刪除" CommandName="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>
        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
    </asp:GridView>

</asp:Content>
