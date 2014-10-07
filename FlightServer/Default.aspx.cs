using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace FlightServer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                     Response.Redirect("~/AdminHomePage.aspx");
                else
                     Response.Redirect("~/UserHomePage.aspx");
            }
        }
    }
}