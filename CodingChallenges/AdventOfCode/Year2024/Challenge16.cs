using CodingChallenges.AdventOfCode.Year2018;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.AxHost;

namespace CodingChallenges.AdventOfCode.Year2024
{
    class Location
    {
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public Location? Parent;
    }
    public class Challenge16 : Challenge
    {
        List<Location> GetWalkableAdjacentSquares(int x, int y)
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
                if (l.X >= 0 && l.Y >= 0 && l.X < Input[0].Length && l.Y < Input.Count)
                {
                    if (Input[l.Y][l.X] != '#')
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
                if (loc.X == l.X && loc.Y == l.Y)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public int FindLowestScore(Point s, Point e)
        {
            // A* algorithm for path finding
            Location current;
            Location start = new() { X = s.X, Y = s.Y };
            Location target = new() { X = e.X, Y = e.Y };
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
                if (current.X == target.X && current.Y == target.Y)
                {
                    break;
                }

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y);
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
                        //adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.H = 0;
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
            return 0;
        }

        public override void Solve()
        {
            Point start = new();
            Point end = new();
            //Directions4Way dir = Directions4Way.Right;

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if (Input[y][x] == 'S')
                    {
                        start.X = x;
                        start.Y = y;
                    }
                    else if (Input[y][x] == 'E')
                    {
                        end.X = x;
                        end.Y = y;
                    }
                }
            }

            //Part1Solution = FindLowestScore(start, end, dir).ToString();

            Part2Solution = "TBD";
        }
    }
}
