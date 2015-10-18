<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_FDJinchuhuoMX.aspx.cs" Inherits="JCSJGL.Page_FDJinchuhuoMX" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>进出货明细</title>
    <script type="text/javascript">

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">   
    <asp:GridView ID="grid_mx" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="tiaoma" HeaderText="条码"></asp:BoundField>
            <asp:BoundField DataField="kuanhao" HeaderText="款号"></asp:BoundField>
            <asp:BoundField DataField="gyskuanhao" HeaderText="供应商款号"></asp:BoundField>
            <asp:BoundField DataField="leixing" HeaderText="类型"></asp:BoundField>
            <asp:BoundField DataField="pinming" HeaderText="品名"></asp:BoundField>
            <asp:BoundField DataField="yanse" HeaderText="颜色"></asp:BoundField>
            <asp:BoundField DataField="chima" HeaderText="尺码"></asp:BoundField>
            <asp:BoundField DataField="jinjia" HeaderText="进价"></asp:BoundField>
            <asp:BoundField DataField="shoujia" HeaderText="售价"></asp:BoundField>
            <asp:BoundField DataField="shuliang" HeaderText="数量"></asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
