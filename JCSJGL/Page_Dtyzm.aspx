<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Dtyzm.aspx.cs" Inherits="JCSJGL.Page_Dtyzm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>动态验证码</title>
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_yzm" runat="server" style="top: 200px; position: relative; font-size: 30px; text-align: center;"></div>
    <div style="text-align: center; position: relative;top: 200px;">
        <asp:Button runat="server" ID="btn_renew" OnClick="btn_renew_Click" Text="重新生成" />
    </div>
</asp:Content>
