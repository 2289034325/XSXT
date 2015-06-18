<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Huiyuan.aspx.cs" Inherits="JCSJGL.Page_Huiyuan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>会员管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,sjh,xm,xb,sr,bz) {
            $("#hid_id").val(id);
            $("#txb_sjh").val(sjh);
            $("#txb_xm").val(xm);
            $("#cmb_xb").val(xb);
            $("#txb_sr").val(sr);
            $("#txb_bz").val(bz);
        }

        //删除
        function Delete(id)
        {
            $("#hid_opt").val("DELETE");
            $("#hid_id").val(id);
        }

        function DeleteZK(id)
        {
            $("#hid_opt").val("DELETEZK");
            $("#hid_id").val(id);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:GridView ID="grid_huiyuan" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="shoujihao" HeaderText="手机号"></asp:BoundField>
            <asp:BoundField DataField="xingming" HeaderText="姓名"></asp:BoundField>
            <asp:BoundField DataField="xingbie" HeaderText="性别"></asp:BoundField>
            <asp:BoundField DataField="shengri" HeaderText="生日"></asp:BoundField>
            <asp:BoundField DataField="jifen" HeaderText="积分"></asp:BoundField>
            <asp:BoundField DataField="jfjsshijian" HeaderText="积分计算时间"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="caozuoren" HeaderText="编辑人"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改"></input><input type="submit" onclick="    Delete(<%# Eval("id")%>)" value="删除"></input>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <asp:Label runat="server" Text="手机号"></asp:Label><asp:TextBox runat="server" ID="txb_sjh" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="姓名"></asp:Label><asp:TextBox runat="server" ID="txb_xm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="性别"></asp:Label><asp:DropDownList runat="server" ID="cmb_xb" ClientIDMode="Static"></asp:DropDownList>
    <asp:Label runat="server" Text="生日"></asp:Label><asp:TextBox runat="server" ID="txb_sr" ClientIDMode="Static"></asp:TextBox>    
    <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />

    <asp:GridView ID="grid_zhekou" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="jifen" HeaderText="积分"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="submit" onclick="DeleteZK(<%# Eval("id")%>)" value="删除"></input>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:Label runat="server" Text="积分"></asp:Label><asp:TextBox runat="server" ID="txb_jf" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="折扣"></asp:Label><asp:TextBox runat="server" ID="txb_zk" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btn_zk_add" Text="增加" OnClick="btn_zk_add_Click" />

</asp:Content>
