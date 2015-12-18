<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_FDJinchuhuo.aspx.cs" Inherits="JCSJGL.Page_FDJinchuhuo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>进出货记录</title>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true" OnSelectedIndexChanged="cmb_jms_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList>
        </div>
        <div>
            <label>款号</label><asp:TextBox runat="server" ID="txb_kh" ClientIDMode="Static" CssClass="middle"></asp:TextBox>
        </div>
        <div>
            <label>条码</label><asp:TextBox runat="server" ID="txb_tm" ClientIDMode="Static" CssClass="long"></asp:TextBox>
        </div>
        <div>
            <label>发生日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_end"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_jinchu" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_jinchu_RowCommand"
        AllowCustomPaging="true" AllowPaging="true" PageSize="5" OnPageIndexChanging="grid_jinchu_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="fangxiang" HeaderText="方向"></asp:BoundField>
            <asp:BoundField DataField="lyqx" HeaderText="来源去向"></asp:BoundField>
            <asp:BoundField DataField="jianshu" HeaderText="件数"></asp:BoundField>
            <asp:BoundField DataField="jine" HeaderText="金额"></asp:BoundField>
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
            <asp:BoundField DataField="gyskuanhao" HeaderText="供应商款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="danjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="diaopaijia" HeaderText="吊牌价"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_jinchu.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_jinchu.PageCount %>" />
</asp:Content>
