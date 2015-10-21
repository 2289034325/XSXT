<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Huiyuan.aspx.cs" Inherits="JCSJGL.Page_Huiyuan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>会员管理</title>
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
        function EditInfo(id,sjh,xm,xb,sr,bz)
        {
            $("#hid_id").val(id);
            $("#txb_sjh").val(sjh);
            $("#txb_xm").val(xm);
            $("#cmb_xb").val(xb);
            $("#txb_sr").val(sr);
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div runat="server" id="div_jms">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_huiyuan" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grid_huiyuan_RowDeleting">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="shoujihao" HeaderText="手机号"></asp:BoundField>
            <asp:BoundField DataField="xingming" HeaderText="姓名"></asp:BoundField>
            <asp:BoundField DataField="xingbie" HeaderText="性别"></asp:BoundField>
            <asp:BoundField DataField="shengri" HeaderText="生日"></asp:BoundField>
            <asp:BoundField DataField="jifen" HeaderText="积分"></asp:BoundField>
            <asp:BoundField DataField="jfjsshijian" HeaderText="积分计算时间"></asp:BoundField>
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
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <label>手机号</label><asp:TextBox CssClass="middle" runat="server" ID="txb_sjh" ClientIDMode="Static" Enabled="false"></asp:TextBox>
        </div>
        <div>
            <label>姓名</label><asp:TextBox CssClass="short" runat="server" ID="txb_xm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>性别</label><asp:DropDownList runat="server" ID="cmb_xb" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>生日</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_sr" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>备注</label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
         <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel" Text="取消" OnClientClick="CloseEditDialog('div_edit');return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_edit" CssClass="btnEdit" Text="确定" OnClick="btn_edit_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add" CssClass="btnAdd" Text="确定" ClientIDMode="Static" />
            </div>
        </div>
    </div>

</asp:Content>
