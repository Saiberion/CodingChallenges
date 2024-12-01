using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day05 : AoCDay
    {
        private static int GetStackCount(string stackIDs)
        {
            string[] splitted = stackIDs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return splitted.Length;
        }

        private void StacksInitialize(Stack<char>[] stacks)
        {
            foreach (Stack<char> s in stacks)
            {
                s.Clear();
            }

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
        }

        private void CrateMover(Stack<char>[] stacks, bool advanced)
        {
            for (int i = 10; i < Input.Count; i++)
            {
                string[] splitted = Input[i].Split(new string[] { "move", "from", " ", "to" }, StringSplitOptions.RemoveEmptyEntries);
                int count = int.Parse(splitted[0]);
                int from = int.Parse(splitted[1]) - 1;
                int to = int.Parse(splitted[2]) - 1;
                if (!advanced)
                {
                    for (int c = 0; c < count; c++)
                    {
                        stacks[to].Push(stacks[from].Pop());
                    }
                }
                else
                {
                    Stack<char> tmp = new();
                    for (int c = 0; c < count; c++)
                    {
                        tmp.Push(stacks[from].Pop());
                    }
                    for (int c = 0; c < count; c++)
                    {
                        stacks[to].Push(tmp.Pop());
                    }
                }
            }
        }

        private static string GetTopCrates(Stack<char>[] stacks)
        {
            StringBuilder sb = new();
            foreach (Stack<char> s in stacks)
            {
                sb.Append(s.Pop());
            }
            return sb.ToString();
        }

        public override void Solve()
        {
            Stack<char>[] stacks;
            int stackCount = GetStackCount(Input[8]);
            stacks = new Stack<char>[stackCount];
            for (int i = 0; i < stackCount; i++)
            {
                stacks[i] = new Stack<char>();
            }

            StacksInitialize(stacks);
            CrateMover(stacks, false);
            Part1Solution = GetTopCrates(stacks);

            StacksInitialize(stacks);
            CrateMover(stacks, true);
            Part2Solution = GetTopCrates(stacks);
        }
    }
}
