<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Kuanhao.aspx.cs" Inherits="JCSJGL.Page_Kuanhao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>款号管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,pp,kh,lx,xb,pm,bz) {
            $("#hid_id").val(id);
            $("#cmb_pp").val(pp);
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
    <div id="div_sch" class="div_sch">
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <label>类型</label><asp:DropDownList runat="server" ID="cmb_lx_sch"></asp:DropDownList>
        </div>
        <div>
            <label>款号</label><asp:TextBox CssClass="middle" runat="server" ID="txb_kh_sch"></asp:TextBox>
        </div>
        <div>
            <label>品名</label><asp:TextBox CssClass="middle" runat="server" ID="txb_pm_sch"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_kuanhao" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowDeleting="grid_kuanhao_RowDeleting"
        AllowCustomPaging="true" AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_kuanhao_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="xingbie" HeaderText="性别"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
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
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>
    <%--<asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />--%>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <asp:Label runat="server" Text="品牌"></asp:Label><asp:DropDownList runat="server" ID="cmb_pp" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="款号"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_kh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="类型"></asp:Label><asp:DropDownList runat="server" ID="cmb_lx" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="性别"></asp:Label><asp:DropDownList runat="server" ID="cmb_xb" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="品名"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_pm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btn_edit" Text="保存" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />
        </div>
    </div>
</asp:Content>

