using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    public class Day04 : Day
    {
        public override void Solve()
        {
            int sumP1 = 0;
            List<int> cardMatches = new() { 0 };
            List<int> analyzeCards = new();

            foreach (string s in Input)
            {
                int cardID;
                string[] splitted = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string[] cardidSplit = splitted[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                cardID = int.Parse(cardidSplit[1]);

                string[] numberSplit = splitted[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                string[] winningNumbersSplit = numberSplit[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> winningNumbers = new();
                foreach(string wns in winningNumbersSplit)
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
                analyzeCards.Add(cardID);
            }

            Part1Solution = sumP1.ToString();

            /*int countScratchCards = analyzeCards.Count;
            while (analyzeCards.Count > 0)
            {
                int card = analyzeCards[0];
                analyzeCards.RemoveAt(0);
                countScratchCards += cardMatches[card];
                int addcard = 1;
                while (addcard <= cardMatches[card])
                {
                    analyzeCards.Add(card + addcard++);
                }
            }

            Part2Solution = countScratchCards.ToString();*/
            Part2Solution = "TBD";
        }
    }
}
