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
            int target_min_x, target_max_x, target_min_y, target_max_y;
            string[] splitted = Input[0].Split(new char[] { ' ', '=', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            target_min_x = int.Parse(splitted[3]);
            target_max_x = int.Parse(splitted[4]);
            target_min_y = int.Parse(splitted[6]);
            target_max_y = int.Parse(splitted[7]);

            int velocity_x, position_x;
            List<int> valid_x_velocities = new List<int>();

            for (int i = 1; i <= target_max_x ; i++)
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
