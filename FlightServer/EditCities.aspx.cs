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
    public partial class EditCities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            FlightsService service = new FlightsService();
            DataTable table = service.GetFlightsCities();
            GridView.DataSource = table;
            GridView.DataBind();
        }
        protected void OnButtonPressedAddCity(object sender, EventArgs e)
        {
            FlightsService service = new FlightsService();
            string city = TextBoxCity.Text;
            service.AddCity(city);
            LoadData();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FlightsService service = new FlightsService();
            string city = GridView.Rows[e.RowIndex].Cells[1].Text;
            service.DeleteCity(city);
            LoadData();
        }
    }
}