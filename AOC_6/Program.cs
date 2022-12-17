using System.IO;
using System.Net.Sockets;
using System.Text;

namespace adventofcode
{
    /**
    * Advent of code Day 6
    */
    class Program
    {
        static readonly string ds_buffer = @"input.txt";

        private static void PartOne()
        {
            using FileStream fs = new(ds_buffer, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new(fs);
            List<char>? charList = new();

            while (!sr.EndOfStream)
            {
                char c = (char)sr.Read();
                charList.Add(c);
            }

            int index = 0;
            while(true)
            {
                char first = charList.ElementAt(index);
                char second = charList.ElementAt(index+1);
                char third = charList.ElementAt(index+2);
                char fourth = charList.ElementAt(index+3);

                if (first == second || first == third || first == fourth || second == third || second == fourth || third == fourth)
                    index++;
                else
                {
                    int result = index + 4;
                    Console.WriteLine($"Result index is: {result}");
                    break;
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Part 1");
            PartOne();
        }
    }
}
