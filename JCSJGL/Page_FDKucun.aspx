<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_FDKucun.aspx.cs" Inherits="JCSJGL.Page_FDKucun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>分店库存记录</title>
    <script type="text/javascript">
        $(document).ready(
            function ()
            {
                $(".delete").click(function ()
                {
                    return confirm('是否确定删除?');
                });
            });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true"></asp:DropDownList>
        </div>        
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_kc_jms" runat="server" AutoGenerateColumns="False"         
        DataKeyNames="id" OnRowCommand="grid_kc_jms_RowCommand" ViewStateMode="Enabled" >
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="jmsid" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="吊牌价金额"></asp:BoundField>
            <asp:ButtonField CommandName="FDKC" Text="分店库存" ButtonType="Button" ShowHeader="false" />
        </Columns>
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />   
    </asp:GridView>

    <asp:GridView ID="grid_kc_fd" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_kc_fd_RowCommand" >
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
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
