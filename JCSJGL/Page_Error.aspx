<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_Error.aspx.cs" Inherits="JCSJGL.Page_Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>错误</title>
    <script type="text/javascript" src="jquery-2.1.3.js"></script>
    <script type="text/javascript" src="MobileAdapter.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;position:relative; top:200px;">
    <asp:Label runat="server" ID="lbl_errorMsg"></asp:Label><br />
        <input type="button" value="返回" onclick="history.back();" />
    </div>
    </form>
</body>
</html>