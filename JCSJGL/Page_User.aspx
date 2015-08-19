<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_User.aspx.cs" Inherits="JCSJGL.Page_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>系统用户</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,dlm,yhm,js,zt,bz) {
            $("#hid_id").val(id);
            $("#txb_dlm").val(dlm);
            $("#txb_mm").val('');
            $("#txb_yhm").val(yhm);
            $("#cmb_js").val(js);
            $("#cmb_zt").val(zt);
            $("#txb_bz").val(bz);
        }

        //修改密码
        //function EditPsw(id)
        //{
        //    $("#hid_opt").val("EDITPSW");
        //    $("#hid_id").val(id);
        //}
        //删除
        //function Delete(id)
        //{
        //    $("#hid_opt").val("DELETE");
        //    $("#hid_id").val(id);
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch" runat="server">
        <div>
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>

    <asp:GridView ID="grid_yonghu" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowDeleting="grid_yonghu_RowDeleting">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
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
    </asp:GridView>
    <%--<asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />--%>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div id="div_edit_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms_edit"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="登录名"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_dlm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="密码"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_mm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="用户名"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_yhm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="角色"></asp:Label><asp:DropDownList runat="server" ID="cmb_js" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="状态"></asp:Label><asp:DropDownList runat="server" ID="cmb_zt" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btn_editxx" Text="保存" OnClick="btn_editxx_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />
        </div>
    </div>
</asp:Content>
