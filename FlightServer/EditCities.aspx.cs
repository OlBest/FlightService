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
            DataTable table;
            if (Service.getInstanse().flightService.GetFlightsCities(out table))
            {
                GridView.DataSource = table;
                GridView.DataBind();
            }
        }
        protected void OnButtonPressedAddCity(object sender, EventArgs e)
        {
            FlightsService service = Service.getInstanse().flightService;
            string city = TextBoxCity.Text;
            if (service.AddCity(city))
                LoadData();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            FlightsService service = Service.getInstanse().flightService;
            string city = GridView.Rows[e.RowIndex].Cells[1].Text;
            if (service.DeleteCity(city))
                LoadData();
        }
    }
}