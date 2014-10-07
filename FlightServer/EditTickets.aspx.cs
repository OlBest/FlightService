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
            LoadData();
        }

        private void LoadData()
        {
            FlightsService servise = new FlightsService();
            DataTable table = servise.GetAllFlights();

            GridView.DataSource = table;
            GridView.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(GridView.Rows[e.RowIndex].Cells[0].Text);
            FlightsService service = new FlightsService();
            service.CancelTicket(index);
            LoadData();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //var row = GridView.Rows[e.RowIndex];
            //int index = Convert.ToInt32(row.Cells[0].Text);

            //FlightsService servise = new FlightsService();
            //servise.UpdateTicket(index, Cells[1].Text, index[2].Text, index[3].Text, index[4].Text);
            LoadData();
        }
    }
}