using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _01.Lecture_Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Maths);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public |
                                                    BindingFlags.Instance |
                                                    BindingFlags.Static |
                                                    BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                var methodParams = method.GetParameters()
                    .Select(p => new KeyValuePair<string, string>(p.Name, p.ParameterType.Name));

                Console.WriteLine($"{method.Name} " +
                    $"-> {string.Join(", ", methodParams)} " +
                    $"-> IsPublic: {method.IsPublic}");

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
