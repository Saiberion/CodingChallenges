using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge02 : Challenge
    {
        static private bool IdIsValid(string id)
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
        
        static private bool IdIsValidExtended(string id)
        {
            if (id.Length > 1)
            {
                for (int matchWindowSize = 1; matchWindowSize <= (id.Length / 2); matchWindowSize++)
                {
                    if ((id.Length % matchWindowSize) == 0)
                    {
                        bool allBlocksEqual = true;
                        for (int i = 0; i < (id.Length - matchWindowSize); i += matchWindowSize)
                        {
                            allBlocksEqual &= (id[i..(i + matchWindowSize)].Equals(id[(i + matchWindowSize)..(i + 2 * matchWindowSize)]));
                            if (allBlocksEqual == false)
                            {
                                break;
                            }
                        }
                        if (allBlocksEqual)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public override void Solve()
        {
            long resultP1 = 0;
            long resultP2 = 0;
            string[] ranges = Input[0].Split([','], StringSplitOptions.RemoveEmptyEntries);

            foreach(string range in ranges)
            {
                string[] rangeLimits = range.Split(['-'], StringSplitOptions.RemoveEmptyEntries);

                for(long l = long.Parse(rangeLimits[0]); l<= long.Parse(rangeLimits[1]); l++)
                {
                    if (!IdIsValid(l.ToString()))
                    {
                        resultP1 += l;
                    }
                    if (!IdIsValidExtended(l.ToString()))
                    {
                        resultP2 += l;
                    }
                }
            }

            Part1Solution = resultP1.ToString();

            Part2Solution = resultP2.ToString();

            Part3Solution = "";
        }
    }
}
