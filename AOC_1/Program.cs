namespace adventofcode
{
    class Program
    {
        //List<int> calories_list = new List<int>();
        public List<int> elf_nr_one = new List<int> {1000, 2000, 3000};
        public List<int> elf_nr_two = new List<int> {4000};
        public  List<int> elf_nr_three = new List<int> {5000, 6000};
        public List<int> elf_nr_four = new List<int> {7000, 8000, 9000};
        public List<int> elf_nr_five = new List<int> {10000};

        private int CaloriesSum(List<int> elf_calories)
        {
            int sum = 0;
            foreach(var cal in elf_calories)
                sum += cal;
            return sum;
        }

        static void Main ()
        {
            Program p = new Program();
            int sum = p.CaloriesSum(p.elf_nr_two);
            Console.WriteLine("ElfOne: " + sum);
        }

    }
}
