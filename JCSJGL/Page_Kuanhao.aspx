<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Kuanhao.aspx.cs" Inherits="JCSJG.Page_Kuanhao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>款号管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,kh,lx,xb,pm,bz) {
            $("#hid_id").val(id);
            $("#txb_kh").val(kh);
            $("#cmb_lx").val(lx);
            $("#cmb_xb").val(xb);
            $("#txb_pm").val(pm);
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
    <asp:GridView ID="grid_kuanhao" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="xingbie" HeaderText="性别"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
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
    <asp:Label runat="server" Text="款号"></asp:Label><asp:TextBox runat="server" ID="txb_kh" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="类型"></asp:Label><asp:DropDownList runat="server" ID="cmb_lx" ClientIDMode="Static"></asp:DropDownList>
    <asp:Label runat="server" Text="性别"></asp:Label><asp:DropDownList runat="server" ID="cmb_xb" ClientIDMode="Static"></asp:DropDownList>
    <asp:Label runat="server" Text="品名"></asp:Label><asp:TextBox runat="server" ID="txb_pm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />

</asp:Content>

