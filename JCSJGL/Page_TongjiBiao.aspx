<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_TongjiBiao.aspx.cs" Inherits="JCSJGL.Page_TongjiBiao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>统计表</title>
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div>
            <label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList>
        </div>
        <div>
            <label>销售日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_xsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_xsrq_end"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_xiaoshou" runat="server" AutoGenerateColumns="False" OnRowCommand="grid_xiaoshou_RowCommand"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <%--<asp:BoundField DataField="rq" HeaderText="日期"></asp:BoundField>
            <asp:BoundField DataField="fd" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="xl" HeaderText="销售数量"></asp:BoundField>
            <asp:BoundField DataField="xse" HeaderText="销售额"></asp:BoundField>
            <asp:BoundField DataField="lr" HeaderText="利润"></asp:BoundField>--%>
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
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>

</asp:Content>
