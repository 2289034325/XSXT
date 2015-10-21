<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Dtyzm.aspx.cs" Inherits="JCSJGL.Page_Dtyzm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>动态验证码</title>
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div style="text-align: center;">
        <div style="height:200px;"></div>
        <div id="div_yzm" runat="server" style="font-size: 30px; "></div>
        <asp:Button runat="server" ID="btn_renew" OnClick="btn_renew_Click" Text="重新生成" />
    </div>
</asp:Content>
