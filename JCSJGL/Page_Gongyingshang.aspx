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
    <asp:GridView ID="grid_gys" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowDeleting="grid_gys_RowDeleting">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="mingcheng" HeaderText="名称"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="电话"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="地址"></asp:BoundField>
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
        <div>
            <asp:Label runat="server" Text="名称"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_mc" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="联系人"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="电话"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="地址"></asp:Label><asp:TextBox CssClass="long" runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox></div>
        <div>
            <asp:Button runat="server" ID="btn_edit" Text="保存" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" /></div>
    </div>
</asp:Content>
