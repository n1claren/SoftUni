using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public IEnumerable<string> Authors { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            var yearComparisson = this.Year.CompareTo(other.Year);

            if (yearComparisson == 0)
            {
                return this.Title.CompareTo(other.Year);
            }

            return yearComparisson;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
