<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Xiaoshou.aspx.cs" Inherits="JCSJGL.Page_Xiaoshou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>销售记录</title>
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
            <label>款号</label><asp:TextBox runat="server" ID="txb_kh" ClientIDMode="Static" CssClass="short"></asp:TextBox>
        </div>
        <div>
            <label>条码</label><asp:TextBox runat="server" ID="txb_tm" ClientIDMode="Static" CssClass="middle"></asp:TextBox>
        </div>
        <div>
            <label>销售日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_xsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_xsrq_end"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_xiaoshou" runat="server" AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_xiaoshou_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="pinpaishang" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
            <asp:BoundField DataField="jinjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="diaopaijia" HeaderText="吊牌价"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:BoundField DataField="moling" HeaderText="抹零"></asp:BoundField>
            <asp:BoundField DataField="jiage" HeaderText="售价"></asp:BoundField>
            <asp:BoundField DataField="lirun" HeaderText="利润"></asp:BoundField>
            <asp:BoundField DataField="huiyuan" HeaderText="会员"></asp:BoundField>
            <asp:BoundField DataField="xiaoshouyuan" HeaderText="销售员"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="xiaoshoushijian" HeaderText="销售时间"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
        </Columns>
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />   
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_xiaoshou.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_xiaoshou.PageCount %>" />

</asp:Content>
