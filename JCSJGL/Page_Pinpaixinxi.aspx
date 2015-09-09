<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_PinpaiXinxi.aspx.cs" Inherits="JCSJGL.Page_PinpaiXinxi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>品牌信息</title>
    <script type="text/javascript">   
        //修改品牌信息
        function EditInfo(id,mc,sfjsjm)
        {
            $("#hid_id").val(id);
            $("#txb_ppmc").val(mc);
            $("#cmb_sfjsjm").val(sfjsjm);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div runat="server" id="div_pp">
        <asp:GridView ID="grid_ycpp" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowDeleting="grid_ycpp_RowDeleting">
            <Columns>
                <asp:BoundField DataField="jms" HeaderText="加盟商"></asp:BoundField>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
                <asp:BoundField DataField="mingcheng" HeaderText="品牌名称"></asp:BoundField>
                <asp:BoundField DataField="kejiameng" HeaderText="是否接受加盟"></asp:BoundField>
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
        <div id="div_ppedit" class="div_edit">
            <div>
                <asp:Label runat="server" Text="名称"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_ppmc" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="是否接受加盟"></asp:Label><asp:DropDownList runat="server" ID="cmb_sfjsjm" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div>
                <asp:Button runat="server" ID="btn_pp_edit" Text="保存" OnClick="btn_pp_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />
            </div>
        </div>
    </div>
</asp:Content>
