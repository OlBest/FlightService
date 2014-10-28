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
    public partial class EditTickets: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            IdTickets = new List<int>();
            LoadData();
        }

        private static List<int> IdTickets;

        private void LoadData()
        {
            FlightsService service = Service.getInstanse().flightService;
            DataTable AllFlightsTable;
            if (service.GetAllFlights(out AllFlightsTable))
            {
                IdTickets.Clear();
                foreach (DataRow row in AllFlightsTable.Rows)
                    IdTickets.Add(Convert.ToInt32(row[0]));
                AllFlightsTable.PrimaryKey = null;
                AllFlightsTable.Columns.RemoveAt(0);
                GridView.DataSource = AllFlightsTable;
                GridView.DataBind();
            }

            DropDownListDeparture.Items.Clear();
            DataTable FlightCityTable;
            if (service.GetFlightsCities(out FlightCityTable))
            {
                foreach (DataRow row in FlightCityTable.Rows)
                    DropDownListDeparture.Items.Add((string)row[0]);
            }
            OnChangeDepartureCity(null, EventArgs.Empty);
            UpdateEnableAddTicket();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = IdTickets[e.RowIndex];
            FlightsService service = Service.getInstanse().flightService;    
            service.CancelTicket(Id);
            LoadData();
        }

   
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = IdTickets[e.RowIndex];

            FlightsService service = Service.getInstanse().flightService;
            string departure = e.NewValues[0].ToString();
            string arrival = e.NewValues[1].ToString();
            int price = Convert.ToInt32(e.NewValues[2].ToString());
            string name = e.NewValues[3].ToString();
            string surname = e.NewValues[4].ToString();
           
            int idFlightPriceId;
            if (service.GetFlightPriceId(departure, arrival, out idFlightPriceId))
                if (service.UpdateTicket(id, idFlightPriceId, name, surname))
                {
                    GridView.EditIndex = -1;
                    LoadData();
                }         
        }

        private void UpdateEnableAddTicket()
        {
            bool bEnable = true;
            bEnable &= DropDownListDeparture.SelectedValue != "";
            bEnable &= DropDownListArrival.SelectedValue != "";
            bEnable &= TextBoxPrice.Text != "";
            bEnable &= TextBoxName.Text != "";
            bEnable &= TextBoxSurname.Text != "";
            ButtonAddNewTicket.Enabled = bEnable;
        }

        protected void OnButtonPressedAddNewTicket(object sender, EventArgs e)
        {
            string name = TextBoxName.Text;
            string surname = TextBoxSurname.Text;
            int price = Convert.ToInt32(TextBoxPrice.Text);
            string departureCity = DropDownListDeparture.SelectedValue;
            string arrivelCity = DropDownListArrival.SelectedValue;

            FlightsService service = Service.getInstanse().flightService;
            service.AddCustomer(name, surname);
            service.BuyTicket(departureCity, arrivelCity, name, surname);
            LoadData();
        }

        protected void OnChangeDepartureCity(object sender, EventArgs e)
        {
            if (DropDownListDeparture.SelectedValue == "")
                return;

            DataTable FlightCityTable;
            if (Service.getInstanse().flightService.GetArrivalCitiesByDeparture(DropDownListDeparture.SelectedValue, out FlightCityTable))
            {
                DropDownListArrival.Items.Clear();
                foreach (DataRow row in FlightCityTable.Rows)
                    DropDownListArrival.Items.Add((string)row[0]);

                UpdateEnableAddTicket();
            }
        }

        protected void OnChangeArricalCity(object sender, EventArgs e)
        {
            UpdateEnableAddTicket();
        }

        protected void OnChangePrice(object sender, EventArgs e)
        {
            UpdateEnableAddTicket();
        }

        protected void OnChangeName(object sender, EventArgs e)
        {
            UpdateEnableAddTicket();
        }

        protected void OnChangeSurname(object sender, EventArgs e)
        {
            UpdateEnableAddTicket();
        }

   }
}