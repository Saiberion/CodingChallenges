using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2017
{
	public class Day06 : AoCDay
	{
		static int CalculateSignature(List<int> l)
		{
			StringBuilder sb = new();

			sb.Append(l.Count);

			for (int i = 0; i < l.Count; i++)
			{
				sb.Append(string.Format(";{0}", l[i]));
			}

			return sb.ToString().GetHashCode();
		}

		static int FindMaxBlocks(List<int> l)
		{
			int maxblocks = -1;
			int index = 0;

			for (int i = 0; i < l.Count; i++)
			{
				if (l[i] > maxblocks)
				{
					maxblocks = l[i];
					index = i;
				}
			}

			return index;
		}

		public override void Solve()
		{
			List<int> memoryBanks = [];
			List<int> uniqueSignatures = [];
			int steps;
			int loopsize;

			foreach (string line in Input)
			{
				string[] vals = line.Split('\t');
				foreach (string s in vals)
				{
					memoryBanks.Add(int.Parse(s));
				}
			}
			uniqueSignatures.Add(CalculateSignature(memoryBanks));

			steps = 0;
			while (true)
			{
				int sig;
				int start;
				start = FindMaxBlocks(memoryBanks);
				int tmp = memoryBanks[start];
				memoryBanks[start++] = 0;
				for (int i = 0; i < tmp; i++)
				{
					if (start > (memoryBanks.Count - 1))
					{
						start = 0;
					}
					memoryBanks[start++]++;
				}
				steps++;
				sig = CalculateSignature(memoryBanks);
				if (uniqueSignatures.Contains(sig))
				{
					loopsize = steps - uniqueSignatures.IndexOf(sig);
					break;
				}
				else
				{
					uniqueSignatures.Add(CalculateSignature(memoryBanks));
				}
			}

			Part1Solution = steps.ToString();
			Part2Solution = loopsize.ToString();
		}
	}
}
