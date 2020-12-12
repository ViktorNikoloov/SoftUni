using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();

        }

        public IReadOnlyCollection<IComponent> Components
            => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals 
            => (IReadOnlyCollection<IPeripheral>)peripherals;

        public void AddComponent(IComponent component)
        {
            IComponent currComponent = components.FirstOrDefault(c => c.GetType().Name == component.GetType().Name);

            if(currComponent!= null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent,
                    currComponent.GetType().Name, 
                    this.GetType().Name,
                    this.Id));
            }

            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (components.Count == 0 || !(components.Any(c => c.GetType().Name == componentType)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType,
                    this.GetType().Name,
                    this.Id));
            }

            IComponent removedComponent = components.FirstOrDefault(x => x.GetType().Name == componentType);
            components.Remove(removedComponent);

            return removedComponent;

        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            IPeripheral currPeripherals = peripherals.FirstOrDefault(c => c.GetType().Name == peripheral.GetType().Name);

            if (currPeripherals != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    currPeripherals.GetType().Name,
                    this.GetType().Name,
                    this.Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (peripherals.Count == 0 || !(peripherals.Any(c => c.GetType().Name == peripheralType)))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType,
                    this.GetType().Name,
                    this.Id));
            }

            IPeripheral removedPeripherals = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            peripherals.Remove(removedPeripherals);

            return removedPeripherals;
        }

        public override double OverallPerformance 
           => components.Count == 0 ? base.OverallPerformance : base.OverallPerformance + components.Average(x => x.OverallPerformance);
        

        public override decimal Price 
            => base.Price + components.Sum(x=>x.Price) + peripherals.Sum(x=>x.Price);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine($" Components ({components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({peripherals.Average(x=>x.OverallPerformance):F2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }
                

            return sb.ToString().TrimEnd();
        }
    }
}
