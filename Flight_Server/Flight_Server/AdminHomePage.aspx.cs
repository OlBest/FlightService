using Flight_Server.localhost;
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
    protected void OnButtonPressedEditFlihts(object sender, EventArgs e)
    {
        Response.Redirect("~/EditFlights.aspx");

    }
    protected void OnButtonPressedShowTickets(object sender, EventArgs e)
    {
        Response.Redirect("~/ShowTickets.aspx");
    }
}