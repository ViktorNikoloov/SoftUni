namespace Exam.DeliveriesManager
{
    using System.Collections;
    using System.Collections.Generic;

    public class Airline
    {
        public Airline(string id, string name, double rating)
        {
            Id = id;
            Name = name;
            Rating = rating;
            Flights = new List<Flight>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
