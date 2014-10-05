using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flight_Server.localhost;

public partial class BuyTicket : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       FlightsService service = new FlightsService();
       service.GetFlightsCities();
    }

    protected void OnChangeDepartureCity(object sender, EventArgs e)
    {

    }
    
    protected void OnChangeArrivalCity(object sender, EventArgs e)
    {

    }

    private void UpdateCost()
    {
        int cost;
        if (DropDownListDeparture.SelectedIndex != -1 && DropDownListArrival.SelectedIndex != -1)
        {
            string ArrivalCity = DropDownListArrival.SelectedValue;
            string DepartureCity = DropDownListDeparture.SelectedValue;
            cost = new FlightsService().GetFlightPrice(DepartureCity, ArrivalCity);
        }
        else
            cost = 0;

        LabelCost.Text = Convert.ToString(cost);
    }

    protected void OnButtonPressedCancel(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx"); 
    }
    protected void OnButtonPressedBuy(object sender, EventArgs e)
    {
        FlightsService servise = new FlightsService();
        servise.AddCustomer(TextBoxName.Text, TextBoxSurname.Text);

        Response.Redirect("~/FinishBuyTicket.aspx");
    }

    private void UpdateEnableButTicket()
    {
        bool bEnable = true;
        bEnable &= !String.IsNullOrEmpty(TextBoxName.Text);
        bEnable &= !String.IsNullOrEmpty(TextBoxSurname.Text);
        bEnable &= DropDownListDeparture.SelectedIndex != -1;
        bEnable &= DropDownListArrival.SelectedIndex != -1;
        ButtonBuyTicket.Enabled = bEnable;
    }
}