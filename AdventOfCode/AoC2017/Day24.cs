using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2017
{
    public class Day24 : AoCDay
    {
        class BridgePart
        {
            public List<int> PortStrength { get; set; }

            public BridgePart(string bp)
            {
                string[] s = bp.Split('/');
                PortStrength = new List<int>
                {
                    int.Parse(s[0]),
                    int.Parse(s[1])
                };
            }
        }

        static void CreateBridges(List<List<BridgePart>> bridges, List<BridgePart> currentBridge, List<BridgePart> bridgeParts, int nextConnector)
        {
            List<BridgePart> bps = new(bridgeParts);
            int next;

            for (int i = 0; i < bps.Count; i++)
            {
                if (bps[i].PortStrength.Contains(nextConnector))
                {
                    if (bps[i].PortStrength[0] == nextConnector)
                    {
                        next = bps[i].PortStrength[1];
                    }
                    else
                    {
                        next = bps[i].PortStrength[0];
                    }
                    List<BridgePart> curBridge = new(currentBridge)
                    {
                        bps[i]
                    };
                    List<BridgePart> remainingParts = new(bps);
                    remainingParts.Remove(bps[i]);
                    bridges.Add(curBridge);
                    CreateBridges(bridges, curBridge, remainingParts, next);
                }
            }
        }

        public override void Solve()
        {
            List<BridgePart> bridgeParts = new();
            List<List<BridgePart>> bridges = new();
            int bestBridgeStrength = int.MinValue;
            int bestBridgeStrengthLongest = int.MinValue;
            int longestBridge = int.MinValue;

            foreach (string line in Input)
            {
                bridgeParts.Add(new BridgePart(line));
            }

            CreateBridges(bridges, new(), bridgeParts, 0);

            foreach (List<BridgePart> bps in bridges)
            {
                int strength = 0;
                foreach (BridgePart bp in bps)
                {
                    strength += bp.PortStrength[0];
                    strength += bp.PortStrength[1];
                }
                if (strength > bestBridgeStrength)
                {
                    bestBridgeStrength = strength;
                }
                if (bps.Count > longestBridge)
                {
                    longestBridge = bps.Count;
                    bestBridgeStrengthLongest = strength;
                }
                else if (bps.Count == longestBridge)
                {
                    if (strength > bestBridgeStrengthLongest)
                    {
                        bestBridgeStrengthLongest = strength;
                    }
                }
            }

            Part1Solution = bestBridgeStrength.ToString();

            Part2Solution = bestBridgeStrengthLongest.ToString();
        }
    }
}
