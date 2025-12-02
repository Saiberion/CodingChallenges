using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge02 : Challenge
    {
        private bool IdIsValid(string id)
        {
            if ((id.Length % 2) == 0)
            {
                if (id[0..(id.Length / 2)].Equals(id[(id.Length / 2)..]))
                {
                    return false;
                }
            }
            return true;
        }

        public override void Solve()
        {
            long resultP1 = 0;
            string[] ranges = Input[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string range in ranges)
            {
                string[] rangeLimits = range.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                for(long l = long.Parse(rangeLimits[0]); l<= long.Parse(rangeLimits[1]); l++)
                {
                    if (!IdIsValid(l.ToString()))
                    {
                        resultP1 += l;
                    }
                }
            }

            Part1Solution = resultP1.ToString();

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
