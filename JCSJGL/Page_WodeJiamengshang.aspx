<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_WodeJiamengshang.aspx.cs" Inherits="JCSJGL.Page_WodeJiamengshang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>子加盟商</title>
    <script type="text/javascript">
        function EditInfo(id,bzmc,bz) {
            $("#hid_id").val(id);
            $("#txb_bzmc").val(bzmc);
            $("#txb_bz").val(bz);
            
            ShowEditDialog("div_edit",false);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:GridView ID="grid_xjsq" runat="server" AutoGenerateColumns="False" Caption="加盟申请" DataKeyNames="id" OnRowCommand="grid_xjsq_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="地区"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="详细地址"></asp:BoundField>
            <asp:BoundField DataField="sqsj" HeaderText="申请时间"></asp:BoundField>
            <asp:ButtonField CommandName="YES" Text="同意" ButtonType="Button" ShowHeader="false" />
            <asp:ButtonField CommandName="NO" Text="不同意" ButtonType="Button" ShowHeader="false" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grid_jms" runat="server" AutoGenerateColumns="False" Caption="我的子加盟商">
        <Columns>
            <asp:BoundField DataField="jmsid" Visible="false" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="地区"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商名称"></asp:BoundField>
            <asp:BoundField DataField="bzmingcheng" HeaderText="备注名称"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="联系电话"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="详细地址"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="jmsj" HeaderText="加盟时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改备注"></input>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <label>备注名称</label><asp:TextBox runat="server" ID="txb_bzmc" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>备注</label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>        
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel" Text="取消" OnClientClick="CloseEditDialog('div_edit');return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_edit" CssClass="btnEdit" Text="确定" OnClick="btn_edit_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add" CssClass="btnAdd"  Text="确定" ClientIDMode="Static" />
            </div>
        </div>
    </div>
</asp:Content>
