<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_CKKucun.aspx.cs" Inherits="JCSJGL.Page_CKKucun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>仓库库存记录</title>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_pps" runat="server">
            <label>品牌商</label><asp:DropDownList runat="server" ID="cmb_pps" AutoPostBack="true" OnSelectedIndexChanged="cmb_pps_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <label>仓库</label><asp:DropDownList runat="server" ID="cmb_ck"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_kc" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_kc_RowCommand">
        <Columns>
            <asp:BoundField DataField="pinpaishang" HeaderText="品牌商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="cangku" HeaderText="仓库"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>             
            <asp:ButtonField CommandName="MX" Text="查看" ButtonType="Button" HeaderText="明细" />    
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grid_mx" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="gyskuanhao" HeaderText="供应商款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="jinjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="shoujia" HeaderText="售价"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
            <asp:BoundField DataField="jinhuoriqi" HeaderText="进货日期"></asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
