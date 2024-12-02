using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2023
{
    public class Day04 : AoCDay
    {
        public override void Solve()
        {
            int sumP1 = 0;
            List<int> cardMatches = new() { 0 };
            List<int> cardCount = new() { 0 };

            foreach (string s in Input)
            {
                int cardID;
                string[] splitted = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string[] cardidSplit = splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                cardID = int.Parse(cardidSplit[1]);

                string[] numberSplit = splitted[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string[] winningNumbersSplit = numberSplit[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> winningNumbers = new();
                foreach (string wns in winningNumbersSplit)
                {
                    winningNumbers.Add(int.Parse(wns));
                }

                string[] scratchNumbersSplit = numberSplit[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int numberMatches = 0;
                foreach (string sns in scratchNumbersSplit)
                {
                    if (winningNumbers.Contains(int.Parse(sns)))
                    {
                        numberMatches++;
                    }
                }
                cardMatches.Add(numberMatches);
                if (numberMatches > 0)
                {
                    sumP1 += 1 << (numberMatches - 1);
                }
                cardCount.Add(1);
            }

            Part1Solution = sumP1.ToString();

            for (int i = 1; i < cardCount.Count; i++)
            {
                int matches = cardMatches[i];
                for (int j = i + 1; matches > 0; j++, matches--)
                {
                    cardCount[j] += cardCount[i];
                }
            }

            int sumP2 = 0;
            foreach (int n in cardCount)
            {
                sumP2 += n;
            }

            Part2Solution = sumP2.ToString();
        }
    }
}
