<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_JiamengshangGuanxi.aspx.cs" Inherits="JCSJGL.Page_JiamengshangGuanxi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>加盟关系</title>
    <script type="text/javascript">
        function EditInfo(id,bzmc,bz) {
            $("#hid_id").val(id);
            $("#txb_bzmc").val(bzmc);
            $("#txb_bz").val(bz);

            $("#div_edit").css("display","");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">    
    <div id="div_wyjmpp" runat="server">
        <asp:Button runat="server" ID="btn_wyjm" Text="我要加盟一个品牌" OnClick="btn_wyjm_Click"></asp:Button>
        <asp:DropDownList runat="server" ID="cmb_ppxz"></asp:DropDownList><br />
        <asp:Label runat="server" ID="lbl_wdsq" Text="我的加盟申请"></asp:Label>
    </div>
    <asp:GridView ID="grid_sjsq" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowCommand="grid_sjsq_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" HeaderText="关系ID"></asp:BoundField>
            <asp:BoundField DataField="dailishang" HeaderText="代理商"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="sqsj" HeaderText="申请时间"></asp:BoundField>
            <asp:BoundField DataField="jieguo" HeaderText="结果"></asp:BoundField>
            <asp:ButtonField CommandName="SC" Text="删除" ButtonType="Link" ShowHeader="false" />
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
    <asp:GridView ID="grid_jmpp" runat="server" AutoGenerateColumns="False" BackColor="White" Caption="我加盟的品牌"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowDeleting="grid_jmpp_RowDeleting">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" HeaderText="关系ID"></asp:BoundField>
            <asp:BoundField DataField="dailishang" HeaderText="代理商"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="jmsj" HeaderText="加盟时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_tcjm" runat="server" OnClientClick="return confirm('确定退出加盟吗?')" Text="退出加盟" CommandName="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:GridView ID="grid_xjsq" runat="server" AutoGenerateColumns="False" BackColor="White" Caption="子加盟商申请"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowCommand="grid_xjsq_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="地区"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="详细地址"></asp:BoundField>
            <asp:BoundField DataField="sqsj" HeaderText="申请时间"></asp:BoundField>
            <asp:ButtonField CommandName="YES" Text="同意" ButtonType="Link" ShowHeader="false" />
            <asp:ButtonField CommandName="NO" Text="不同意" ButtonType="Link" ShowHeader="false" />
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
    <asp:GridView ID="grid_jms" runat="server" AutoGenerateColumns="False" BackColor="White" Caption="我的子加盟商"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="jmsid" Visible="false" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="地区"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商名称"></asp:BoundField>
            <asp:BoundField DataField="bzmingcheng" HeaderText="备注名称"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="详细地址"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="jmsj" HeaderText="加盟时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改备注"></input>
                </ItemTemplate>
            </asp:TemplateField>
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
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit" style="display: none;">
        <div>
            <asp:Label runat="server" Text="备注名称"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_bzmc" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btn_edit" Text="保存" OnClick="btn_edit_Click" />
        </div>
    </div>
</asp:Content>
