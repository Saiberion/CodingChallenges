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
            // by analysing the input all IDs are in the length range of 2 - 10
            switch(id.Length)
            {
                case 10:
                    if (id[0..(id.Length / 2)].Equals(id[(id.Length / 2)..]))
                    {
                        return false;
                    }
                    if ((id[0..2].Equals(id[2..4])) && (id[0..2].Equals(id[4..6])) && (id[0..2].Equals(id[6..8])) && (id[0..2].Equals(id[8..10])))
                    {
                        return false;
                    }
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]) && (id[0] == id[4]) && (id[0] == id[5]) && (id[0] == id[6]) && (id[0] == id[7]) && (id[0] == id[8]) && (id[0] == id[9]))
                    {
                        return false;
                    }
                    break;
                case 9:
                    if ((id[0..3].Equals(id[3..6])) && (id[0..3].Equals(id[6..9])))
                    {
                        return false;
                    }
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]) && (id[0] == id[4]) && (id[0] == id[5]) && (id[0] == id[6]) && (id[0] == id[7]) && (id[0] == id[8]))
                    {
                        return false;
                    }
                    break;
                case 8:
                    if (id[0..(id.Length / 2)].Equals(id[(id.Length / 2)..]))
                    {
                        return false;
                    }
                    if ((id[0..2].Equals(id[2..4])) && (id[0..2].Equals(id[4..6])) && (id[0..2].Equals(id[6..8])))
                    {
                        return false;
                    }
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]) && (id[0] == id[4]) && (id[0] == id[5]) && (id[0] == id[6]) && (id[0] == id[7]))
                    {
                        return false;
                    }
                    break;
                case 7:
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]) && (id[0] == id[4]) && (id[0] == id[5]) && (id[0] == id[6]))
                    {
                        return false;
                    }
                    break;
                case 6:
                    if (id[0..(id.Length / 2)].Equals(id[(id.Length / 2)..]))
                    {
                        return false;
                    }
                    if ((id[0..2].Equals(id[2..4])) && (id[0..2].Equals(id[4..6])))
                    {
                        return false;
                    }
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]) && (id[0] == id[4]) && (id[0] == id[5]))
                    {
                        return false;
                    }
                    break;
                case 5:
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]) && (id[0] == id[4]))
                    {
                        return false;
                    }
                    break;
                case 4:
                    if (id[0..(id.Length / 2)].Equals(id[(id.Length / 2)..]))
                    {
                        return false;
                    }
                    if ((id[0] == id[1]) && (id[0] == id[2]) && (id[0] == id[3]))
                    {
                        return false;
                    }
                    break;
                case 3:
                    if ((id[0] == id[1]) && (id[0] == id[2]))
                    {
                        return false;
                    }
                    break;
                case 2:
                    if (id[0..(id.Length / 2)].Equals(id[(id.Length / 2)..]))
                    {
                        return false;
                    }
                    break;
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
