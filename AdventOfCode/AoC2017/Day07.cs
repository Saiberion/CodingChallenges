using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
	class TowerElement
	{
		public string Name { get; internal set; }
		public int Weight { get; set; }
		public List<TowerElement> Disc { get; internal set; }
		public int TotalWeight { get; set; }
		public bool IsBalanced { get; internal set; }
		public TowerElement Parent { get; internal set; }

		public TowerElement(string name)
		{
			Name = name;
			Weight = 0;
			Disc = new List<TowerElement>();
			TotalWeight = 0;
			IsBalanced = true;
			Parent = null;
		}
	}

	public class Day07 : Day
    {
		static void DetermineTotalWeights(TowerElement t)
		{
			if (t.Disc.Count == 0)
            {
				t.TotalWeight = t.Weight;
            }
			else
            {
				DetermineTotalWeights(t.Disc[0]);
				int w = t.Disc[0].TotalWeight;
				int refw = w;
				for (int i = 1; i < t.Disc.Count; i++)
                {
                    DetermineTotalWeights(t.Disc[i]);
					w += t.Disc[i].TotalWeight;
					if (refw != t.Disc[i].TotalWeight)
					{
						t.IsBalanced = false;
					}
				}
				t.TotalWeight = w + t.Weight;
            }
		}

		static int FindUnbalancedElement(TowerElement tower)
		{
			Dictionary<int, int> d = new();
			foreach(TowerElement t in tower.Disc)
            {
				if (!d.ContainsKey(t.TotalWeight))
                {
					d.Add(t.TotalWeight, 0);
                }
				d[t.TotalWeight]++;
            }
			if (d.Count == 1)
			{
				foreach (TowerElement te2 in tower.Parent.Disc)
                {
					if (tower.TotalWeight != te2.TotalWeight)
                    {
						int nw = tower.TotalWeight - tower.Weight;
						nw = Math.Abs(nw - te2.TotalWeight);
						return nw;
                    }
                }
				return 0;
			}
			else
			{
				foreach (KeyValuePair<int, int> kvp in d)
				{
					if (kvp.Value == 1)
                    {
						foreach(TowerElement te in tower.Disc)
                        {
							if (te.TotalWeight == kvp.Key)
                            {
								return FindUnbalancedElement(te);
							}
                        }
					}
					return 0;
				}
				return 0;
			}
		}

		public override void Solve()
        {
			Dictionary<string, TowerElement> programs = new();
			TowerElement root = null;

			foreach (string line in Input)
			{
				TowerElement t;
				string[] s = line.Split(new string[] { "(", ")", "->", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
				
				if (!programs.ContainsKey(s[0]))
                {
					t = new TowerElement(s[0]);
					programs.Add(s[0], t);
                }
				t = programs[s[0]];
				t.Weight = int.Parse(s[1]);
				for (int i = 2; i < s.Length; i++)
				{
					if (!programs.ContainsKey(s[i]))
					{
						programs.Add(s[i], new TowerElement(s[i]));
					}
					TowerElement te = programs[s[i]];
					t.Disc.Add(te);
					te.Parent = t;
				}
			}

			foreach(KeyValuePair<string, TowerElement> kvp in programs)
            {
				if (kvp.Value.Parent == null)
                {
					root = kvp.Value;
                }
            }

			Part1Solution = root.Name;

			DetermineTotalWeights(root);

			Part2Solution = FindUnbalancedElement(root).ToString();
		}
	}
}
