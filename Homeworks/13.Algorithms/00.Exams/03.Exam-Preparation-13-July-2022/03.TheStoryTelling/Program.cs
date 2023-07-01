namespace _03.TheStoryTelling
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> passed;

        static void Main(string[] args)
        {
            ReadInputAndFillTheGraph();

            passed = new HashSet<string>();
            foreach (var parent in graph.Keys)
            {
                DFS(parent);
            }

            Console.WriteLine(String.Join(" ", passed.Reverse()));
        }

        private static void ReadInputAndFillTheGraph()
        {
            graph = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] args = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);
                string preStory = args[0].Trim();

                if (!graph.ContainsKey(preStory))
                {
                    graph[preStory] = new List<string>();
                }

                if (args.Length < 2)
                {
                    continue;
                }

                string[] postStories = args[1]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                graph[preStory].AddRange(postStories);

            }
        }

        private static void DFS(string parentNode)
        {
            if (passed.Contains(parentNode))
            {
                return;
            }

            foreach (var childNote in graph[parentNode])
            {
                DFS(childNote);
            }

            passed.Add(parentNode);
        }
    }
}