namespace adventofcode
{
    /**
    * Advent of code Day 7
    */
    class Program
    {
        private static readonly string[] input = File.ReadAllLines("input.txt");
        internal class Node
        {
            public string? Name { get; set; }
            public Node? Parent { get; set; }
            public List<Node>? Childs { get; set; }
            public int Size { get; set; }
        }

        private static void GetNodeTree(string[] input)
        {
            List<Node>? result = new List<Node>();
            Node currentNode = null;

            foreach (string line in input)
            {
                if (line.StartsWith("$"))           // Commands
                {
                    if (line.Equals("$ ls"))        //Command: List all items
                        continue;

                    if (!line.Equals("$ cd .."))    // Command: Go back one directory
                    {
                        string nodeName = line.Split(' ')[2];
                        if (currentNode == null)
                        {
                            Node node = new()
                            {
                                Name = nodeName,
                                Parent = currentNode
                            };
                            currentNode = node;
                            result.Add(node);
                        }
                        else
                        {
                            try
                            {
                                Node child = currentNode.Childs.FirstOrDefault(x => x.Name == nodeName);
                                if (child != null)
                                {
                                    child.Parent = currentNode;
                                    currentNode = child;
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Error getting child node: {ex}");
                            }
                        }

                    }
                    else
                    {
                        int size = currentNode.Size;
                        currentNode = currentNode.Parent;

                        if (currentNode.Name != "/")
                            currentNode.Size += size;

                    }
                    continue;
                }
                else if (line.StartsWith("dir"))            // Directory name
                {
                    currentNode.Childs ??= new List<Node>();

                    Node child = new()
                    {
                        Name = line.Split(' ')[1]
                    };

                    currentNode.Childs.Add(child);

                    result.Add(child);
                }
                else
                {
                    int values = int.Parse(line.Split(' ')[0]);
                    currentNode.Size += values;
                }
            }
            // Find all of the directories with a total size of at most 100000, then calculate the sum of their total sizes
            Console.WriteLine($"Result: {result.Where(x => x.Size <= 100000).Select(x => x.Size).Sum()}");
        }

        private static void PartOne()
        {
            GetNodeTree(input);
        }

        static void Main()
        {
            Console.WriteLine("Part 1");
            PartOne();

            Console.WriteLine("Press Enter to quit...");
            Console.ReadLine();
        }
    }
}
