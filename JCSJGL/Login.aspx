<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JCSJG.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:500px;margin:auto;">
    <label>登录名</label><input type="text" id="txb_dlm" name="txb_dlm"/>
    <label>密码</label><input type="password" id="txb_mm" name="txb_mm"/>
        <input type="submit" value="登陆" />
    </div>
    </form>
</body>
</html>
