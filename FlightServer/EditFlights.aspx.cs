using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlightServer.localhost;

namespace FlightServer
{
    public partial class EditFlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            idFlightPrice = -1;
            UpdateAllTable();
        }

        private void UpdateAllTable()
        {
            FlightsService service = Service.getInstanse().flightService;
            DataTable FlightPriceTable;
            if (service.GetFlightsPrice(out FlightPriceTable))
            {
                GridView.DataSource = FlightPriceTable;
                GridView.DataBind();
            }

            DataTable FlightCitiesTable;
            if (service.GetFlightsCities(out FlightCitiesTable))
            {
                DropDownListDeparture.Items.Clear();
                DropDownListArrival.Items.Clear();

                foreach (DataRow row in FlightCitiesTable.Rows)
                {
                    DropDownListDeparture.Items.Add((string)row[0]);
                    DropDownListArrival.Items.Add((string)row[0]);
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            string departure = GridView.Rows[index].Cells[1].Text;
            string arrival = GridView.Rows[index].Cells[2].Text;
            FlightsService service = Service.getInstanse().flightService;
            service.DeleteFlightPrice(departure, arrival);
            UpdateAllTable();
        }

        protected void OnButtonPressedAddFlight(object sender, EventArgs e)
        {
            string arrival = DropDownListArrival.SelectedValue;
            string departure = DropDownListDeparture.SelectedValue;
            string priceStr = TextBoxPrice.Text;

            if (arrival == "" || departure == "" || priceStr == "")
                return;
            if (arrival == departure)
                return;
            int price = Convert.ToInt32(priceStr);

            FlightsService service = Service.getInstanse().flightService;
            service.AddFlightPrice(departure, arrival, price);
            UpdateAllTable();
        }

        private static int idFlightPrice;

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            string departureCity = GridView.Rows[e.NewEditIndex].Cells[1].Text;
            string arrivalCity = GridView.Rows[e.NewEditIndex].Cells[2].Text;
            FlightsService service = Service.getInstanse().flightService;
            if (service.GetFlightPriceId(departureCity, arrivalCity, out idFlightPrice))
            {
                GridView.EditIndex = e.NewEditIndex;
                UpdateAllTable();
            }
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string departure = e.NewValues[0].ToString();
            string arrival = e.NewValues[1].ToString();
            string priceStr = e.NewValues[2].ToString();

            if (departure == "" || arrival == "" || priceStr == "")
            {
                e.Cancel = true;
                return;
            }
            int price = Convert.ToInt32(priceStr);
            FlightsService service = Service.getInstanse().flightService;
            service.UpdateFlightPrice(idFlightPrice, departure, arrival, price);
            GridView.EditIndex = -1;
            UpdateAllTable();
        }

        protected void OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            GridView.EditIndex = -1;
            UpdateAllTable();
        }

        protected void OnRowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            idFlightPrice = -1;
            GridView.EditIndex = -1;
            UpdateAllTable();
        }
    }
}