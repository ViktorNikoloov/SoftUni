namespace _03.Guards
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes + 1];
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var from = edge[0];
                var to = edge[1];
                
                graph[from].Add(to);
            }

            var startNode = int.Parse(Console.ReadLine());

            visited = new bool[nodes + 1];
            DFS(startNode);


            Console.WriteLine(GetOut());
        }

        private static string GetOut()
        {
            var sb = new StringBuilder();

            for (int i = 1; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    sb.Append($"{i} ");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child);
            }
        }
    }
}