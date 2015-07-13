<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_TongjiBaobiao.aspx.cs" Inherits="JCSJGL.Page_TongjiBaobiao" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>统计报表</title>
    <script type="text/javascript">
        function Search()
        {
            $("#hid_windowWidth").val(document.body.clientWidth);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:HiddenField runat="server" ID="hid_windowWidth" ClientIDMode="Static" />
    <div id="div_sch" class="div_sch">
        <div><label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList></div>
        <div><label>销售日期</label><asp:TextBox CssClass="middle"  runat="server" ID="txb_xsrq_start"></asp:TextBox><asp:TextBox CssClass="middle"  runat="server" ID="txb_xsrq_end"></asp:TextBox></div>
        <div><label>图表类型</label><asp:DropDownList runat="server" ID="cmb_ctype"></asp:DropDownList></div>
        <div><asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" OnClientClick="Search()" /></div>
    </div>

    <div>
        <asp:Chart ID="cht_date" runat="server">        
        </asp:Chart>
    </div>    
    <div>
        <asp:Chart ID="cht_hour" runat="server">        
        </asp:Chart>
    </div>
    <div>
        <asp:Chart ID="cht_week" runat="server">        
        </asp:Chart>
    </div>
    <div>
        <asp:Chart ID="cht_pie_type" runat="server">        
        </asp:Chart>
    </div>
    <div>
        <asp:Chart ID="cht_pie_price" runat="server">        
        </asp:Chart>
    </div>
</asp:Content>
