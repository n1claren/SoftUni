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
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        protected Computer(
            int id, 
            string manufacturer, 
            string model, 
            decimal price, 
            double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => (IReadOnlyCollection<IComponent>)components;

        public IReadOnlyCollection<IPeripheral> Peripherals => (IReadOnlyCollection<IPeripheral>)peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, 
                    component.GetType().Name, 
                    GetType().Name, 
                    Id));
            }

            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, 
                    GetType().Name, 
                    Id));
            }

            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent comp = Components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (comp == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, 
                    GetType().Name, 
                    Id));
            }

            components.Remove(comp);

            return comp;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peri = Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peri == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, 
                    GetType().Name, 
                    Id));
            }

            peripherals.Remove(peri);

            return peri;
        }

        public override double OverallPerformance
        {
            get
            {
                if (Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    double avgComponentPerformance = Components.Average(x => x.OverallPerformance);

                    return base.OverallPerformance + avgComponentPerformance;
                }
            }
        }

        public override decimal Price
        {
            get
            {
                decimal totalPrice = base.Price;

                foreach (var component in Components)
                {
                    totalPrice += component.Price;
                }

                foreach (var peripheral in Peripherals)
                {
                    totalPrice += peripheral.Price;
                }

                return totalPrice;
            }
        }

        public override string ToString()
        {
            double peripheralsAvg = Peripherals.Count > 0 ? Peripherals.Average(x => x.OverallPerformance) : 0;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($" Components ({Components.Count}):");

            foreach (var component in Components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine($" Peripherals ({Peripherals.Count}); " +
                $"Average Overall Performance ({peripheralsAvg:F2}):");

            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return base.ToString() + $"\n{sb.ToString().TrimEnd()}";
        }
    }
}
