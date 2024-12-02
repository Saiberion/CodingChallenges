using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2020
{
    public class Bag
    {
        public string Name { get; set; }
        public List<string> Within { get; set; }
        public Dictionary<string, int> Content { get; set; }
    }

    public class Day07 : AoCDay
    {
        private List<string> OuterBagNames;

        private static Bag FindOrCreateBag(string name, List<Bag> bags)
        {
            Bag bag = null;
            foreach (Bag g in bags)
            {
                if (g.Name.Equals(name))
                {
                    bag = g;
                    break;
                }
            }
            if (bag == null)
            {
                bag = new Bag
                {
                    Name = name,
                    Within = [],
                    Content = []
                };
                bags.Add(bag);
            }
            return bag;
        }

        private void GetOuterBags(string bagName, List<Bag> bags)
        {
            Bag bag = FindOrCreateBag(bagName, bags);

            foreach (string s in bag.Within)
            {
                if (!OuterBagNames.Contains(s))
                {
                    OuterBagNames.Add(s);
                    GetOuterBags(s, bags);
                }
            }
        }

        private static int CountBags(string bagName, List<Bag> bags)
        {
            int result = 0;
            Bag bag = FindOrCreateBag(bagName, bags);

            foreach (KeyValuePair<string, int> kvp in bag.Content)
            {
                result += kvp.Value;
                result += kvp.Value * CountBags(kvp.Key, bags);
            }
            return result;
        }

        override public void Solve()
        {
            List<Bag> bags = [];
            Bag bag, bagContainer;

            foreach (string s in Input)
            {
                string[] splitted = s.Split([" bags contain "], StringSplitOptions.RemoveEmptyEntries);

                bag = FindOrCreateBag(splitted[0], bags);
                bagContainer = bag;

                string[] splitted2 = splitted[1].Split([" bag, ", " bags, ", " bag.", " bags."], StringSplitOptions.RemoveEmptyEntries);
                if (!splitted2[0].Equals("no other"))
                {
                    foreach (string s2 in splitted2)
                    {
                        int amount = int.Parse(s2.Remove(1, s2.Length - 1));
                        string name = s2.Remove(0, 2);
                        bag = FindOrCreateBag(name, bags);
                        bag.Within.Add(splitted[0]);
                        bagContainer.Content.Add(bag.Name, amount);
                    }
                }
            }

            OuterBagNames = [];
            GetOuterBags("shiny gold", bags);

            Part1Solution = OuterBagNames.Count.ToString();
            Part2Solution = CountBags("shiny gold", bags).ToString();
        }
    }
}
