<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_FDJinchuhuo.aspx.cs" Inherits="JCSJGL.Page_FDJinchuhuo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>进出货记录</title>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div><label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList></div>
        <div><label>发生日期</label><asp:TextBox CssClass="middle" runat="server" ID="txb_fsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" runat="server" ID="txb_fsrq_end"></asp:TextBox></div>
        <div><label>上报日期</label><asp:TextBox CssClass="middle" runat="server" ID="txb_sbrq_start"></asp:TextBox><asp:TextBox CssClass="middle" runat="server" ID="txb_sbrq_end"></asp:TextBox></div>
        <div><asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" /></div>
    </div>
    <asp:GridView ID="grid_jinchu" runat="server" AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="true" PageSize="20" 
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grid_jinchu_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="fangxiang" HeaderText="方向"></asp:BoundField>
            <asp:BoundField DataField="lyqx" HeaderText="来源去向"></asp:BoundField>
            <asp:BoundField DataField="jianshu" HeaderText="件数"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="fashengshijian" HeaderText="发生时间"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="Page_FDJinchuhuoMX.aspx?id={0}" Text="查看" HeaderText="查看明细"></asp:HyperLinkField>
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
