using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // ButtonBuyTicket.Enabled = User.Identity.IsAuthenticated;
    }
    
    protected void OnClickedButtonBuyTicket(object sender, EventArgs e)
    {
        Response.Redirect("~/BuyTicket.aspx");
    }
}