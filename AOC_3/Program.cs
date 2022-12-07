namespace adventofcode
{
    /**
    * Advent of code Day 3
    */
    class Program
    {
        private int sum;
        private void Init()
        {
           Console.WriteLine("*** INIT ***");
           sum = 0;
        }
            
        // Part 1
        private void RucksackReorganization()
        {
            Init();
            Console.WriteLine("*** Rucksack Reorganisation ***");
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {
                    
                int lineLength = line.Length;
                string rucksack1 = line.Substring(0, lineLength/2);
                string rucksack2 = line.Substring(lineLength/2, lineLength/2); //Begin from half and and get from other half
                var unique1 = new HashSet<char>(rucksack1); // Remove duplicated characters
                var unique2 = new HashSet<char>(rucksack2); // Remove duplicated characters
                int ascii = 0;

                foreach(var c in unique1)
                {   
                    if(unique2.Contains(c)) { ascii = (int) c;}
                }
               
                //Check lower case
                if (ascii >= 97 && ascii <= 122)
                    sum += (ascii - 96);
                
                // Check upper case
                if (ascii >= 65 && ascii <= 90)
                    sum += ((ascii - 65) + 27);
            }
            Console.WriteLine("Sum: {0}", sum);
        }


        static void Main ()
        {
            Program p = new Program();
            p.RucksackReorganization();
        }
    }
}
