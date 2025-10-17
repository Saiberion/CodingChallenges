using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
    class Generator(ulong initialValue, ulong factor)
    {
        private ulong previousValue = initialValue;
        private readonly ulong factor = factor;
        private const ulong modulo = 2147483647;

        private ulong Generate()
        {
            ulong mult = previousValue * factor;
            previousValue = (uint)(mult % modulo);
            return previousValue;
        }

        public ulong GenerateNext(ulong divisableBy)
        {
            if (divisableBy == 0)
            {
                return Generate();
            }
            else
            {
                ulong result;
                while ((result = Generate()) % divisableBy != 0) ;
                return result;
            }
        }
    }

    public class Challenge15 : Challenge
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
                ulong a, b;
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
                ulong a, b;
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
