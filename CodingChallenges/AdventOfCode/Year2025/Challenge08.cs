using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge08 : Challenge
    {
        public override void Solve()
        {
            List<JunctionBox> junctionBoxes = [];
            List<List<JunctionBox>> circuits = [];

            foreach (string line in Input)
            {
                string[] coords = line.Split([','], StringSplitOptions.RemoveEmptyEntries);
                JunctionBox b = new(int.Parse(coords[0]), int.Parse(coords[1]), int.Parse(coords[2]));
                junctionBoxes.Add(b);
                circuits.Add([b]);
            }

            int nextFreeCircuit = 1;

            int iter = 0;
            do
            {
                int minDistance = int.MaxValue;
                int startBox = -1;
                int endBox = -1;
                for (int i = 0; i < junctionBoxes.Count - 1; i++)
                {
                    for (int j = i + 1; j < junctionBoxes.Count; j++)
                    {
                        if (!junctionBoxes[i].ConnectedBoxes.Contains(junctionBoxes[j]))
                        {
                            int distance = junctionBoxes[i].Position.GetDistanceTo(junctionBoxes[j].Position);
                            if (distance < minDistance)
                            {
                                minDistance = distance;
                                startBox = i;
                                endBox = j;
                            }
                        }
                    }
                }
                junctionBoxes[startBox].ConnectedBoxes.Add(junctionBoxes[endBox]);
                junctionBoxes[endBox].ConnectedBoxes.Add(junctionBoxes[startBox]);
            }
            while (++iter < 10);

            

            /*if ((junctionBoxes[startBox].Circuit == 0) && (junctionBoxes[endBox].Circuit == 0))
            {
                junctionBoxes[startBox].Circuit = junctionBoxes[endBox].Circuit = nextFreeCircuit++;
            }
            else if ((junctionBoxes[startBox].Circuit != 0) && (junctionBoxes[endBox].Circuit == 0))
            {
                junctionBoxes[endBox].Circuit = junctionBoxes[startBox].Circuit;
            }
            else if ((junctionBoxes[startBox].Circuit == 0) && (junctionBoxes[endBox].Circuit != 0))
            {
                junctionBoxes[startBox].Circuit = junctionBoxes[endBox].Circuit;
            }
            else
            {

            }*/

                Part1Solution = "TBD";

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
