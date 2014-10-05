<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Добро пожаловать в авиакомпанию BSU</h2>
            </hgroup>
            <p>
                <asp:Button ID="ButtonBuyTicket" runat="server" OnClick="OnClickedButtonBuyTicket" Text="Купить билет" />
            </p>
        </div>
    </section>
</asp:Content>
