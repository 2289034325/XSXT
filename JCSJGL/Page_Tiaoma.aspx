<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Tiaoma.aspx.cs" Inherits="JCSJGL.Page_Tiaoma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>条码信息</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,tm,ys,cm,jj,sj,kh,gyskh) {
            $("#hid_id").val(id);
            $("#txb_tm").val(tm);
            $("#txb_ys").val(ys);
            $("#txb_cm").val(cm);
            $("#txb_jj").val(jj);
            $("#txb_sj").val(sj);
            $("#txb_kh").val(kh);
            $("#txb_gyskh").val(gyskh);
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
     <div id="div_sch">
        <label>类型</label><asp:DropDownList runat="server" ID="cmb_lx"></asp:DropDownList>
        <label>款号</label><asp:TextBox runat="server" ID="txb_kh_sch"></asp:TextBox>
        <label>条码号</label><asp:TextBox runat="server" ID="txb_tmh_sch"></asp:TextBox>        
        <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
    </div>
    <asp:GridView ID="grid_tiaoma" runat="server" AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="true" PageSize="20" 
         BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grid_tiaoma_PageIndexChanging">
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
            <asp:BoundField DataField="caozuoren" HeaderText="编辑人"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改"></input><input type="submit" onclick="    Delete(<%# Eval("id")%>)" value="删除"></input>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
        <PagerSettings Mode="Numeric" Visible="true" />
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
    <asp:Button runat="server" ID="btn_edit" Text="修改" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />

</asp:Content>
