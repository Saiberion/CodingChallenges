using AdventOfCode;
using AoC2018;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    public class Day08 : Day
    {
        readonly Dictionary<string, List<string>> network = new();

        private long StepsToEnd(string node)
        {
            int jumps = 0;

            while (!node.EndsWith("Z"))
            {
                for (int i = 0; (i < Input[0].Length) && !node.Equals("ZZZ"); i++)
                {
                    List<string> currentNode = network[node];
                    if (Input[0][i] == 'L')
                    {
                        node = currentNode[0];
                    }
                    else
                    {
                        node = currentNode[1];
                    }
                    jumps++;
                }
            }
            return jumps;
        }

        public override void Solve()
        {
            for (int i = 2; i < Input.Count; i++)
            {
                string[] splitted = Input[i].Split(new char[] { ' ', '=', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

                network.Add(splitted[0], new List<string>() { splitted[1], splitted[2] });
            }

            string node = "AAA";

            Part1Solution = StepsToEnd(node).ToString();

            //jumps = 0;
            //List<string> nodeWalker = new();
            //List<long> nodeWalker = new();
            long prod = 1;
            foreach (string k in network.Keys)
            {
                if (k.EndsWith("A"))
                {
                    //nodeWalker.Add(StepsToEnd(k));
                    prod *= StepsToEnd(k);
                }
            }

            /*bool walking = true;
            while (walking)
            {
                for (int i = 0; (i < sequence.Length) && walking; i++)
                {
                    //for(int j = 0; j < nodeWalker.Count; j++)
                    int j = 1;
                    {
                        List<string> currentNode = network[nodeWalker[j]];
                        if (sequence[i] == 'L')
                        {
                            nodeWalker[j] = currentNode[0];
                        }
                        else
                        {
                            nodeWalker[j] = currentNode[1];
                        }
                    }
                    jumps++;*/

                    /*walking = false;
                    foreach(string s in nodeWalker)
                    {
                        if (!s.EndsWith("Z"))
                        {
                            walking = true;
                            break;
                        }
                    }*/
                    /*if (nodeWalker[j].EndsWith("Z"))
                    {
                        walking = false;
                    }
                }
            }*/

            Part2Solution = prod.ToString();
        }
    }
}
