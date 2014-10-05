<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyTicket.aspx.cs" Inherits="BuyTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Купить билет:</p>
        <p>
            Имя:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        </p>
        <p>
            Фамилия:&nbsp;&nbsp;
            <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
&nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Отправление:"></asp:Label>
&nbsp;
            <asp:DropDownList ID="DropDownListDeparture" runat="server" OnSelectedIndexChanged="OnChangeDepartureCity">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="Label" runat="server" Text="Прибытие:"></asp:Label>
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownListArrival" runat="server" OnSelectedIndexChanged="OnChangeArrivalCity">
            </asp:DropDownList>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Стоимость:
            <asp:Label ID="LabelCost" runat="server"></asp:Label>
        </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonBuyTicket" runat="server" OnClick="OnButtonPressedBuy" Text="Купить" Width="74px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" OnClick="OnButtonPressedCancel" Text="Отмена" Width="81px" />
        </p>
    </form>
    </body>
</html>
