using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace adventofcode
{
    /**
    * Advent of code Day 5
    */
    class Program
    {
        static readonly string[] input = File.ReadAllLines("puzzleinput.txt");

        //Get all instructions - they all begin with the word 'move'
        static readonly string[] instructions = Array.FindAll(input, line => line.StartsWith("move"));

        // Locate stackline numbers in the bottom and get how many stacklines/columns 1,2,3... there are
        static readonly int stacksLine = Array.FindIndex(input, line => line.StartsWith(" 1"));
        static readonly int stacksNumber = input[stacksLine].Trim().Last() - '0';


        private static void PartOne()
        {
            //From the bottom, get crates
            var cratesStartingStack = input.Take(stacksLine).ToArray().Reverse();

            List<Stack<string>> cratesToRearrange = new();

            for (int i = 0; i < stacksNumber; i++)
            {
                cratesToRearrange.Add(new Stack<string>());
            }

            foreach (var line in cratesStartingStack)
            {
                //Console.WriteLine($"line in cratesStartingStack: {line}");
                int lineCounter = 0;
                for (int j = 1; j <= line.Length; j += 4)
                {
                    var crate = line.ElementAt(j).ToString();
                    if (!string.IsNullOrWhiteSpace(crate))
                    {
                        cratesToRearrange.ElementAt(lineCounter).Push(crate);
                    }
                    lineCounter++;
                }
            }

            foreach (var line in instructions)
            {                                                               // Example  [0][1][2][3][4]
                var moves = line.Trim().Split(' ');                         // Example [move][1][from]2[to][1]
                int cratesToMove = int.Parse(moves.ElementAt(1));           // 1
                int previousStack = int.Parse(moves.ElementAt(3)) - 1;      // 2
                int nextStack = int.Parse(moves.ElementAt(5)) - 1;          // 1

                while (cratesToMove > 0)
                {
                    var crate = cratesToRearrange.ElementAt(previousStack).Pop();
                    cratesToRearrange.ElementAt(nextStack).Push(crate);
                    cratesToMove--;
                }
            }

            foreach (var stack in cratesToRearrange)
            {
                Console.WriteLine($"Crate: {stack.Peek()}");
            }
        }

        private static void PartTwo()
        {
            //9001:Move multiple crates!
            //From the bottom, get crates
            var cratesStartingStack = input.Take(stacksLine).ToArray().Reverse();
            
            List<Stack<string>> cratesToRearrange = new();

            for (int i = 0; i < stacksNumber; i++)
            {
                cratesToRearrange.Add(new Stack<string>());
            }

            foreach (var line in cratesStartingStack)
            {
                int lineCounter = 0;
                for (int j = 1; j <= line.Length; j += 4)
                {
                    var crate = line.ElementAt(j).ToString();
                    if (!string.IsNullOrWhiteSpace(crate))
                    {
                        cratesToRearrange.ElementAt(lineCounter).Push(crate);
                    }
                    lineCounter++;
                }
            }

            foreach (var line in instructions)
            {
                var moves = line.Trim().Split(' ');
                int cratesToMove = int.Parse(moves.ElementAt(1));
                int previousStack = int.Parse(moves.ElementAt(3)) - 1;
                int nextStack = int.Parse(moves.ElementAt(5)) - 1;
                var miniStack = new Stack<string>();

                while (cratesToMove > 0)
                {
                    var crate = cratesToRearrange.ElementAt(previousStack).Pop();
                    miniStack.Push(crate);
                    cratesToMove--;
                }

                while (miniStack.Count > 0)
                {
                    var crate = miniStack.Pop();
                    cratesToRearrange.ElementAt(nextStack).Push(crate);
                }
            }
            
            foreach (var stack in cratesToRearrange)
            {
                Console.WriteLine($"crate: {stack.Peek()}");
            }
        }

        static void Main ()
        {
            foreach (var in_put in input)
            {
                Console.WriteLine($"input: {in_put}");
            }
            Console.WriteLine();
            Console.WriteLine("Part 1");
            PartOne();
            Console.WriteLine();
            Console.WriteLine("Part 2");
            PartTwo();
        }
    }
}
