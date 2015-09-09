<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Fendian.aspx.cs" Inherits="JCSJGL.Page_Fendian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>分店管理</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id,fzxb,fzlx,dm,pp,mj,kll,dc,dpxz,zrf,yz,dq,dz,lxr,dh,kdrq,zt,bz,czrid,crsj,xgsj) {
            $("#hid_id").val(id);
            $("#cmb_fzxb").val(fzxb);
            $("#cmb_fzlx").val(fzlx);
            $("#txb_dm").val(dm);
            $("#cmb_pp").val(pp);
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
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch" class="div_sch" runat="server">
        <div>
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
        </div>
    </div>
    <asp:GridView ID="grid_fendian" runat="server" AutoGenerateColumns="False" BackColor="White" DataKeyNames="id"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDeleting="grid_fendian_RowDeleting">
        <Columns>
            <asp:BoundField DataField="jiamengshang" HeaderText="加盟商"></asp:BoundField>
            <asp:BoundField DataField="id" HeaderText="ID"></asp:BoundField>
            <asp:BoundField DataField="fzxingbie" HeaderText="服装性质"></asp:BoundField>
            <asp:BoundField DataField="fzleixing" HeaderText="服装类型"></asp:BoundField>
            <asp:BoundField DataField="dianming" HeaderText="店名"></asp:BoundField>
            <asp:BoundField DataField="pinpai" HeaderText="品牌"></asp:BoundField>
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
    <%--<asp:HiddenField runat="server" ID="hid_opt" ClientIDMode="Static" />--%>
    <asp:HiddenField runat="server" ID="hid_id" ClientIDMode="Static" />
    <div id="div_edit" class="div_edit">
        <div>
            <asp:Label runat="server" Text="服装性质"></asp:Label><asp:DropDownList runat="server" ID="cmb_fzxz" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="服装类型"></asp:Label><asp:DropDownList runat="server" ID="cmb_fzlx" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="店名"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_dm" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="品牌"></asp:Label><asp:DropDownList runat="server" ID="cmb_pp" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="面积"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_mj" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="客流量"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_kll" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="档次"></asp:Label><asp:DropDownList runat="server" ID="cmb_dc" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="店铺性质"></asp:Label><asp:DropDownList runat="server" ID="cmb_dpxz" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="转让费"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_zrf" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="月租"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_yz" ClientIDMode="Static"></asp:TextBox>
        </div>        
        <div>
            <asp:Label runat="server" Text="省市"></asp:Label><asp:DropDownList runat="server" ID="cmb_xzdq" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="地址"></asp:Label><asp:TextBox CssClass="long" runat="server" ID="txb_dz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="联系人"></asp:Label><asp:TextBox CssClass="middle" runat="server" ID="txb_lxr" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="电话"></asp:Label><asp:TextBox CssClass="short" runat="server" ID="txb_dh" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="开店日期"></asp:Label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_kdrq" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Label runat="server" Text="状态"></asp:Label><asp:DropDownList runat="server" ID="cmb_zt" ClientIDMode="Static"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" Text="备注"></asp:Label><asp:TextBox CssClass="large" runat="server" ID="txb_bz" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btn_edit" Text="保存" OnClick="btn_edit_Click" /><asp:Button runat="server" ID="btn_add" Text="增加" OnClick="btn_add_Click" />
        </div>
    </div>
</asp:Content>
