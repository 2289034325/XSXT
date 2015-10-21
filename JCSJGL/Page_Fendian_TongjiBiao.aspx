<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Fendian_TongjiBiao.aspx.cs" Inherits="JCSJGL.Page_Fendian_TongjiBiao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>销售统计表</title>
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_jms" runat="server">
            <label>品牌商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true" OnSelectedIndexChanged="cmb_jms_SelectedIndexChanged"></asp:DropDownList>
        </div>        
        <div id="div_sch_zjms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_zjms" AutoPostBack="true" OnSelectedIndexChanged="cmb_zjms_SelectedIndexChanged"></asp:DropDownList>
        </div>
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
    <asp:GridView ID="grid_jms" runat="server" AutoGenerateColumns="False" DataKeyNames="jmsid" OnRowCommand="grid_jms_RowCommand"
        AllowCustomPaging="true" AllowPaging="true" OnPageIndexChanging="grid_jms_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="jms" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="jmsid" HeaderText="加盟商ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="xl" HeaderText="销售量"></asp:BoundField>
            <asp:BoundField DataField="xse" HeaderText="销售额"></asp:BoundField>
            <asp:BoundField DataField="lr" HeaderText="利润"></asp:BoundField>
            <asp:ButtonField CommandName="FENDIAN" Text="分店" ButtonType="Button" ShowHeader="false" />
            <asp:ButtonField CommandName="RIQI" Text="日期" ButtonType="Button" ShowHeader="false" />
            <asp:ButtonField CommandName="XIANGXI" Text="详细" ButtonType="Button" ShowHeader="false" />
        </Columns>
        <RowStyle HorizontalAlign="Right"></RowStyle>
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>

    <asp:GridView ID="grid_jms_rq" runat="server" AutoGenerateColumns="False" DataKeyNames="jmsid,rq" OnRowCommand="grid_jms_rq_RowCommand">
        <Columns>
            <asp:BoundField DataField="jms" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="jmsid" HeaderText="加盟商ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="rq" HeaderText="日期"></asp:BoundField>
            <asp:BoundField DataField="xl" HeaderText="销售量"></asp:BoundField>
            <asp:BoundField DataField="xse" HeaderText="销售额"></asp:BoundField>
            <asp:BoundField DataField="lr" HeaderText="利润"></asp:BoundField>
            <asp:ButtonField CommandName="FENDIAN" Text="分店" ButtonType="Button" ShowHeader="false" />
            <asp:ButtonField CommandName="XIANGXI" Text="详细" ButtonType="Button" ShowHeader="false" />
        </Columns>
        <RowStyle HorizontalAlign="Right"></RowStyle>
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>
    <asp:GridView ID="grid_fd" runat="server" AutoGenerateColumns="False" DataKeyNames="jmsid,fdid" OnRowCommand="grid_fd_RowCommand">
        <Columns>
            <asp:BoundField DataField="jmsid" HeaderText="加盟商ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fdid" HeaderText="分店ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fd" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="xl" HeaderText="销售量"></asp:BoundField>
            <asp:BoundField DataField="xse" HeaderText="销售额"></asp:BoundField>
            <asp:BoundField DataField="lr" HeaderText="利润"></asp:BoundField>
            <asp:ButtonField CommandName="RIQI" Text="日期" ButtonType="Button" ShowHeader="false" />
            <asp:ButtonField CommandName="XIANGXI" Text="详细" ButtonType="Button" ShowHeader="false" />
        </Columns>
        <RowStyle HorizontalAlign="Right"></RowStyle>
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>
    <asp:GridView ID="grid_rq_fd" runat="server" AutoGenerateColumns="False" DataKeyNames="jmsid,fdid,rq" OnRowCommand="grid_fd_rq_RowCommand">
        <Columns>
            <asp:BoundField DataField="jmsid" HeaderText="加盟商ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fdid" HeaderText="分店ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="rq" HeaderText="日期"></asp:BoundField>
            <asp:BoundField DataField="fd" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="xl" HeaderText="销售量"></asp:BoundField>
            <asp:BoundField DataField="xse" HeaderText="销售额"></asp:BoundField>
            <asp:BoundField DataField="lr" HeaderText="利润"></asp:BoundField>
            <asp:ButtonField CommandName="XIANGXI" Text="详细" ButtonType="Button" ShowHeader="false" />
        </Columns>
        <RowStyle HorizontalAlign="Right"></RowStyle>
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>
</asp:Content>
