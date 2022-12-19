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
                    Console.WriteLine($"Start-of-packet marker index: {result}");
                    break;
                }
            }
        }

        private static void PartTwo()
        {
            using FileStream fs = new(ds_buffer, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new(fs);
            List<char>? charList = new();
            HashSet<string> hash = new();


            while (!sr.EndOfStream)
            {
                char c = (char)sr.Read();
                charList.Add(c);
            }

            int index = 0;
            int result = 0;
            while (true)
            {
                StringBuilder sb = new();

                for(int i = 0; i < 14; i++)
                {
                    sb.Append(charList.ElementAt(index + i));
                }

                var unique = new HashSet<char>(sb.ToString()); // Remove duplicated characters

                if(unique.Count == 14)
                {
                    result = index+ 14;
                    Console.WriteLine($"Start-of-message marker index: {result}");
                    break;
                }
                else
                {
                    index++;
                }               
            }
        }

        static void Main()
        {
            Console.WriteLine("Part 1");
            PartOne();
            Console.WriteLine("Part 2");
            PartTwo();
        }
    }
}
