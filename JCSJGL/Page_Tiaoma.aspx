<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Tiaoma.aspx.cs" Inherits="JCSJGL.Page_Tiaoma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>条码信息</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,tm,ys,cm,jj,sj,kh,gysid,gyskh) {
            $("#hid_id").val(id);
            $("#txb_tm").val(tm);
            $("#txb_ys").val(ys);
            $("#txb_cm").val(cm);
            $("#txb_jj").val(jj);
            $("#txb_sj").val(sj);
            $("#txb_kh").val(kh);
            $("#cmb_gys").val(gysid);
            $("#txb_gyskh").val(gyskh);
        }

        //删除
        //function Delete(id)
        //{
        //    $("#hid_opt").val("DELETE");
        //    $("#hid_id").val(id);
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div>
            <label>类型</label><asp:DropDownList runat="server" ID="cmb_lx"></asp:DropDownList></div>
        <div>
            <label>款号</label><asp:TextBox CssClass="short" runat="server" ID="txb_kh_sch"></asp:TextBox></div>
        <div>
            <label>条码号</label><asp:TextBox CssClass="middle" runat="server" ID="txb_tmh_sch"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" /></div>
    </div>
    <asp:GridView ID="grid_tiaoma" runat="server" AutoGenerateColumns="False"
         AllowCustomPaging="true" AllowPaging="true" PageSize="20" BackColor="White"  DataKeyNames="id" OnRowDeleting="grid_tiaoma_RowDeleting"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grid_tiaoma_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="gongyingshang" HeaderText="供应商"></asp:BoundField>
            <asp:BoundField DataField="gyskuanhao" HeaderText="供应商款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="jinjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="shoujia" HeaderText="售价"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改"></input>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_delete" runat="server" OnClientClick="return confirm('确定删除吗?')" Text="刪除" CommandName="Delete" />
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
    <%--<asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />--%>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <asp:Label runat="server" Text="条码"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_tm" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="款号"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_kh" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="供应商"></asp:Label><asp:DropDownList runat="server" ID="cmb_gys" ClientIDMode="Static"></asp:DropDownList></div>
        <div>
            <asp:Label runat="server" Text="供应商款号"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_gyskh" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="颜色"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_ys" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="尺码"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_cm" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="进价"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_jj" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="售价"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_sj" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Button runat="server" ID="btn_edit" Text="保存" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" /></div>
    </div>

</asp:Content>
