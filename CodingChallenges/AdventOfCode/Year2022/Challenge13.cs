using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2022
{
    public class Challenge13 : Challenge
    {
        private static int CreatePacket(List<object> parent, string s)
        {
            int counter = 0;
            StringBuilder sb = new();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    List<object> l = [];
                    parent.Add(l);
                    int skip = CreatePacket(l, s[(i + 1)..]);
                    i += skip;
                    counter += skip + 1;
                }
                else if (s[i] == ']')
                {
                    if (sb.Length > 0)
                    {
                        parent.Add(int.Parse(sb.ToString()));
                    }
                    return ++counter;
                }
                else if (s[i] == ',')
                {
                    if (sb.Length > 0)
                    {
                        parent.Add(int.Parse(sb.ToString()));
                        sb.Clear();
                    }
                    counter++;
                }
                else
                {
                    sb.Append(s[i]);
                    counter++;
                }
            }
            return counter;
        }

        private int IsPacketInOrder(object left, object right)
        {
            if (typeof(int) == left.GetType() && typeof(int) == right.GetType())
            {
                // both ints
                if ((int)left < (int)right)
                {
                    return -1;
                }
                else if ((int)left > (int)right)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (typeof(List<object>) == left.GetType() && typeof(List<object>) == right.GetType())
            {
                List<object> l = (List<object>)left;
                List<object> r = (List<object>)right;

                int i;
                for (i = 0; i < l.Count; i++)
                {
                    if (i < r.Count)
                    {
                        int res = IsPacketInOrder(l[i], r[i]);
                        if (res == 0)
                        {
                            continue;
                        }
                        return res;
                    }
                    else
                    {
                        return 1;
                    }
                }

                if (i < r.Count)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (typeof(int) == left.GetType())
                {
                    return IsPacketInOrder(new List<object> { left }, right);
                }
                else
                {
                    return IsPacketInOrder(left, new List<object> { right });
                }
            }
        }

        public override void Solve()
        {
            int indexSum = 0;
            List<object>[] packetPairs = [[], []];
            List<object> distressSignal = [];

            for (int i = 0; i < Input.Count; i += 3)
            {
                CreatePacket(packetPairs[0], Input[i]);
                CreatePacket(packetPairs[1], Input[i + 1]);
            }

            for (int i = 0; i < packetPairs[0].Count; i++)
            {
                int res = IsPacketInOrder(packetPairs[0][i], packetPairs[1][i]);
                if (res == -1)
                {
                    indexSum += i + 1;
                }
            }

            Part1Solution = indexSum.ToString();

            distressSignal.AddRange(packetPairs[0]);
            distressSignal.AddRange(packetPairs[1]);
            List<object> divPacket1 = [new List<object> { 2 }];
            List<object> divPacket2 = [new List<object> { 6 }];
            distressSignal.Add(divPacket1);
            distressSignal.Add(divPacket2);

            distressSignal.Sort(IsPacketInOrder);

            Part2Solution = ((distressSignal.IndexOf(divPacket1) + 1) * (distressSignal.IndexOf(divPacket2) + 1)).ToString();
        }
    }
}
