using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2019
{
    public class Day07 : AoCDay
    {
        internal List<List<int>> phaseCombinations = [];
        
        static void SwapElements(ref int a, ref int b)
        {
            (b, a) = (a, b);
        }

        void GetAllCombinations(int[] input, int k, int m)
        {
            if (k == m)
            {
                List<int> combination = [];
                for (int i = 0; i <= m; i++)
                {
                    combination.Add(input[i]);
                }
                phaseCombinations.Add(combination);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    SwapElements(ref input[k], ref input[i]);
                    GetAllCombinations(input, k + 1, m);
                    SwapElements(ref input[k], ref input[i]);
                }
            }
        }

        override public void Solve()
        {
            Queue<long> input = new();
            IntCodeComputer ic = new(Input[0]);
            List<long> thrusterSignals = [];
            List<int> phaseSettings =
            [
                0,
                1,
                2,
                3,
                4
            ];
            GetAllCombinations([.. phaseSettings], 0, phaseSettings.Count - 1);

            foreach (List<int> ps in phaseCombinations)
            {
                long sig = 0;
                for (int i = 0; i < ps.Count; i++)
                {
                    input.Enqueue(ps[i]);
                    input.Enqueue(sig);
                    sig = ic.Execute(input);
                }
                thrusterSignals.Add(sig);
            }

            long maxThrusterSignal = long.MinValue;
            foreach (long ts in thrusterSignals)
            {
                maxThrusterSignal = Math.Max(maxThrusterSignal, ts);
            }
            Part1Solution = maxThrusterSignal.ToString();

            thrusterSignals.Clear();
            Queue<long> outA = new();
            Queue<long> outB = new();
            Queue<long> outC = new();
            Queue<long> outD = new();
            Queue<long> outE = new();
            IntCodeComputer ampA = new(Input[0]);
            IntCodeComputer ampB = new(Input[0]);
            IntCodeComputer ampC = new(Input[0]);
            IntCodeComputer ampD = new(Input[0]);
            IntCodeComputer ampE = new(Input[0]);

            foreach (List<int> ps in phaseCombinations)
            {
                outE.Enqueue(ps[0] + 5);
                outE.Enqueue(0);
                outA.Enqueue(ps[1] + 5);
                outB.Enqueue(ps[2] + 5);
                outC.Enqueue(ps[3] + 5);
                outD.Enqueue(ps[4] + 5);

                ampA.ExecuteAsync(outE, outA);
                ampB.ExecuteAsync(outA, outB);
                ampC.ExecuteAsync(outB, outC);
                ampD.ExecuteAsync(outC, outD);
                ampE.ExecuteAsync(outD, outE);
                while (ampE.IsProgramHalted() == false) ;
                thrusterSignals.Add(outE.Dequeue());
            }

            maxThrusterSignal = long.MinValue;
            foreach (long ts in thrusterSignals)
            {
                maxThrusterSignal = Math.Max(maxThrusterSignal, ts);
            }
            Part2Solution = maxThrusterSignal.ToString();
        }
    }
}
