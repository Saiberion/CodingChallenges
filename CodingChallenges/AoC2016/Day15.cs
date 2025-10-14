using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2016
{
    class Disc(int positions, int startingPosition)
    {
        public int Positions { get; internal set; } = positions;
        public int CurrentPosition { get; internal set; } = startingPosition;

        public int GetPositionAt(int time)
        {
            return (time + this.CurrentPosition) % this.Positions;
        }
    }

    public class Day15 : AoCDay
    {
        static int DiscMazePassThrough(List<string> input, bool second)
        {
            List<Disc> discs = [];
            foreach (string line in input)
            {
                string[] splitted = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
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
