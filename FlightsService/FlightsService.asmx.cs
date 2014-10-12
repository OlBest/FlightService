using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.UI.WebControls;
using FlightsService.AccountService;
using FlightsService.App_Data;
using FlightsService.App_Data.FlightsDataSetTableAdapters;
using FlightsService.PaymentService;

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
        private readonly AccountService.AccountServiceService _accountClient = new AccountServiceService();
        private readonly PaymentService.PaymentServiceService _paymentClient = new PaymentServiceService();
        
        private readonly int _serviceId;
        private Timer _timer;
        private string _company;
        private bool _isPayed;

        public FlightsService()
        {
            _serviceId = _accountClient.register("FlightsService");
            _isPayed = false;
        }

        private void PayedTimeEnded(object state)
        {
            _isPayed = _paymentClient.isPayed(_serviceId, _company);
        }

        [WebMethod]
        public void RegisterCompany(string company)
        {
            _company = company;
        }

        [WebMethod]
        public string Pay()
        {
            var result =_paymentClient.pay(_serviceId, _company);
            _isPayed = _paymentClient.isPayed(_serviceId, _company);
            return result;
        }

        [WebMethod]
        public  string PayForTimeInMilliSeconds(long time)
        {
            var result =_paymentClient.payForMilliseconds(_serviceId, _company, time);
            _isPayed = _paymentClient.isPayed(_serviceId, _company);
            _timer = new Timer(PayedTimeEnded,null,time,-1);
            return result;
        }

        [WebMethod]
        public bool BuyTicket(string departure, string arrival, string name, string surname)
        {
            if (_isPayed)
            {
                var adapter = new FLIGHTSTableAdapter();
                adapter.InsertFlight(Convert.ToInt32(adapter.GetNumberFlights() + 1),
                    Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightsPriceId(departure, arrival)),
                    Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(name, surname)));
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool GetAllFlights(out DataTable table)
        {
            table = null;
            if (_isPayed)
            {
                table = new FlightsTableAdapter().GetAllFlights();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool GetFlightPriceId(string departure, string arrival, out int id)
        {
            id = -1;
            if (_isPayed)
            {
                id = Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightsPriceId(departure, arrival));
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool UpdateFlightPrice(int flightPriceId, string departure, string arrival, int price)
        {
            if (_isPayed)
            {
                new FLIGHTSPRICETableAdapter().UpdateFlightPrice(price, flightPriceId, departure, arrival);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool GetFlightsPrice(out DataTable table)
        {
            table = null;
            if (_isPayed)
            {
                table = new FlightsPriceTableAdapter().GetFligthsPrice();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool AddFlightPrice(string departure, string arrival, int price)
        {
            if (_isPayed)
            {
                var adapter = new FLIGHTSPRICETableAdapter();
                var cityAdapter = new CITIESTableAdapter();
                adapter.InsertFlightPrice(Convert.ToInt32(adapter.GetNumberFlightPrice() + 1),
                    Convert.ToInt32(cityAdapter.GetCityId(departure)), Convert.ToInt32(cityAdapter.GetCityId(arrival)),
                    price);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool CancelTicket(int flightId)
        {
            if (_isPayed)
            {
                new FLIGHTSTableAdapter().DeleteFlight(flightId);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool UpdateTicket(int flightId, int flightPriceId, string name, string surname)
        {
            if (_isPayed)
            {
                var adapter = new FLIGHTSTableAdapter();
                var customerAdapter = new CUSTOMERTableAdapter();
                adapter.UpdateFlight(flightPriceId,
                    Convert.ToInt32(customerAdapter.GetCustomerIdByNameAndSurname(name, surname)), flightId);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool DeleteFlightPrice(string departure, string arrival)
        {
            if (_isPayed)
            {
                var adapter = new FLIGHTSPRICETableAdapter();
                adapter.DeleteFlightPrice(Convert.ToInt32(adapter.GetFlightsPriceId(departure, arrival)));
                return true;
            }
            return false;
        }

        [WebMethod]
        public  bool GetArrivalCitiesByDeparture (string departure, out DataTable table)
        {
            table = null;
            if (_isPayed)
            {
                table = new CityTableAdapter().GetArrivalCitiesByDeparture(departure);
                return true;
            }
            return false;
        }


        [WebMethod]
        public bool AddCity(string city)
        {
            if(_isPayed)
            { 
                var adapter = new CITIESTableAdapter();
                adapter.AddCity(Convert.ToInt32(adapter.GetNumberCities() + 1), city);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool DeleteCity(string city)
        {
            if(_isPayed)
            { 
                 new CITIESTableAdapter().DeleteCity(city);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool AddCustomer(string name,string surname)
        {
            if (_isPayed)
            {
                var adapter = new CUSTOMERTableAdapter();
                adapter.AddCustomer(Convert.ToInt32(adapter.GetNumberCustomers()) + 1, name, surname);
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool GetCustomers(out DataTable table)
        {
            table = null;
            if(_isPayed)
            { 
                var adapter = new CustomersTableAdapter();
                table = adapter.GetCustomers();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool GetCustomerFlights(string name , string surname,out DataTable table)
        {
            table = null;
            if (_isPayed)
            {
                var adapter = new CustomerFlightsTableAdapter();
                table =
                    adapter.GetCustomerFlights(
                        Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(name, surname)));
                return true;
            }
            return false;
        }




        [WebMethod]
        public bool UpdateCustomer(string newName, string newSurname,string oldName,string oldSurname)
        {
            if (_isPayed)
            {
                new CUSTOMERTableAdapter().UpdateCustomer(newName, newSurname,
                    Convert.ToInt32(new CUSTOMERTableAdapter().GetCustomerIdByNameAndSurname(oldName, oldSurname)));
                return true;
            }
            return false;
        }


        [WebMethod]
        public bool GetFlightsCities(out DataTable table)
        {
            table = null;
            if (_isPayed)
            {
                var adater = new CityTableAdapter();
                table = adater.GetFlightCities();
                return true;
            }
            return false;
        }


        [WebMethod]
        public bool GetFlightPrice(string departure, string arrival, out int price)
        {
            price = -1;
            if (_isPayed)
            {
                price = Convert.ToInt32(new FLIGHTSPRICETableAdapter().GetFlightPrice(departure, arrival));
                return true;
            }
            return false;
        }
    }
}