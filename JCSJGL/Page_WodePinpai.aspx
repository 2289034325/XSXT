<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_WodePinpai.aspx.cs" Inherits="JCSJGL.Page_WodePinpai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>我的品牌</title>
    <script type="text/javascript">
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">    
    <div id="div_wyjmpp" runat="server">
        <asp:Button runat="server" ID="btn_wyjm" Text="我要加盟一个品牌" OnClick="btn_wyjm_Click"></asp:Button>
        <asp:DropDownList runat="server" ID="cmb_ppxz"></asp:DropDownList><br />
        <asp:Label runat="server" ID="lbl_wdsq" Text="我的加盟申请"></asp:Label>
    </div>
    <asp:GridView ID="grid_sjsq" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_sjsq_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" HeaderText="关系ID"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="sqsj" HeaderText="申请时间"></asp:BoundField>
            <asp:BoundField DataField="jieguo" HeaderText="结果"></asp:BoundField>
            <asp:ButtonField CommandName="SC" Text="删除" ButtonType="Button" ShowHeader="false" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grid_jmpp" runat="server" AutoGenerateColumns="False" Caption="我加盟的品牌" DataKeyNames="id" OnRowDeleting="grid_jmpp_RowDeleting">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" HeaderText="关系ID"></asp:BoundField>
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
    </asp:GridView>    
</asp:Content>
