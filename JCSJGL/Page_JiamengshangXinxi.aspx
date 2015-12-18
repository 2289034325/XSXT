<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_JiamengshangXinxi.aspx.cs" Inherits="JCSJGL.Page_JiamengshangXinxi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>加盟商管理</title>
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
                            height:450,
                            width:400,
                            modal: true
                        });                
                    udl.parent().appendTo(jQuery("form:first"));               
                }
            });

        //编辑
        function EditInfo(id,mc,sjh,yx,dq,dz,lxr,dh,bz,pps,zhs,hys,fds,xsjls,jchjls,kcjls) {
            $("#hid_id").val(id);
            $("#txb_mc").val(mc);
            $("#txb_sjh").val(sjh);
            $("#txb_yx").val(yx);
            $("#cmb_xzdq").val(dq);
            $("#txb_dz").val(dz);
            $("#txb_lxr").val(lxr);
            $("#txb_dh").val(dh);
            $("#txb_bz").val(bz);   
            
            $("#txb_pps").val(pps);
            $("#txb_zhs").val(zhs);
            $("#txb_hys").val(hys);
            $("#txb_fds").val(fds);
            $("#txb_xsjls").val(xsjls);
            $("#txb_jchjls").val(jchjls);
            $("#txb_kcjls").val(kcjls);

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">               
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_jiamengshang" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_jiamengshang_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="mingcheng" HeaderText="名称"></asp:BoundField>
            <asp:BoundField DataField="daima" HeaderText="代码"></asp:BoundField>
            <asp:BoundField DataField="shoujihao" HeaderText="手机号"></asp:BoundField>
            <asp:BoundField DataField="youxiang" HeaderText="邮箱"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="地区"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="地址"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="电话"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="pinpaishu" HeaderText="品牌数"></asp:BoundField>
            <asp:BoundField DataField="zhanghaoshu" HeaderText="账号数"></asp:BoundField>
            <asp:BoundField DataField="huiyuanshu" HeaderText="会员数"></asp:BoundField>
            <asp:BoundField DataField="fendianshu" HeaderText="分店数"></asp:BoundField>
            <asp:BoundField DataField="xsjilushu" HeaderText="销售记录数"></asp:BoundField>
            <asp:BoundField DataField="jchjilushu" HeaderText="进出货记录数"></asp:BoundField>
            <asp:BoundField DataField="kcjilushu" HeaderText="库存记录数"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改"></input>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="SC" Text="删除" ButtonType="Button" ShowHeader="false" ItemStyle-CssClass="delete" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <label>名称</label><asp:TextBox CssClass="middle" runat="server" ID="txb_mc" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>注册手机号</label><asp:TextBox CssClass="middle" runat="server" ID="txb_sjh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>注册邮箱</label><asp:TextBox CssClass="middle" runat="server" ID="txb_yx" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>省市</label><asp:DropDownList runat="server" ID="cmb_xzdq" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>地址</label><asp:TextBox CssClass="large" runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>联系人</label><asp:TextBox CssClass="middle" runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>电话</label><asp:TextBox CssClass="middle" runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>备注</label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>品牌数</label><asp:TextBox CssClass="short" runat="server" ID="txb_pps" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>账号数</label><asp:TextBox CssClass="short" runat="server" ID="txb_zhs" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>会员数</label><asp:TextBox CssClass="short" runat="server" ID="txb_hys" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>分店数</label><asp:TextBox CssClass="short" runat="server" ID="txb_fds" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>销售记录数</label><asp:TextBox CssClass="short" runat="server" ID="txb_xsjls" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>进出货记录数</label><asp:TextBox CssClass="short" runat="server" ID="txb_jchjls" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>库存记录数</label><asp:TextBox CssClass="short" runat="server" ID="txb_kcjls" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="Button1" Text="取消" OnClientClick="CloseEditDialog('div_edit');return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_add" CssClass="btnAdd" Text="确定" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_edit" CssClass="btnEdit" Text="确定" OnClick="btn_edit_Click" ClientIDMode="Static" />
            </div>
        </div>
    </div>
</asp:Content>
