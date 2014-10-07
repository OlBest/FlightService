using Flight_Server.localhost;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flight_Server
{
    public partial class BuyNewTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlightsService service = new FlightsService();
            DataTable table = service.GetFlightsCities();

            if (DropDownListDeparture.Items.Count == 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    DropDownListDeparture.Items.Add((string)row[0]);
                }
            }
            UpdateEnableBuyTicket();
            UpdateCost();
        }

        protected void OnChangeDepartureCity(object sender, EventArgs e)
        {
            FillArrivalCity();

            UpdateCost();
            UpdateEnableBuyTicket();
        }

        private void FillArrivalCity()
        {
            DropDownListArrival.Items.Clear();
            FlightsService servise = new FlightsService();
            string DepartureCity = DropDownListDeparture.SelectedValue;
            DataTable table = servise.GetArrivalCitiesByDeparture(DepartureCity);
            foreach (DataRow row in table.Rows)
                DropDownListArrival.Items.Add((string)row[0]);
        }

        protected void OnChangeArrivalCity(object sender, EventArgs e)
        {
            UpdateCost();
            UpdateEnableBuyTicket();
        }

        private void UpdateCost()
        {
            if (DropDownListDeparture.SelectedIndex != -1 && DropDownListArrival.SelectedIndex != -1)
            {
                string ArrivalCity = DropDownListArrival.SelectedValue;
                string DepartureCity = DropDownListDeparture.SelectedValue;
                int cost = new FlightsService().GetFlightPrice(DepartureCity, ArrivalCity);
                LabelCost.Text = Convert.ToString(cost);
            }
            else
                LabelCost.Text = "undefined";
        }

        protected void OnButtonPressedCancel(object sender, EventArgs e)
        {
            Response.Redirect("~/HomeUserPage.aspx");
        }
        protected void OnButtonPressedBuy(object sender, EventArgs e)
        {
            FlightsService servise = new FlightsService();
            servise.AddCustomer(TextBoxName.Text, TextBoxSurname.Text);
            servise.BuyTicket(DropDownListDeparture.SelectedValue, DropDownListArrival.SelectedValue,
                                TextBoxName.Text, TextBoxSurname.Text);

            Response.Redirect("~/FinishBuyTicket.aspx");
        }

        private void UpdateEnableBuyTicket()
        {
            bool bEnable = true;
            bEnable &= !String.IsNullOrEmpty(TextBoxName.Text);
            bEnable &= !String.IsNullOrEmpty(TextBoxSurname.Text);
            bEnable &= DropDownListDeparture.SelectedIndex != -1;
            bEnable &= DropDownListArrival.SelectedIndex != -1;
            ButtonBuyTicket.Enabled = bEnable;
        }

        protected void OnNameChange(object sender, EventArgs e)
        {
            UpdateEnableBuyTicket();
        }

        protected void OnSurnameChange(object sender, EventArgs e)
        {
            UpdateEnableBuyTicket();
        }
    }
}