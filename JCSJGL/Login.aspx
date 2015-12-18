<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JCSJGL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登陆</title>
    <script type="text/javascript" src="jquery-2.1.3.js"></script>
    <script type="text/javascript" src="Common.js"></script>
    <script type="text/javascript" src="MobileAdapter.js"></script>
    <script>
        function login() {
            document.getElementById("form").submit();
        }
    </script>
    <style type="text/css">
        body {
            
        }
        label {

        }
        .lbl_autologin {
            position:relative;
            top:-3px;
            font-size:0.8em;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div id="div_login" style="text-align:center; position:relative; top:200px;">
            <div style="display:inline-block;">
                <label>登录名</label><input type="text" id="txb_dlm" runat="server" /><br />
                <label>密码</label><input type="password" style="float:right;" id="txb_mm" runat="server" /><br /><br />
                <input runat="server" type="checkbox" id="chk_auto" /><label class="lbl_autologin">自动登陆</label>
                <input type="button" value="登陆" onclick="login()" style="float:right;" /><br /><br />
                <a style="float:right;" href="Zhuce.aspx">注册</a>           
            </div>
        </div>
    </form>
</body>
</html>
