<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_JMSFahuoTuihuo.aspx.cs" Inherits="JCSJGL.Page_JMSFahuoTuihuo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>发货退货单</title>
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
                            height:150,
                            width:400,
                            modal: true
                        });                
                    udl.parent().appendTo(jQuery("form:first"));        

                    var mxdl = $( "#div_edit_mx" ).dialog(
                         {
                             autoOpen: false,
                             resizable: false,
                             height:150,
                             width:400,
                             modal: true                             
                         });     
                    mxdl.parent().appendTo(jQuery("form:first"));
                }
            });
        function EditJc(id,zk,bz) 
        {
            $("#hid_jcid").val(id);
            $("#txb_zk").val(zk);
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
        function AddMx(jcid) 
        {
            if(IsPC())
            {
                $("#hid_jcid").val(jcid);     
                $(".btnAdd").css("display","");
                $(".btnEdit").css("display","none");           
                $( "#div_edit_mx" ).dialog( "option", "title", "增加" );
                $( "#div_edit_mx" ).dialog().dialog( "open" );
            }
            else
            {                
                ShowEditDialog("div_edit_mx",true);
            }
        } 
        function EditMx(id,tm,jhj) 
        {
            $("#hid_mxid").val(id);
            $("#txb_tm_edit").val(tm);
            $("#txb_jhj").val(jhj);

            if(IsPC())
            {            
                $(".btnAdd").css("display","none");
                $(".btnEdit").css("display","");
                $( "#div_edit_mx" ).dialog( "option", "title", "修改" );
                $( "#div_edit_mx" ).dialog().dialog( "open" );
            }
            else
            {                
                ShowEditDialog("div_edit_mx",false);
            }
        } 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch">
        <div id="div_sch_dls" runat="server">
            <label>代理商</label><asp:DropDownList runat="server" ID="cmb_dls" AutoPostBack="true" OnSelectedIndexChanged="cmb_dls_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <label>条码</label><asp:TextBox CssClass="middle" TextMode="SingleLine" runat="server" ID="txb_tm"></asp:TextBox>
        </div>
        <div>
            <label>发生日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_fsrq_end"></asp:TextBox>
        </div>
        <div class="twoButtonInline left">
            <asp:Button ID="btn_fahuo" runat="server" Text="发货" OnClick="btn_fahuo_Click" />
            </div><div class="twoButtonInline">
            <asp:Button ID="btn_tuihuo" runat="server" Text="退货" OnClick="btn_tuihuo_Click" />
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_jc" runat="server" AutoGenerateColumns="False" OnRowCommand="grid_jc_RowCommand" DataKeyNames="id"
        AllowCustomPaging="true" AllowPaging="true" OnPageIndexChanging="grid_jc_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="dailishang" HeaderText="代理商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="fashengriqi" HeaderText="发生日期"></asp:BoundField>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="fangxiang" HeaderText="方向"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
            <asp:BoundField DataField="jine" HeaderText="金额"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="登记时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditJc(<%# Eval("editParams")%>)" value="修改"></input>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="AddMx(<%# Eval("editParams")%>)" value="增加一件"></input>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="MX" Text="查看明细" ButtonType="Button" ShowHeader="false" />
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Button" ShowHeader="false" ItemStyle-CssClass="delete" />
        </Columns>
        <PagerSettings Mode="NextPrevious" Visible="true" NextPageText="Next" PreviousPageText="Prev" />   
    </asp:GridView>
    <input type="hidden" id="hid_pageIndex" value="<%= grid_jc.PageIndex %>" />
    <input type="hidden" id="hid_pageCount" value="<%= grid_jc.PageCount %>" />

    <asp:GridView ID="grid_mx" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="grid_mx_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名" Visible="false"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="diaopaijia" HeaderText="吊牌价"></asp:BoundField>
            <asp:BoundField DataField="jinhuojia" HeaderText="拿货价"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditMx(<%# Eval("editParams")%>)" value="修改"></input>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="DEL" Text="删除" ButtonType="Button" ShowHeader="false" ItemStyle-CssClass="delete" />
        </Columns>
    </asp:GridView>
    <div id="div_edit" class="div_edit">        
        <div>
            <label>折扣</label><asp:TextBox  runat="server" ID="txb_zk" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>备注</label><asp:TextBox  runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel" Text="取消" OnClientClick="CloseEditDialog('div_edit');return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_save_jc" CssClass="btnEdit" Text="确定" OnClick="btn_save_jc_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add"  CssClass="btnAdd" Text="确定" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <div id="div_edit_mx" class="div_edit">
        <div>
            <label>条码</label><asp:TextBox runat="server" ID="txb_tm_edit" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>进货价</label><asp:TextBox  runat="server" ID="txb_jhj" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <div class="twoButtonInline left">
                <asp:Button runat="server" ID="btn_cancel2" Text="取消" OnClientClick="CloseEditDialog('div_edit_mx');return false;" />
            </div><div class="twoButtonInline">
                <asp:Button runat="server" ID="btn_save_mx" CssClass="btnEdit" Text="确定" OnClick="btn_save_mx_Click" ClientIDMode="Static" />
                <asp:Button runat="server" ID="btn_add_mx"  CssClass="btnAdd" Text="确定" OnClick="btn_add_mx_Click" ClientIDMode="Static" />
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hid_jcid" ClientIDMode="Static" />
    <asp:HiddenField runat="server" ID="hid_mxid" ClientIDMode="Static" />

</asp:Content>
