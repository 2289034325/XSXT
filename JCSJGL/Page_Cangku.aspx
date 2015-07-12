<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Cangku.aspx.cs" Inherits="JCSJGL.Page_Cangku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>仓库管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,mc,dz,lxr,dh,bz) {
            $("#hid_id").val(id);
            $("#txb_mc").val(mc);
            $("#txb_dz").val(dz);
            $("#txb_lxr").val(lxr);
            $("#txb_dh").val(dh);
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
    <asp:GridView ID="grid_cangku" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="mingcheng" HeaderText="名称"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="地址"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="电话"></asp:BoundField>
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
    <div id="div_edit" class="div_edit">
        <div><asp:Label runat="server" Text="名称"></asp:Label><asp:TextBox runat="server" ID="txb_mc" ClientIDMode="Static" CssClass="middle"></asp:TextBox></div>
        <div><asp:Label runat="server" Text="地址"></asp:Label><asp:TextBox runat="server" ID="txb_dz" ClientIDMode="Static" CssClass="long"></asp:TextBox></div>
        <div><asp:Label runat="server" Text="联系人"></asp:Label><asp:TextBox runat="server" ID="txb_lxr" ClientIDMode="Static" CssClass="middle"></asp:TextBox></div>
        <div><asp:Label runat="server" Text="电话"></asp:Label><asp:TextBox runat="server" ID="txb_dh" ClientIDMode="Static" CssClass="middle"></asp:TextBox></div>
        <div><asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static" CssClass="large"></asp:TextBox></div>
        <div><asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" /></div>
    </div>
</asp:Content>
