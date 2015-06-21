<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Jinribaobiao.aspx.cs" Inherits="JCSJGL.Page_Jinribaobiao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>今日报表</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#div_main").find("label").css("font-size", "4em");
            $(".lbl_dm").css("font-size", "6em").css("color","red");
            //在页面装载时，在ID为#labels的DOM元素里插入labels.html的内容。
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_main">
        <%= this.Trs %>        
    </div>
</asp:Content>
