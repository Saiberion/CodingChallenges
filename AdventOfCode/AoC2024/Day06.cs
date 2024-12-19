using AdventOfCode;
using AdventOfCode.AoC2018;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdventOfCode.AoC2024
{
    internal class Guard
    {
        public Point Position;
        public Directions4Way Direction { get; set; }

        public void Move()
        {
            
            switch (Direction)
            {
                case Directions4Way.Up:
                    Position.Y--;
                    break;
                case Directions4Way.Right:
                    Position.X++;
                    break;
                case Directions4Way.Down:
                    Position.Y++;
                    break;
                case Directions4Way.Left:
                    Position.X--;
                    break;
            }
        }
    }

    internal class Laboratory
    {
        public  Guard g = new();
        char[,] map = new char[0, 0];

        public void LoadMap(List<string> input)
        {
            map = new char[input[0].Length, input.Count];
            for (int y = 0; y < input.Count; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    map[x, y] = input[y][x];
                    if (input[y][x] == '^')
                    {
                        g.Position.X = x;
                        g.Position.Y = y;
                        g.Direction = Directions4Way.Up;
                    }
                }
            }
        }

        private bool IsPathBlocked()
        {
            bool result = false;
            switch (g.Direction)
            {
                case Directions4Way.Up:
                    if ((g.Position.Y > 0) && (map[g.Position.X, g.Position.Y - 1] == '#'))
                    {
                        result = true;
                    }
                    break;
                case Directions4Way.Right:
                    if ((g.Position.X < (map.GetLength(0) - 1)) && (map[g.Position.X + 1, g.Position.Y] == '#'))
                    {
                        result = true;
                    }
                    break;
                case Directions4Way.Down:
                    if ((g.Position.Y < (map.GetLength(1) - 1)) && (map[g.Position.X, g.Position.Y + 1] == '#'))
                    {
                        result = true;
                    }
                    break;
                case Directions4Way.Left:
                    if ((g.Position.X > 0) && (map[g.Position.X - 1, g.Position.Y] == '#'))
                    {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        public bool Patrol()
        {
            int stepsTaken = 0;
            while ((g.Position.X < map.GetLength(0)) && (g.Position.Y < map.GetLength(1)) && (g.Position.X >= 0) && (g.Position.Y >= 0) && stepsTaken < 10000)
            {
                if (IsPathBlocked())
                {
                    switch (g.Direction)
                    {
                        case Directions4Way.Up:
                            g.Direction = Directions4Way.Right;
                            break;
                        case Directions4Way.Right:
                            g.Direction = Directions4Way.Down;
                            break;
                        case Directions4Way.Down:
                            g.Direction = Directions4Way.Left;
                            break;
                        case Directions4Way.Left:
                            g.Direction = Directions4Way.Up;
                            break;
                    }
                }
                else
                {
                    map[g.Position.X, g.Position.Y] = 'X';
                    g.Move();
                    stepsTaken++;
                }
            }
            if (stepsTaken == 10000)
            {
                return true;
            }
            //System.Diagnostics.Debug.WriteLine($"{stepsTaken}");
            return false;
        }

        public int GetGuardedSpots()
        {
            int guardedSpots = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] == 'X')
                    {
                        guardedSpots++;
                    }
                }
            }
            return guardedSpots;
        }

        public void AddObstruction(int x, int y)
        {
            if (map[x, y] != '^')
            {
                map[x, y] = '#';
            }
        }
    }

    public class Day06 : AoCDay
    {
        public override void Solve()
        {
            Laboratory l = new();

            l.LoadMap(Input);
            l.Patrol();

            Part1Solution = l.GetGuardedSpots().ToString();

            l.LoadMap(Input);
            int foundLoops = 0;
            for(int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    l.AddObstruction(x, y);
                    if (l.Patrol() == true)
                    {
                        foundLoops++;
                    }
                    l.LoadMap(Input);
                }
            }

            Part2Solution = foundLoops.ToString();
        }
    }
}
