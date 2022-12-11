using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverers = new Dictionary<string, Deliverer>();
        private Dictionary<string, Package> packages = new Dictionary<string, Package>();

        public void AddDeliverer(Deliverer deliverer)
        {
            if (this.Contains(deliverer))
            {
                throw new ArgumentException();
            }

            this.deliverers.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            if (this.packages.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }

            this.packages.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!this.Contains(deliverer) || !this.Contains(package))
            {
                throw new ArgumentException();
            }

            deliverer.Packages.Add(package);
            package.Deliverer = deliverer;
        }

        public bool Contains(Deliverer deliverer)
        => this.deliverers.ContainsKey(deliverer.Id);

        public bool Contains(Package package)
        => this.packages.ContainsKey(package.Id);

        public IEnumerable<Deliverer> GetDeliverers()
        => this.deliverers.Values;

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        => this.GetDeliverers().OrderByDescending(x => x.Packages.Count).ThenBy(x => x.Name);

        public IEnumerable<Package> GetPackages()
        => this.packages.Values;

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        => this.GetPackages().OrderByDescending(x => x.Weight).ThenBy(x => x.Receiver);

        public IEnumerable<Package> GetUnassignedPackages()
        => this.GetPackages().Where(x => x.Deliverer == null);
    }
}
