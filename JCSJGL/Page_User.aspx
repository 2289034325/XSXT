<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_User.aspx.cs" Inherits="JCSJGL.Page_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>系统用户</title>
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
                            height:260,
                            width:400,
                            modal: true
                        });                
                    udl.parent().appendTo(jQuery("form:first"));                    
                    
                    var fddl = $( "#div_cmb_fds" ).dialog(
                        {
                            autoOpen: false,
                            resizable: false,
                            height:130,
                            width:400,
                            modal: true
                        });                
                    fddl.parent().appendTo(jQuery("form:first"));    
                }
            });

        //编辑
        function EditInfo(id,dlm,yhm,js,zt,bz) {
            $("#hid_id").val(id);
            $("#txb_dlm").val(dlm);
            $("#txb_mm").val('');
            $("#txb_yhm").val(yhm);
            $("#cmb_js").val(js);
            $("#cmb_zt").val(zt);
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

        function AddUser()
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
        <div id="div_sch_pps" runat="server">
            <label>品牌商</label><asp:DropDownList runat="server" CssClass="middle" ID="cmb_pps"></asp:DropDownList>
        </div>
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" CssClass="middle" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div id="div_sch_xtyh" runat="server">
            <label>系统用户</label><asp:CheckBox runat="server" ID="chk_xtyh" />
        </div>
        <div>
            <asp:Button ID="btn_toAdd" runat="server" Text="新增" OnClientClick="AddUser();return false;" />
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>

    <asp:GridView ID="grid_yonghu" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_yonghu_RowCommand">
        <Columns>
            <asp:BoundField DataField="pinpaishang" HeaderText="品牌商"></asp:BoundField>
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
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Button" ShowHeader="false" ItemStyle-CssClass="delete" />           
        </Columns>
    </asp:GridView>    
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">       
        <div>
            <label>登录名</label><asp:TextBox runat="server" ID="txb_dlm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>密码</label><asp:TextBox runat="server" ID="txb_mm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>用户名</label><asp:TextBox runat="server" ID="txb_yhm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>角色</label><asp:DropDownList runat="server" ID="cmb_js" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>状态</label><asp:DropDownList runat="server" ID="cmb_zt" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>备注</label><asp:TextBox runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel" CssClass="btnCancel" Text="取消" OnClientClick="CloseEditDialog('div_edit');return false;" />
            </div>
            <div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_edit" CssClass="btnEdit" Text="确定" OnClick="btn_edit_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add" CssClass="btnAdd" Text="确定" OnClick="btn_add_Click" ClientIDMode="Static" />
            </div>
        </div>
    </div>
</asp:Content>
