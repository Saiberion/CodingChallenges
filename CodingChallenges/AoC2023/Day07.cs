using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CodingChallenges.AoC2023
{
    public class Hand : IComparable<Hand>
    {
        public enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind
        }
        public string Cards { get; set; }
        public int Bid { get; set; }
        public HandType Type { get; internal set; }
        public List<int> CardValues { get; internal set; }

        private void DetermineHandTypeAndCardValues()
        {
            Dictionary<char, int> cardCounts = [];
            CardValues = [];

            foreach (char c in Cards)
            {
                if (char.IsDigit(c))
                {
                    CardValues.Add(int.Parse(c.ToString()));
                }
                else
                {
                    switch (c)
                    {
                        case 'A':
                            CardValues.Add(14);
                            break;
                        case 'K':
                            CardValues.Add(13);
                            break;
                        case 'Q':
                            CardValues.Add(12);
                            break;
                        case 'J':
                            CardValues.Add(11);
                            break;
                        case 'T':
                            CardValues.Add(10);
                            break;
                    }
                }
                if (cardCounts.TryGetValue(c, out int value))
                {
                    cardCounts[c] = ++value;
                }
                else
                {
                    cardCounts.Add(c, 1);
                }

                switch (cardCounts.Count)
                {
                    case 5:
                        Type = HandType.HighCard;
                        break;
                    case 4:
                        Type = HandType.OnePair;
                        break;
                    case 3:
                        bool isThreeOfAKind = false;
                        foreach (int i in cardCounts.Values)
                        {
                            if (i == 3)
                            {
                                isThreeOfAKind = true;
                                break;
                            }
                        }
                        if (isThreeOfAKind)
                        {
                            Type = HandType.ThreeOfAKind;
                        }
                        else
                        {
                            Type = HandType.TwoPair;
                        }
                        break;
                    case 2:
                        bool isFourOfAKind = false;
                        foreach (int i in cardCounts.Values)
                        {
                            if (i == 4)
                            {
                                isFourOfAKind = true;
                                break;
                            }
                        }
                        if (isFourOfAKind)
                        {
                            Type = HandType.FourOfAKind;
                        }
                        else
                        {
                            Type = HandType.FullHouse;
                        }
                        break;
                    case 1:
                        Type = HandType.FiveOfAKind;
                        break;
                    default:
                        Type = HandType.HighCard;
                        break;
                }
            }
        }

        public Hand(string cards, int bid)
        {
            Cards = cards;
            Bid = bid;
            CardValues = [];
            DetermineHandTypeAndCardValues();
        }

        public int CompareTo(Hand? other)
        {
            if (other == null)
            {
                return 1;
            }
            if (this.Type == other.Type)
            {
                for (int i = 0; i < this.CardValues.Count; i++)
                {
                    if (this.CardValues[i] < other.CardValues[i])
                    {
                        return -1;
                    }
                    else if (this.CardValues[i] > other.CardValues[i])
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else if (this.Type < other.Type)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    public class Day07 : Challenge
    {
        public override void Solve()
        {
            List<Hand> hands = [];

            foreach (string line in Input)
            {
                string[] splitted = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);

                Hand h = new(splitted[0], int.Parse(splitted[1]));
                hands.Add(h);
            }

            hands.Sort();

            int winnings = 0;
            for (int i = 0; i < hands.Count; i++)
            {
                winnings += (i + 1) * hands[i].Bid;
            }

            Part1Solution = winnings.ToString();

            Part2Solution = "TBD";
        }
    }
}
