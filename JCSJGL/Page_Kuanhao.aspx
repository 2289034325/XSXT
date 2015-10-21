<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Kuanhao.aspx.cs" Inherits="JCSJGL.Page_Kuanhao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>款号管理</title>
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
        function EditInfo(id,kh,lx,xb,pm,bz) {
            $("#hid_id").val(id);
            $("#txb_kh").val(kh);
            $("#cmb_lx").val(lx);
            $("#cmb_xb").val(xb);
            $("#txb_pm").val(pm);
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
            <asp:Button ID="btn_toAdd" runat="server" Text="新增" OnClientClick="Add();return false;" />
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_kuanhao" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grid_kuanhao_RowDeleting"
        AllowCustomPaging="true" AllowPaging="true" PageSize="20" OnPageIndexChanging="grid_kuanhao_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
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
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_kuanhao.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_kuanhao.PageCount %>" />
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <label>款号</label><asp:TextBox CssClass="middle" runat="server" ID="txb_kh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>类型</label><asp:DropDownList runat="server" ID="cmb_lx" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>性别</label><asp:DropDownList runat="server" ID="cmb_xb" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>品名</label><asp:TextBox CssClass="middle" runat="server" ID="txb_pm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>备注</label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel" Text="取消" OnClientClick="CloseEditDialog();return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_edit" CssClass="btnEdit" Text="确定" OnClick="btn_edit_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add" CssClass="btnAdd" Text="确定" OnClick="btn_add_Click" ClientIDMode="Static" />
            </div>
        </div>
    </div>
</asp:Content>

