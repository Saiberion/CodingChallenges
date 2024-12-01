using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2015
{
    class ReplacementRule
    {
        public required string From { get; set; }
        public required string To { get; set; }
    }

    public class Day19 : AoCDay
    {
        override public void Solve()
        {
            string startingMolecule = "";
            List<ReplacementRule> replacementRules = new();
            HashSet<string> uniqueMolecules = new();

            foreach (string s in Input)
            {
                if (s.Contains("=>"))
                {
                    // Replacement rule
                    string[] splitted = s.Split(new char[] { ' ', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    replacementRules.Add(new ReplacementRule() { From = splitted[0], To = splitted[1] });
                }
                else if (s.Length > 0)
                {
                    // starting molecule
                    startingMolecule = s;
                }
            }

            foreach (ReplacementRule r in replacementRules)
            {
                int searchIndex = 0;
                int foundIndex;

                while ((foundIndex = startingMolecule.IndexOf(r.From, searchIndex)) >= 0)
                {
                    string n = string.Concat(startingMolecule.AsSpan(0, foundIndex), r.To, startingMolecule.AsSpan(foundIndex + r.From.Length));
                    uniqueMolecules.Add(n);
                    searchIndex = foundIndex + r.From.Length;
                }
            }

            Part1Solution = uniqueMolecules.Count.ToString();

            int cnt = 0;
            while (!startingMolecule.Equals("e"))
            {
                foreach (ReplacementRule r in replacementRules)
                {
                    int searchIndex = 0;
                    int foundIndex;

                    if ((foundIndex = startingMolecule.IndexOf(r.To, searchIndex)) >= 0)
                    {
                        string n = string.Concat(startingMolecule.AsSpan(0, foundIndex), r.From, startingMolecule.AsSpan(foundIndex + r.To.Length));
                        cnt++;
                        startingMolecule = n;
                    }
                }
            }
            Part2Solution = cnt.ToString();
        }
    }
}
