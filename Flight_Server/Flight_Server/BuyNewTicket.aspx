<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuyNewTicket.aspx.cs" Inherits="Flight_Server.BuyNewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p style="margin-left: 120px; font-size: large; font-style: italic; font-weight: bold;">
        Купить билет:&nbsp;
    </p>
        <p style="margin-left: 40px">
            Имя:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxName" runat="server" AutoPostBack="True" OnTextChanged="OnNameChange" Width="122px"></asp:TextBox>
        </p>
        <p style="margin-left: 40px">
            Фамилия:&nbsp; &nbsp;&nbsp;
            <asp:TextBox ID="TextBoxSurname" runat="server" AutoPostBack="True" OnTextChanged="OnSurnameChange" Width="123px"></asp:TextBox>
&nbsp;</p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label1" runat="server" Text="Отправление:"></asp:Label>
&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListDeparture" runat="server" OnSelectedIndexChanged="OnChangeDepartureCity" AutoPostBack="True" Width="117px">
            </asp:DropDownList>
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label" runat="server" Text="Прибытие:"></asp:Label>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListArrival" runat="server" OnSelectedIndexChanged="OnChangeArrivalCity" AutoPostBack="True" Width="119px">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Стоимость:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelCost" runat="server"></asp:Label>
        </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonBuyTicket" runat="server" OnClick="OnButtonPressedBuy" Text="Купить" Width="116px" />
        <asp:Button ID="ButtonCancel" runat="server" OnClick="OnButtonPressedCancel" Text="Отмена" Width="114px" />
        </asp:Content>
