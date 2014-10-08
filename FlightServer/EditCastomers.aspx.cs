using FlightServer.localhost;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlightServer
{
    public partial class EditCastomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlightsService service = new FlightsService();
            DataTable table = service.GetCustomers();
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}