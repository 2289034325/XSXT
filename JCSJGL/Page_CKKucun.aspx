<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_CKKucun.aspx.cs" Inherits="JCSJGL.Page_CKKucun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>仓库库存记录</title>
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
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true" OnSelectedIndexChanged="cmb_jms_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <label>仓库</label><asp:DropDownList runat="server" ID="cmb_ck"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_kc_total" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grid_kc_ck" runat="server" AutoGenerateColumns="False" OnRowCommand="grid_kc_ck_RowCommand" DataKeyNames="ckid">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="ckid" HeaderText="仓库ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="cangku" HeaderText="仓库"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField> 
            <asp:ButtonField CommandName="LSKC" Text="查看" ButtonType="Button" HeaderText="历史库存" />    
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grid_kc" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_kc_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="cangku" HeaderText="仓库"></asp:BoundField>
            <asp:BoundField DataField="kucunshuliang" HeaderText="库存数量"></asp:BoundField>
            <asp:BoundField DataField="chengbenjine" HeaderText="成本金额"></asp:BoundField>
            <asp:BoundField DataField="shoujiajine" HeaderText="售价金额"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>             
            <asp:ButtonField CommandName="MX" Text="查看" ButtonType="Button" HeaderText="明细" />    
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Button" ShowHeader="false" ControlStyle-CssClass="delete" />
        </Columns>
    </asp:GridView>

</asp:Content>
