using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2023
{
    public class Day04 : AoCDay
    {
        public override void Solve()
        {
            int sumP1 = 0;
            List<int> cardMatches = [0];
            List<int> cardCount = [0];

            foreach (string s in Input)
            {
                int cardID;
                string[] splitted = s.Split([':'], StringSplitOptions.RemoveEmptyEntries);

                string[] cardidSplit = splitted[0].Split([' '], StringSplitOptions.RemoveEmptyEntries);
                cardID = int.Parse(cardidSplit[1]);

                string[] numberSplit = splitted[1].Split(['|'], StringSplitOptions.RemoveEmptyEntries);

                string[] winningNumbersSplit = numberSplit[0].Split([' '], StringSplitOptions.RemoveEmptyEntries);

                List<int> winningNumbers = [];
                foreach (string wns in winningNumbersSplit)
                {
                    winningNumbers.Add(int.Parse(wns));
                }

                string[] scratchNumbersSplit = numberSplit[1].Split([' '], StringSplitOptions.RemoveEmptyEntries);
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
