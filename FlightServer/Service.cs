using FlightServer.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightServer
{
    public class Service
    {
        private Service()
        {
            _flightService = new FlightsService();
            _flightService.RegisterCompany("BSUFlight");
            _flightService.Pay();
        }

        static Service _service = new Service();

        private FlightsService _flightService;
        public FlightsService flightService
        {
           get
            {
                return _flightService;
            }
        }
        static public Service getInstanse()
        {
            return _service;
        }
    }
}