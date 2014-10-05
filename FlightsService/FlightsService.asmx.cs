using System;
using System.Data;
using System.Web.Services;
using FlightsService.App_Data.FlightsDataSetTableAdapters;

namespace FlightsService
{
    /// <summary>
    /// Summary description for FlightsService
    /// </summary>
    [WebService(Description="Web-сервис для работы с клиентами", Namespace="http://flights.com/", Name="FlightsService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FlightsService : WebService
    {

        [WebMethod]
        public int GetCustomerIdByNameAndSurname(string name, string surname)
        {
             return Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(name, surname));
        }

        [WebMethod]
        public int GetNumberCustomers()
        {
            return Convert.ToInt32(new CUSTOMERTableAdapter().GetNumberCustomers());
        }

        [WebMethod]
        public void AddCustomer(string name,string surname)
        {
            var adapter = new CUSTOMERTableAdapter();
            adapter.AddCustomer(Convert.ToInt32(adapter.GetNumberCustomers()) + 1, name, surname);
        }

        [WebMethod]
        public DataTable GetCustomers()
        {
            var adapter = new CUSTOMERTableAdapter();
            return adapter.GetCustomers();
        }

        [WebMethod]
        public DataTable GetCustomerFlights(int customerId)
        {
            var adapter = new FLIGHTSTableAdapter();
            return adapter.GetCustomerFlights(customerId);
        }

        [WebMethod]
        public DataTable GetFlightsCities()
        {
            var adater = new CITIESTableAdapter();
            return adater.GetFlightsCities();
        }


        [WebMethod]
        public int GetFlightPrice(string departure, string arrival)
        {
            return Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightPrice(departure, arrival));
        }
    }
}