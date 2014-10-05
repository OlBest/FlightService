<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowTickets.aspx.cs" Inherits="Flight_Server.ShowTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Информация о билетах&nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="TableTickets" runat="server" Height="28px" Width="435px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Enabled="False">Оправление</asp:TableCell>
            <asp:TableCell runat="server" Enabled="False">Прибытие</asp:TableCell>
            <asp:TableCell runat="server" Enabled="False">Имя</asp:TableCell>
            <asp:TableCell runat="server" Enabled="False">Фамилия</asp:TableCell>
            <asp:TableCell runat="server" Enabled="False">Цена</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
