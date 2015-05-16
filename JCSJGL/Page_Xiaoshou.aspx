﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Xiaoshou.aspx.cs" Inherits="JCSJG.Page_Xiaoshou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>销售记录</title>
    <script type="text/javascript">
        //编辑
        function EditInfo(id, tm, ys, cm, jj, sj, kh, gys, gyskh, ms) {
            $("#hid_id").val(id);
            $("#txb_tm").val(tm);
            $("#txb_ys").val(ys);
            $("#txb_cm").val(cm);
            $("#txb_jj").val(jj);
            $("#txb_sj").val(sj);
            $("#txb_kh").val(kh);
            $("#txb_gyskh").val(gyskh);
        }

        //删除
        function Delete(id) {
            $("#hid_opt").val("DELETE");
            $("#hid_id").val(id);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <div id="div_sch">
        <label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList>
        <label>销售日期</label><asp:TextBox runat="server" ID="txb_xsrq_start"></asp:TextBox><asp:TextBox runat="server" ID="txb_xsrq_end"></asp:TextBox>
        <label>上报日期</label><asp:TextBox runat="server" ID="txb_sbrq_start"></asp:TextBox><asp:TextBox runat="server" ID="txb_sbrq_end"></asp:TextBox>
        <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" />
    </div>
    <asp:GridView ID="grid_xiaoshou" runat="server" AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="true" PageSize="10"
        BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grid_xiaoshou_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="fendian" HeaderText="分店"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
            <asp:BoundField DataField="danjia" HeaderText="单价"></asp:BoundField>
            <asp:BoundField DataField="zhekou" HeaderText="折扣"></asp:BoundField>
            <asp:BoundField DataField="moling" HeaderText="抹零"></asp:BoundField>
            <asp:BoundField DataField="jiage" HeaderText="价格"></asp:BoundField>
            <asp:BoundField DataField="huiyuan" HeaderText="会员"></asp:BoundField>
            <asp:BoundField DataField="xiaoshouyuan" HeaderText="销售员"></asp:BoundField>
            <asp:BoundField DataField="xiaoshoushijian" HeaderText="销售时间"></asp:BoundField>
            <asp:BoundField DataField="shangbaoshijian" HeaderText="上报时间"></asp:BoundField>
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
        <PagerSettings Mode="Numeric" Visible="true" />
    </asp:GridView>

</asp:Content>