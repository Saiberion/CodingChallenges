using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode.AoC2017
{
    public class Day03 : AoCDay
    {
        public static int SumAdjecent(Dictionary<Point, int> grid, int x, int y)
        {
            int sum = 0;
            List<Point> possibleAdjecent =
            [
                new Point (x - 1, y - 1),
                new Point (x, y - 1),
                new Point (x + 1, y - 1),
                new Point (x + 1, y),
                new Point (x + 1, y + 1),
                new Point (x, y + 1),
                new Point (x - 1, y + 1),
                new Point (x - 1, y)
            ];

            foreach (Point p in possibleAdjecent)
            {
                if (grid.TryGetValue(p, out int value))
                {
                    sum += value;
                }
            }

            return sum;
        }

        public override void Solve()
        {
            Dictionary<Point, int> grid = [];
            int x = 0, y = 0;
            int dir = 0;
            int count = 1;
            int content = 0;
            int input = int.Parse(Input[0]);

            grid.Add(new Point(x, y), 1);

            while (count < input)
            {
                switch (dir)
                {
                    case 0:
                        x++;
                        if (!grid.ContainsKey(new Point(x, y - 1)))
                        {
                            dir++;
                        }
                        break;
                    case 1:
                        y--;
                        if (!grid.ContainsKey(new Point(x - 1, y)))
                        {
                            dir++;
                        }
                        break;
                    case 2:
                        x--;
                        if (!grid.ContainsKey(new Point(x, y + 1)))
                        {
                            dir++;
                        }
                        break;
                    case 3:
                        y++;
                        if (!grid.ContainsKey(new Point(x + 1, y)))
                        {
                            dir = 0;
                        }
                        break;
                }

                if (content < input)
                {
                    content = SumAdjecent(grid, x, y);
                }
                grid.Add(new Point(x, y), content);
                count++;
            }

            Part1Solution = (Math.Abs(x) + Math.Abs(y)).ToString();

            Part2Solution = content.ToString();
        }
    }
}
