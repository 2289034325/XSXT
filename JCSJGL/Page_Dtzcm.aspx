<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Dtzcm.aspx.cs" Inherits="JCSJGL.Page_Dtzcm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>注册码</title>
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:Button runat="server" ID="btn_new" OnClick="btn_new_Click" Text="生成10个新注册码" />
    <div id="div_zcm" runat="server" style="font-size: 30px;"></div>
</asp:Content>
