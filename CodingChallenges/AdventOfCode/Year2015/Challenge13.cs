using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2015
{
    class Happiness(string pers1, string pers2, int happ)
    {
        public string person1 = pers1;
        public string person2 = pers2;
        public int happiness = happ;
    }

    public class Challenge13 : Challenge
    {
        internal List<List<string>> seatingOrder = [];

        void GetAllCombinations(string[] input, int k, int m)
        {
            if (k == m)
            {
                List<string> combination = [];
                for (int i = 0; i <= m; i++)
                {
                    combination.Add(input[i]);
                }
                seatingOrder.Add(combination);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    (input[i], input[k]) = (input[k], input[i]);
                    GetAllCombinations(input, k + 1, m);
                    (input[i], input[k]) = (input[k], input[i]);
                }
            }
        }

        int FindBestHappiness(bool includeYourself)
        {
            int maxHappiness = int.MinValue;

            List<Happiness> happinesses = [];
            List<string> persons = [];
            Dictionary<List<string>, int> seatingHappines = [];
            foreach (string s in Input)
            {
                string[] splitted = s.Split([' ', '.'], StringSplitOptions.RemoveEmptyEntries);

                if (!persons.Contains(splitted[0]))
                {
                    persons.Add(splitted[0]);
                }
                if (!persons.Contains(splitted[10]))
                {
                    persons.Add(splitted[10]);
                }

                int sign = splitted[2].Equals("lose") ? -1 : 1;
                Happiness h = new(splitted[0], splitted[10], int.Parse(splitted[3]) * sign);
                happinesses.Add(h);
            }

            if (includeYourself)
            {
                foreach (string s in persons)
                {
                    happinesses.Add(new("myself", s, 0));
                    happinesses.Add(new(s, "myself", 0));
                }
                persons.Add("myself");
            }

            GetAllCombinations([.. persons], 0, persons.Count - 1);

            foreach (List<string> t in seatingOrder)
            {
                int happ = 0;
                for (int i = 0; i < t.Count - 1; i++)
                {
                    foreach (Happiness h in happinesses)
                    {
                        if (t[i].Equals(h.person1) && t[i + 1].Equals(h.person2))
                        {
                            happ += h.happiness;
                        }

                    }
                }
                foreach (Happiness h in happinesses)
                {
                    if (t[^1].Equals(h.person1) && t[0].Equals(h.person2))
                    {
                        happ += h.happiness;
                    }

                }
                for (int i = t.Count - 1; i > 0; i--)
                {
                    foreach (Happiness h in happinesses)
                    {
                        if (t[i].Equals(h.person1) && t[i - 1].Equals(h.person2))
                        {
                            happ += h.happiness;
                        }

                    }
                }
                foreach (Happiness h in happinesses)
                {
                    if (t[0].Equals(h.person1) && t[^1].Equals(h.person2))
                    {
                        happ += h.happiness;
                    }

                }
                seatingHappines.Add(t, happ);
            }

            foreach (KeyValuePair<List<string>, int> kvp in seatingHappines)
            {
                maxHappiness = Math.Max(maxHappiness, kvp.Value);
            }

            return maxHappiness;
        }

        override public void Solve()
        {
            Part1Solution = FindBestHappiness(false).ToString();
            seatingOrder.Clear();
            Part2Solution = FindBestHappiness(true).ToString();
        }
    }
}
