using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2016
{
    class Disc
    {
        public int Positions { get; internal set; }
        public int CurrentPosition { get; internal set; }

        public Disc(int positions, int startingPosition)
        {
            this.Positions = positions;
            this.CurrentPosition = startingPosition;
        }

        public int GetPositionAt(int time)
        {
            return (time + this.CurrentPosition) % this.Positions;
        }
    }

    public class Day15 : Day
    {
        static int DiscMazePassThrough(List<string> input, bool second)
        {
            List<Disc> discs = new();
            foreach (string line in input)
            {
                string[] splitted = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                discs.Add(new Disc(int.Parse(splitted[3]), int.Parse(splitted[11].Remove(1))));
            }
            if (second)
            {
                discs.Add(new Disc(11, 0));
            }

            int time = 0;
            while (true)
            {
                bool allDiscsAtPos0 = true;
                for (int i = 0; i < discs.Count; i++)
                {
                    if (discs[i].GetPositionAt(time + i + 1) != 0)
                    {
                        allDiscsAtPos0 = false;
                        break;
                    }
                }
                if (allDiscsAtPos0)
                {
                    break;
                }
                time++;
            }

            return time;
        }

        public override void Solve()
        {
            Part1Solution = DiscMazePassThrough(Input, false).ToString();

            Part2Solution = DiscMazePassThrough(Input, true).ToString();
        }
    }
}
