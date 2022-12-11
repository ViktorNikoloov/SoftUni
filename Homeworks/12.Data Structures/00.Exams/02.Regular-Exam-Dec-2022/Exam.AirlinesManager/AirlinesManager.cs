using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
        private Dictionary<string, Flight> flights = new Dictionary<string, Flight>();

        public void AddAirline(Airline airline)
        {
            if (this.Contains(airline))
            {
                throw new ArgumentException();
            }

            this.airlines.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            if (!this.Contains(airline) || this.Contains(flight))
            {
                throw new ArgumentException();
            }

            this.flights.Add(flight.Id, flight);
            airline.Flights.Add(flight);
        }

        public bool Contains(Airline airline)
        => this.airlines.ContainsKey(airline.Id);

        public bool Contains(Flight flight)
        => this.flights.ContainsKey(flight.Id);

        public void DeleteAirline(Airline airline)
        {
            if (!this.Contains(airline))
            {
                throw new ArgumentException();
            }

            this.airlines.Remove(airline.Id, out Airline airlines);
            foreach (var flight in airlines.Flights)
            {
                this.flights.Remove(flight.Id);
            }

            airlines.Flights.Clear();
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        => this.GetAllAirlines()
            .OrderByDescending(x => x.Rating)
            .ThenByDescending(x => x.Flights.Count)
            .ThenBy(x=>x.Name);

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        => this.GetAllAirlines()
            .Where(x => x.Flights.Count > 0 && x.Flights
            .Any(y => y.IsCompleted == false && y.Origin == origin && y.Destination == destination));

        public IEnumerable<Flight> GetAllFlights()
        => this.flights.Values;

        public IEnumerable<Airline> GetAllAirlines()
        => this.airlines.Values;

        public IEnumerable<Flight> GetCompletedFlights()
        => this.GetAllFlights().Where(x => x.IsCompleted = true);

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        => this.GetAllFlights().OrderBy(x => x.Number).OrderBy(x => x.IsCompleted == true);

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!this.Contains(airline) || !this.Contains(flight))
            {
                throw new ArgumentException();
            }

            flight.IsCompleted = true;

            return flight;
        }
    }
}
