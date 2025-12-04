using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge04 : Challenge
    {
        static private int CheckAdjecent(List<string> map, int x, int y)
        {
            int blockedSpaces = 0;

            if (x > 0)
            {
                if (map[y][x - 1] == '@')
                {
                    blockedSpaces++;
                }
            }
            if (x < (map[y].Length - 1))
            {
                if (map[y][x + 1] == '@')
                {
                    blockedSpaces++;
                }
            }
            if (y > 0)
            {
                if (map[y - 1][x] == '@')
                {
                    blockedSpaces++;
                }
            }
            if (y < (map.Count - 1))
            {
                if (map[y + 1][x] == '@')
                {
                    blockedSpaces++;
                }
            }
            if ((x > 0) && (y > 0))
            {
                if (map[y - 1][x - 1] == '@')
                {
                    blockedSpaces++;
                }
            }
            if ((x < (map[y].Length - 1)) && (y < (map.Count - 1)))
            {
                if (map[y + 1][x + 1] == '@')
                {
                    blockedSpaces++;
                }
            }
            if ((x < (map[y].Length - 1)) && (y > 0))
            {
                if (map[y - 1][x + 1] == '@')
                {
                    blockedSpaces++;
                }
            }
            if ((x > 0) && (y < (map.Count - 1)))
            {
                if (map[y + 1][x - 1] == '@')
                {
                    blockedSpaces++;
                }
            }

            return blockedSpaces;
        }

        public override void Solve()
        {
            //char[,] paperStorage = new char[Input[0].Length + 2, Input.Count + 2];
            int moveableRolls = 0;

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    //paperStorage[x + 1, y + 1] = Input[y][x];
                    if (Input[y][x] == '@')
                    {
                        if (CheckAdjecent(Input, x, y) < 4)
                        {
                            moveableRolls++;
                        }
                    }
                }
            }


            Part1Solution = moveableRolls.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
