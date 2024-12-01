using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
    public class Day02 : AoCDay
    {
        public override void Solve()
        {
            int sum = 0;
            int sumdiv = 0;
            List<List<int>> spreadsheet = new();

            foreach (string line in Input)
            {
                List<int> row = new();
                string[] splitted = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int min = int.MaxValue;
                int max = int.MinValue;
                foreach (string s in splitted)
                {
                    int i = int.Parse(s);
                    min = Math.Min(min, i);
                    max = Math.Max(max, i);
                    row.Add(i);
                }
                sum += max - min;
                spreadsheet.Add(row);
            }

            foreach (List<int> l in spreadsheet)
            {
                bool keepRunning = true;
                for (int dividend = 0; (dividend < l.Count) && keepRunning; dividend++)
                {
                    for (int divisor = 0; (divisor < l.Count) && keepRunning; divisor++)
                    {
                        if (dividend != divisor)
                        {
                            if (l[dividend] % l[divisor] == 0)
                            {
                                sumdiv += l[dividend] / l[divisor];
                                keepRunning = false;
                            }
                        }
                    }
                }
            }

            Part1Solution = sum.ToString();
            Part2Solution = sumdiv.ToString();
        }
    }
}
