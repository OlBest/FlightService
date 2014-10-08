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
            LoadData();
        }

        private List<int> IdTickets = new List<int>();

        private void LoadData()
        {
            FlightsService service = new FlightsService();
            DataTable AllFlightsTable = service.GetAllFlights();
            IdTickets.Clear();
            foreach (DataRow row in AllFlightsTable.Rows)
                IdTickets.Add(Convert.ToInt32(row[0]));
            AllFlightsTable.PrimaryKey = null;
            AllFlightsTable.Columns.RemoveAt(0);
            GridView.DataSource = AllFlightsTable;
            GridView.DataBind();

            DropDownListDeparture.Items.Clear();
            DataTable FlightCityTable = service.GetFlightsCities();
            foreach (DataRow row in FlightCityTable.Rows)
                 DropDownListDeparture.Items.Add((string)row[0]);
            OnChangeDepartureCity(null, EventArgs.Empty);
            UpdateEnableAddTicket();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = IdTickets[e.RowIndex];
            FlightsService service = new FlightsService();      
            service.CancelTicket(Id);
            LoadData();
        }

//         protected void OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
//         {
// 
//         }
       
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = IdTickets[e.RowIndex];
            
            FlightsService service = new FlightsService();
            string departure = e.NewValues[0].ToString();
            string arrival = e.NewValues[1].ToString();
            int price = Convert.ToInt32(e.NewValues[2].ToString());
            string name = e.NewValues[3].ToString();
            string surname = e.NewValues[4].ToString();
            service.UpdateTicket(id, service.GetFlightPriceId(departure, arrival), name, surname);
            LoadData();
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
            string arrivelCity = DropDownListDeparture.SelectedValue;

            FlightsService service = new FlightsService();
            service.AddCustomer(name, surname);
            service.BuyTicket(departureCity, arrivelCity, name, surname);
            LoadData();
        }

        protected void OnChangeDepartureCity(object sender, EventArgs e)
        {
            if (DropDownListDeparture.SelectedValue == "")
                return;

            FlightsService service = new FlightsService();
            DataTable FlightCityTable = service.GetArrivalCitiesByDeparture(DropDownListDeparture.SelectedValue);
            DropDownListArrival.Items.Clear();
            foreach (DataRow row in FlightCityTable.Rows)
                 DropDownListArrival.Items.Add((string)row[0]);
            
            UpdateEnableAddTicket();
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