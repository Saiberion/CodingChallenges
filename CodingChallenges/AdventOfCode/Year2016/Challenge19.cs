using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2016
{
    class Elf
    {
        public int Seat { get; set; }
        public int Presents { get; set; }
        public Elf? Next { get; set; }
        public Elf? Prev { get; set; }
    }

    public class Challenge19 : Challenge
    {
        static int StealingPart1(int maxElves)
        {
            Elf root = new() { Seat = 1, Presents = 1 };
            Elf? elf = root;
            Elf? target = new();

            for (int i = 1; i < maxElves; i++)
            {
                if (i == maxElves)
                {
                    elf.Next = root;
                }
                else
                {
                    elf.Next = new Elf { Seat = i + 1, Presents = 1, Prev = elf };
                }
                elf = elf.Next;
                if (i == 1)
                {
                    target = elf;
                }
            }
            elf.Next = root;
            root.Prev = elf;
            elf = root;

            while (elf?.Next != elf)
            {
                if (elf != null && target != null)
                {
                    elf.Presents += target.Presents;

                    if (target.Prev != null)
                    {
                        target.Prev.Next = target.Next;
                    }
                    if (target.Next != null)
                    {
                        target.Next.Prev = target.Prev;
                    }
                    if (target.Next != null)
                    {
                        target = target.Next.Next;
                    }

                    elf = elf.Next;
                }
            }

            if (elf != null)
            {
                return elf.Seat;
            }
            return 0;
        }

        static int StealingPart2(int maxElves)
        {
            Elf root = new() { Seat = 1, Presents = 1 };
            Elf? elf = root;
            Elf? target = new();
            int remaining = maxElves;

            for (int i = 1; i < maxElves; i++)
            {
                if (i == maxElves)
                {
                    elf.Next = root;
                }
                else
                {
                    elf.Next = new Elf { Seat = i + 1, Presents = 1, Prev = elf };
                }
                elf = elf.Next;
                if (i == maxElves / 2)
                {
                    target = elf;
                }
            }
            elf.Next = root;
            root.Prev = elf;
            elf = root;

            while (elf?.Next != elf)
            {
                if (elf != null && target != null)
                {
                    elf.Presents += target.Presents;

                    if (target.Prev != null)
                    {
                        target.Prev.Next = target.Next;
                    }
                    if (target.Next != null)
                    {
                        target.Next.Prev = target.Prev;
                    }
                    if (remaining % 2 == 1)
                    {
                        if (target.Next != null)
                        {
                            target = target.Next.Next;
                        }
                    }
                    else
                    {
                        target = target.Next;
                    }
                    remaining--;

                    elf = elf.Next;
                }
            }

            if (elf != null)
            {
                return elf.Seat;
            }
            return 0;
        }


        public override void Solve()
        {
            Part1Solution = StealingPart1(int.Parse(Input[0])).ToString();

            Part2Solution = StealingPart2(int.Parse(Input[0])).ToString();
        }
    }
}
