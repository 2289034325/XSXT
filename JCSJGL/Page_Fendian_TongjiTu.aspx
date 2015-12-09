<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Page_Fendian_TongjiTu.aspx.cs" Inherits="JCSJGL.Page_Fendian_TongjiTu" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_head" runat="server">
    <title>销售统计图</title>
    <script type="text/javascript">
        function Search()
        {
            if (IsPC())
            {
                $("#hid_windowWidth").val(Number(document.body.clientWidth) * 0.8);
            }
            else
            {
                $("#hid_windowWidth").val(document.body.clientWidth);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="server">
    <asp:HiddenField runat="server" ID="hid_windowWidth" ClientIDMode="Static" />
    <div id="div_sch" class="div_sch">       
        <div id="div_sch_jms" runat="server">
            <label>加盟商</label><asp:DropDownList runat="server" ID="cmb_jms" AutoPostBack="true" OnSelectedIndexChanged="cmb_jms_SelectedIndexChanged"></asp:DropDownList>
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
        <div>
            <asp:CheckBoxList runat="server" ID="chk_x" RepeatDirection="Horizontal"></asp:CheckBoxList>
        </div>
        <div>
            <asp:Button ID="btn_sch" runat="server" Text="查询" OnClick="btn_sch_Click" OnClientClick="Search()" />
        </div>
    </div>

    <div runat="server" id="div_charts">
    </div>
</asp:Content>
