using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2016
{
    class Elf
    {
        public int Seat { get; set; }
        public int Presents { get; set; }
        public Elf Next { get; set; }
        public Elf Prev { get; set; }
    }

    public class Day19 : AoCDay
    {
        static int StealingPart1(int maxElves)
        {
            Elf root = new() { Seat = 1, Presents = 1 };
            Elf elf = root;
            Elf target = null;

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

            while (elf.Next != elf)
            {
                elf.Presents += target.Presents;

                target.Prev.Next = target.Next;
                target.Next.Prev = target.Prev;
                target = target.Next.Next;

                elf = elf.Next;
            }

            return elf.Seat;
        }

        static int StealingPart2(int maxElves)
        {
            Elf root = new() { Seat = 1, Presents = 1 };
            Elf elf = root;
            Elf target = null;
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

            while (elf.Next != elf)
            {
                elf.Presents += target.Presents;

                target.Prev.Next = target.Next;
                target.Next.Prev = target.Prev;
                if ((remaining % 2) == 1)
                {
                    target = target.Next.Next;
                }
                else
                {
                    target = target.Next;
                }
                remaining--;

                elf = elf.Next;
            }

            return elf.Seat;
        }


        public override void Solve()
        {
            Part1Solution = StealingPart1(int.Parse(Input[0])).ToString();

            Part2Solution = StealingPart2(int.Parse(Input[0])).ToString();
        }
    }
}
