using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace _03.Path_Finder
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    var children = line
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[i] = children;
                }
            }

            var pathsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pathsCount; i++)
            {
                var path = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                visited = new bool[nodes];

                var startPathIndex = 0;
                var startNode = path[startPathIndex];

                DFS(startNode, path, startPathIndex);

                if (PathExists(path, visited))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static bool PathExists(int[] path, bool[] visited)
        {
            foreach (var node in path)
            {
                if (!visited[node])
                {
                    return false;
                }
            }

            return true;
        }

        private static void DFS(int node, int[] path, int pathIdx)
        {
            if (visited[node] || pathIdx >= path.Length || node != path[pathIdx])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, path, pathIdx + 1);
            }
        }
    }
}