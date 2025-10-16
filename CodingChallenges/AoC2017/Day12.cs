using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.AoC2017
{
	public class Day12 : Challenge
	{
		static int CountIDs(Dictionary<int, List<int>> pipes, List<int> groupIDs, int searchID)
		{
			int ret = 0;
			if (!groupIDs.Contains(searchID))
			{
				ret++;
				groupIDs.Add(searchID);
				foreach (int i in pipes[searchID])
				{
					ret += CountIDs(pipes, groupIDs, i);
				}
			}
			return ret;
		}

		public override void Solve()
		{
			Dictionary<int, List<int>> progPipes = [];
			List<int> groups = [];

			foreach (string line in Input)
			{
				List<int> canTalkTo = [];
				string[] s = line.Replace(" ", "").Split(["<->", ","], StringSplitOptions.RemoveEmptyEntries);
				for (int i = 1; i < s.Length; i++)
				{
					canTalkTo.Add(int.Parse(s[i]));
				}
				progPipes.Add(int.Parse(s[0]), canTalkTo);
			}

			while (progPipes.Count > 0)
			{
				List<int> groupIDs = [];
				groups.Add(CountIDs(progPipes, groupIDs, progPipes.First().Key));
				foreach (int i in groupIDs)
				{
					progPipes.Remove(i);
				}
			}

			Part1Solution = groups[0].ToString();
			Part2Solution = groups.Count.ToString();
		}
	}
}
