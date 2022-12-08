namespace adventofcode
{
    /**
    * Advent of code Day 4
    */
    class Program
    {
        private int sumPairs;
        private void Init()
        {
            Console.WriteLine("*** Init ***");
            sumPairs = 0;
        }
            
        // Part 1
        private void CampCleanup()
        {
            Init();
            Console.WriteLine("*** Camp Cleanup ***");
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {
                string[] sections = line.Split(',');
                string[] range1 = sections[0].Split('-');
                string[] range2 = sections[1].Split('-');

                int leftMin = Int32.Parse(range1[0]);
                int leftMax = Int32.Parse(range1[1]);
                int rightMin = Int32.Parse(range2[0]);
                int rightMax = Int32.Parse(range2[1]);

                //Check if one is already fully contained by another team
                if( (leftMin >= rightMin && leftMax <= rightMax) || (rightMin >= leftMin && rightMax <= leftMax) )
                {
                    ++sumPairs;
                }
                
            }
        }

        static void Main ()
        {
            Program p = new Program();
            //Part 1
            p.CampCleanup();
            Console.WriteLine("Sum pairs: {0}", p.sumPairs);
            
        }
    }
}
