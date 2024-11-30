using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day17 : Day
    {
        override public void Solve()
        {
            int target_min_x, target_max_x;
            string[] splitted = Input[0].Split(new char[] { ' ', '=', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            target_min_x = int.Parse(splitted[3]);
            target_max_x = int.Parse(splitted[4]);

            int velocity_x, position_x;
            List<int> valid_x_velocities = new();

            for (int i = 1; i <= target_max_x; i++)
            {
                velocity_x = i;
                position_x = 0;
                while (velocity_x > 0)
                {
                    position_x += velocity_x;
                    velocity_x--;
                    if (position_x >= target_min_x)
                    {
                        valid_x_velocities.Add(i);
                        break;
                    }
                    else if (position_x > target_max_x)
                    {
                        break;
                    }
                }
            }

            Part1Solution = "TBD";
            Part2Solution = "TBD";
        }
    }
}
