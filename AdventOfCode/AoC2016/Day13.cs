using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2016
{
    class Location
    {
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public Location Parent;
    }

    public class Day13 : AoCDay
    {
        static bool GetParity(int n)
        {
            bool parity = false;
            while (n != 0)
            {
                parity = !parity;
                n &= (n - 1);
            }
            return parity;

        }

        static List<Location> GetWalkableAdjacentSquares(int x, int y, int input)
        {
            List<Location> proposedLocations = new()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };
            List<Location> possibleLocations = new();

            foreach (Location l in proposedLocations)
            {
                if ((l.X >= 0) && (l.Y >= 0))
                {
                    if (!GetParity(l.X * l.X + 3 * l.X + 2 * l.X * l.Y + l.Y + l.Y * l.Y + input))
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

        static int GetShorestPathDistance(int startx, int starty, int targetx, int targety, int input)
        {
            // A* algorithm for path finding
            Location current = null;
            Location start = new() { X = startx, Y = starty };
            Location target = new() { X = targetx, Y = targety };
            List<Location> openList = new();
            List<Location> closedList = new();
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

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, input);
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

            return current.G;
        }

        static int GetNumberLocationsUpToDistance(int startx, int starty, int input)
        {
            // A* algorithm for path finding
            Location current;
            Location start = new() { X = startx, Y = starty };
            List<Location> openList = new();
            List<Location> closedList = new();
            int g;

            // add the starting position to the open list
            openList.Add(start);

            while (openList.Count > 0)
            {
                current = openList[0];

                // add the current square to the closed list
                closedList.Add(current);

                // remove it from the open list
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                g = current.G;
                if (g == 50)
                {
                    continue;
                }

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, input);
                g++;

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
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                }
            }

            return closedList.Count;
        }

        public override void Solve()
        {
            Part1Solution = GetShorestPathDistance(1, 1, 31, 39, int.Parse(Input[0])).ToString();

            Part2Solution = GetNumberLocationsUpToDistance(1, 1, int.Parse(Input[0])).ToString();
        }
    }
}
