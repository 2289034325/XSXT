<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Gongyingshang.aspx.cs" Inherits="JCSJGL.Page_Gongyingshang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>供应商管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,mc,lxr,dh,dz,bz) {
            $("#hid_id").val(id);
            $("#txb_mc").val(mc);
            $("#txb_lxr").val(lxr);
            $("#txb_dh").val(dh);
            $("#txb_dz").val(dz);
            $("#txb_bz").val(bz);
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
    <asp:GridView ID="grid_gys" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="mingcheng" HeaderText="名称"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="电话"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="地址"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="caozuoren" HeaderText="编辑人"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改"></input><input type="submit" onclick="    EditPsw(<%# Eval("id")%>)" value="修改密码"></input><input type="submit" onclick="    Delete(<%# Eval("id")%>)" value="删除"></input>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <asp:Label runat="server" Text="名称"></asp:Label><asp:TextBox runat="server" ID="txb_mc" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="联系人"></asp:Label><asp:TextBox runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="电话"></asp:Label><asp:TextBox runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="地址"></asp:Label><asp:TextBox runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />

</asp:Content>
