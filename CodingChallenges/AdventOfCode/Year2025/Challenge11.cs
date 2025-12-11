using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    class Device(string name, string[] connections)
    {
        public string Name { get; set; } = name;
        public List<string> ConnectedTo { get; set; } = [.. connections];
        public bool Visited = false;
    }

    public class Challenge11 : Challenge
    {
        static void DFS(string node, string dest, Dictionary<string, Device> graph, ref int count)
        {
            // If destination is reached, 
            // increment count
            if (node.Equals(dest))
            {
                count++;
                return;
            }

            // Mark current node as visited
            graph[node].Visited = true;

            // Explore all unvisited neighbors
            foreach (string neighbor in graph[node].ConnectedTo)
            {
                if (!graph[neighbor].Visited)
                {
                    DFS(neighbor, dest, graph, ref count);
                }
            }

            // Backtrack: unmark the node 
            // before returning
            graph[node].Visited = false;
        }

        static int CountPaths(Dictionary<string, Device> nodes, string source, string destination)
        {
            int count = 0;

            // Start DFS from source
            DFS(source, destination, nodes, ref count);

            return count;
        }

        public override void Solve()
        {
            Dictionary<string, Device> devices= [];

            devices.Add("out", new("out", []));
            foreach (string line in Input)
            {
                string[] devcon = line.Split([' ', ':'], StringSplitOptions.RemoveEmptyEntries);
                devices.Add(devcon[0], new(devcon[0], [.. devcon[1..]]));
            }
            Part1Solution = CountPaths(devices, "you", "out").ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
