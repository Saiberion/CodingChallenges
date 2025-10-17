using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2022
{
    public class Challenge12 : Challenge
    {
        class Location
        {
            public int X;
            public int Y;
            public int F;
            public int G;
            //public int H;
            public Location? Parent;
        }

        private static bool IsInList(Location l, List<Location> list)
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

        /*private static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }*/

        private static List<Location> GetWalkableAdjacentSquares(int x, int y, char[,] heightmap)
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
                if (l.X >= 0 && l.Y >= 0 && l.X < heightmap.GetLength(0) && l.Y < heightmap.GetLength(1))
                {
                    if (heightmap[l.X, l.Y] <= heightmap[x, y] + 1)
                    {
                        possibleLocations.Add(l);
                    }
                }
            }

            return possibleLocations;
        }

        private static int GetShorestPathDistance(int startx, int starty, int targetx, int targety, char[,] heightmap)
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
                if (current.X == target.X && current.Y == target.Y)
                {
                    break;
                }

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, heightmap);
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
                        adjacentSquare.F = adjacentSquare.G /*+ adjacentSquare.H*/;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g /*+ adjacentSquare.H*/ < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G /*+ adjacentSquare.H*/;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            if (current != null)
            {
                return current.G;
            }
            return 0;
        }

        private static int GetShorestPathDistance(int targetx, int targety, char[,] heightmap)
        {
            // A* algorithm for path finding
            Location? current = null;
            //Location start = new() { X = startx, Y = starty };
            Location target = new() { X = targetx, Y = targety };
            List<Location> openList = [];
            List<Location> closedList = [];
            int g;

            for (int y = 0; y < heightmap.GetLength(1); y++)
            {
                for (int x = 0; x < heightmap.GetLength(0); x++)
                {
                    if (heightmap[x, y] == 'a')
                    {
                        openList.Add(new() { X = x, Y = y });
                    }
                }
            }

            // add the starting position to the open list
            //openList.Add(start);

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

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, heightmap);
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
                        adjacentSquare.F = adjacentSquare.G /*+ adjacentSquare.H*/;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g /*+ adjacentSquare.H*/ < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G /*+ adjacentSquare.H*/;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            if (current != null)
            {
                return current.G;
            }
            return 0;
        }

        public override void Solve()
        {
            char[,] heightmap = new char[Input[0].Length, Input.Count];
            int startx = 0, starty = 0, endx = 0, endy = 0;

            List<Location> startPoints = [];

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    heightmap[x, y] = Input[y][x];
                    if (heightmap[x, y] == 'S')
                    {
                        startx = x;
                        starty = y;
                        heightmap[x, y] = 'a';
                    }
                    else if (heightmap[x, y] == 'E')
                    {
                        endx = x;
                        endy = y;
                        heightmap[x, y] = 'z';
                    }
                    else if (heightmap[x, y] == 'a')
                    {
                        startPoints.Add(new() { X = x, Y = y });
                    }
                }
            }

            Part1Solution = GetShorestPathDistance(startx, starty, endx, endy, heightmap).ToString();

            Part2Solution = GetShorestPathDistance(endx, endy, heightmap).ToString();
        }
    }
}
