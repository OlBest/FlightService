using FlightServer.localhost;
using System;
using System.Collections.Generic;
using System.Data;
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

            DataTable table;
            if (Service.getInstanse().flightService.GetCustomerFlights(name, surname, out table))
            {
                 GridView.DataSource = table;
                 GridView.DataBind();
            }
        }
    }
}