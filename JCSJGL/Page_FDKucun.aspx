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
            <label>品牌商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true" OnSelectedIndexChanged="cmb_jms_SelectedIndexChanged"></asp:DropDownList>
        </div>        
        <div id="div_sch_zjms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_zjms" AutoPostBack="true"></asp:DropDownList>
        </div>        
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="刷新" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_kc_total" runat="server" AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="true" PageSize="20"
        DataKeyNames="id" OnRowCommand="grid_kc_total_RowCommand" ViewStateMode="Enabled" OnPageIndexChanging="grid_kc_total_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="jmsid" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="吊牌价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
            <asp:ButtonField CommandName="FDKC" Text="分店库存" ButtonType="Button" ShowHeader="false" />
        </Columns>
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />   
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_kc_total.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_kc_total.PageCount %>" />

    <asp:GridView ID="grid_kc_fd" runat="server" AutoGenerateColumns="False" DataKeyNames="fdid" OnRowCommand="grid_kc_fd_RowCommand">
        <Columns>
            <asp:BoundField DataField="fdid" HeaderText="分店ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
            <asp:ButtonField CommandName="LSKC" Text="历史库存" ButtonType="Button" ShowHeader="false" />
        </Columns>
    </asp:GridView>

    <asp:GridView ID="grid_kc" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_kc_RowCommand" >
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>      
            <asp:ButtonField CommandName="MX" Text="查看" ButtonType="Button" HeaderText="明细" />    
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Button" ShowHeader="false" ControlStyle-CssClass="delete" />
        </Columns>
    </asp:GridView>

</asp:Content>
