using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2015
{
    class Distance(string loc1, string loc2, int dist)
    {
        public string location1 = loc1;
        public string location2 = loc2;
        public int distance = dist;
    }

    public class Challenge09 : Challenge
    {
        internal List<List<string>> tracks = [];

        void GetAllCombinations(string[] input, int k, int m)
        {
            if (k == m)
            {
                List<string> combination = [];
                for (int i = 0; i <= m; i++)
                {
                    combination.Add(input[i]);
                }
                tracks.Add(combination);
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

        override public void Solve()
        {
            List<Distance> distances = [];
            List<string> locations = [];
            Dictionary<List<string>, int> trackDistances = [];
            foreach (string s in Input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);

                if (!locations.Contains(splitted[0]))
                {
                    locations.Add(splitted[0]);
                }
                if (!locations.Contains(splitted[2]))
                {
                    locations.Add(splitted[2]);
                }

                Distance d = new(splitted[0], splitted[2], int.Parse(splitted[4]));
                distances.Add(d);
            }
            GetAllCombinations([.. locations], 0, locations.Count - 1);

            foreach (List<string> t in tracks)
            {
                int dist = 0;
                for (int i = 0; i < t.Count - 1; i++)
                {
                    foreach (Distance d in distances)
                    {
                        if (t[i].Equals(d.location1) && t[i + 1].Equals(d.location2) ||
                            t[i].Equals(d.location2) && t[i + 1].Equals(d.location1))
                        {
                            dist += d.distance;
                            break;
                        }
                    }
                }
                trackDistances.Add(t, dist);
            }

            int minDistance = int.MaxValue;
            int maxDistance = int.MinValue;
            foreach (KeyValuePair<List<string>, int> kvp in trackDistances)
            {
                minDistance = Math.Min(minDistance, kvp.Value);
                maxDistance = Math.Max(maxDistance, kvp.Value);
            }
            Part1Solution = minDistance.ToString();
            Part2Solution = maxDistance.ToString();
        }
    }
}
