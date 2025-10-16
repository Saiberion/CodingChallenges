using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2017
{
    class Generator(UInt64 initialValue, UInt64 factor)
    {
        private UInt64 previousValue = initialValue;
        private readonly UInt64 factor = factor;
        private const UInt64 modulo = 2147483647;

        private UInt64 Generate()
        {
            UInt64 mult = this.previousValue * this.factor;
            this.previousValue = (uint)(mult % modulo);
            return this.previousValue;
        }

        public UInt64 GenerateNext(UInt64 divisableBy)
        {
            if (divisableBy == 0)
            {
                return Generate();
            }
            else
            {
                UInt64 result;
                while (((result = Generate()) % divisableBy) != 0) ;
                return result;
            }
        }
    }

    public class Day15 : Challenge
    {
        public override void Solve()
        {
            Generator genA, genB;
            int matchesPart1 = 0;
            int matchesPart2 = 0;

            genA = new Generator(289, 16807);
            genB = new Generator(629, 48271);

            for (int i = 0; i < 40000000; i++)
            {
                UInt64 a, b;
                a = genA.GenerateNext(0);
                b = genB.GenerateNext(0);

                if ((a & 0xffff) == (b & 0xffff))
                {
                    matchesPart1++;
                }
            }

            genA = new Generator(289, 16807);
            genB = new Generator(629, 48271);

            for (int i = 0; i < 5000000; i++)
            {
                UInt64 a, b;
                a = genA.GenerateNext(4);
                b = genB.GenerateNext(8);

                if ((a & 0xffff) == (b & 0xffff))
                {
                    matchesPart2++;
                }
            }

            Part1Solution = matchesPart1.ToString();
            Part2Solution = matchesPart2.ToString();
        }
    }
}
