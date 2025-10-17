using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2019
{
    public class Challenge12 : Challenge
    {
        override public void Solve()
        {
            List<Moon> moons = [];
            foreach (string s in Input)
            {
                moons.Add(new Moon(s));
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int m1 = 0; m1 < moons.Count; m1++)
                {
                    for (int m2 = m1 + 1; m2 < moons.Count; m2++)
                    {
                        moons[m1].ApplyGravity(moons[m2]);
                    }
                }
                foreach (Moon m in moons)
                {
                    m.Step();
                }
            }

            int systemEnergy = 0;
            foreach (Moon m in moons)
            {
                systemEnergy += m.GetTotalEnergy();
            }
            Part1Solution = systemEnergy.ToString();
            Part2Solution = "TBD";
        }
    }

    class Moon
    {
        Coordinate3D Position { get; set; }
        Coordinate3D Velocity { get; set; }
        int PotentialEnergy { get; set; }
        int KineticEnergy { get; set; }

        public Moon(string initialPosition)
        {
            string[] splitted = initialPosition.Split(['=', ',', '>']);
            Position = new Coordinate3D(int.Parse(splitted[1]), int.Parse(splitted[3]), int.Parse(splitted[5]));
            Velocity = new Coordinate3D(0, 0, 0);
        }

        void UpdatePotentialEnergy()
        {
            PotentialEnergy = Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        }

        void UpdateKineticEnergy()
        {
            KineticEnergy = Math.Abs(Velocity.X) + Math.Abs(Velocity.Y) + Math.Abs(Velocity.Z);
        }

        public void Step()
        {
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
            UpdatePotentialEnergy();
            UpdateKineticEnergy();
        }

        public void ApplyGravity(Moon m)
        {
            if (Position.X < m.Position.X)
            {
                Velocity.X++;
                m.Velocity.X--;
            }
            else if (Position.X > m.Position.X)
            {
                Velocity.X--;
                m.Velocity.X++;
            }

            if (Position.Y < m.Position.Y)
            {
                Velocity.Y++;
                m.Velocity.Y--;
            }
            else if (Position.Y > m.Position.Y)
            {
                Velocity.Y--;
                m.Velocity.Y++;
            }

            if (Position.Z < m.Position.Z)
            {
                Velocity.Z++;
                m.Velocity.Z--;
            }
            else if (Position.Z > m.Position.Z)
            {
                Velocity.Z--;
                m.Velocity.Z++;
            }
        }

        public int GetTotalEnergy()
        {
            return PotentialEnergy * KineticEnergy;
        }
    }
}
