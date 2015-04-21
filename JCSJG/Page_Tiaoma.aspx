<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Tiaoma.aspx.cs" Inherits="JCSJG.Page_Tiaoma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>条码信息</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,tm,ys,cm,jj,sj,kh,gys,gyskh,ms) {
            $("#hid_id").val(id);
            $("#txb_tm").val(tm);
            $("#txb_ys").val(ys);
            $("#txb_cm").val(cm);
            $("#txb_jj").val(jj);
            $("#txb_sj").val(sj);
            $("#txb_kh").val(kh);
            $("#cmb_gys").val(gys);
            $("#txb_gyskh").val(gyskh);
            $("#txb_ms").val(ms);
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
    <asp:GridView ID="grid_tiaoma" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="gyskuanhao" HeaderText="供应商款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="jinjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="shoujia" HeaderText="售价"></asp:BoundField>
            <asp:BoundField DataField="maishou" HeaderText="买手"></asp:BoundField>
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
    <asp:Label runat="server" Text="条码"></asp:Label><asp:TextBox runat="server" ID="txb_tm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="款号"></asp:Label><asp:TextBox runat="server" ID="txb_kh" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="供应商款号"></asp:Label><asp:TextBox runat="server" ID="txb_gyskh" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="颜色"></asp:Label><asp:TextBox runat="server" ID="txb_ys" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="尺码"></asp:Label><asp:TextBox runat="server" ID="txb_cm" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="进价"></asp:Label><asp:TextBox runat="server" ID="txb_jj" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="售价"></asp:Label><asp:TextBox runat="server" ID="txb_sj" ClientIDMode="Static"></asp:TextBox>
    <asp:Label runat="server" Text="供应商"></asp:Label><asp:DropDownList runat="server" ID="cmb_gys" ClientIDMode="Static"></asp:DropDownList>
    <asp:Label runat="server" Text="买手"></asp:Label><asp:TextBox runat="server" ID="txb_ms" ClientIDMode="Static"></asp:TextBox>
    <asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />

</asp:Content>
