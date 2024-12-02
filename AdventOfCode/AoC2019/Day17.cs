using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2019
{
    public class Day17 : AoCDay
    {
        override public void Solve()
        {
            Queue<long> input = new();
            Queue<long> output;
            IntCodeComputer ic = new(Input[0]);

            output = ic.Execute();

            List<long> cameraview = new();

            while (output.Count > 0)
            {
                cameraview.Add(output.Dequeue());
            }
            int lineLength = cameraview.IndexOf(10);
            int rowCount = cameraview.Count / lineLength + 1;

            long[,] cameraMap = new long[lineLength, rowCount];
            int x = 0;
            int y = 0;
            foreach (long l in cameraview)
            {
                if (l == 10)
                {
                    y++;
                    x = 0;
                    System.Diagnostics.Debug.WriteLine("");
                }
                else
                {
                    cameraMap[x++, y] = l;
                    System.Diagnostics.Debug.Write(Convert.ToChar(l));
                }
            }

            int alignmentParameterSum = 0;
            for (y = 1; y < rowCount - 2; y++)
            {
                for (x = 1; x < lineLength - 2; x++)
                {
                    if ((cameraMap[x, y] == 35) &&
                        (cameraMap[x, y - 1] == 35) &&
                        (cameraMap[x, y + 1] == 35) &&
                        (cameraMap[x - 1, y] == 35) &&
                        (cameraMap[x + 1, y] == 35))
                    {
                        alignmentParameterSum += x * y;
                    }
                }
            }
            Part1Solution = alignmentParameterSum.ToString();

            // Used print out of camera view from earlier to get the complete movement instructions of
            // L,12,L,12,R,12,L,12,L,12,R,12,L,8,L,8,R,12,L,8,L,8,L,10,R,8,R,12,L,10,R,8,R,12,L,12,L,12,R,12,L,8,L,8,R,12,L,8,L,8,L,10,R,8,R,12,L,12,L,12,R,12,L,8,L,8,R,12,L,8,L,8
            // and manually reduced them to
            // A = L,12,L,12,R,12
            // B = L,8,L,8,R,12,L,8,L,8
            // C = L,10,R,8,R,12
            // A,A,B,C,C,A,B,C,A,B

            string mainMovementRoutine = "A,A,B,C,C,A,B,C,A,B";
            string movementFunctionA = "L,12,L,12,R,12";
            string movementFunctionB = "L,8,L,8,R,12,L,8,L,8";
            string movementFunctionC = "L,10,R,8,R,12";

            foreach (char c in mainMovementRoutine)
            {
                input.Enqueue(Convert.ToInt64(c));
            }
            input.Enqueue(10);
            foreach (char c in movementFunctionA)
            {
                input.Enqueue(Convert.ToInt64(c));
            }
            input.Enqueue(10);
            foreach (char c in movementFunctionB)
            {
                input.Enqueue(Convert.ToInt64(c));
            }
            input.Enqueue(10);
            foreach (char c in movementFunctionC)
            {
                input.Enqueue(Convert.ToInt64(c));
            }
            input.Enqueue(10);
            input.Enqueue('n');
            input.Enqueue(10);
            output.Clear();
            ic.ExecuteAsync(input, output, 2);
            while (!ic.IsProgramHalted()) ;
            long dust = 0;
            foreach (long l in output)
            {
                dust = l;
            }
            Part2Solution = dust.ToString();
        }
    }
}
