using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2022
{
    public class Day06 : Day
    {
        private int PositionAfterDistinctChars(int distinct)
        {
            int i;
            for (i = distinct; i < Input[0].Length; i++)
            {
                char[] c = new char[distinct];
                for (int k = 0; k < distinct; k++)
                {
                    c[k] = Input[0][i - k - 1];
                }
                Dictionary<char, int> uniqueKeys = new();
                uniqueKeys.Add(c[0], 1);
                try
                {
                    for (int j = 1; j < distinct; j++)
                    {
                        uniqueKeys.Add(c[j], 1);
                    }
                    break;
                }
                catch (Exception)
                {

                }
            }
            return i;
        }

        public override void Solve()
        {
            Part1Solution = PositionAfterDistinctChars(4).ToString();

            Part2Solution = PositionAfterDistinctChars(14).ToString();
        }
    }
}
