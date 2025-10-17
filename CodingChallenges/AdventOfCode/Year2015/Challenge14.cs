using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2015
{
    class Reindeer(int speed, int flyTime, int restTime)
    {
        public int Speed { get; set; } = speed;
        public int FlyTime { get; set; } = flyTime;
        public int RestTime { get; set; } = restTime;
        public int TraveledDistance { get; set; } = 0;
        public int PointsScored { get; set; } = 0;

        private bool isFlying = true;
        private int travelTime = 0;

        public void Travel()
        {
            if (isFlying)
            {
                TraveledDistance += Speed;
                if (++travelTime == FlyTime)
                {
                    isFlying = false;
                    travelTime = 0;
                }
            }
            else
            {
                if (++travelTime == RestTime)
                {
                    isFlying = true;
                    travelTime = 0;
                }
            }
        }
    }

    public class Challenge14 : Challenge
    {
        override public void Solve()
        {
            List<Reindeer> reindeers = [];
            int winningDistance = int.MinValue;
            int winningPoints = int.MinValue;

            foreach (string s in Input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                reindeers.Add(new Reindeer(int.Parse(splitted[3]), int.Parse(splitted[6]), int.Parse(splitted[13])));
            }

            for (int i = 0; i < 2503; i++)
            {
                Reindeer leading;
                foreach (Reindeer r in reindeers)
                {
                    r.Travel();
                    winningDistance = Math.Max(winningDistance, r.TraveledDistance);
                }

                leading = reindeers[0];
                for (int r = 1; r < reindeers.Count; r++)
                {
                    if (reindeers[r].TraveledDistance > leading.TraveledDistance)
                    {
                        leading = reindeers[r];
                    }
                }
                foreach (Reindeer r in reindeers)
                {
                    if (r.TraveledDistance == leading.TraveledDistance)
                    {
                        winningPoints = Math.Max(winningPoints, ++r.PointsScored);
                    }
                }
            }

            Part1Solution = winningDistance.ToString();
            Part2Solution = winningPoints.ToString();
        }
    }
}
