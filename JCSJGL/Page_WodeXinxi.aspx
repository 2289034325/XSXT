<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_WodeXinxi.aspx.cs" Inherits="JCSJGL.Page_WodeXinxi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>我的信息</title>
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
                height:80px;
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

        .div_shuoming 
        {
            margin-left:100px;
            width:300px;
            color: gray;
            font-size: 12px;

        }
    </style>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">        
    <div class="div_out">
            <div class="div_input">
                <label>名称</label><input type="text" id="txb_mc" runat="server" disabled="disabled" />
            </div>
            <div class="div_shuoming">
                <label>这是您区别其他用户或代理商的唯一名称</label>
            </div>
            <div class="div_input">
                <label>代码</label><input type="text" id="txb_dm" runat="server" disabled="disabled" />
            </div>
            <div class="div_input">
                <label>手机号</label><input type="text" id="txb_sjh" runat="server" />
            </div>
            <div class="div_shuoming">
                <label>这个手机号将作为注册成功后的登陆名，并且是您以后修改密码和资料的重要凭证</label>
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
            <div class="div_input" style="float: right;">                
                <asp:Button runat="server" ID="btn_save" Text="保存" OnClick="btn_save_Click"/>
            </div>
        </div>
</asp:Content>
