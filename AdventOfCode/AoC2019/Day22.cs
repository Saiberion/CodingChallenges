using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class Day22 : Day
    {
        override public void Solve()
        {
            List<int> cards = new List<int>();

            for (int i = 0; i < 10007; i++)
            {
                cards.Add(i);
            }

            foreach(string s in Input)
            {
                string[] splitted = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (splitted[0].Equals("deal"))
                {
                    if (splitted[1].Equals("into"))
                    {
                        cards.Reverse();
                    }
                    else if (splitted[1].Equals("with"))
                    {
                        int incr = int.Parse(splitted[3]);
                        int[] arr = new int[cards.Count];
                        for(int i = 0, pos = 0; i < cards.Count; i++)
                        {
                            arr[pos] = cards[i];
                            pos = (pos + incr) % arr.Length;
                        }
                        cards.Clear();
                        cards.AddRange(arr);
                    }
                }
                else if (splitted[0].Equals("cut"))
                {
                    int cutAmount = int.Parse(splitted[1]);
                    if (cutAmount > 0)
                    {
                        cards.AddRange(cards.GetRange(0, cutAmount));
                        cards.RemoveRange(0, cutAmount);
                    }
                    else
                    {
                        // expect negative, as cut 0 would do nothing
                        cutAmount = Math.Abs(cutAmount);
                        cards.InsertRange(0, cards.GetRange(cards.Count - cutAmount, cutAmount));
                        cards.RemoveRange(cards.Count - cutAmount, cutAmount);
                    }
                }
                
            }

            Part1Solution = cards.IndexOf(2019).ToString();
            Part2Solution = "TBD";
        }
    }
}
