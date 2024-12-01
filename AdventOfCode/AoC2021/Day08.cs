using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day08 : AoCDay
    {
        override public void Solve()
        {
            int countUnique = 0;
            int sumUp = 0;

            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitted2 = splitted[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] splitted3 = splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string s2 in splitted2)
                {
                    if ((s2.Length == 2) || (s2.Length == 3) || (s2.Length == 4) || (s2.Length == 7))
                    {
                        countUnique++;
                    }
                }

                char A = 'Q', B = 'Q', C = 'Q', D = 'Q', E = 'Q', F = 'Q', G = 'Q';
                Dictionary<int, List<string>> segmentMapping = new()
                {
                    { 0, new List<string>() },
                    { 1, new List<string>() },
                    { 2, new List<string>() },
                    { 3, new List<string>() },
                    { 4, new List<string>() },
                    { 5, new List<string>() },
                    { 6, new List<string>() },
                    { 7, new List<string>() }
                };

                foreach (string s3 in splitted3)
                {
                    segmentMapping[s3.Length].Add(s3);
                }
                int idx1 = segmentMapping[3][0].IndexOf(segmentMapping[2][0][0]);
                string step1 = segmentMapping[3][0].Remove(idx1, 1);
                int idx2 = step1.IndexOf(segmentMapping[2][0][1]);
                string step2 = step1.Remove(idx2, 1);

                A = step2[0];


                foreach (string sixSegs in segmentMapping[6])
                {
                    if ((sixSegs.Contains(segmentMapping[2][0][0].ToString()) && sixSegs.Contains(segmentMapping[2][0][1].ToString())) == false)
                    {
                        if (sixSegs.Contains(segmentMapping[2][0][0].ToString()) == false)
                        {
                            C = segmentMapping[2][0][0];
                        }
                        else
                        {
                            C = segmentMapping[2][0][1];
                        }
                    }
                }


                F = segmentMapping[2][0].Remove(segmentMapping[2][0].IndexOf(C), 1)[0];


                foreach (string sixSegs in segmentMapping[6])
                {
                    string reduced = sixSegs;
                    for (int i = 0; i < segmentMapping[4][0].Length; i++)
                    {
                        if (reduced.Contains(segmentMapping[4][0][i].ToString()))
                        {
                            reduced = reduced.Remove(reduced.IndexOf(segmentMapping[4][0][i]), 1);
                        }
                    }
                    if (reduced.Contains(A.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(A), 1);
                    }
                    if (reduced.Length == 1)
                    {
                        G = reduced[0];
                    }
                }


                foreach (string fiveSegs in segmentMapping[5])
                {
                    string reduced = fiveSegs;
                    if (reduced.Contains(A.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(A), 1);
                    }
                    if (reduced.Contains(C.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(C), 1);
                    }
                    if (reduced.Contains(F.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(F), 1);
                    }
                    if (reduced.Contains(G.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(G), 1);
                    }
                    if (reduced.Length == 1)
                    {
                        D = reduced[0];
                    }
                }


                foreach (string fiveSegs in segmentMapping[5])
                {
                    string reduced = fiveSegs;
                    for (int i = 0; i < segmentMapping[4][0].Length; i++)
                    {
                        if (reduced.Contains(segmentMapping[4][0][i].ToString()))
                        {
                            reduced = reduced.Remove(reduced.IndexOf(segmentMapping[4][0][i]), 1);
                        }
                    }
                    if (reduced.Contains(A.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(A), 1);
                    }
                    if (reduced.Contains(G.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(G), 1);
                    }
                    if (reduced.Length == 1)
                    {
                        E = reduced[0];
                    }
                }


                foreach (string sevenSegs in segmentMapping[7])
                {
                    string reduced = sevenSegs;
                    if (reduced.Contains(A.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(A), 1);
                    }
                    if (reduced.Contains(C.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(C), 1);
                    }
                    if (reduced.Contains(D.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(D), 1);
                    }
                    if (reduced.Contains(E.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(E), 1);
                    }
                    if (reduced.Contains(F.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(F), 1);
                    }
                    if (reduced.Contains(G.ToString()))
                    {
                        reduced = reduced.Remove(reduced.IndexOf(G), 1);
                    }
                    if (reduced.Length == 1)
                    {
                        B = reduced[0];
                    }
                }


                Dictionary<string, int> numberMapping = new();
                StringBuilder sb;

                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(B);
                sb.Append(C);
                sb.Append(E);
                sb.Append(F);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 0);
                sb = new StringBuilder();
                sb.Append(C);
                sb.Append(F);
                numberMapping.Add(SortString(sb.ToString()), 1);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(C);
                sb.Append(D);
                sb.Append(E);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 2);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(C);
                sb.Append(D);
                sb.Append(F);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 3);
                sb = new StringBuilder();
                sb.Append(B);
                sb.Append(C);
                sb.Append(D);
                sb.Append(F);
                numberMapping.Add(SortString(sb.ToString()), 4);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(B);
                sb.Append(D);
                sb.Append(F);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 5);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(B);
                sb.Append(D);
                sb.Append(E);
                sb.Append(F);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 6);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(C);
                sb.Append(F);
                numberMapping.Add(SortString(sb.ToString()), 7);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(B);
                sb.Append(C);
                sb.Append(D);
                sb.Append(E);
                sb.Append(F);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 8);
                sb = new StringBuilder();
                sb.Append(A);
                sb.Append(B);
                sb.Append(C);
                sb.Append(D);
                sb.Append(F);
                sb.Append(G);
                numberMapping.Add(SortString(sb.ToString()), 9);

                sb = new StringBuilder();
                foreach (string s2 in splitted2)
                {
                    sb.Append(numberMapping[SortString(s2)]);
                }
                sumUp += int.Parse(sb.ToString());
            }


            Part1Solution = countUnique.ToString();
            Part2Solution = sumUp.ToString();
        }

        static string SortString(string input)
        {
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
