using FlightServer.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHomePage: Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void OnButtonPressedEditDataPassagers(object sender, EventArgs e)
    {
        Response.Redirect("~/EditCastomers.aspx");

    }
    protected void OnButtonPressedEditFlights(object sender, EventArgs e)
    {
        Response.Redirect("~/EditFlights.aspx");

    }
    protected void OnButtonPressedEditTickets(object sender, EventArgs e)
    {
        Response.Redirect("~/EditTickets.aspx");
    }
}