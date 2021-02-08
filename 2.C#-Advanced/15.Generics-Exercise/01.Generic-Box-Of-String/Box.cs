using System;
using System.Collections.Generic;
using System.Text;

namespace tralala
{
    public class Box<T>
    {
        private List<T> collection;

        public Box()
        {
            collection = new List<T>();
        }

        public Box(T element)
        {
            collection = new List<T>();

            collection.Add(element);
        }

        public override string ToString()
        {
            string toString = string.Empty;

            foreach (var element in collection)
            {
                toString += $"{element.GetType()}: {element}" + Environment.NewLine;
            }

            return toString.Trim();
        }
    }
}
