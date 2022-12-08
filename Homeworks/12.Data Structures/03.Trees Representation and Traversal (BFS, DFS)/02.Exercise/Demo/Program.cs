namespace Demo
{
    using System;

    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            var input = new string[] { "9 17", "9 4", "9 14", "4 36", "14 53", "14 59", "53 67", "53 73" };

            var treeFactory = new IntegerTreeFactory();

            var tree = treeFactory.CreateTreeFromStrings(input);
            Console.WriteLine($"Tree {new String('-', 20)}");
            Console.WriteLine(tree.AsString());


            Console.WriteLine($"Leafs {new String('-', 20)}");
            var leafs = tree.GetLeafKeys();
            Console.WriteLine(string.Join(", ",leafs));


            Console.WriteLine($"Internal Nodes {new String('-', 20)}");
            var internalKeys = tree.GetInternalKeys();
            Console.WriteLine(string.Join(", ", internalKeys));


            Console.WriteLine($"Deepest Key {new String('-', 20)}");
            var deepestKey = tree.GetDeepestKey();
            Console.WriteLine(deepestKey);

            Console.WriteLine($"Longest Path {new String('-', 20)}");
            var longestPath = tree.GetLongestPath();
            Console.WriteLine(string.Join(", ", longestPath));

        }
    }
}
