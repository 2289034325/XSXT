<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_JiamengshangXinxi.aspx.cs" Inherits="JCSJGL.Page_JiamengshangXinxi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>加盟商管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,mc,sjh,yx,dq,dz,lxr,dh,bz,fjmss,zjmss,pps,zhs,khs,tms,hys,fds,cks,gyss,xsjls,jchjls,kcjls,scff,xfdj,jzrq) {
            $("#hid_id").val(id);
            $("#txb_mc").val(mc);
            $("#txb_sjh").val(sjh);
            $("#txb_yx").val(yx);
            $("#cmb_xzdq").val(dq);
            $("#txb_lxr").val(lxr);
            $("#txb_dh").val(dh);
            $("#txb_dz").val(dz);
            $("#txb_bz").val(bz);   
            
            $("#txb_fjmss").val(fjmss);
            $("#txb_zjmss").val(zjmss);
            $("#txb_pps").val(pps);
            $("#txb_zhs").val(zhs);
            $("#txb_khs").val(khs);
            $("#txb_tms").val(tms);
            $("#txb_hys").val(hys);
            $("#txb_fds").val(fds);
            $("#txb_cks").val(cks);
            $("#txb_gyss").val(gyss);
            $("#txb_xsjls").val(xsjls);
            $("#txb_jchjls").val(jchjls);
            $("#txb_kcjls").val(kcjls);
            $("#txb_scff").val(scff);
            $("#txb_xfdj").val(xfdj);
            $("#txb_jzrq").val(jzrq);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:GridView ID="grid_jiamengshang" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="id" OnRowCommand="grid_jiamengshang_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="mingcheng" HeaderText="名称"></asp:BoundField>
            <asp:BoundField DataField="shoujihao" HeaderText="手机号"></asp:BoundField>
            <asp:BoundField DataField="youxiang" HeaderText="邮箱"></asp:BoundField>
            <asp:BoundField DataField="diqu" HeaderText="地区"></asp:BoundField>
            <asp:BoundField DataField="dizhi" HeaderText="地址"></asp:BoundField>
            <asp:BoundField DataField="lianxiren" HeaderText="联系人"></asp:BoundField>
            <asp:BoundField DataField="dianhua" HeaderText="电话"></asp:BoundField>
            <asp:BoundField DataField="beizhu" HeaderText="备注"></asp:BoundField>
            <asp:BoundField DataField="fjmsshu" HeaderText="父加盟商数"></asp:BoundField>
            <asp:BoundField DataField="zjmsshu" HeaderText="子加盟商数"></asp:BoundField>
            <asp:BoundField DataField="ppshu" HeaderText="品牌数"></asp:BoundField>
            <asp:BoundField DataField="ppshu" HeaderText="品牌数"></asp:BoundField>
            <asp:BoundField DataField="zhanghaoshu" HeaderText="账号数"></asp:BoundField>
            <asp:BoundField DataField="kuanhaoshu" HeaderText="款号数"></asp:BoundField>
            <asp:BoundField DataField="tiaomashu" HeaderText="条码数"></asp:BoundField>
            <asp:BoundField DataField="huiyuanshu" HeaderText="会员数"></asp:BoundField>
            <asp:BoundField DataField="fendianshu" HeaderText="分店数"></asp:BoundField>
            <asp:BoundField DataField="cangkushu" HeaderText="仓库数"></asp:BoundField>
            <asp:BoundField DataField="gongyingshangshu" HeaderText="供应商数"></asp:BoundField>
            <asp:BoundField DataField="xsjilushu" HeaderText="销售记录数"></asp:BoundField>
            <asp:BoundField DataField="jchjilushu" HeaderText="进出货记录数"></asp:BoundField>
            <asp:BoundField DataField="kcjilushu" HeaderText="库存记录数"></asp:BoundField>
            <asp:BoundField DataField="shoucifufei" HeaderText="首付收费"></asp:BoundField>
            <asp:BoundField DataField="xufeidanjia" HeaderText="续费单价"></asp:BoundField>
            <asp:BoundField DataField="jiezhiriqi" HeaderText="截止日期"></asp:BoundField>
            <asp:BoundField DataField="charushijian" HeaderText="插入时间"></asp:BoundField>
            <asp:BoundField DataField="xiugaishijian" HeaderText="修改时间"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <input type="button" onclick="EditInfo(<%# Eval("editParams")%>)" value="修改"></input>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btn_delete" runat="server" OnClientClick="return confirm('确定删除吗?')" Text="刪除" CommandName="SC" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>
        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>
        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>
        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>
        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>
        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
    </asp:GridView>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <asp:Label runat="server" Text="名称"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_mc" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="注册手机号"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_sjh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="注册邮箱"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_yx" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="省市"></asp:Label><asp:DropDownList runat="server" ID="cmb_xzdq" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="地址"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="联系人"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="电话"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="父加盟商数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_fjmss" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="子加盟商数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_zjmss" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="品牌数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_pps" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="账号数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_zhs" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="款号数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_khs" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="条码数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_tms" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="会员数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_hys" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="分店数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_fds" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="仓库数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_cks" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="供应商数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_gyss" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="销售记录数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_xsjls" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="进出货记录数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_jchjls" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="库存记录数"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_kcjls" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="首次付费"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_scff" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="续费单价"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_xfdj" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="截止日期"></asp:Label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_jzrq" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btn_edit" Text="保存" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />
        </div>
    </div>
</asp:Content>
