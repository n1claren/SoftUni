namespace EasterRaces.IO
{
    using System;
    using System.IO;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        string path = "../../../result.txt";

        public ConsoleWriter()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write("");
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }

            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(message);
            }

            Console.Write(message);
        }
    }
}