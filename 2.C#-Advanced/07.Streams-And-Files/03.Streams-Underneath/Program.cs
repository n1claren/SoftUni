using System;
using System.IO;
using System.Text;

namespace _03.Streams_Underneath
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            using (FileStream stream = new FileStream("../../../students.txt", FileMode.Open))
            {
                byte[] buffer = new byte[4096];

                Console.WriteLine($"Stream Position: {stream.Position}");

                Console.WriteLine(stream.Read(buffer, 0, buffer.Length));

                while (stream.Read(buffer, 0, buffer.Length) > 0)
                {
                    string chunk = Encoding.UTF8.GetString(buffer);

                    if (chunk.Contains("Gogi"))
                    {
                        count++;
                    }
                }

                for (int i = 0; i < stream.Length / buffer.Length; i++)
                {
                    using (FileStream writerStream = new FileStream($"../../../students-{i}.txt", FileMode.Create, FileAccess.Write))
                    {
                        writerStream.Write(buffer, 0, buffer.Length);
                    }
                }

                Console.WriteLine($"Stream Position: {stream.Position}");
            }

            Console.WriteLine(count);


        }
    }
}