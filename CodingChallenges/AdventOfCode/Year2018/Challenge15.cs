using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2018
{
    public class Location(int x, int y) : IComparable<Location>
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public int F { get; set; } = 0;
        public int G { get; set; } = 0;
        public int H { get; set; } = 0;
        public Location? Parent = null;

        public int CompareTo(Location? other)
        {
            if (other == null)
            {
                return 1;
            }
            if (Y == other.Y)
            {
                if (X == other.X)
                {
                    return 0;
                }
                return X - other.X;
            }
            return Y - other.Y;
        }
    }

    public class Challenge15 : Challenge
    {
        public override void Solve()
        {
            string[,] mapLayer = new string[Input[0].Length, Input.Count];
            List<Unit> units = [];
            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    mapLayer[x, y] = Input[y][x].ToString();
                    switch (mapLayer[x, y])
                    {
                        case "G":
                            units.Add(new Unit(UnitTypes.Goblin, new Location(x, y)));
                            break;
                        case "E":
                            units.Add(new Unit(UnitTypes.Elf, new Location(x, y)));
                            break;
                    }
                }
            }

            while (true)
            {
                // determine turn order
                units.Sort();

                // Execute turn of each unit
                foreach (Unit u in units)
                {
                    if (u.HitPoints > 0)
                    {
                        u.Turn(units, mapLayer);
                    }
                }
                for (int y = 0; y < mapLayer.GetLength(1); y++)
                {
                    for (int x = 0; x < mapLayer.GetLength(0); x++)
                    {
                        System.Diagnostics.Debug.Write(mapLayer[x, y]);
                    }
                    System.Diagnostics.Debug.WriteLine("");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }
    }

    public enum UnitTypes
    {
        Elf,
        Goblin
    }

    public class Unit(UnitTypes type, Location pos) : IComparable<Unit>
    {
        public UnitTypes Type { get; set; } = type;
        public Location Positon { get; set; } = pos;
        public int AttackPower { get; set; } = 3;
        public int HitPoints { get; set; } = 200;

        public int CompareTo(Unit? other)
        {
            if (other == null)
            {
                return 1;
            }
            if (Positon.Y == other.Positon.Y)
            {
                if (Positon.X == other.Positon.X)
                {
                    return 0;
                }
                return Positon.X - other.Positon.X;
            }
            return Positon.Y - other.Positon.Y;
        }

        private bool IsEnemyInRange(string[,] mapLayer)
        {
            bool result = false;
            List<string> adjecentSquares =
            [
                mapLayer[Positon.X, Positon.Y - 1],
                mapLayer[Positon.X + 1, Positon.Y],
                mapLayer[Positon.X, Positon.Y + 1],
                mapLayer[Positon.X - 1, Positon.Y]
            ];

            foreach (string s in adjecentSquares)
            {
                switch (s)
                {
                    case "G":
                        if (Type == UnitTypes.Elf)
                        {
                            result = true;
                        }
                        break;
                    case "E":
                        if (Type == UnitTypes.Goblin)
                        {
                            result = true;
                        }
                        break;
                }
            }
            return result;
        }

        private List<Location> GetFreeAdjacentSqures(string[,] mapLayer)
        {
            List<Location> freeSquares = [];

            if (mapLayer[Positon.X, Positon.Y - 1].Equals("."))
            {
                freeSquares.Add(new Location(Positon.X, Positon.Y - 1));
            }
            if (mapLayer[Positon.X + 1, Positon.Y].Equals("."))
            {
                freeSquares.Add(new Location(Positon.X + 1, Positon.Y));
            }
            if (mapLayer[Positon.X, Positon.Y + 1].Equals("."))
            {
                freeSquares.Add(new Location(Positon.X, Positon.Y + 1));
            }
            if (mapLayer[Positon.X - 1, Positon.Y].Equals("."))
            {
                freeSquares.Add(new Location(Positon.X - 1, Positon.Y));
            }

            return freeSquares;
        }

        public void Turn(List<Unit> allUnits, string[,] mapLayer)
        {
            // Identify possible targets
            List<Unit> targets = [];
            foreach (Unit u in allUnits)
            {
                if (Type != u.Type)
                {
                    if (u.HitPoints > 0)
                    {
                        targets.Add(u);
                    }
                }
            }

            if (targets.Count > 0)
            {
                if (!IsEnemyInRange(mapLayer))
                {
                    List<Location> targetSquares = [];
                    foreach (Unit t in targets)
                    {
                        targetSquares.AddRange(t.GetFreeAdjacentSqures(mapLayer));
                    }

                    if (targetSquares.Count > 0)
                    {
                        List<Location> reachable = [];
                        foreach (Location l in targetSquares)
                        {
                            reachable.AddRange(GetShortestPathDistance(l, mapLayer));
                        }
                        int minimumDistance = int.MaxValue;
                        foreach (Location r in reachable)
                        {
                            minimumDistance = Math.Min(minimumDistance, r.G);
                        }
                        List<Location> closest = [];
                        foreach (Location r in reachable)
                        {
                            if (r.G == minimumDistance)
                            {
                                closest.Add(r);
                            }
                        }
                        closest.Sort();
                        Location c = closest[0];
                        while (c.Parent != null)
                        {
                            c = c.Parent;
                        }
                        mapLayer[Positon.X, Positon.Y] = ".";
                        mapLayer[c.X, c.Y] = Type == UnitTypes.Elf ? "E" : "G";
                        Positon.X = c.X;
                        Positon.Y = c.Y;

                        if (IsEnemyInRange(mapLayer))
                        {
                            Attack(targets, mapLayer);
                        }
                    }
                }
                else
                {
                    Attack(targets, mapLayer);
                }
            }
        }

        private void Attack(List<Unit> allTargets, string[,] mapLayer)
        {
            List<Unit> possibleTargets = [];
            foreach (Unit t in allTargets)
            {
                if (IsTargetInRange(t))
                {
                    possibleTargets.Add(t);
                }
            }

            Unit target;
            if (possibleTargets.Count > 1)
            {
                possibleTargets.Sort();
                target = possibleTargets[0];

                for (int i = 1; i < possibleTargets.Count; i++)
                {
                    if (possibleTargets[i].HitPoints < target.HitPoints)
                    {
                        target = possibleTargets[i];
                    }
                }
            }
            else
            {
                target = possibleTargets[0];
            }
            target.HitPoints -= AttackPower;
            if (target.HitPoints <= 0)
            {
                mapLayer[target.Positon.X, target.Positon.Y] = ".";
            }
        }

        private bool IsTargetInRange(Unit target)
        {
            Location l;

            l = new Location(Positon.X, Positon.Y - 1);
            if (l.CompareTo(target.Positon) == 0)
            {
                return true;
            }

            l = new Location(Positon.X - 1, Positon.Y);
            if (l.CompareTo(target.Positon) == 0)
            {
                return true;
            }

            l = new Location(Positon.X + 1, Positon.Y);
            if (l.CompareTo(target.Positon) == 0)
            {
                return true;
            }

            l = new Location(Positon.X, Positon.Y + 1);
            if (l.CompareTo(target.Positon) == 0)
            {
                return true;
            }

            return true;
        }

        private List<Location> GetShortestPathDistance(Location targetSquare, string[,] mapLayer)
        {
            // A* algorithm for path finding
            Location current;
            Location start = new(Positon.X, Positon.Y);
            Location target = new(targetSquare.X, targetSquare.Y);
            List<Location> openList = [];
            List<Location> closedList = [];
            int g;
            List<Location> reachable = [];

            // add the starting position to the open list
            openList.Add(start);

            while (openList.Count > 0)
            {
                openList.Sort();
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
                    reachable.Add(current);
                    // eventuell trotzdem weiterlaufen lassen für weitere mögliche Pfade
                    //break;
                }

                List<Location> adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, mapLayer);
                //g++;
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
                        if (current.CompareTo(start) != 0)
                        {
                            adjacentSquare.Parent = current;
                        }

                        // and add it to the open list
                        //openList.Insert(0, adjacentSquare);
                        openList.Add(adjacentSquare);
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

            return reachable;
        }

        static private List<Location> GetWalkableAdjacentSquares(int x, int y, string[,] mapLayer)
        {
            List<Location> proposedLocations =
            [
                new(x, y - 1),
                new(x - 1, y),
                new(x + 1, y),
                new(x, y + 1),
            ];
            List<Location> possibleLocations = [];

            foreach (Location l in proposedLocations)
            {
                if (mapLayer[l.X, l.Y].Equals("."))
                {
                    possibleLocations.Add(l);
                }
            }

            return possibleLocations;
        }

        static private bool IsInList(Location l, List<Location> list)
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

        static private int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
    }
}
