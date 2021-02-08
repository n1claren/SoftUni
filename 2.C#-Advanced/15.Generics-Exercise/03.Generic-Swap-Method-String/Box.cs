using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Generic_Swap_Method_String
{
    public class Box<T>
    {
        private List<T> collection;

        public Box()
        {
            collection = new List<T>();
        }

        public Box(List<T> collection)
        {
            this.collection = collection;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= 0 && firstIndex < collection.Count &&
                secondIndex >= 0 && secondIndex < collection.Count &&
                collection.Count > 0)
            {
                var firstIndexElement = collection[firstIndex];

                var secondIndexElement = collection[secondIndex];

                collection[firstIndex] = secondIndexElement;

                collection[secondIndex] = firstIndexElement;
            }
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
