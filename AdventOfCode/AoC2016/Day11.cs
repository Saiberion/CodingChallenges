using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2016
{
    public class Day11 : Day
    {
        int StepsTaken(int[] floorTest)
        {
            int moveCount = 0;
            int totalPieces = floorTest.Sum();
            int elevatorPieces = Math.Min(floorTest[1], 2);
            floorTest[1] -= elevatorPieces;
            int currentFloor = 1;
            while (floorTest[4] + 1 != totalPieces)
            {
                // go down
                while (elevatorPieces < 2 && currentFloor > 1)
                {
                    currentFloor--;
                    int piecesTaken = Math.Min(floorTest[currentFloor], 2 - elevatorPieces);
                    if (piecesTaken > 0)
                    {
                        elevatorPieces += piecesTaken;
                        floorTest[currentFloor] -= piecesTaken;
                    }
                    moveCount++;
                }
                // go up
                while (currentFloor < 4)
                {
                    currentFloor++;
                    int piecesTaken = Math.Min(floorTest[currentFloor], 2 - elevatorPieces);
                    if (piecesTaken > 0)
                    {
                        elevatorPieces += piecesTaken;
                        floorTest[currentFloor] -= piecesTaken;
                    }
                    moveCount++;
                }

                floorTest[4] += 1;
                elevatorPieces--;
            }

            return moveCount;
        }

        public override void Solve()
        {
            Part1Solution = StepsTaken(new int[] { 0, 4, 5, 1, 0 }).ToString();

            Part2Solution = StepsTaken(new int[] { 0, 8, 5, 1, 0 }).ToString();
        }
    }
}
