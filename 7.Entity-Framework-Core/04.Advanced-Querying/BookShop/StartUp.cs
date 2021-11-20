namespace BookShop
{
    using System;
    using Data;
    using Initializer;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            // 01. Age Restriction
            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(dbContext, command));

            // 02. Golden Books
            Console.WriteLine(GetGoldenBooks(dbContext)); 

            // 03. Books by Price
            Console.WriteLine(GetBooksByPrice(dbContext));

            // 04. Not Released In
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetBooksNotReleasedIn(dbContext, year));

            // 05. Book Titles by Category
            string input = Console.ReadLine();
            Console.WriteLine(GetBooksByCategory(dbContext, input));

            // 06. Released Before Date
            string date = Console.ReadLine();
            Console.WriteLine(GetBooksReleasedBefore(dbContext, date));

            // 07. Author Search 
            string ending = Console.ReadLine();
            Console.WriteLine(GetAuthorNamesEndingIn(dbContext, ending));

            // 08. Book Search 
            string titleInput = Console.ReadLine();
            Console.WriteLine(GetBookTitlesContaining(dbContext, titleInput));

            // 09. Book Search by Author 
            string starting = Console.ReadLine();
            Console.WriteLine(GetBooksByAuthor(dbContext, starting));

            // 10. Count Books
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(CountBooks(dbContext, count));

            // 11. Total Book Copies
            Console.WriteLine(CountCopiesByAuthor(dbContext));

            // 12. Profit by Category 
            Console.WriteLine(GetTotalProfitByCategory(dbContext));

            // 13. Most Recent Books 
            Console.WriteLine(GetMostRecentBooks(dbContext));
        }

        // 01. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context
                .Books
                .Where(book => book.AgeRestriction == ageRestriction)
                .Select(book => book.Title)
                .OrderBy(title => title)
                .ToArray();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        // 02. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            string result = string.Join(Environment.NewLine, books.Select(b => b.Title));

            return result;
        }

        // 03. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToArray();

            string result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:F2}"));

            return result;
        }

        // 04. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        // 05. Book Titles by Category 
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            var books = context
                .Books
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .ToArray()
                .Where(b => b.BookCategories
                    .Any(category => categories.Contains(category.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(title => title)
                .ToArray();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        // 06. Released Before Date 
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value < parsedDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate.Value
                })
                .OrderByDescending(b => b.Value)
                .ToArray();

            string result = string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));

            return result;
        }

        // 07. Author Search 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray();

            var result = string.Join(Environment.NewLine, authors);

            return result;
        }

        // 08. Book Search 
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .ToArray()
                .Where(b => b.Title.Contains(input, StringComparison.CurrentCultureIgnoreCase))
                .Select(b => b.Title)
                .OrderBy(title => title)
                .ToArray();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        // 09. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        // 10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        // 11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            string result = string.Join(Environment.NewLine, authors
                .Select(a => $"{a.AuthorName} - {a.Copies}"));

            return result;
        }

        // 12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
             .OrderByDescending(c => c.Profit)
             .ThenBy(c => c.Name)
             .ToList();

            string result = string.Join(Environment.NewLine, categories
                .Select(c => $"{c.Name} ${c.Profit:F2}"));

            return result;
        }

        // 13. Most Recent Books 
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Books = c.CategoryBooks
                            .Select(cb => cb.Book)
                            .OrderByDescending(b => b.ReleaseDate)
                            .Take(3)
                            .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in categories)
            {
                sb.AppendLine($"--{item.Name}");

                foreach (var book in item.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().Trim();
        }

        // 14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 15. Remove Books 
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int count = books.Count();

            var booksCategories = context
                .BooksCategories
                .Where(bc => bc.Book.Copies < 4200)
                .ToArray();

            context.BooksCategories.RemoveRange(booksCategories);

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return count;
        }
    }
}
