<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCastomers.aspx.cs" Inherits="Flight_Server.EditCastomers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Редактирования данных пассажиров</b>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <asp:Table ID="TablePassagers" runat="server" Height="25px" Width="290px">
           <asp:TableRow runat="server">
               <asp:TableCell runat="server">Имя</asp:TableCell>
               <asp:TableCell runat="server">Фамилия</asp:TableCell>
           </asp:TableRow>
</asp:Table>
</asp:Content>
