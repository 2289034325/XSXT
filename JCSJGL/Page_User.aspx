<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_User.aspx.cs" Inherits="JCSJG.Page_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>系统用户</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,dlm,yhm,js,zt,bz) {
            $("#hid_id").val(id);
            $("#txb_dlm").val(dlm);
            $("#txb_yhm").val(yhm);
            $("#cmb_js").val(js);
            $("#cmb_zt").val(zt);
            $("#txb_bz").val(bz);
        }

        //修改密码
        function EditPsw(id)
        {
            $("#hid_opt").val("EDITPSW");
            $("#hid_id").val(id);
        }
        //删除
        function Delete(id)
        {
            $("#hid_opt").val("DELETE");
            $("#hid_id").val(id);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:GridView ID="grid_yonghu" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="dengluming" HeaderText="登录名"></asp:BoundField>
            <asp:BoundField DataField="yonghuming" HeaderText="用户名"></asp:BoundField>
            <asp:BoundField DataField="juese_view" HeaderText="角色"></asp:BoundField>
            <asp:BoundField DataField="zhuangtai_view" HeaderText="状态"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改资料"></input><input type="submit" onclick="EditPsw(<%# Eval("id")%>)" value="修改密码"></input><input type="submit" onclick="Delete(<%# Eval("id")%>)" value="删除"></input>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <asp:Label runat="server" Text="登录名"></asp:Label><asp:TextBox runat="server" ID="txb_dlm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="密码"></asp:Label><asp:TextBox runat="server" ID="txb_mm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="用户名"></asp:Label><asp:TextBox runat="server" ID="txb_yhm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="角色"></asp:Label><asp:DropDownList runat="server" ID="cmb_js" ClientIDMode="Static"></asp:DropDownList>
    <asp:Label runat="server" Text="状态"></asp:Label><asp:DropDownList runat="server" ID="cmb_zt" ClientIDMode="Static"></asp:DropDownList>
    <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btn_editxx" Text="修改" OnClick="btn_editxx_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />

</asp:Content>
