namespace adventofcode
{
    /**
    * Advent of code Day 3
    */
    class Program
    {
        private int sum, badgessum;
        private void Init()
        {
           Console.WriteLine("*** INIT ***");
           sum = 0;
           badgessum = 0;
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
        }

        // Part 2
        private void RucksackReorganizationFindBadges()
        {
            Init();
            Console.WriteLine("*** Rucksack Reorganisation Badges ***");
            List<string> LineList = new List<string>();
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {
                LineList.Add(RemoveDuplicates(line));
            }
            
            int index = 0;
            while(index < LineList.Count)
            {
                string str1 = LineList[index];
                string str2 = LineList[index + 1];
                string str3 = LineList[index + 2];

                foreach(var c in str1)
                {
                    if(str2.Contains(c))
                    {
                        if(str3.Contains(c))
                        {
                            int ascii = (int)c;
                            //Check lower case
                            if (ascii >= 97 && ascii <= 122)
                                badgessum += (ascii - 96);
                            
                            // Check upper case
                            if (ascii >= 65 && ascii <= 90)
                                badgessum += ((ascii - 65) + 27);
                        }
                    }
                }

                // Increase by three to get next three rucksacks 
                index += 3;
            }

        }

        private static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }


        static void Main ()
        {
            Program p = new Program();
            p.RucksackReorganization();
            Console.WriteLine("Sum: {0}", p.sum);
            
            p.RucksackReorganizationFindBadges();
            Console.WriteLine("BadgesSum: {0}", p.badgessum);
        }
    }
}
