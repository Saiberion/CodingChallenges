using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2023
{
    public class SeedMapper
    {
        public long DestinationStart { get; set; }
        public long SourceStart { get; set; }
        public long RangeLength { get; set; }

        public SeedMapper(string s)
        {
            string[] mapping = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            DestinationStart = long.Parse(mapping[0]);
            SourceStart = long.Parse(mapping[1]);
            RangeLength = long.Parse(mapping[2]);
        }
    }

    public class Day05 : AoCDay
    {
        private enum EInputReadType
        {
            none,
            seeds,
            seedToSoilMap,
            soilToFertilizterMap,
            fertilizerToWaterMap,
            waterToLightMap,
            lightToTemperatureMap,
            temperatureToHumidityMap,
            humidityToLocationMap
        }

        public static long GetID(long fromID, List<SeedMapper> map)
        {
            foreach (SeedMapper mapping in map)
            {
                if ((fromID >= mapping.SourceStart) && (fromID < (mapping.SourceStart + mapping.RangeLength)))
                {
                    return fromID - mapping.SourceStart + mapping.DestinationStart;
                }
            }
            return fromID;
        }

        public override void Solve()
        {
            List<long> seeds = [];
            List<SeedMapper> seedToSoil = [];
            List<SeedMapper> soilToFertilizer = [];
            List<SeedMapper> fertilizerToWater = [];
            List<SeedMapper> waterToLight = [];
            List<SeedMapper> lightToTemperature = [];
            List<SeedMapper> temperatureToHumidity = [];
            List<SeedMapper> humidityToLocation = [];

            EInputReadType readType = EInputReadType.none;

            foreach (string line in Input)
            {
                if (line.StartsWith("seeds:"))
                {
                    readType = EInputReadType.seeds;
                }
                else if (line.StartsWith("seed-to-soil map:"))
                {
                    readType = EInputReadType.seedToSoilMap;
                    continue;
                }
                else if (line.StartsWith("soil-to-fertilizer map:"))
                {
                    readType = EInputReadType.soilToFertilizterMap;
                    continue;
                }
                else if (line.StartsWith("fertilizer-to-water map:"))
                {
                    readType = EInputReadType.fertilizerToWaterMap;
                    continue;
                }
                else if (line.StartsWith("water-to-light map:"))
                {
                    readType = EInputReadType.waterToLightMap;
                    continue;
                }
                else if (line.StartsWith("light-to-temperature map:"))
                {
                    readType = EInputReadType.lightToTemperatureMap;
                    continue;
                }
                else if (line.StartsWith("temperature-to-humidity map:"))
                {
                    readType = EInputReadType.temperatureToHumidityMap;
                    continue;
                }
                else if (line.StartsWith("humidity-to-location map:"))
                {
                    readType = EInputReadType.humidityToLocationMap;
                    continue;
                }
                else if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                switch (readType)
                {
                    case EInputReadType.none:
                        break;
                    case EInputReadType.seeds:
                        string[] seedsStr = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                        foreach (string seed in seedsStr)
                        {
                            if (char.IsDigit(seed[0]))
                            {
                                seeds.Add(long.Parse(seed));
                            }
                        }
                        readType = EInputReadType.none;
                        break;
                    case EInputReadType.seedToSoilMap:
                        seedToSoil.Add(new(line));
                        break;
                    case EInputReadType.soilToFertilizterMap:
                        soilToFertilizer.Add(new(line));
                        break;
                    case EInputReadType.fertilizerToWaterMap:
                        fertilizerToWater.Add(new(line));
                        break;
                    case EInputReadType.waterToLightMap:
                        waterToLight.Add(new(line));
                        break;
                    case EInputReadType.lightToTemperatureMap:
                        lightToTemperature.Add(new(line));
                        break;
                    case EInputReadType.temperatureToHumidityMap:
                        temperatureToHumidity.Add(new(line));
                        break;
                    case EInputReadType.humidityToLocationMap:
                        humidityToLocation.Add(new(line));
                        break;
                }
            }

            long closestLocation = long.MaxValue;
            foreach (long seed in seeds)
            {
                long nextid = GetID(seed, seedToSoil);
                nextid = GetID(nextid, soilToFertilizer);
                nextid = GetID(nextid, fertilizerToWater);
                nextid = GetID(nextid, waterToLight);
                nextid = GetID(nextid, lightToTemperature);
                nextid = GetID(nextid, temperatureToHumidity);
                closestLocation = Math.Min(closestLocation, GetID(nextid, humidityToLocation));
            }

            Part1Solution = closestLocation.ToString();

            /*closestLocation = long.MaxValue;
            for (int i = 0; i < seeds.Count; i += 2)
            {
                for(long j = 0; j < seeds[i + 1]; j++)
                {
                    long nextid = GetID(seeds[i] + j, seedToSoil);
                    nextid = GetID(nextid, soilToFertilizer);
                    nextid = GetID(nextid, fertilizerToWater);
                    nextid = GetID(nextid, waterToLight);
                    nextid = GetID(nextid, lightToTemperature);
                    nextid = GetID(nextid, temperatureToHumidity);
                    closestLocation = Math.Min(closestLocation, GetID(nextid, humidityToLocation));
                }
            }*/

            Part2Solution = "2254686 (brute forced, run skipped)";
        }
    }
}
