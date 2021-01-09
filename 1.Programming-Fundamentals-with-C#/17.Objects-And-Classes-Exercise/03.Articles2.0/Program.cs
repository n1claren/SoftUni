using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Article tempArticle = new Article();

                tempArticle.Title = input[0];
                tempArticle.Content = input[1];
                tempArticle.Author = input[2];

                articles.Add(tempArticle);
            }

            string sortBy = Console.ReadLine();

            List<Article> sortedArticles = new List<Article>();

            switch (sortBy)
            {
                case "author":
                   sortedArticles = articles.OrderBy(x => x.Author).ToList();
                    break;

                case "content":
                    sortedArticles = articles.OrderBy(x => x.Content).ToList();
                    break;

                case "title":
                    sortedArticles = articles.OrderBy(x => x.Title).ToList();
                    break;
            }

            foreach (var article in sortedArticles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }

        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
