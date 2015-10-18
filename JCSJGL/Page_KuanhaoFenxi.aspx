<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_KuanhaoFenxi.aspx.cs" Inherits="JCSJGL.Page_KuanhaoFenxi" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>款号分析</title>
    <script type="text/javascript">
        //$(document).ready(
        //   function ()
        //   {
        //       $("area").click(function () { window.location.href=this.href; return false;});
        //   });
        function Search()
        {
            $("#hid_windowWidth").val(document.body.clientWidth);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:HiddenField runat="server" ID="hid_windowWidth" ClientIDMode="Static" />
    <div id="div_sch" class="div_sch">
        <div id="div_sch_jms" runat="server">
            <label>品牌商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true" OnSelectedIndexChanged="cmb_jms_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div id="div_sch_zjms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_zjms" AutoPostBack="true" OnSelectedIndexChanged="cmb_zjms_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div>
            <label>分店</label><asp:DropDownList runat="server" ID="cmb_fd"></asp:DropDownList>
        </div>
        <div>
            <label>销售日期</label><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_xsrq_start"></asp:TextBox><asp:TextBox CssClass="middle" TextMode="Date" runat="server" ID="txb_xsrq_end"></asp:TextBox>
        </div>
        <div>
            <label>Y轴</label><asp:DropDownList runat="server" ID="cmb_y"></asp:DropDownList>
        </div>
        <div style="overflow:scroll;">
            <asp:CheckBoxList runat="server" ID="chk_x" RepeatDirection="Horizontal"></asp:CheckBoxList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" OnClientClick="Search()" />
        </div>
    </div>

    <div runat="server" id="div_charts">
    </div>
</asp:Content>
