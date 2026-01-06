using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge08 : Challenge
    {
        private readonly List<List<int>> circuits = [];

        private int GetCircuitIndex(int a)
        {
            for (int i = 0; i < circuits.Count; i++)
            {
                if (circuits[i].Contains(a))
                {
                    return i;
                }
            }
            return -1;
        }

        public override void Solve()
        {
            List<Coordinate3D> junctionBoxes = [];
            Dictionary<long, List<int>> distances = [];
            List<long> sortedDistances = [];

            foreach (string line in Input)
            {
                string[] coords = line.Split([','], StringSplitOptions.RemoveEmptyEntries);
                Coordinate3D c = new(int.Parse(coords[0]), int.Parse(coords[1]), int.Parse(coords[2]));
                junctionBoxes.Add(c);
            }

            for (int i = 0; i < junctionBoxes.Count - 1; i++)
            {
                for (int j = i + 1; j < junctionBoxes.Count; j++)
                {
                    long distance = junctionBoxes[i].GetDistanceTo(junctionBoxes[j]);
                    distances.Add(distance, [i, j]);
                }
            }
            sortedDistances.AddRange(distances.Keys);
            sortedDistances.Sort();

            circuits.Clear();
            for (int iter = 0; iter < sortedDistances.Count; iter ++)
            {
                if (iter == Repetitions[UseTestData ? 0 : 1])
                {
                    List<int> nodesInCircuit = [];
                    foreach (List<int> l in circuits)
                    {
                        nodesInCircuit.Add(l.Count);
                    }
                    nodesInCircuit.Sort();
                    nodesInCircuit.Reverse();

                    Part1Solution = (nodesInCircuit[0] * nodesInCircuit[1] * nodesInCircuit[2]).ToString();
                }


                int boxA = distances[sortedDistances[iter]][0];
                int boxB = distances[sortedDistances[iter]][1];

                if ((GetCircuitIndex(boxA) == -1) && (GetCircuitIndex(boxB) == -1))
                {
                    circuits.Add([boxA, boxB]);
                }
                else if ((GetCircuitIndex(boxA) != -1) && (GetCircuitIndex(boxB) == -1))
                {
                    circuits[GetCircuitIndex(boxA)].Add(boxB);
                }
                else if ((GetCircuitIndex(boxA) == -1) && (GetCircuitIndex(boxB) != -1))
                {
                    circuits[GetCircuitIndex(boxB)].Add(boxA);
                }
                else if ((GetCircuitIndex(boxA) != -1) && (GetCircuitIndex(boxB) != -1) && (GetCircuitIndex(boxA) != GetCircuitIndex(boxB)))
                {
                    List<int> l = circuits[GetCircuitIndex(boxB)];
                    circuits.Remove(l);
                    circuits[GetCircuitIndex(boxA)].AddRange(l);
                }

                if (circuits[0].Count == junctionBoxes.Count)
                {
                    Part2Solution = (junctionBoxes[boxA].X * junctionBoxes[boxB].X).ToString();
                    break;
                }
            }

            Part3Solution = "";
        }
    }
}
