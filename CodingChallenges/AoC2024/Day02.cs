using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2024
{
    public class Day02 : AoCDay
    {
        private static bool IsValidReport(List<int> report)
        {
            int prev = report[0];
            int dir = 0;

            for (int i = 1; i < report.Count; i++)
            {
                int diff = report[i] - prev;
                if (dir == 0)
                {
                    dir = diff;
                    if (diff == 0)
                    {
                        return false;
                    }
                }
                else if (dir > 0)
                {
                    if (diff <= 0)
                    {
                        return false;
                    }
                }
                else if (dir < 0)
                {
                    if (diff >= 0)
                    {
                        return false;
                    }
                }

                if (Math.Abs(diff) > 3)
                {
                    return false;
                }

                prev = report[i];
            }
            return true;
        }

        private static bool IsValidDampened(List<int> report)
        {
            if (!IsValidReport(report))
            {
                for (int i = 0; i < report.Count; i++)
                {
                    List<int> rep = [];
                    rep.AddRange(report);
                    rep.RemoveAt(i);

                    if (IsValidReport(rep))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        public override void Solve()
        {
            int validReports = 0;
            int validReportsDampened = 0;
            List<int> report = [];
            foreach(string s in Input)
            {
                report.Clear();
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                foreach (string r in splitted)
                {
                    report.Add(int.Parse(r));
                }
                if (IsValidReport(report))
                {
                    validReports++;
                }
                if (IsValidDampened(report))
                {
                    validReportsDampened++;
                }
            }

            Part1Solution = validReports.ToString();

            Part2Solution = validReportsDampened.ToString();
        }
    }
}
