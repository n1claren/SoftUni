using CarDealer.XMLHelper;
using ProductShop.Data;
using ProductShop.DataTransferObjects.Input;
using ProductShop.DataTransferObjects.Output;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            // 01. Import Users 
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            var usersResult = ImportUsers(dbContext, usersXml);
            Console.WriteLine(usersResult);

            // 02. Import Products
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var productsResult = ImportProducts(dbContext, productsXml);
            Console.WriteLine(productsResult);

            // 03. Import Categories
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categoriesResult = ImportCategories(dbContext, categoriesXml);
            Console.WriteLine(categoriesResult);

            // 04. Import Categories and Products
            var categoriesAndProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var categoriesAndProductsResult = ImportCategoryProducts(dbContext, categoriesAndProductsXml);
            Console.WriteLine(categoriesAndProductsResult);

            // 05. Export Products In Range
            Console.WriteLine(GetProductsInRange(dbContext));

            // 06. Export Sold Products
            Console.WriteLine(GetSoldProducts(dbContext));
        }

        // 01. Import Users 
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDto = XmlConverter.Deserializer<UserInputModel>(inputXml, "Users");

            var users = usersDto
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                });

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsDto = XmlConverter.Deserializer<ProductInputModel>(inputXml, "Products");

            var products = productsDto
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                });

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDto = XmlConverter.Deserializer<CategoriesInputModel>(inputXml, "Categories");

            var categories = categoriesDto
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                });

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductDto = XmlConverter.Deserializer<CategoryProductInputModel>(inputXml, "CategoryProducts");

            var categoryIds = context
                .Categories
                .Select(c => c.Id)
                .ToList();

            var productIds = context
                .Products
                .Select(p => p.Id)
                .ToList();

            var categoriesProducts = categoryProductDto
                .Where(x => categoryIds.Contains(x.CategoryId) && productIds.Contains(x.ProductId))
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                });

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ProductsInRangeOutputModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .ToList();

            var result = XmlConverter.Serialize(products, "Products");

            return result;
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new UserSoldProductsOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new SoldProducts
                    {
                        Name = p.Name,
                        Price = p.Price
                    }).ToArray()
                })
                .ToArray();

            var result = XmlConverter.Serialize(usersWithSoldProducts, "Users");

            return result;
        }
    }
}