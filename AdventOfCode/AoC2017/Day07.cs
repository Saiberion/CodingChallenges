using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2017
{
	class TowerElement
	{
		public string name;
		public int weight;
		public List<TowerElement> subs = new List<TowerElement>();
		public int totalWeight;
	}

	public class Day07 : Day
    {
		bool AddToTower(List<TowerElement> tower, TowerElement t)
		{
			if (tower.Count == 0)
			{
				tower.Add(t);
				return true;
			}
			else
			{
				foreach (TowerElement te in tower)
				{
					if (te.subs.Count > 0)
					{
						for (int i = 0; i < te.subs.Count; i++)
						{
							if (te.subs[i].name.Equals(t.name))
							{
								te.subs[i] = t;
								return true;
							}
							else
							{
								if (te.subs[i].subs.Count > 0)
								{
									if (AddToTower(te.subs[i].subs, t))
									{
										return true;
									}
								}
							}
						}
						if (AddToTower(te.subs, t))
						{
							return true;
						}
					}
					else
					{
						if (te.name.Equals(t.name))
						{
							tower.Remove(te);
							tower.Add(t);
							return true;
						}
					}
				}
			}
			return false;
		}

		bool AddFromTower(List<TowerElement> tower, TowerElement t)
		{
			if (tower.Count == 0)
			{
				return false;
			}
			else
			{
				for (int i = 0; i < t.subs.Count; i++)
				{
					foreach (TowerElement te in tower)
					{
						if (te.name.Equals(t.subs[i].name))
						{
							t.subs[i] = te;
							tower.Remove(te);
							break;
						}
					}
				}
			}
			return false;
		}

		void TowerWeight(TowerElement t)
		{
			if (t.subs.Count > 0)
			{
				t.totalWeight = t.weight;
				foreach (TowerElement te in t.subs)
				{
					TowerWeight(te);
				}
				foreach (TowerElement te in t.subs)
				{
					t.totalWeight += te.totalWeight;
				}
			}
			else
			{
				t.totalWeight = t.weight;
			}
		}

		/*void FindUnbalancedElement(TowerElement tower)
		{
			int compare = 0;
			for (int i = 0; i < tower.subs.Count; i++)
			{
				if (i == 0)
				{
					compare = tower.subs[i].totalWeight;
				}
				else
				{
					if (compare != tower.subs[i].totalWeight)
					{

					}
				}
			}
		}*/

		public override void Solve()
        {
			List<TowerElement> tower = new List<TowerElement>();

			foreach (string line in Input)
			{
				string[] s = line.Replace(" ", "").Split(new string[] { "(", ")", "->" }, StringSplitOptions.RemoveEmptyEntries);
				TowerElement t = new TowerElement()
				{
					name = s[0],
					weight = int.Parse(s[1])
				};
				if (s.Length > 2)
				{
					string[] csv = s[2].Split(',');
					foreach (string n in csv)
					{
						TowerElement te = new TowerElement()
						{
							name = n
						};
						t.subs.Add(te);
					}
					AddFromTower(tower, t);
				}

				if (!AddToTower(tower, t))
				{
					// Turm hat schon eine Basis, kann nirgends eingehängt werden
					tower.Add(t);
				}
			}

			TowerWeight(tower[0]);
			Part1Solution = tower[0].name;

            Part2Solution = "TBD";
        }
    }
}
