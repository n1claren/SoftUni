using CarDealer.Data;
using CarDealer.DataTransferObjects.Input;
using CarDealer.DataTransferObjects.Output;
using CarDealer.DTO.Output;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            // 09. Import Suppliers
            var supplierXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var supplierResult = ImportSuppliers(dbContext, supplierXml);
            Console.WriteLine(supplierResult);

            // 10. Import Parts
            var partXml = File.ReadAllText("../../../Datasets/parts.xml");
            var partResult = ImportParts(dbContext, partXml);
            Console.WriteLine(partResult);

            // 11. Import Cars
            var carXml = File.ReadAllText("../../../Datasets/cars.xml");
            var carResult = ImportCars(dbContext, carXml);
            Console.WriteLine(carResult);

            // 12. Import Customers 
            var customerXml = File.ReadAllText("../../../Datasets/customers.xml");
            var customerResult = ImportCustomers(dbContext, customerXml);
            Console.WriteLine(customerResult);

            // 13. Import Sales 
            var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            var salesResult = ImportSales(dbContext, salesXml);
            Console.WriteLine(salesResult);
        }

        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));

            var textReader = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textReader) as SupplierInputModel[];

            var suppliers = suppliersDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            });

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));

            var textReader = new StringReader(inputXml);

            var partsDto = xmlSerializer.Deserialize(textReader) as PartInputModel[];

            var supplierIds = context
                .Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto
                .Where(p => supplierIds.Contains(p.SupplierId))
                .Select(x => new Part
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                SupplierId = x.SupplierId
            });

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsDto = XmlConverter.Deserializer<CarInputModel>(inputXml, "Cars");

            var cars = new List<Car>();

            var allParts = context
                .Parts
                .Select(x => x.Id)
                .ToList();

            var linqCars = carsDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                    PartCars = x.CarPartsInputModel.Select(x => x.Id)
                                .Distinct()
                                .Intersect(allParts)
                                .Select(pc => new PartCar
                                {
                                    PartId = pc
                                })
                                .ToList()
                })
                .ToList();

            foreach (var currentCar in carsDto)
            {
                var distinctParts = currentCar.CarPartsInputModel.Select(x => x.Id).Distinct();

                var carParts = distinctParts
                    .Intersect(allParts)
                    .Select(pc => new PartCar
                    {
                        PartId = pc
                    })
                    .ToList();

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TravelledDistance = currentCar.TraveledDistance,
                    PartCars = carParts
                };

                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        // 12. Import Customers 
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customersDto = XmlConverter.Deserializer<CustomerInputModel>(inputXml, "Customers");

            var customers = customersDto
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                });

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        // 13. Import Sales 
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesDto = XmlConverter.Deserializer<SaleInputModel>(inputXml, "Sales");

            var carIds = context
                .Cars
                .Select(x => x.Id)
                .ToList();

            var sales = salesDto
                .Where(x => carIds.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                });

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        // 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new CarOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute("cars"));

            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            xmlSerializer.Serialize(textWriter, cars, ns);

            var result = textWriter.ToString();

            return result;
        }

        // 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmws = context
                .Cars
                .Where(c => c.Make == "BMW")
                .Select(x => new BmwOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToList();

            var result = XmlConverter.Serialize(bmws, "cars");

            return result;
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartCount = x.Parts.Count
                })
                .ToList();

            var result = XmlConverter.Serialize(suppliers, "suppliers");

            return result;
        }

        // 17. Export Cars With Their List Of Parts 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .Select(c => new CarWithPartsOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new PartDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            var result = XmlConverter.Serialize(carsWithParts, "cars");

            return result;
        }

        // 18. Export Total Sales By Customer 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context
                .Customers
                .Where(c => c.Sales.Any())
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales
                                    .Select(c => c.Car)
                                    .SelectMany(x => x.PartCars)
                                    .Sum(x => x.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var result = XmlConverter.Serialize(customers, "customers");

            return result;
        }

        // 19. Export Sales With Applied Discount 
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context
               .Sales
               .Select(x => new SaleOutputModel()
               {
                   Car = new CarSaleOutputModel()
                   {
                       Make = x.Car.Make,
                       Model = x.Car.Model,
                       TravelledDistance = x.Car.TravelledDistance
                   },
                   CustomerName = x.Customer.Name,
                   Discount = x.Discount,
                   Price = x.Car.PartCars.Sum(c => c.Part.Price),
                   PriceWithDiscount = x.Car.PartCars.Sum(c => c.Part.Price) - x.Car.PartCars.Sum(c => c.Part.Price) * x.Discount / 100
               })
               .ToList();

            var result = XmlConverter.Serialize(sales, "sales");

            return result;
        }
    }
}