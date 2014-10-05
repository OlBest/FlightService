<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFlights.aspx.cs" Inherits="Flight_Server.EditFlights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <p>
        Редактировать данные полетов</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table ID="TableEditFlights" runat="server" Height="40px" Width="320px">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">Отправление</asp:TableCell>
            <asp:TableCell runat="server">Прибытие</asp:TableCell>
            <asp:TableCell runat="server">Цена</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
