using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day03 : Day
    {
        override public void Solve()
        {
            int gammaRate = GetGammaRate(new List<string>(Input.ToArray()));
            
            Part1Solution = (gammaRate * (~gammaRate & ((int)Math.Pow(2, Input[0].Length) - 1))).ToString();

            int o2Rate = GetO2GenRate(new List<string>(Input.ToArray()));
            int co2Rate = GetCO2GenRate(new List<string>(Input.ToArray()));
            Part2Solution = (o2Rate * co2Rate).ToString();
        }

        private int GetO2GenRate(List<string> diag)
        {
            int counter;
            StringBuilder o2Rate = new StringBuilder();

            for (int bitpos = 0; (bitpos < diag[0].Length) && (diag.Count > 1); bitpos++)
            {
                counter = 0;
                for (int l = 0; l < diag.Count; l++)
                {
                    if (diag[l][bitpos] == '0')
                    {
                        counter--;
                    }
                    else
                    {
                        counter++;
                    }
                }

                if (counter >= 0)
                {
                    o2Rate.Append("1");
                }
                else if (counter < 0)
                {
                    o2Rate.Append("0");
                }

                List<string> newdiag = new List<string>();
                for (int l = 0; l < diag.Count; l++)
                {
                    if (diag[l].StartsWith(o2Rate.ToString()))
                    {
                        newdiag.Add(diag[l]);
                    }
                }
                diag = newdiag;
            }

            int o2 = 0;
            for(int l = 0; l < o2Rate.Length; l++)
            {
                o2 <<= 1;
                if (o2Rate[l] == '1')
                {
                    o2 |= 1;
                }
            }
            return o2;
        }

        private int GetCO2GenRate(List<string> diag)
        {
            int counter;
            StringBuilder co2Rate = new StringBuilder();

            for (int bitpos = 0; (bitpos < diag[0].Length) && (diag.Count > 1); bitpos++)
            {
                counter = 0;
                for (int l = 0; l < diag.Count; l++)
                {
                    if (diag[l][bitpos] == '0')
                    {
                        counter--;
                    }
                    else
                    {
                        counter++;
                    }
                }

                if (counter >= 0)
                {
                    co2Rate.Append("0");
                }
                else if (counter < 0)
                {
                    co2Rate.Append("1");
                }

                List<string> newdiag = new List<string>();
                for (int l = 0; l < diag.Count; l++)
                {
                    if (diag[l].StartsWith(co2Rate.ToString()))
                    {
                        newdiag.Add(diag[l]);
                    }
                }
                diag = newdiag;
            }

            int co2 = 0;
            for (int l = 0; l < diag[0].Length; l++)
            {
                co2 <<= 1;
                if (diag[0][l] == '1')
                {
                    co2 |= 1;
                }
            }
            return co2;
        }

        private int GetGammaRate(List<string> diag)
        {
            int counter;
            int gammaRate = 0;

            for (int bitpos = 0; bitpos < diag[0].Length; bitpos++)
            {
                counter = 0;
                for (int l = 0; l < diag.Count; l++)
                {
                    if (diag[l][bitpos] == '0')
                    {
                        counter--;
                    }
                    else
                    {
                        counter++;
                    }
                }

                gammaRate <<= 1;
                if (counter > 0)
                {
                    gammaRate |= 1;
                }
                else if (counter < 0)
                {
                    gammaRate |= 0;
                }
            }
            return gammaRate;
        }
    }
}
