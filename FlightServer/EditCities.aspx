<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCities.aspx.cs" Inherits="FlightServer.EditCities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1>Города полетов</h1>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView" runat="server" OnRowDeleting="OnRowDeleting">
        <Columns>
            <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:TextBox ID="TextBoxCity" runat="server" Height="22px" Width="95px"></asp:TextBox>
&nbsp;
    <asp:Button ID="ButtonAddCity" runat="server" Height="35px" OnClick="OnButtonPressedAddCity" Text="Добавить" Width="109px" />
</asp:Content>
