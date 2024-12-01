using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace AoC2022
{
    public class Day11 : AoCDay
    {
        public class Monkey
        {
            public List<ulong> items = new();
            public ulong testValue;
            public int trueTarget;
            public int falseTarget;
            public uint inspectionCount;
            public string worryOperation;
            public string worryValue;

            public void Inspect(ulong commonDivisor)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    ulong operand;
                    if (worryValue.Equals("old"))
                    {
                        operand = items[i];
                    }
                    else
                    {
                        operand = uint.Parse(worryValue);
                    }

                    switch (worryOperation)
                    {
                        case "+":
                            items[i] += operand;
                            break;
                        case "*":
                            items[i] *= operand;
                            break;
                    }
                    if (commonDivisor == 0)
                    {
                        items[i] /= 3;
                    }
                    else
                    {
                        items[i] = items[i] % commonDivisor;
                    }
                    inspectionCount++;
                }
            }

            public void Throw(List<Monkey> monkies)
            {
                if (items.Count > 0)
                {
                    do
                    {
                        ulong l = items[0];
                        items.RemoveAt(0);

                        if ((l % testValue) == 0)
                        {
                            monkies[trueTarget].items.Add(l);
                        }
                        else
                        {
                            monkies[falseTarget].items.Add(l);
                        }
                    } while (items.Count > 0);
                }
            }
        }

        public List<Monkey> InitializeHoard(ref ulong commonDivisor)
        {
            List<Monkey> monkies = new();
            Monkey monkey = new();
            foreach (string s in Input)
            {
                string[] splitted = s.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length > 0)
                {
                    if (splitted[0].Equals("Monkey"))
                    {
                        monkey = new Monkey();
                        monkies.Add(monkey);
                    }
                    else if (splitted[0].Equals("Starting"))
                    {
                        for (int i = 2; i < splitted.Length; i++)
                        {
                            monkey.items.Add(uint.Parse(splitted[i]));
                        }
                    }
                    else if (splitted[0].Equals("Operation:"))
                    {
                        monkey.worryOperation = splitted[4];
                        monkey.worryValue = splitted[5];
                    }
                    else if (splitted[0].Equals("Test:"))
                    {
                        monkey.testValue = ulong.Parse(splitted[3]);
                        commonDivisor *= monkey.testValue;
                    }
                    else if (splitted[1].Equals("true:"))
                    {
                        monkey.trueTarget = int.Parse(splitted[5]);
                    }
                    else if (splitted[1].Equals("false:"))
                    {
                        monkey.falseTarget = int.Parse(splitted[5]);
                    }
                }
            }
            return monkies;
        }

        public static ulong GetMonkeyBusiness(List<Monkey> monkies)
        {
            List<ulong> monkeyBusiness = new();
            foreach (Monkey m in monkies)
            {
                monkeyBusiness.Add(m.inspectionCount);
            }
            monkeyBusiness.Sort();
            monkeyBusiness.Reverse();

            return monkeyBusiness[0] * monkeyBusiness[1];
        }

        public static void GoRounds(List<Monkey> monkies, int rounds, ulong commonDivisor)
        {
            for (int round = 0; round < rounds; round++)
            {
                foreach (Monkey m in monkies)
                {
                    m.Inspect(commonDivisor);
                    m.Throw(monkies);
                }
            }
        }

        public override void Solve()
        {
            ulong commonDivisor = 1;
            List<Monkey> monkies = InitializeHoard(ref commonDivisor);
            GoRounds(monkies, 20, 0);
            Part1Solution = GetMonkeyBusiness(monkies).ToString();

            commonDivisor = 1;
            monkies = InitializeHoard(ref commonDivisor);
            GoRounds(monkies, 10000, commonDivisor);
            Part2Solution = GetMonkeyBusiness(monkies).ToString();
        }
    }
}
