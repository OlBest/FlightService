using System;
using System.Data;
using System.Web.Services;
using FlightsService.App_Data;
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
        public void BuyTicket(string departure, string arrival, string name, string surname)
        {
            var adapter = new FLIGHTSTableAdapter();
            adapter.InsertFlight(Convert.ToInt32(adapter.GetNumberFlights() + 1),
                Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightsPriceId(departure, arrival)),
                Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(name, surname)));
        }

        [WebMethod]
        public DataTable GetAllFlights()
        {
            return new FlightsTableAdapter().GetAllFlights();
        }

        [WebMethod]
        public int GetFlightPriceId(string departure, string arrival)
        {
            return Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightsPriceId(departure, arrival));
        }

        [WebMethod]
        public void UpdateFlightPrice(int flightPriceId, string departure, string arrival, int price)
        {
            new FLIGHTSPRICETableAdapter().UpdateFlightPrice(price, flightPriceId, departure, arrival);
        }

        [WebMethod]
        public DataTable GetFlightsPrice()
        {
            return new FlightsPriceTableAdapter().GetFligthsPrice();
        }

        [WebMethod]
        public void AddFlightPrice(string departure, string arrival, int price)
        {
            var adapter = new FLIGHTSPRICETableAdapter();
            var cityAdapter = new CITIESTableAdapter();
            adapter.InsertFlightPrice(Convert.ToInt32(adapter.GetNumberFlightPrice() + 1),
                Convert.ToInt32(cityAdapter.GetCityId(departure)),Convert.ToInt32(cityAdapter.GetCityId(arrival)), price);
        }

        [WebMethod]
        public void CancelTicket(int flightId)
        {
            new FLIGHTSTableAdapter().DeleteFlight(flightId);
        }

        [WebMethod]
        public void UpdateTicket(int flightId, int flightPriceId, string name, string surname)
        {
            var adapter = new FLIGHTSTableAdapter();
            var customerAdapter = new CUSTOMERTableAdapter();
            adapter.UpdateFlight(flightPriceId, Convert.ToInt32(customerAdapter.GetCustomerIdByNameAndSurname(name, surname)), flightId);
        }

        [WebMethod]
        public void DeleteFlightPrice(string departure, string arrival)
        {
            var adapter = new FLIGHTSPRICETableAdapter();
            adapter.DeleteFlightPrice(Convert.ToInt32(adapter.GetFlightsPriceId(departure, arrival)));
        }

        [WebMethod]
        public DataTable GetArrivalCitiesByDeparture (string departure)
        {
            return new CityTableAdapter().GetArrivalCitiesByDeparture(departure);
        }


        [WebMethod]
        public void AddCity(string city)
        {
            var adapter = new CITIESTableAdapter();
            adapter.AddCity(Convert.ToInt32(adapter.GetNumberCities() + 1), city);
        }

        [WebMethod]
        public void DeleteCity(string city)
        {
            new CITIESTableAdapter().DeleteCity(city);
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
            var adapter = new CustomersTableAdapter();
            return adapter.GetCustomers();
        }

        [WebMethod]
        public DataTable GetCustomerFlights(string name , string surname)
        {
            var adapter = new CustomerFlightsTableAdapter();
            return adapter.GetCustomerFlights(Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(name, surname)));
        }




        [WebMethod]
        public void UpdateCustomer(string newName, string newSurname,string oldName,string oldSurname)
        {
            new CUSTOMERTableAdapter().UpdateCustomer(newName, newSurname,
               Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(oldName, oldSurname)));
        }


        [WebMethod]
        public DataTable GetFlightsCities()
        {
            var adater = new CityTableAdapter();
            return adater.GetFlightCities();
        }


        [WebMethod]
        public int GetFlightPrice(string departure, string arrival)
        {
            return Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightPrice(departure, arrival));
        }
    }
}