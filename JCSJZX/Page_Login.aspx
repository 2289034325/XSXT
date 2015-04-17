<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_Login.aspx.cs" Inherits="JCSJZX.Page_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登陆</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin:auto; width:500px;">
            <label>登录名</label><input type="text" id="txb_dlm" name="txb_dlm" />
            <label>密码</label><input type="password" id="txb_mm" name="txb_mm" />
            <input type="submit" value="登陆" />
        </div>
    </form>
</body>
</html>
