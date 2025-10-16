using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;

namespace CodingChallenges.AoC2016
{
    public class Day24 : AoCDay
    {
        static List<Location> GetWalkableAdjacentSquares(int x, int y, int[,] grid)
        {
            List<Location> proposedLocations =
            [
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            ];
            List<Location> possibleLocations = [];

            foreach (Location l in proposedLocations)
            {
                if ((l.X >= 0) && (l.Y >= 0))
                {
                    if (grid[l.X, l.Y] == 0)
                    {
                        possibleLocations.Add(l);
                    }
                }
            }

            return possibleLocations;
        }

        static bool IsInList(Location l, List<Location> list)
        {
            bool ret = false;
            foreach (Location loc in list)
            {
                if ((loc.X == l.X) && (loc.Y == l.Y))
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }

        static int GetShorestPathDistance(int startx, int starty, int targetx, int targety, int[,] grid)
        {
            // A* algorithm for path finding
            Location? current = null;
            Location start = new() { X = startx, Y = starty };
            Location target = new() { X = targetx, Y = targety };
            List<Location> openList = [];
            List<Location> closedList = [];
            int g;

            // add the starting position to the open list
            openList.Add(start);

            while (openList.Count > 0)
            {
                // get the square with the lowest F score from openList
                current = openList[0];
                for (int i = 1; i < openList.Count; i++)
                {
                    if (openList[i].F < current.F)
                    {
                        current = openList[i];
                    }
                }

                // add the current square to the closed list
                closedList.Add(current);

                // remove it from the open list
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if ((current.X == target.X) && (current.Y == target.Y))
                {
                    break;
                }

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, grid);
                g = current.G + 1;

                foreach (Location adjacentSquare in adjacentSquares)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (IsInList(adjacentSquare, closedList))
                    {
                        continue;
                    }

                    // if it's not in the open list...
                    if (!IsInList(adjacentSquare, openList))
                    {
                        // compute its score, set the parent
                        adjacentSquare.G = g;
                        adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            if (current != null)
            {
                return current.G;
            }
            else
            {
                return 0;
            }
        }

        public static List<List<Point>> Permutations(List<Point> values)
        {
            List<List<Point>> route = [];
            int[] p = new int[values.Count + 1];
            for (int pi = 0; pi < p.Length; pi++)
            {
                p[pi] = pi;
            }

            route.Add(new List<Point>(values));

            int i = 1;
            while (i < values.Count)
            {
                p[i]--;
                int j;
                if ((i % 2) != 0)
                {
                    j = p[i];
                }
                else
                {
                    j = 0;
                }
                if (i != j)
                {
                    (values[j], values[i]) = (values[i], values[j]);
                }
                route.Add(new List<Point>(values));
                i = 1;
                while (p[i] == 0)
                {
                    p[i] = i;
                    i++;
                }
            }
            return route;
        }

        public override void Solve()
        {
            List<Point> wires = [];
            int[,] hvac = new int[Input[0].Length, Input.Count];
            List<List<Point>> routes;

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if (Input[y][x] == '#')
                    {
                        hvac[x, y] = -1;
                    }
                    else if (Input[y][x] == '.')
                    {
                        hvac[x, y] = 0;
                    }
                    else
                    {
                        hvac[x, y] = 0;
                        if (Input[y][x] == '0')
                        {
                            wires.Insert(0, new Point(x, y));
                        }
                        else
                        {
                            wires.Add(new Point(x, y));
                        }
                    }
                }
            }

            Dictionary<Tuple<Point, Point>, int> distances = [];

            for (int i = 0; i < wires.Count; i++)
            {
                for (int j = i + 1; j < wires.Count; j++)
                {
                    int dist = GetShorestPathDistance(wires[i].X, wires[i].Y, wires[j].X, wires[j].Y, hvac);
                    distances.Add(new Tuple<Point, Point>(wires[i], wires[j]), dist);
                    distances.Add(new Tuple<Point, Point>(wires[j], wires[i]), dist);
                }
            }

            routes = Permutations(wires.GetRange(1, wires.Count - 1));

            int min = Int32.MaxValue;
            foreach (List<Point> l in routes)
            {
                int dist = 0;
                List<Point> l2 = new(l);
                l2.Insert(0, wires[0]);
                for (int c = 0; c < l2.Count - 1; c++)
                {
                    dist += distances[new Tuple<Point, Point>(l2[c], l2[c + 1])];
                }
                min = Math.Min(min, dist);
            }
            Part1Solution = min.ToString();

            min = Int32.MaxValue;
            foreach (List<Point> l in routes)
            {
                int dist = 0;
                List<Point> l2 = new(l);
                l2.Insert(0, wires[0]);
                l2.Add(wires[0]);
                for (int c = 0; c < l2.Count - 1; c++)
                {
                    dist += distances[new Tuple<Point, Point>(l2[c], l2[c + 1])];
                }
                min = Math.Min(min, dist);
            }
            Part2Solution = min.ToString();
        }
    }
}
