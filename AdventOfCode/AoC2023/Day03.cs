using AdventOfCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AoC2023
{
    public class Day03 : AoCDay
    {
        private Point gearCoords = new(-1, -1);

        public bool FindSpecialChar(int x, int y)
        {
            bool result = false;
            char borderingChar = Input[y][x];
            if (!char.IsDigit(borderingChar) && (borderingChar != '.'))
            {
                result = true;
            }
            if (borderingChar == '*')
            {
                gearCoords = new(x, y);
            }
            return result;
        }

        public override void Solve()
        {
            char nextChar;
            int sumP1 = 0;
            int sumP2 = 0;

            // confirmed by debugging that a part number will have only one special character around it
            bool isPartNumber = false;
            List<char> partNumber = new();
            Dictionary<Point, List<int>> gears = new();

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if (char.IsDigit(Input[y][x]))
                    {
                        partNumber.Add(Input[y][x]);
                        if ((x > 0) && (y > 0))
                        {
                            isPartNumber |= FindSpecialChar(x - 1, y - 1);
                        }
                        if (x > 0)
                        {
                            isPartNumber |= FindSpecialChar(x - 1, y);
                        }
                        if ((x > 0) && (y < (Input.Count - 1)))
                        {
                            isPartNumber |= FindSpecialChar(x - 1, y + 1);
                        }
                        if (y < (Input.Count - 1))
                        {
                            isPartNumber |= FindSpecialChar(x, y + 1);
                        }
                        if ((x < (Input[y].Length - 1)) && (y < (Input.Count - 1)))
                        {
                            isPartNumber |= FindSpecialChar(x + 1, y + 1);
                        }
                        if (x < (Input[y].Length - 1))
                        {
                            isPartNumber |= FindSpecialChar(x + 1, y);
                            nextChar = Input[y][x + 1];
                        }
                        else
                        {
                            nextChar = '.';
                        }
                        if ((x < (Input[y].Length - 1)) && (y > 0))
                        {
                            isPartNumber |= FindSpecialChar(x + 1, y - 1);
                        }
                        if (y > 0)
                        {
                            isPartNumber |= FindSpecialChar(x, y - 1);
                        }

                        if (!char.IsDigit(nextChar))
                        {
                            if (isPartNumber)
                            {
                                StringBuilder sb = new();
                                foreach (char c in partNumber)
                                {
                                    sb.Append(c);
                                }
                                int partNr = int.Parse(sb.ToString());
                                if (gearCoords != new Point(-1, -1))
                                {
                                    if (gears.ContainsKey(gearCoords))
                                    {
                                        gears[gearCoords].Add(partNr);
                                    }
                                    else
                                    {
                                        gears.Add(gearCoords, new List<int>() { partNr });
                                    }
                                    gearCoords = new(-1, -1);
                                }
                                sumP1 += partNr;
                                isPartNumber = false;
                            }
                            partNumber.Clear();
                        }
                    }
                }
            }

            Part1Solution = sumP1.ToString();

            foreach (List<int> l in gears.Values)
            {
                if (l.Count == 2)
                {
                    sumP2 += l[0] * l[1];
                }
            }

            Part2Solution = sumP2.ToString();
        }
    }
}
