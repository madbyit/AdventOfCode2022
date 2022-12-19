using System;
using System.Text;

namespace adventofcode
{
    /**
    * Advent of code Day 7
    */
    class Program
    {
        static readonly string[] input = File.ReadAllLines("input.txt");
        private static void PartOne()
        {
            foreach (string line in input)
            {
                Console.WriteLine(line);
            }
        }


        static void Main()
        {
            Console.WriteLine("Part 1");
            PartOne();
            Console.WriteLine("Press any key to quit...");
            Console.ReadLine();
        }
    }
}
