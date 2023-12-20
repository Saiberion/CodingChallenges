using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class Day22 : Day
    {
        private static bool SequenceIsEqal(List<int> l1, List<int> l2)
        {
            if (l1.Count == l2.Count)
            {
                for (int i = 0; i < l1.Count; i++)
                {
                    if (l1[i] != l2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int StartGame(List<int> p1, List<int> p2, bool recursive)
        {
            List<List<int>> prevRoundsP1 = new();
            List<List<int>> prevRoundsP2 = new();
            if (!recursive)
            {
                while ((p1.Count > 0) && (p2.Count > 0))
                {
                    if (p1[0] > p2[0])
                    {
                        p1.Add(p1[0]);
                        p1.Add(p2[0]);
                    }
                    else
                    {
                        p2.Add(p2[0]);
                        p2.Add(p1[0]);
                    }
                    p1.RemoveAt(0);
                    p2.RemoveAt(0);
                }

                if (p1.Count == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                bool endGame = false;
                while ((p1.Count > 0) && (p2.Count > 0) && !endGame)
                {
                    for (int i = 0; i < prevRoundsP1.Count; i++)
                    {
                        if (SequenceIsEqal(prevRoundsP1[i], p1) && SequenceIsEqal(prevRoundsP2[i], p2))
                        {
                            endGame = true;
                            break;
                        }
                    }
                    if (endGame)
                    {
                        continue;
                    }

                    prevRoundsP1.Add(new List<int>(p1));
                    prevRoundsP2.Add(new List<int>(p2));

                    int c1 = p1[0];
                    int c2 = p2[0];

                    p1.RemoveAt(0);
                    p2.RemoveAt(0);

                    if ((c1 <= p1.Count) && (c2 <= p2.Count))
                    {
                        int[] new_p1, new_p2;
                        new_p1 = new int[c1];
                        new_p2 = new int[c2];
                        p1.CopyTo(0, new_p1, 0, c1);
                        p2.CopyTo(0, new_p2, 0, c2);
                        // start sub game
                        if (StartGame(new List<int>(new_p1), new List<int>(new_p2), recursive) == 0)
                        {
                            p1.Add(c1);
                            p1.Add(c2);
                        }
                        else
                        {
                            p2.Add(c2);
                            p2.Add(c1);
                        }
                    }
                    else
                    {
                        if (c1 > c2)
                        {
                            p1.Add(c1);
                            p1.Add(c2);
                        }
                        else
                        {
                            p2.Add(c2);
                            p2.Add(c1);
                        }
                    }
                }

                if (p1.Count == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private static int GetScore(List<int> p1, List<int> p2, int winnerIdx)
        {
            List<int>[] new_deck = new List<int>[2];
            new_deck[0] = p1;
            new_deck[1] = p2;

            int score = 0;
            for (int i = 0; i < new_deck[winnerIdx].Count; i++)
            {
                score += (new_deck[winnerIdx].Count - i) * new_deck[winnerIdx][i];
            }
            return score;
        }

        override public void Solve()
        {
            List<int>[] decks = new List<int>[2];

            decks[0] = new List<int>();
            decks[1] = new List<int>();

            int playerIdx = -1;
            string[] splitted;

            foreach(string s in Input)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    if (s.StartsWith("Player"))
                    {
                        splitted = s.Split(new string[] { "Player ", ":" }, StringSplitOptions.RemoveEmptyEntries);
                        playerIdx = int.Parse(splitted[0]) - 1;
                    }
                    else
                    {
                        decks[playerIdx].Add(int.Parse(s));
                    }
                }
            }

            List<int> p1 = new(decks[0].ToArray());
            List<int> p2 = new(decks[1].ToArray());
            playerIdx = StartGame(p1, p2, false);
            Part1Solution = GetScore(p1, p2, playerIdx).ToString();

            p1 = new(decks[0].ToArray());
            p2 = new(decks[1].ToArray());
            playerIdx = StartGame(p1, p2, true);
            Part2Solution = GetScore(p1, p2, playerIdx).ToString();
        }
    }
}
