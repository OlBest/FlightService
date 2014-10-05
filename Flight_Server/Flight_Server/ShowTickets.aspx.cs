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
    public partial class ShowTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlightsService servise = new FlightsService();
            DataTable table = servise.GetAllFlights();

            foreach (DataRow dataRow in table.Rows)
            {
                TableRow row = new TableRow();
                foreach (object obj in dataRow.ItemArray)
                {
                    TableCell c = new TableCell();
                    LiteralControl LitControl = new LiteralControl((string)obj);
                    c.Controls.Add(LitControl);
                    row.Cells.Add(c);
                }
                TableTickets.Rows.Add(row);
            }
        }
    }
}