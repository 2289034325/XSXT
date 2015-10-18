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

                var fddl = $( "#div_cmb_fds" ).dialog(
                    {
                        autoOpen: false,
                        resizable: false,
                        height:220,
                        width:400,
                        modal: true,
                        buttons: 
                            {
                                "确定": function() 
                                {
                                    $("#btn_fdsel_ok").trigger('click');
                                },
                                "取消": function() {
                                    $( this ).dialog( "close" );
                                }
                            }
                    });                
                fddl.parent().appendTo(jQuery("form:first"));       
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
        }

        //给店长角色增加一个管辖的分店
        function AddFendian(id)
        {            
            $("#hid_id").val(id);
            $( "#div_cmb_fds" ).dialog().dialog( "open" );
        }
    </script>
     <style type="text/css">
        .invisible {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>

    <asp:GridView ID="grid_yonghu" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_yonghu_RowCommand">
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
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Link" ShowHeader="false" ItemStyle-CssClass="delete" />
            <asp:ButtonField CommandName="FDS" Text="查看分店" ButtonType="Link" ShowHeader="false" />
             <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="AddFendian(<%# Eval("editParams")%>)" value="增加分店"></input>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="grid_ufs" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_ufs_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="dianming" HeaderText="店名"></asp:BoundField>
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Link" ShowHeader="false" ItemStyle-CssClass="delete" />
        </Columns>
    </asp:GridView>
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

    <div id="div_cmb_fds" class="ui-widget">
        <div>
            <asp:Label runat="server" Text="分店"></asp:Label><asp:DropDownList runat="server" ID="cmb_fd" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <asp:Button runat="server" ID="btn_fdsel_ok" OnClick="btn_fdsel_ok_Click" ClientIDMode="Static" Text="确定" CssClass="invisible" />
    </div>
</asp:Content>
