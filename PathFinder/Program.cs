using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            List<int>[] graph = ReadGraph(nodes);
            int pathsCount = int.Parse(Console.ReadLine());
            List<int>[] paths = ReadPaths(pathsCount);

            foreach (List<int> path in paths)
            {
                bool isPathExist = TraverseBFS(graph, path);

                if (isPathExist)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }

        private static bool TraverseBFS(List<int>[] graph, List<int> path)
        {
            Queue<int> queue = new Queue<int>();

            int count = 0;
            queue.Enqueue(path[count]);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                count++;

                if (graph[current].Contains(path[count]))
                {
                    if (count == path.Count - 1)
                    {
                        break;
                    }

                    queue.Enqueue(path[count]);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static List<int>[] ReadPaths(int pathsCount)
        {
            List<int>[] paths = new List<int>[pathsCount];

            for (int i = 0; i < pathsCount; i++)
            {
                string input = Console.ReadLine();
                int[] children = !string.IsNullOrEmpty(input) ?
                    input.Split().Select(int.Parse).ToArray()
                    : new int[0];

                paths[i] = new List<int>(children);
            }

            return paths;
        }

        private static List<int>[] ReadGraph(int nodes)
        {
            List<int>[] graph = new List<int>[nodes];

            for (int i = 0; i < nodes; i++)
            {
                string input = Console.ReadLine();
                int[] children = !string.IsNullOrEmpty(input) ?
                    input.Split().Select(int.Parse).ToArray()
                    : new int[0];

                graph[i] = new List<int>(children);
            }

            return graph;
        }
    }
}
