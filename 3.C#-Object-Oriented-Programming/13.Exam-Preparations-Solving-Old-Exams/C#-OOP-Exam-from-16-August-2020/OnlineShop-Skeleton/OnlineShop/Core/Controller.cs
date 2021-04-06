using OnlineShop.Common.Constants;
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
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            components = new List<IComponent>();
            computers = new List<IComputer>();
            peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;

                case "Motherboard":
                    component = new Motherboard
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;

                case "PowerSupply":
                    component = new PowerSupply
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;

                case "RandomAccessMemory":
                    component = new RandomAccessMemory
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;

                case "SolidStateDrive":
                    component = new SolidStateDrive
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;

                case "VideoCard":
                    component = new VideoCard
                        (id, manufacturer, model, price, overallPerformance, generation);
                    break;

                default: throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            components.Add(component);

            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);

            return string.Format(SuccessMessages.AddedComponent,
                component.GetType().Name,
                component.Id,
                computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset
                        (id, manufacturer, model, price, overallPerformance, connectionType);
                    break;

                case "Keyboard":
                    peripheral = new Keyboard
                        (id, manufacturer, model, price, overallPerformance, connectionType);
                    break;

                case "Monitor":
                    peripheral = new Monitor
                        (id, manufacturer, model, price, overallPerformance, connectionType);
                    break;

                case "Mouse":
                    peripheral = new Mouse
                        (id, manufacturer, model, price, overallPerformance, connectionType);
                    break;

                default: throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
          
            peripherals.Add(peripheral);
            
            computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);

            IComputer computer = computers.FirstOrDefault(x => x.Id == id);

            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);

            return computers.FirstOrDefault(x => x.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);

            IComponent component = computers
                .FirstOrDefault(x => x.Id == computerId)
                .RemoveComponent(componentType);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);

            IPeripheral peripheral = computers
                .FirstOrDefault(x => x.Id == computerId)
                .RemovePeripheral(peripheralType);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void CheckIfComputerExists(int computerId)
        {
            if (computers.FirstOrDefault(x => x.Id == computerId) == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
