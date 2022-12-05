namespace adventofcode
{
    class Program
    {
        private void ElfCarriedCaloriesCounter()
        {
            int countElfs = 1;
            int sum = 0;
            int max = 0;
            int elfwithmaxcalories = 0;
  
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
            p.ElfCarriedCaloriesCounter();
            
            // Suspend the screen.
            Console.WriteLine("Press any key."); 
            Console.ReadLine();  
        
        }

    }
}
