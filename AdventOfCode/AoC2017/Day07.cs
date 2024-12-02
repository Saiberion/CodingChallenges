using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2017
{
	class TowerElement(string name)
    {
        public string Name { get; internal set; } = name;
        public int Weight { get; set; } = 0;
        public List<TowerElement> Disc { get; internal set; } = [];
        public int TotalWeight { get; set; } = 0;
        public bool IsBalanced { get; internal set; } = true;
        public TowerElement? Parent { get; internal set; } = null;
    }

	public class Day07 : AoCDay
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
			Dictionary<int, int> d = [];
			foreach (TowerElement t in tower.Disc)
			{
				if (!d.TryGetValue(t.TotalWeight, out int value))
				{
                    value = 0;
                    d.Add(t.TotalWeight, value);
				}
				d[t.TotalWeight] = ++value;
			}
			if (d.Count == 1)
			{
				if (tower.Parent != null)
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
				}
				return 0;
			}
			else
			{
				foreach (KeyValuePair<int, int> kvp in d)
				{
					if (kvp.Value == 1)
					{
						foreach (TowerElement te in tower.Disc)
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
			Dictionary<string, TowerElement> programs = [];
			TowerElement? root = null;

			foreach (string line in Input)
			{
				TowerElement t;
				string[] s = line.Split(["(", ")", "->", ",", " "], StringSplitOptions.RemoveEmptyEntries);

				if (!programs.TryGetValue(s[0], out TowerElement? value))
				{
					t = new TowerElement(s[0]);
                    value = t;
                    programs.Add(s[0], value);
				}
				t = value;
				t.Weight = int.Parse(s[1]);
				for (int i = 2; i < s.Length; i++)
				{
					if (!programs.TryGetValue(s[i], out TowerElement? te))
					{
                        te = new TowerElement(s[i]);
                        programs.Add(s[i], te);
					}

                    t.Disc.Add(te);
					te.Parent = t;
				}
			}

			foreach (KeyValuePair<string, TowerElement> kvp in programs)
			{
				if (kvp.Value.Parent == null)
				{
					root = kvp.Value;
				}
			}

			if (root != null)
			{
				Part1Solution = root.Name;
                
				DetermineTotalWeights(root);

                Part2Solution = FindUnbalancedElement(root).ToString();
            }
			else
			{
				Part1Solution = "Something went wrong";
				Part2Solution = "Something went wrong";
            }
		}
	}
}
