<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zhuce.aspx.cs" Inherits="JCSJGL.Zhuce" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
    <script type="text/javascript" src="jquery-2.1.3.js"></script>
    <script type="text/javascript" src="MobileAdapter.js"></script>
    <style type="text/css">
        .div_out {
            padding-top: 50px;
            width: 300px;
            margin: auto;
        }

        .div_input {
            display: -webkit-inline-flex;
            display:-ms-inline-flexbox;
        }

            .div_input label {
                width: 100px;
            }

            .div_input textarea {
                float: right;
                width: 200px;
                height: 80px;
            }

            .div_input input[type='text'] {
                float: right;
                width: 200px;
            }

            .div_input input[type='password'] {
                float: right;
                width: 200px;
            }

            .div_input input[type='button'] {
                float: right;
            }

            .div_input select {
                width: 100px;
            }

        .lbl_tongyi {
            font-size: 10px;
            color: gray;
            padding-top: 2px;
        }

        .div_shuoming {
            margin-left: 100px;
            width: 300px;
            color: gray;
            font-size: 12px;
        }
    </style>
    <script>
        function chk_change() {
            var chk_tongyi = $("#chk_tongyi");
            var btn_zhuce = $("#btn_zhuce");
            if (chk_tongyi.is(':checked')) {
                btn_zhuce.attr("disabled", false);
            }
            else {
                btn_zhuce.attr("disabled", true);
            }
        }

        $(document).ready(function () {
            var chk_tongyi = $("#chk_tongyi");
            var btn_zhuce = $("#btn_zhuce");
            if (chk_tongyi.is(':checked')) {
                btn_zhuce.attr("disabled", false);
            }
            else {
                btn_zhuce.attr("disabled", true);
            }
        });
    </script>
</head>
<body>
    <form id="form" runat="server">
        <div class="div_out">
            <div class="div_input">
                <label>名称</label><input type="text" id="txb_mc" runat="server" />
            </div>
            <div class="div_shuoming">
                <label>请输入您的品牌名称或者公司名称或者姓名，这个名称必须唯一而且注册后不可修改</label>
            </div>
            <div class="div_input">
                <label>手机号</label><input type="text" id="txb_sjh" runat="server" />
            </div>
            <div class="div_shuoming">
                <label>这个手机号将作为注册成功后的登陆名，并且是您以后修改密码和资料的重要凭证</label>
            </div>
            <div class="div_input">
                <label>登陆密码</label><input type="password" id="txb_mm" runat="server" />
            </div>
            <div class="div_input">
                <label>确认密码</label><input type="password" id="txb_mmqr" runat="server" />
            </div>
            <div class="div_input">
                <label>邮箱</label><input type="text" id="txb_yx" runat="server" />
            </div>
            <div class="div_shuoming">
                <label>请务必填写一个有效可用的邮箱，建议使用QQ邮箱</label>
            </div>
            <div class="div_input">
                <label>联系人</label><input type="text" id="txb_lxr" runat="server" />
            </div>
            <div class="div_input">
                <label>联系电话</label><input type="text" id="txb_dh" runat="server" />
            </div>
            <div class="div_input">
                <label>行政地区</label><asp:DropDownList AutoPostBack="true" runat="server" ID="cmb_sheng" OnSelectedIndexChanged="cmb_sheng_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="cmb_shi"></asp:DropDownList>
            </div>
            <div class="div_input">
                <label>详细地址</label><textarea id="txb_dz" runat="server"></textarea>
            </div>
            <div class="div_input">
                <label>注册码</label><input type="text" id="txb_zcm" runat="server" />
            </div>
            <div class="div_input" style="float: right;">
                <input runat="server" type="checkbox" id="chk_tongyi" onchange="chk_change()" /><label class="lbl_tongyi" for="chk_tongyi">同意使用协议</label>
                <asp:Button runat="server" ID="btn_zhuce" Text="注册" OnClick="btn_zhuce_Click" />
            </div>
        </div>
    </form>
</body>
</html>
