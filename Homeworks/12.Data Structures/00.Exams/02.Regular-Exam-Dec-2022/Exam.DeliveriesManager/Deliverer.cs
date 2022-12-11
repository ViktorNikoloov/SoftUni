namespace Exam.DeliveriesManager
{
    using System.Collections;
    using System.Collections.Generic;

    public class Deliverer
    {
        public Deliverer(string id, string name)
        {
            Id = id;
            Name = name;
            Packages = new List<Package>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
