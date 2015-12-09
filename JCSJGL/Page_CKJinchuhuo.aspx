<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_CKJinchuhuo.aspx.cs" Inherits="JCSJGL.Page_CKJinchuhuo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>仓库进出货记录</title>
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
            <label>批次码</label><asp:TextBox CssClass="short" runat="server" ID="txb_pcm"></asp:TextBox>
        </div>
        <div>
            <label>条码</label><asp:TextBox CssClass="middle" runat="server" ID="txb_tm"></asp:TextBox>
        </div>
        <div>
            <label>来源去向</label><asp:DropDownList runat="server" ID="cmb_lyqx"></asp:DropDownList>
        </div>
        <div>
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <label>发生日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_end"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_jinchu" runat="server" AutoGenerateColumns="False" AllowCustomPaging="true" DataKeyNames="id"
        AllowPaging="true" PageSize="5" OnPageIndexChanging="grid_jinchu_PageIndexChanging" OnRowCommand="grid_jinchu_RowCommand">
        <Columns>
            <asp:BoundField DataField="pinpaishang" HeaderText="品牌商"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="cangku" HeaderText="仓库"></asp:BoundField>
            <asp:BoundField DataField="picima" HeaderText="批次码"></asp:BoundField>
            <asp:BoundField DataField="fangxiang" HeaderText="方向"></asp:BoundField>
            <asp:BoundField DataField="lyqx" HeaderText="来源去向"></asp:BoundField>
            <asp:BoundField DataField="jianshu" HeaderText="件数"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:BoundField DataField="zhongjia" HeaderText="总价"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="fashengshijian" HeaderText="发生时间"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>            
            <asp:ButtonField CommandName="MX" Text="查看" ButtonType="Button" HeaderText="明细" /> 
        </Columns>
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />   
    </asp:GridView>
    <asp:GridView ID="grid_mx" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="danjia" HeaderText="单价"></asp:BoundField>
            <asp:BoundField DataField="diaopaijia" HeaderText="吊牌价"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_jinchu.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_jinchu.PageCount %>" />
</asp:Content>
