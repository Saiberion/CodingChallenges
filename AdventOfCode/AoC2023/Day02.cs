using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    public class Day02 : Day
    {
        public override void Solve()
        {
            int sum = 0;
            int sumP2 = 0;
            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                int gameId = int.Parse(splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
                string[] sets = splitted[1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                bool possible = true;
                int maxred = int.MinValue;
                int maxgreen = int.MinValue;
                int maxblue = int.MinValue;
                foreach (string set in sets)
                {
                    string[] cubes = set.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string shownCubes in cubes)
                    {
                        string[] cubecount = shownCubes.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        switch (cubecount[1])
                        {
                            case "red":
                                int r = int.Parse(cubecount[0]);
                                if (r > 12)
                                {
                                    possible = false;
                                }
                                maxred = Math.Max(r, maxred);
                                break;
                            case "green":
                                int g = int.Parse(cubecount[0]);
                                if (g > 13)
                                {
                                    possible = false;
                                }
                                maxgreen = Math.Max(g, maxgreen);
                                break;
                            case "blue":
                                int b = int.Parse(cubecount[0]);
                                if (b > 14)
                                {
                                    possible = false;
                                }
                                maxblue = Math.Max(b, maxblue);
                                break;
                        }
                    }
                }
                if (possible)
                {
                    sum += gameId;
                }
                sumP2 += maxred * maxgreen * maxblue;
            }

            Part1Solution = sum.ToString();

            Part2Solution = sumP2.ToString();
        }
    }
}
