<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Gongyingshang.aspx.cs" Inherits="JCSJGL.Page_Gongyingshang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>供应商管理</title>
    <script type="text/javascript">
        $(document).ready(
            function () {
                $(".delete").click(function () 
                {
                    return confirm('是否确定删除?');
                });

                if(IsPC())
                {
                    var udl = $( "#div_edit" ).dialog(
                        {
                            autoOpen: false,
                            resizable: false,
                            height:220,
                            width:400,
                            modal: true
                        });                
                    udl.parent().appendTo(jQuery("form:first"));              
                }
            });

        //编辑
        function EditInfo(id,mc,lxr,dh,dz,bz) {
            $("#hid_id").val(id);
            $("#txb_mc").val(mc);
            $("#txb_lxr").val(lxr);
            $("#txb_dh").val(dh);
            $("#txb_dz").val(dz);
            $("#txb_bz").val(bz);
            if(IsPC())
            {            
                $(".btnAdd").css("display","none");
                $(".btnEdit").css("display","");
                $( "#div_edit" ).dialog( "option", "title", "修改" );
                $( "#div_edit" ).dialog().dialog( "open" );
            }
            else
            {                
                ShowEditDialog("div_edit",false);
            }
        }

        function Add()
        {
            if(IsPC())
            {
                $(".btnAdd").css("display","");
                $(".btnEdit").css("display","none");
                $( "#div_edit" ).dialog( "option", "title", "新增" );
                $( "#div_edit" ).dialog().dialog( "open" );
            }
            else
            {
                ShowEditDialog('div_edit',true);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div runat="server" id="div_pps">
            <label>品牌商</label><asp:DropDownList runat="server" ID="cmb_pps" CssClass="middle"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_toAdd" runat="server" Text="新增" OnClientClick="Add();return false;" />
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_gys" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grid_gys_RowDeleting">
        <Columns>
            <asp:BoundField DataField="pinpaishang" HeaderText="品牌商"></asp:BoundField>
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
    </asp:GridView>
    <%--<asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />--%>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <label>名称</label><asp:TextBox runat="server" ID="txb_mc" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>联系人</label><asp:TextBox runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>电话</label><asp:TextBox runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>地址</label><asp:TextBox runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>备注</label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel" Text="取消" OnClientClick="CloseEditDialog('div_edit');return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_edit" CssClass="btnEdit" Text="确定" OnClick="btn_edit_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add" CssClass="btnAdd" Text="确定" OnClick="btn_add_Click" ClientIDMode="Static" />
            </div>
        </div>
    </div>
</asp:Content>
