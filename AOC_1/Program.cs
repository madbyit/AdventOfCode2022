namespace adventofcode
{
    /**
    * Advent of code Day 1
    */
    class Program
    {

        private int countElfs, sum, totalTopThree, max, max1, max2, max3, elfwithmaxcalories;
    
        private void init()
        {
            countElfs = 0;
            sum = 0;
            totalTopThree = 0;
            max1 = 0;
            max1 = 0;
            max2 = 0;
            max3 = 0;
            elfwithmaxcalories = 0;
        }

        // Part 2
        private void TopThreeCaloriesCounter()
        {
            init();
            // Read the file and display it line by line.  
            foreach (string line in File.ReadLines("inputlist.txt"))
            {  
                if(line != string.Empty)
                {
                    sum += Int32.Parse(line);
                }
                else
                {
                    
                    if(sum > max3 && sum > max2 && sum > max1)
                    {
                        max3 = sum;
                    }
                    if(sum < max3 && sum > max2 && sum > max1 )
                    {
                        max2 = sum;
                    }
                    if(sum > max1 && sum < max2 && sum < max3)
                    {
                        max1 = sum;
                    }

                    sum = 0;
                }
            } 
            totalTopThree = max1 + max2 + max3; 
            
            Console.WriteLine("Total top 3 calories: {0}", totalTopThree);  

        }

        // Part 1
        private void MaxCaloriesCounter()
        {
            init();
            int countElfs = 1;
    
            // Read the file and display it line by line.  
            foreach (string line in File.ReadLines("inputlist.txt"))
            {  
                if(line != string.Empty)
                {
                    sum += Int32.Parse(line);
                }
                else
                {
                    if(sum > max)
                    {
                        elfwithmaxcalories = countElfs;
                        max = sum;
                    }
                    countElfs++;
                    sum = 0;
                }
                    
            }  
            
            Console.WriteLine("Max calories: {0} by elf number: {1}.", max, elfwithmaxcalories);  
        }

        static void Main ()
        {
            Program p = new Program();
            p.MaxCaloriesCounter();
            p.TopThreeCaloriesCounter();
        }
    }
}
