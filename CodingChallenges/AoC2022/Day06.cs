using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2022
{
    public class Day06 : AoCDay
    {
        private int PositionAfterDistinctChars(int distinct)
        {
            int i;
            bool nextChar;
            List<char> uniques = [];
            for (i = distinct; i < Input[0].Length; i++)
            {
                uniques.Clear();
                nextChar = false;

                uniques.Add(Input[0][i - 1]);
                for (int j = 1; j < distinct; j++)
                {
                    if (uniques.Contains(Input[0][i - j - 1]))
                    {
                        nextChar = true;
                        break;
                    }
                    else
                    {
                        uniques.Add(Input[0][i - j - 1]);
                    }
                }
                if (!nextChar)
                {
                    break;
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
