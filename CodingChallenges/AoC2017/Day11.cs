﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2017
{
	class HexGridPosition
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int Z { get; set; }

		public HexGridPosition()
		{
			this.X = 0;
			this.Y = 0;
			this.Z = 0;
		}

		public void Move(string dir)
		{
			switch (dir)
			{
				case "n":
					this.X--;
					this.Y++;
					break;
				case "ne":
					this.Y++;
					this.Z--;
					break;
				case "nw":
					this.X--;
					this.Z++;
					break;
				case "s":
					this.X++;
					this.Y--;
					break;
				case "sw":
					this.Y--;
					this.Z++;
					break;
				case "se":
					this.X++;
					this.Z--;
					break;
			}
		}

		public int Distance(HexGridPosition pos)
		{
			int diffx, diffy, diffz;
			int distance;

			diffx = Math.Abs(pos.X - this.X);
			diffy = Math.Abs(pos.Y - this.Y);
			diffz = Math.Abs(pos.Z - this.Z);

			distance = Math.Max(Math.Max(diffx, diffy), diffz);

			return distance;
		}
	}

	public class Day11 : AoCDay
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
