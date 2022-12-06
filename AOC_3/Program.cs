namespace adventofcode
{
    /**
    * Advent of code Day 3
    */
    class Program
    {
        private void Init()
        {
           Console.WriteLine("*** INIT ***");
        }
            
        // Part 1
        private void TBD()
        {
            Init();
            
            foreach (string line in File.ReadLines("puzzleinput.txt"))
            {
                 Console.WriteLine("Line:" + line);
            }
        }


        static void Main ()
        {
            Program p = new Program();
            p.TBD();
        }
    }
}
