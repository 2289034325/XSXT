<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Tiaoma.aspx.cs" Inherits="JCSJGL.Page_Tiaoma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>条码信息</title>
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
                         height:270,
                         width:400,
                         modal: true
                     });                
                 udl.parent().appendTo(jQuery("form:first"));          
             }
         });

        //编辑
        function EditInfo(id,tm,ys,cm,jj,sj,gysid,gyskh) {
            $("#hid_id").val(id);
            $("#txb_tm").val(tm);
            $("#txb_ys").val(ys);
            $("#txb_cm").val(cm);
            $("#txb_jj").val(jj);
            $("#txb_sj").val(sj);
            $("#cmb_gys").val(gysid);
            $("#txb_gyskh").val(gyskh);

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
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <label>类型</label><asp:DropDownList runat="server" ID="cmb_lx"></asp:DropDownList>
        </div>
        <div>
            <label>款号</label><asp:TextBox CssClass="short" runat="server" ID="txb_kh_sch"></asp:TextBox>
        </div>
        <div>
            <label>条码号</label><asp:TextBox CssClass="middle" runat="server" ID="txb_tmh_sch"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_tiaoma" runat="server" AutoGenerateColumns="False"
        AllowCustomPaging="true" AllowPaging="true" PageSize="20" DataKeyNames="id" OnRowDeleting="grid_tiaoma_RowDeleting" OnPageIndexChanging="grid_tiaoma_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="gongyingshang" HeaderText="供应商"></asp:BoundField>
            <asp:BoundField DataField="gyskuanhao" HeaderText="供应商款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="jinjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="shoujia" HeaderText="售价"></asp:BoundField>
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
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />   
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_tiaoma.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_tiaoma.PageCount %>" />
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <label>条码</label><asp:TextBox CssClass="middle" runat="server" ID="txb_tm" Enabled="false" ClientIDMode="Static"></asp:TextBox>
        </div>
        <%--<div>
            <label>款号</label><asp:TextBox CssClass="short" runat="server" ID="txb_kh" ClientIDMode="Static"></asp:TextBox>
        </div>--%>
        <div>
            <label>供应商</label><asp:DropDownList runat="server" ID="cmb_gys" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label style="font-size:0.9em;">供应商款号</label><asp:TextBox CssClass="short" runat="server" ID="txb_gyskh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>颜色</label><asp:TextBox CssClass="short" runat="server" ID="txb_ys" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>尺码</label><asp:TextBox CssClass="short" runat="server" ID="txb_cm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>进价</label><asp:TextBox CssClass="short" runat="server" ID="txb_jj" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>售价</label><asp:TextBox CssClass="short" runat="server" ID="txb_sj" ClientIDMode="Static"></asp:TextBox>
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
