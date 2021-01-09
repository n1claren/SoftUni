using System;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ").ToList();

            Article article = new Article();

            article.Title = input[0];
            article.Content = input[1];
            article.Author = input[2];

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string changeInput = Console.ReadLine();

                Constructor(changeInput, article);
            }

            Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
        }

        public static void Constructor(string input, Article article)
        {
            var editCommand = input.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();

            switch (editCommand[0])
            {
                case "Edit":
                    article.Content = editCommand[1];
                    break;
                case "ChangeAuthor":
                    article.Author = editCommand[1];
                    break;
                case "Rename":
                    article.Title = editCommand[1];
                    break;
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
