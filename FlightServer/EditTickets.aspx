<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditTickets.aspx.cs" Inherits="FlightServer.EditTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Редактировать билеты клиентов</h1>
      
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView" runat="server" HorizontalAlign="Center" OnRowDeleting="OnRowDeleting" OnRowUpdating="OnRowUpdating" Width="363px" OnRowEditing="OnRowEditing">
            <Columns>
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
<p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:DropDownList ID="DropDownListDeparture" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="OnChangeDepartureCity" Width="82px">
        </asp:DropDownList>
        &nbsp;&nbsp;<asp:DropDownList ID="DropDownListArrival" runat="server" AutoPostBack="True" Height="25px" OnSelectedIndexChanged="OnChangeArricalCity" Width="83px">
        </asp:DropDownList>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPrice" runat="server" Height="16px" Width="81px" AutoPostBack="True" OnTextChanged="OnChangePrice"></asp:TextBox>
&nbsp;
        <asp:TextBox ID="TextBoxName" runat="server" Width="74px" AutoPostBack="True" OnTextChanged="OnChangeName"></asp:TextBox>
&nbsp;<asp:TextBox ID="TextBoxSurname" runat="server" Width="79px" AutoPostBack="True" OnTextChanged="OnChangeSurname"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonAddNewTicket" runat="server" Height="32px" Text="Добавить" OnClick="OnButtonPressedAddNewTicket" Width="110px" />
</p>
<p>
        &nbsp;</p>
    
</asp:Content>
