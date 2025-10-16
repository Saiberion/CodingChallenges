using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    class Bot
    {
        //public int ID { get; set; }
        public List<int> Chips { get; set; }
        public int GiveLowerTo { get; set; }
        public int GiveHigherTo { get; set; }

        public Bot()
        {
            this.Chips = [];
        }
    }

    public class Day10 : Challenge
    {
        void ParseInstructions(List<string> input)
        {
            Dictionary<int, Bot> bots = [];
            Dictionary<int, List<int>> outputs = [];

            foreach (string s in input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                if (splitted[0].Equals("value"))
                {
                    int val = int.Parse(splitted[1]);
                    int botId = int.Parse(splitted[5]);

                    if (!bots.TryGetValue(botId, out Bot? value))
                    {
                        value = new Bot();
                        bots.Add(botId, value);
                    }

                    value.Chips.Add(val);
                }
                else
                {
                    int botId = int.Parse(splitted[1]);
                    int targetLow = int.Parse(splitted[6]);
                    int targetHigh = int.Parse(splitted[11]);
                    if (!bots.TryGetValue(botId, out Bot? value))
                    {
                        value = new Bot();
                        bots.Add(botId, value);
                    }
                    if (splitted[5].Equals("bot"))
                    {
                        value.GiveLowerTo = targetLow;
                    }
                    else
                    {
                        value.GiveLowerTo = (targetLow * -1) - 1;
                        if (!outputs.ContainsKey(bots[botId].GiveLowerTo))
                        {
                            outputs.Add(bots[botId].GiveLowerTo, []);
                        }
                    }
                    if (splitted[10].Equals("bot"))
                    {
                        value.GiveHigherTo = targetHigh;
                    }
                    else
                    {
                        value.GiveHigherTo = (targetHigh * -1) - 1;
                        if (!outputs.ContainsKey(bots[botId].GiveHigherTo))
                        {
                            outputs.Add(bots[botId].GiveHigherTo, []);
                        }
                    }
                }
            }

            while (!((outputs[-1].Count == 1) && (outputs[-2].Count == 1) && (outputs[-3].Count == 1)))
            {
                foreach (KeyValuePair<int, Bot> kvp in bots)
                {
                    Bot b = kvp.Value;
                    if (b.Chips.Count == 2)
                    {
                        int lower, higher;

                        if (b.Chips[0] > b.Chips[1])
                        {
                            higher = b.Chips[0];
                            lower = b.Chips[1];
                        }
                        else
                        {
                            higher = b.Chips[1];
                            lower = b.Chips[0];
                        }

                        if ((higher == 61) && (lower == 17))
                        {
                            Part1Solution = kvp.Key.ToString();
                        }

                        if ((b.GiveHigherTo >= 0) && (b.GiveLowerTo >= 0))
                        {
                            if ((bots[b.GiveHigherTo].Chips.Count < 2) && (bots[b.GiveLowerTo].Chips.Count < 2))
                            {
                                bots[b.GiveHigherTo].Chips.Add(higher);
                                bots[b.GiveLowerTo].Chips.Add(lower);
                                b.Chips.Clear();
                            }
                        }
                        else if ((b.GiveHigherTo >= 0) && (b.GiveLowerTo < 0))
                        {
                            if (bots[b.GiveHigherTo].Chips.Count < 2)
                            {
                                bots[b.GiveHigherTo].Chips.Add(higher);
                                outputs[b.GiveLowerTo].Add(lower);
                                b.Chips.Clear();
                            }
                        }
                        else if ((b.GiveLowerTo >= 0) && (b.GiveHigherTo < 0))
                        {
                            if (bots[b.GiveLowerTo].Chips.Count < 2)
                            {
                                bots[b.GiveLowerTo].Chips.Add(lower);
                                outputs[b.GiveHigherTo].Add(higher);
                                b.Chips.Clear();
                            }
                        }
                        else
                        {
                            outputs[b.GiveLowerTo].Add(lower);
                            outputs[b.GiveHigherTo].Add(higher);
                            b.Chips.Clear();
                        }
                    }
                }
            }
            Part2Solution = (outputs[-1][0] * outputs[-2][0] * outputs[-3][0]).ToString();
        }

        public override void Solve()
        {
            ParseInstructions(Input);
        }
    }
}
