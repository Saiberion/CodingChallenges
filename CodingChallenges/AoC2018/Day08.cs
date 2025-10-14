using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2018
{
    class Node
    {
        public List<Node> Children { get; set; }
        public List<int> MetaData { get; set; }

        public Node()
        {
            this.Children = [];
            this.MetaData = [];
        }
    }

    public class Day08 : AoCDay
    {
        static Node CreateNode(List<int> data)
        {
            int c, m;
            Node n = new();
            c = data[0];
            m = data[1];
            data.RemoveRange(0, 2);
            for (int i = 0; i < c; i++)
            {
                n.Children.Add(CreateNode(data));
            }
            for (int j = 0; j < m; j++)
            {
                n.MetaData.Add(data[j]);
            }
            data.RemoveRange(0, m);
            return n;
        }

        static Node CreateNodeTree(string input)
        {
            List<int> data = [];
            string[] splitted = input.Split([' ']);

            for (int i = 0; i < splitted.Length; i++)
            {
                data.Add(int.Parse(splitted[i]));
            }

            return CreateNode(data);
        }

        static int SumAllMeta(Node rootNode)
        {
            int result = 0;
            for (int i = 0; i < rootNode.MetaData.Count; i++)
            {
                result += rootNode.MetaData[i];
            }
            for (int i = 0; i < rootNode.Children.Count; i++)
            {
                result += SumAllMeta(rootNode.Children[i]);
            }
            return result;
        }

        static int SumOfNode(Node rootNode)
        {
            int result = 0;

            if (rootNode.Children.Count > 0)
            {
                for (int i = 0; i < rootNode.MetaData.Count; i++)
                {
                    if ((rootNode.MetaData[i] > 0) && (rootNode.MetaData[i] <= rootNode.Children.Count))
                    {
                        result += SumOfNode(rootNode.Children[rootNode.MetaData[i] - 1]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < rootNode.MetaData.Count; i++)
                {
                    result += rootNode.MetaData[i];
                }
            }
            return result;
        }

        public override void Solve()
        {
            Node rootNode = CreateNodeTree(Input[0]);
            int sumAllMeta = SumAllMeta(rootNode);
            int sumIdxMeta = SumOfNode(rootNode);

            Part1Solution = sumAllMeta.ToString();
            Part2Solution = sumIdxMeta.ToString();
        }
    }
}
