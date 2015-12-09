﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Fendian.aspx.cs" Inherits="JCSJGL.Page_Fendian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>分店管理</title>
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
                            height:480,
                            width:400,
                            modal: true
                        });                
                    udl.parent().appendTo(jQuery("form:first"));          
                }
            });

        //编辑
        function EditInfo(id,fzxb,fzlx,dm,mj,kll,dc,dpxz,zrf,yz,dq,dz,lxr,dh,kdrq,zt,bz,czrid,crsj,xgsj) 
        {
            $("#hid_id").val(id);
            $("#cmb_fzxb").val(fzxb);
            $("#cmb_fzlx").val(fzlx);
            $("#txb_dm").val(dm);
            $("#txb_mj").val(mj);
            $("#txb_kll").val(kll);
            $("#cmb_dc").val(dc);
            $("#cmb_dpxz").val(dpxz);
            $("#txb_zrf").val(zrf);
            $("#txb_yz").val(yz);
            $("#cmb_xzdq").val(dq);
            $("#txb_dz").val(dz);
            $("#txb_lxr").val(lxr);
            $("#txb_dh").val(dh);
            $("#txb_kdrq").val(kdrq);
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
        <div id="div_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_toAdd" runat="server" Text="新增" OnClientClick="Add();return false;" />
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_fendian" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowDeleting="grid_fendian_RowDeleting">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="fzxingbie" HeaderText="服装性质"></asp:BoundField>
            <asp:BoundField DataField="fzleixing" HeaderText="服装类型"></asp:BoundField>
            <asp:BoundField DataField="dianming" HeaderText="店名"></asp:BoundField>
            <asp:BoundField DataField="mianji" HeaderText="面积"></asp:BoundField>
            <asp:BoundField DataField="keliuliang" HeaderText="客流量"></asp:BoundField>
            <asp:BoundField DataField="dangci" HeaderText="档次"></asp:BoundField>
            <asp:BoundField DataField="dpxingzhi" HeaderText="店铺性质"></asp:BoundField>
            <asp:BoundField DataField="zhuanrangfei" HeaderText="转让费"></asp:BoundField>
            <asp:BoundField DataField="yuezu" HeaderText="月租"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="省市"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="地址"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="电话"></asp:BoundField>
            <asp:BoundField DataField="kaidianriqi" HeaderText="开店日期"></asp:BoundField>
            <asp:BoundField DataField="zhuangtai" HeaderText="状态"></asp:BoundField>
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
            <label>服装性质</label><asp:DropDownList runat="server" ID="cmb_fzxz" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>服装类型</label><asp:DropDownList runat="server" ID="cmb_fzlx" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>店名</label><asp:TextBox runat="server" ID="txb_dm" ClientIDMode="Static"></asp:TextBox>
        </div>       
        <div>
            <label>面积</label><asp:TextBox runat="server" ID="txb_mj" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>客流量</label><asp:TextBox runat="server" ID="txb_kll" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>档次</label><asp:DropDownList runat="server" ID="cmb_dc" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>店铺性质</label><asp:DropDownList runat="server" ID="cmb_dpxz" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>转让费</label><asp:TextBox runat="server" ID="txb_zrf" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>月租</label><asp:TextBox runat="server" ID="txb_yz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>省市</label><asp:DropDownList runat="server" ID="cmb_xzdq" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <label>地址</label><asp:TextBox runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>联系人</label><asp:TextBox runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>电话</label><asp:TextBox runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>开店日期</label><asp:TextBox CssClass="singleDate" TextMode="Date" runat="server" ID="txb_kdrq" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label>状态</label><asp:DropDownList runat="server" ID="cmb_zt" ClientIDMode="Static"></asp:DropDownList>
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
