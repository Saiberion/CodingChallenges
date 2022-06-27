using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class Day13 : Day
    {
        private static long GCD(long a, long b)
        {
            if (a == 0)
                return b;

            while (b != 0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }

        public static long LCM(long a, long b)
        {
            return (a * b) / GCD(a, b);
        }

        override public void Solve()
        {
            int earliestDepartureTime = int.Parse(Input[0]);
            List<int> busIDs = new List<int>();
            string[] splitted = Input[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in splitted)
            {
                if (s.Equals("x"))
                {
                    busIDs.Add(-1);
                }
                else
                {
                    busIDs.Add(int.Parse(s));
                }
            }

            bool resultFound = false;
            for (int time = earliestDepartureTime; resultFound == false; time++)
            {
                foreach(int b in busIDs)
                {
                    if (b != -1)
                    {
                        if ((time % b) == 0)
                        {
                            Part1Solution = ((time - earliestDepartureTime) * b).ToString();
                            resultFound = true;
                            break;
                        }
                    }
                }
            }

            int highestBusId = 0;

            for (int i = 0; i < busIDs.Count; i++)
            {
                if (busIDs[i] > highestBusId)
                {
                    highestBusId = busIDs[i];
                }
            }

            List<int> indexedBusIDs = new List<int>();
            for(int i = 0; i < busIDs.Count; i++)
            {
                if (busIDs[i] != -1)
                {
                    indexedBusIDs.Add(busIDs[i] + i);
                }
            }

            long kgv = indexedBusIDs[0];
            indexedBusIDs.RemoveAt(0);
            while(indexedBusIDs.Count > 0)
            {
                kgv = LCM(kgv, indexedBusIDs[0]);
                indexedBusIDs.RemoveAt(0);
            }

            /*while (!subsequentDepartures)
            {
                departureTime += highestBusId;
                subsequentDepartures = true;
                for (int i = 0; (i < busIDs.Count) && subsequentDepartures; i++)
                {
                    if (busIDs[i] != -1)
                    {
                        if (((departureTime + (i - highestBusIdIndex)) % busIDs[i]) != 0)
                        {
                            subsequentDepartures = false;
                        }
                    }
                }
            }*/
            
            Part2Solution = kgv.ToString();
        }
    }
}
