using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode._2019
{
    class Wire
    {
        public int ID { get; set; }
        public int Steps { get; set; }

        public Wire(int id, int steps)
        {
            ID = id;
            Steps = steps;
        }
    }
    public class Day03 : Day
    {
        public Day03()
        {
            Load("2019/inputs/day03.txt");
        }

        internal List<Point> crossings = new List<Point>();

        void UpdateGridPos(Dictionary<Point, Wire> wireGrid, Point currentPos, int wireID, int steps)
        {
            if (!wireGrid.ContainsKey(currentPos))
            {
                wireGrid.Add(currentPos, new Wire(wireID, steps));
            }
            else
            {
                if ((wireGrid[currentPos].ID != 0) && (wireGrid[currentPos].ID != 3) && (wireGrid[currentPos].ID != wireID))
                {
                    wireGrid[currentPos].Steps += steps;
                    wireGrid[currentPos].ID = 3;
                    crossings.Add(new Point(currentPos.X, currentPos.Y));
                }
            }
        }

        void DrawWire(Dictionary<Point, Wire> wireGrid, int wireID, List<string> directions)
        {
            Point currentPos = new Point(0, 0);
            int steps = 0;
            foreach (string direction in directions)
            {
                int stepsToTake = int.Parse(direction.Remove(0, 1));
                switch (direction[0])
                {
                    case 'U':
                        for (int i = 0; i < stepsToTake; i++)
                        {
                            currentPos.Y--;
                            UpdateGridPos(wireGrid, currentPos, wireID, ++steps);
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < stepsToTake; i++)
                        {
                            currentPos.Y++;
                            UpdateGridPos(wireGrid, currentPos, wireID, ++steps);
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < stepsToTake; i++)
                        {
                            currentPos.X--;
                            UpdateGridPos(wireGrid, currentPos, wireID, ++steps);
                        }
                        break;
                    case 'R':
                        for (int i = 0; i < stepsToTake; i++)
                        {
                            currentPos.X++;
                            UpdateGridPos(wireGrid, currentPos, wireID, ++steps);
                        }
                        break;
                }
            }
        }

        override public void Solve()
        {
            List<List<string>> wires = new List<List<string>>();
            foreach(string s in Input)
            {
                List<string> sl = new List<string>();
                string[] splitted = s.Split(new char[] { ',' });
                foreach(string spl in splitted)
                {
                    sl.Add(spl);
                }
                wires.Add(sl);
            }

            Dictionary<Point, Wire> wireGrid = new Dictionary<Point, Wire>
            {
                { new Point(0, 0), new Wire(0, 0) }
            };

            DrawWire(wireGrid, 1, wires[0]);
            DrawWire(wireGrid, 2, wires[1]);

            int smallestDistance = int.MaxValue;
            int smallestSteps = int.MaxValue;

            foreach (Point p in crossings)
            {
                int distance = Math.Abs(p.X) + Math.Abs(p.Y);
                smallestDistance = Math.Min(smallestDistance, distance);

                int stepsTaken = wireGrid[p].Steps;
                smallestSteps = Math.Min(smallestSteps, stepsTaken);
            }

            Part1Solution = smallestDistance.ToString();
            Part2Solution = smallestSteps.ToString();
        }
    }
}
