using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AoC2023
{
    public class Day16 : Challenge
    {
        public enum EDirections
        {
            right = 1,
            down = 2,
            left = 4,
            up = 8
        }

        public class Beam(Point c, Day16.EDirections d)
        {
            public Point Coords { get; set; } = c;
            public EDirections Dir { get; set; } = d;
        }

        public int EnergizeTiles(char[,] lightMaze, Beam beam)
        {
            int[,] energizedMap = new int[lightMaze.GetLength(0), lightMaze.GetLength(1)];
            Queue<Beam> beams = new();
            beams.Enqueue(beam);

            while (beams.Count > 0)
            {
                Beam b = beams.Dequeue();
                Point beamCoords = b.Coords;
                EDirections beamDir = b.Dir;
                // movement
                switch (beamDir)
                {
                    case EDirections.right:
                        beamCoords.X++;
                        break;
                    case EDirections.down:
                        beamCoords.Y++;
                        break;
                    case EDirections.left:
                        beamCoords.X--;
                        break;
                    case EDirections.up:
                        beamCoords.Y--;
                        break;
                }

                // coords valid
                if ((beamCoords.X >= 0) && (beamCoords.X < lightMaze.GetLength(0)))
                {
                    if ((beamCoords.Y >= 0) && (beamCoords.Y < lightMaze.GetLength(1)))
                    {
                        if ((energizedMap[beamCoords.X, beamCoords.Y] & (int)beamDir) > 0)
                        {
                            continue;
                        }
                        else
                        {
                            energizedMap[beamCoords.X, beamCoords.Y] += (int)beamDir;
                        }

                        // new direction
                        switch (lightMaze[beamCoords.X, beamCoords.Y])
                        {
                            case '.':
                                break;
                            case '-':
                                if ((beamDir == EDirections.down) || (beamDir == EDirections.up))
                                {
                                    // Split beam
                                    beamDir = EDirections.left;
                                    beams.Enqueue(new(new(beamCoords.X, beamCoords.Y), EDirections.right));
                                }
                                break;
                            case '|':
                                if ((beamDir == EDirections.left) || (beamDir == EDirections.right))
                                {
                                    // Split beam
                                    beamDir = EDirections.up;
                                    beams.Enqueue(new(new(beamCoords.X, beamCoords.Y), EDirections.down));
                                }
                                break;
                            case '/':
                                switch (beamDir)
                                {
                                    case EDirections.right:
                                        beamDir = EDirections.up;
                                        break;
                                    case EDirections.down:
                                        beamDir = EDirections.left;
                                        break;
                                    case EDirections.left:
                                        beamDir = EDirections.down;
                                        break;
                                    case EDirections.up:
                                        beamDir = EDirections.right;
                                        break;
                                }
                                break;
                            case '\\':
                                switch (beamDir)
                                {
                                    case EDirections.right:
                                        beamDir = EDirections.down;
                                        break;
                                    case EDirections.down:
                                        beamDir = EDirections.right;
                                        break;
                                    case EDirections.left:
                                        beamDir = EDirections.up;
                                        break;
                                    case EDirections.up:
                                        beamDir = EDirections.left;
                                        break;
                                }
                                break;

                        }
                        beams.Enqueue(new(beamCoords, beamDir));
                    }
                }
            }

            int energizedTiles = 0;
            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    if (energizedMap[x, y] > 0)
                    {
                        energizedTiles++;
                    }
                }
            }

            return energizedTiles;
        }

        public override void Solve()
        {
            char[,] lightMaze = new char[Input[0].Length, Input.Count];

            for (int y = 0; y < Input.Count; y++)
            {
                for (int x = 0; x < Input[y].Length; x++)
                {
                    lightMaze[x, y] = Input[y][x];
                }
            }

            Part1Solution = EnergizeTiles(lightMaze, new(new(-1, 0), EDirections.right)).ToString();

            List<Beam> startingPositions = [];

            for (int x = 0; x < lightMaze.GetLength(0); x++)
            {
                startingPositions.Add(new(new(x, -1), EDirections.down));
                startingPositions.Add(new(new(x, lightMaze.GetLength(1)), EDirections.up));
            }
            for (int y = 0; y < lightMaze.GetLength(1); y++)
            {
                startingPositions.Add(new(new(-1, y), EDirections.right));
                startingPositions.Add(new(new(lightMaze.GetLength(0), y), EDirections.left));
            }

            int maxEnergizedTiles = int.MinValue;
            foreach (Beam b in startingPositions)
            {
                maxEnergizedTiles = Math.Max(maxEnergizedTiles, EnergizeTiles(lightMaze, b));
            }

            Part2Solution = maxEnergizedTiles.ToString();
        }
    }
}
