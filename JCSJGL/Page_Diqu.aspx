<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Diqu.aspx.cs" Inherits="JCSJGL.Page_Diqu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>地区编码</title>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">        
    <div>
        <asp:TextBox runat="server" ID="txb_mc"></asp:TextBox><asp:Button runat="server" ID="btn_addRoot" Text="增加根节点" OnClick="btn_addRoot_Click" />
        <asp:Button runat="server" ID="btn_addChild" Text="增加子节点" OnClick="btn_addChild_Click" />
        <asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" />
        <asp:Button runat="server" ID="btn_delete" Text="删除" OnClick="btn_delete_Click" />
    </div>
    <asp:TreeView ID="trv" runat="server" ImageSet="Arrows">
        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD"></HoverNodeStyle>

        <NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"></NodeStyle>

        <ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

        <SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True" ForeColor="#5555DD"></SelectedNodeStyle>
    </asp:TreeView>
</asp:Content>
