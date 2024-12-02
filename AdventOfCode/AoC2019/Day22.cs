using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2019
{
    public class Day22 : AoCDay
    {
        private long ShuffleAndFollowCard(long card, long deckSize, long iterations)
        {
            long posOfCard = card;

            for (long l = 0; l < iterations; l++)
            {
                foreach (string s in Input)
                {
                    string[] splitted = s.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    if (splitted[0].Equals("deal"))
                    {
                        if (splitted[1].Equals("into"))
                        {
                            posOfCard = deckSize - posOfCard - 1;
                        }
                        else if (splitted[1].Equals("with"))
                        {
                            long incr = long.Parse(splitted[3]);
                            posOfCard = (posOfCard * incr) % deckSize;
                        }
                    }
                    else if (splitted[0].Equals("cut"))
                    {
                        long cutAmount = long.Parse(splitted[1]);
                        if (cutAmount > 0)
                        {
                            if (posOfCard < cutAmount)
                            {
                                posOfCard = deckSize - cutAmount + posOfCard;
                            }
                            else
                            {
                                posOfCard -= cutAmount;
                            }
                        }
                        else
                        {
                            if (posOfCard < (deckSize + cutAmount))
                            {
                                posOfCard -= cutAmount;
                            }
                            else
                            {
                                posOfCard = posOfCard - deckSize - cutAmount;
                            }
                        }
                    }
                }
            }

            return posOfCard;
        }

        /*private long ShuffleAndFollowPosition(long card, long deckSize)
        {
            for (long l = 0; l < deckSize; l++)
            {
                if (ShuffleAndFollowCard(l, deckSize, 101741582076661) == card)
                {
                    return l;
                }
            }
            return -1;
        }*/

        override public void Solve()
        {
            Part1Solution = ShuffleAndFollowCard(2019, 10007, 1).ToString();
            Part2Solution = "TBD";
            //Part2Solution = ShuffleAndFollowPosition(2020, 119315717514047L).ToString();
        }
    }
}
