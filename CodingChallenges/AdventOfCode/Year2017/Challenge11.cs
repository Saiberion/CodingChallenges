using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
	class HexGridPosition
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public HexGridPosition()
		{
			X = 0;
			Y = 0;
			Z = 0;
		}

		public void Move(string dir)
		{
			switch (dir)
			{
				case "n":
					X--;
					Y++;
					break;
				case "ne":
					Y++;
					Z--;
					break;
				case "nw":
					X--;
					Z++;
					break;
				case "s":
					X++;
					Y--;
					break;
				case "sw":
					Y--;
					Z++;
					break;
				case "se":
					X++;
					Z--;
					break;
			}
		}

		public int Distance(HexGridPosition pos)
		{
			int diffx, diffy, diffz;
			int distance;

			diffx = Math.Abs(pos.X - X);
			diffy = Math.Abs(pos.Y - Y);
			diffz = Math.Abs(pos.Z - Z);

			distance = Math.Max(Math.Max(diffx, diffy), diffz);

			return distance;
		}
	}

	public class Challenge11 : Challenge
	{
		public override void Solve()
		{
			HexGridPosition start = new();
			HexGridPosition goal = new();
			string[] directions = Input[0].Split(',');
			int maxDistance = int.MinValue;
			int distance;

			foreach (string dir in directions)
			{
				goal.Move(dir);
				distance = goal.Distance(start);
				if (distance > maxDistance)
				{
					maxDistance = distance;
				}
			}

			Part1Solution = goal.Distance(start).ToString();
			Part2Solution = maxDistance.ToString();
		}
	}
}
