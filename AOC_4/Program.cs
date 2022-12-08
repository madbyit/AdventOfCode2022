namespace adventofcode
{
    /**
    * Advent of code Day 4
    */
    class Program
    {
        private int sumPairs, sumPairsAny;
        private void Init()
        {
            Console.WriteLine("*** Init ***");
            sumPairs = 0;
            sumPairsAny = 0;
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

        // Part 2
        private void CampCleanupOverlaps()
        {
            Init();
            Console.WriteLine("*** Camp Cleanup Overlaps***");
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {
                string[] sections = line.Split(',');
                string[] range1 = sections[0].Split('-');
                string[] range2 = sections[1].Split('-');

                int leftMin = Int32.Parse(range1[0]);
                int leftMax = Int32.Parse(range1[1]);
                int rightMin = Int32.Parse(range2[0]);
                int rightMax = Int32.Parse(range2[1]);

                int rangeleft = leftMax-leftMin;
                int rangeright = rightMax-rightMin;

                int[] numbersleft = new int[rangeleft+1];
                int[] numbersright = new int[rangeright+1];
                
                //Console.WriteLine("*** Left side ***");
                for(int i = 0; i <= rangeleft; i++)
                {
                    numbersleft[i] = leftMin;
                    leftMin++;
                }

                //Console.WriteLine("*** Right side ***");
                for(int i = 0; i <= rangeright; i++)
                {
                    numbersright[i] = rightMin;
                    rightMin++;
                }
                
                
                foreach(var valleft in numbersleft)
                {
                    bool tst = true;
                        
                    foreach(var valright in numbersright)
                    {

                        if(valright == valleft)
                        {
                            sumPairsAny++;
                            tst = false;
                            break;
                        }
                    }

                    if(tst == false)
                    {
                        break;
                    }
                }
            }
        }
        static void Main ()
        {
            Program p = new Program();
            //Part 1
            p.CampCleanup();
            Console.WriteLine("Sum pairs: {0}", p.sumPairs);

            //Part 2
            p.CampCleanupOverlaps();
            Console.WriteLine("Sum overlaps: {0}", p.sumPairsAny);
            
        }
    }
}
