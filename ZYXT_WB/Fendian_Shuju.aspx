﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Fendian_Shuju.aspx.cs" Inherits="ZYXT_WB.Fendian_Xinxi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>分店信息</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_grid_fdxx">
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField HeaderText="ID"></asp:BoundField>
                <asp:BoundField HeaderText="店名"></asp:BoundField>
                <asp:BoundField HeaderText="地址"></asp:BoundField>
                <asp:BoundField HeaderText="联系人"></asp:BoundField>
                <asp:BoundField HeaderText="电话"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
