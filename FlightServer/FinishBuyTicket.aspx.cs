using FlightServer.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlightServer
{
    public partial class FinishBuyTicket1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String name = Request.QueryString["name"];
            String surname = Request.QueryString["surname"];

            FlightsService service = new FlightsService();
            var table = service.GetCustomerFlights(name, surname);

            GridView.DataSource = table;
            GridView.DataBind();
        }
    }
}