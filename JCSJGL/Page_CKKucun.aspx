<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_CKKucun.aspx.cs" Inherits="JCSJGL.Page_CKKucun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>仓库库存记录</title>
    <script type="text/javascript">
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
    <asp:GridView ID="grid_kc_ck" runat="server" AutoGenerateColumns="False">
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
    </asp:GridView>
    <asp:GridView ID="grid_kc" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grid_kc_RowDeleting">
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
    </asp:GridView>

</asp:Content>
