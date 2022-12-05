using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day05 : Day
    {
        public override void Solve()
        {
            Stack<char>[] stacks = { new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>(), new Stack<char>() };

            for(int i = 7; i >= 0; i--)
            {
                for (int c = 1; c < Input[i].Length; c += 4)
                {
                    if (Input[i][c] != ' ')
                    {
                        stacks[(c - 1) / 4].Push(Input[i][c]);
                    }
                }
            }


            for (int i = 10; i < Input.Count;i++)
            {
                string[] splitted = Input[i].Split(new string[] { "move", "from", " ", "to" }, StringSplitOptions.RemoveEmptyEntries);
                int count = int.Parse(splitted[0]);
                int from = int.Parse(splitted[1]) - 1;
                int to = int.Parse(splitted[2]) - 1;
                for(int c = 0; c < count; c++)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach(Stack<char> s in stacks)
            {
                sb.Append(s.Pop());
                s.Clear();
            }
            Part1Solution = sb.ToString();

            for (int i = 7; i >= 0; i--)
            {
                for (int c = 1; c < Input[i].Length; c += 4)
                {
                    if (Input[i][c] != ' ')
                    {
                        stacks[(c - 1) / 4].Push(Input[i][c]);
                    }
                }
            }

            for (int i = 10; i < Input.Count; i++)
            {
                string[] splitted = Input[i].Split(new string[] { "move", "from", " ", "to" }, StringSplitOptions.RemoveEmptyEntries);
                int count = int.Parse(splitted[0]);
                int from = int.Parse(splitted[1]) - 1;
                int to = int.Parse(splitted[2]) - 1;
                Stack<char> tmp = new Stack<char>();
                for (int c = 0; c < count; c++)
                {
                    tmp.Push(stacks[from].Pop());
                }
                for (int c = 0; c < count; c++)
                {
                    stacks[to].Push(tmp.Pop());
                }
            }

            sb = new StringBuilder();
            foreach (Stack<char> s in stacks)
            {
                sb.Append(s.Pop());
            }

            Part2Solution = sb.ToString();
        }
    }
}
