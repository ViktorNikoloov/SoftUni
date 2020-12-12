using OnlineShop.Common.Constants;
using OnlineShop.Models.Products;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private IProduct product;
        private IPeripheral peripheral;
        private IComponent component;
        private IComputer computer;


        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        //NOTE: For each command, except for "AddComputer" and "BuyBest", you must check if a computer, with that id, exists in the computers collection. If it doesn't, throw an ArgumentException with the message "Computer with this id does not exist.".

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IsIdExist(computerId);

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }


            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            else
            {
                components.Add(component);
            }
            computers.First(x => x.Id == computerId).AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }


        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IsIdExist(computerId);

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            computers.First(x => x.Id == computerId).AddPeripheral(peripheral);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            else
            {
                peripherals.Add(peripheral);
            }

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IsIdExist(computerId);

            computers.First(x => x.Id == computerId).RemovePeripheral(peripheralType);

            IPeripheral toBeRemoved = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            peripherals.Remove(toBeRemoved);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IsIdExist(computerId);

            computers.First(x => x.Id == computerId).RemoveComponent(componentType);

            IComponent toBeRemoved = components.FirstOrDefault(x => x.GetType().Name == componentType);

            components.Remove(toBeRemoved);

            return string.Format(SuccessMessages.RemovedComponent, componentType, toBeRemoved.Id);
        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count == 0 || computers.Any(x=>x.Price > budget))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computer = computers.OrderByDescending(x => x.OverallPerformance).FirstOrDefault(x => x.Price <= budget);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            computer = computers.FirstOrDefault(x => x.Id == id);

            string result = null;
            if (computers.Remove(computer))
            {
                result = computer.ToString();

            }

            return result;
        }

        public string GetComputerData(int id)
        {
            string result = "Computer with this id does not exist.";

            if (computers.Any(x => x.Id == id))
            {
                 computer = computers.FirstOrDefault(x => x.Id == id);

                result = computer.ToString();

            }

            return result;
        }

        private void IsIdExist(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
