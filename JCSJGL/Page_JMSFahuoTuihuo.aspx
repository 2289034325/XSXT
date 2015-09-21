<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_JMSFahuoTuihuo.aspx.cs" Inherits="JCSJGL.Page_JMSFahuoTuihuo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>发货退货单</title>
    <script type="text/javascript">
        $(document).ready(
            function ()
            {
                $(".delete").click(function ()
                {
                    return alert('是否确定删除?');
                });
            });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_dls" runat="server">
            <label>代理商</label><asp:DropDownList runat="server" ID="cmb_dls" AutoPostBack="true" OnSelectedIndexChanged="cmb_dls_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div>
            <label>条码</label><asp:TextBox CssClass="middle" TextMode="SingleLine" runat="server" ID="txb_tm"></asp:TextBox>
        </div>
        <div>
            <label>发生日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_end"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
            <asp:Button ID="btn_fahuo" runat="server" Text="发货" OnClick="btn_fahuo_Click" />
            <asp:Button ID="btn_tuihuo" runat="server" Text="退货" OnClick="btn_tuihuo_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_jc" runat="server" AutoGenerateColumns="False" OnRowCommand="grid_jc_RowCommand" DataKeyNames="id"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="dailishang" HeaderText="代理商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fashengriqi" HeaderText="发生日期"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="fangxiang" HeaderText="方向"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
            <asp:BoundField DataField="jine" HeaderText="金额"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="登记时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:CommandField ShowEditButton="True"></asp:CommandField>
            <asp:ButtonField CommandName="MX" Text="查看明细" ButtonType="Link" ShowHeader="false" />
            <asp:ButtonField CommandName="ADDMX" Text="增加一款" ButtonType="Link" ShowHeader="false" />
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Link" ShowHeader="false" ItemStyle-CssClass="delete" />           
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
    </asp:GridView>

    <asp:GridView ID="grid_mx" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_mx_RowCommand"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="diaopaijia" HeaderText="吊牌价"></asp:BoundField>
            <asp:BoundField DataField="jinhuojia" HeaderText="拿货价"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Link" ShowHeader="false" ItemStyle-CssClass="delete" />   
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
    </asp:GridView>

</asp:Content>
