using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Flight_Server.localhost;

namespace Flight_Server
{
    public partial class EditFlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlightsService servise = new FlightsService();
            DataTable table = servise.GetAllFlights();

            GridView.DataSource = table;
            GridView.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int index = Convert.ToInt32(GridView.Rows[e.RowIndex].Cells[0].Text);
            //FlightsService servise = new FlightsService();
            //servise.DeleteFlight(index);

        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //var row = GridView.Rows[e.RowIndex];
            //int index = Convert.ToInt32(row.Cells[0].Text);
                        
            //FlightsService servise = new FlightsService();
            //servise.UpdateFlight(index, Cells[1].Text, index[2].Text, index[3].Text, index[4].Text);
        }

    }
}