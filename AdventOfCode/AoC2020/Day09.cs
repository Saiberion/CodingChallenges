using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class Day09 : Day
    {
        private static bool IsValidNumber(long nr, List<long> l)
        {
            for (int a = 0; a < (l.Count - 1); a++)
            {
                for (int b = a + 1; b < l.Count; b++)
                {
                    if ((l[a] + l[b]) == nr)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static long FindEncryptionWeakness(long nr, List<long> l)
        {
            long sum;
            for (int a = 0; a < (l.Count - 1); a++)
            {
                sum = l[a];
                long min = l[a], max = l[a];
                for (int b = a + 1; b < l.Count; b++)
                {
                    min = Math.Min(min, l[b]);
                    max = Math.Max(max, l[b]);
                    sum += l[b];
                    if (sum > nr)
                    {
                        break;
                    }
                    else if (sum == nr)
                    {
                        return min + max;
                    }
                }
            }
            return 0;
        }

        override public void Solve()
        {
            long nextNr = 0;
            List<long> encoding = new();
            List<long> encodingComplete = new();
            for (int i = 0; i < Input.Count; i++)
            {
                encodingComplete.Add(long.Parse(Input[i]));
                if (i < 25)
                {
                    encoding.Add(long.Parse(Input[i]));
                }
                else
                {
                    nextNr = long.Parse(Input[i]);
                    if (!IsValidNumber(nextNr, encoding))
                    {
                        break;
                    }
                    else
                    {
                        encoding.RemoveAt(0);
                        encoding.Add(nextNr);
                    }
                }
            }

            Part1Solution = nextNr.ToString();

            Part2Solution = FindEncryptionWeakness(nextNr, encodingComplete).ToString();
        }
    }
}
