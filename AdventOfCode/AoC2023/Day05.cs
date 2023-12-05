using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2023
{
    

    public class Day05 : Day
    {
        private enum EInputReadType
        {
            none,
            seed,
            seedToSoilMap,
            soilToFertilizterMap,
            fertilizerToWater,
            waterToLight,
            lightToTemperature,
            temperatureToHumidity,
            humidityToLocation
        }

        public override void Solve()
        {
            List<int> seeds = new();
            EInputReadType readType = EInputReadType.none;

            foreach (string line in Input)
            {
                if (line.StartsWith("seeds:"))
                {
                    string[] seedsStr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(string seed in seedsStr)
                    {
                        if (char.IsDigit(seed[0]))
                        {
                            seeds.Add(int.Parse(seed));
                        }
                    }
                }
                else if (line.StartsWith("seed-to-soil map:"))
                {
                    readType = EInputReadType.seedToSoilMap;
                }

                switch(readType)
                {
                    case EInputReadType.none:
                        break;
                }
            }

            Part1Solution = "TBD";

            Part2Solution = "TBD";
        }
    }
}
