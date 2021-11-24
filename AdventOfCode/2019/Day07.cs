using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019
{
    public class Day07 : Day
    {
        internal List<List<int>> phaseCombinations = new List<List<int>>();
        public Day07()
        {
            Load("2019/inputs/day07.txt");
        }

        void SwapElements(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        void GetAllCombinations(int[] input, int k, int m)
        {
            if (k == m)
            {
                List<int> combination = new List<int>();
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
            Queue<long> input = new Queue<long>();
            Queue<long> output = new Queue<long>();
            IntCodeComputer ic = new IntCodeComputer(Input[0]);
            List<long> thrusterSignals = new List<long>();
            List<int> phaseSettings = new List<int>
            {
                0,
                1,
                2,
                3,
                4
            };
            GetAllCombinations(phaseSettings.ToArray(), 0, phaseSettings.Count - 1);

            foreach(List<int> ps in phaseCombinations)
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

            int maxThrusterSignal = int.MinValue;
            foreach(int ts in thrusterSignals)
            {
                maxThrusterSignal = Math.Max(maxThrusterSignal, ts);
            }
            Part1Solution = maxThrusterSignal.ToString();

            thrusterSignals.Clear();
            Queue<long> outA = new Queue<long>();
            Queue<long> outB = new Queue<long>();
            Queue<long> outC = new Queue<long>();
            Queue<long> outD = new Queue<long>();
            Queue<long> outE = new Queue<long>();
            IntCodeComputer ampA = new IntCodeComputer(Input[0]);
            IntCodeComputer ampB = new IntCodeComputer(Input[0]);
            IntCodeComputer ampC = new IntCodeComputer(Input[0]);
            IntCodeComputer ampD = new IntCodeComputer(Input[0]);
            IntCodeComputer ampE = new IntCodeComputer(Input[0]);

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

            maxThrusterSignal = int.MinValue;
            foreach (int ts in thrusterSignals)
            {
                maxThrusterSignal = Math.Max(maxThrusterSignal, ts);
            }
            Part2Solution = maxThrusterSignal.ToString();
        }
    }
}
