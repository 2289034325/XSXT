<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_TongjiBaobiao.aspx.cs" Inherits="JCSJGL.Page_TongjiBaobiao" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>统计报表</title>
    <script type="text/javascript">
        function Search()
        {
            $("#hid_windowWidth").val($(window).width());
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:HiddenField runat="server" ID="hid_windowWidth" ClientIDMode="Static" />
    <div id="div_sch">
        <label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList>
        <label>销售日期</label><asp:TextBox runat="server" ID="txb_xsrq_start"></asp:TextBox><asp:TextBox runat="server" ID="txb_xsrq_end"></asp:TextBox>
        <label>图表类型</label><asp:DropDownList runat="server" ID="cmb_ctype"></asp:DropDownList>
        <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" OnClientClick="Search()" />
    </div>
    <asp:Chart ID="cht_date" runat="server">        
    </asp:Chart>
    <asp:Chart ID="cht_hour" runat="server">        
    </asp:Chart>
    <asp:Chart ID="cht_week" runat="server">        
    </asp:Chart>
    <asp:Chart ID="cht_fds_today" runat="server">        
    </asp:Chart>
    <asp:Chart ID="cht_fds_period" runat="server">        
    </asp:Chart>

</asp:Content>
