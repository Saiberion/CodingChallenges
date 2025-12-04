using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge04 : Challenge
    {
        static private int CheckAdjecent(char[,] map, int x, int y)
        {
            int blockedSpaces = 0;

            if (x > 0)
            {
                if (map[x - 1, y] != '.')
                {
                    blockedSpaces++;
                }
            }
            if (x < (map.GetLength(0) - 1))
            {
                if (map[x + 1, y] != '.')
                {
                    blockedSpaces++;
                }
            }
            if (y > 0)
            {
                if (map[x, y - 1] != '.')
                {
                    blockedSpaces++;
                }
            }
            if (y < (map.GetLength(1) - 1))
            {
                if (map[x, y + 1] != '.')
                {
                    blockedSpaces++;
                }
            }
            if ((x > 0) && (y > 0))
            {
                if (map[x - 1, y - 1] != '.')
                {
                    blockedSpaces++;
                }
            }
            if ((x < (map.GetLength(0) - 1)) && (y < (map.GetLength(1) - 1)))
            {
                if (map[x + 1, y + 1] != '.')
                {
                    blockedSpaces++;
                }
            }
            if ((x < (map.GetLength(0) - 1)) && (y > 0))
            {
                if (map[x + 1, y - 1] != '.')
                {
                    blockedSpaces++;
                }
            }
            if ((x > 0) && (y < (map.GetLength(1) - 1)))
            {
                if (map[x - 1, y + 1] != '.')
                {
                    blockedSpaces++;
                }
            }

            return blockedSpaces;
        }

        static private int CountAllPaperRolls(char[,] map)
        {
            int blocked = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == '@')
                    {
                        blocked++;
                    }
                }
            }
            return blocked;
        }

        static private int CountAccessablePaperRolls(char[,] map, bool freeAccessableSpace)
        {
            int removeable = 0;

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] != '.')
                    {
                        if (CheckAdjecent(map, x, y) < 4)
                        {
                            removeable++;
                            if (freeAccessableSpace)
                            {
                                map[x, y] = 'A';
                            }
                        }
                    }
                }
            }

            if (freeAccessableSpace)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    for (int x = 0; x < map.GetLength(0); x++)
                    {
                        if (map[x, y] == 'A')
                        {
                            map[x, y] = '.';
                        }
                    }
                }
            }

            return removeable;
        }

        public override void Solve()
        {
            char[,] paperStorage = new char[Input[0].Length, Input.Count];

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    paperStorage[x, y] = Input[y][x];
                }
            }

            int initialPaperRolls = CountAllPaperRolls(paperStorage);
            int moveableRolls = CountAccessablePaperRolls(paperStorage, false);

            Part1Solution = moveableRolls.ToString();

            do
            {
                moveableRolls = CountAccessablePaperRolls(paperStorage, true);
            } while (moveableRolls > 0);

            int remainingPaperRolls = CountAllPaperRolls(paperStorage);
            Part2Solution = (initialPaperRolls - remainingPaperRolls).ToString();

            Part3Solution = "";
        }
    }
}
