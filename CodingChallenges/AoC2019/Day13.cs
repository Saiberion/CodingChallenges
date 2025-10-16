using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace CodingChallenges.AoC2019
{
    public class Day13 : Challenge
    {
        override public void Solve()
        {
            // TODO Part 2 answer is somehow influenced with other running solve threads, only works (and takes quite long) if run alone
            Queue<long> input = new();
            Queue<long> output = new();
            // First value of input already set to starting value for part 2
            // the Intcode computer still outputs the initial gamescreen that is needed for part 1
            IntCodeComputer ic = new(Input[0]);
            Dictionary<Point, long> gameScreen = [];

            ic.ExecuteAsync(input, output);

            System.Threading.Thread.Sleep(200);

            long blockTiles = 0;
            while (output.Count > 0)
            {
                Point p = new((int)output.Dequeue(), (int)output.Dequeue());
                if (!gameScreen.ContainsKey(p))
                {
                    gameScreen.Add(p, output.Dequeue());
                }
                else
                {
                    gameScreen[p] = output.Dequeue();
                }
            }

            int ballXCoord = 0, paddleXCoord = 0;

            foreach (KeyValuePair<Point, long> kvp in gameScreen)
            {
                if (kvp.Value == 2)
                {
                    blockTiles++;
                }

                if (kvp.Value == 4)
                {
                    ballXCoord = kvp.Key.X;
                }
                if (kvp.Value == 3)
                {
                    paddleXCoord = kvp.Key.X;
                }
            }
            Part1Solution = blockTiles.ToString();

            while (!ic.IsProgramHalted() && (blockTiles > 0))
            {
                if (paddleXCoord < ballXCoord)
                {
                    input.Enqueue(1);
                }
                else if (paddleXCoord > ballXCoord)
                {
                    input.Enqueue(-1);
                }
                else
                {
                    input.Enqueue(0);
                }

                while (output.Count < 3)
                {
                    System.Threading.Thread.Sleep(1);
                }

                while (output.Count > 2)
                {
                    Point p = new((int)output.Dequeue(), (int)output.Dequeue());
                    long tile = output.Dequeue();
                    if (!gameScreen.TryAdd(p, tile))
                    {
                        gameScreen[p] = tile;
                    }
                    if (tile == 4)
                    {
                        ballXCoord = p.X;
                    }
                    if (tile == 3)
                    {
                        paddleXCoord = p.X;
                    }
                }

                blockTiles = 0;
                foreach (KeyValuePair<Point, long> kvp in gameScreen)
                {
                    if (kvp.Value == 2)
                    {
                        blockTiles++;
                    }

                    if (kvp.Value == 4)
                    {
                        ballXCoord = kvp.Key.X;
                    }
                    if (kvp.Value == 3)
                    {
                        paddleXCoord = kvp.Key.X;
                    }
                }
            }

            for (int y = 0; y <= 19; y++)
            {
                for (int x = 0; x <= 36; x++)
                {
                    Point p = new(x, y);
                    long t = gameScreen[p];
                    switch (t)
                    {
                        case 0:
                            Debug.Write(" ");
                            break;
                        case 1:
                            Debug.Write("#");
                            break;
                        case 2:
                            Debug.Write("*");
                            break;
                        case 3:
                            Debug.Write("-");
                            break;
                        case 4:
                            Debug.Write(".");
                            break;
                    }
                }
                Debug.WriteLine("");
            }

            Part2Solution = gameScreen[new Point(-1, 0)].ToString();
        }
    }
}
