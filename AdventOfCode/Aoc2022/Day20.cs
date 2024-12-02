using AdventOfCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2022
{
    public class Day20 : AoCDay
    {
        public class MixItem
        {
            public long item;

            public MixItem(string s, long key)
            {
                item = long.Parse(s) * key;
            }
        }

        public long Decrypt(int rounds, long key)
        {
            List<MixItem> mixingFile = new();

            foreach (string s in Input)
            {
                mixingFile.Add(new MixItem(s, key));
            }

            MixItem[] movingOrder = new MixItem[mixingFile.Count];
            for (int i = 0; i < mixingFile.Count; i++)
            {
                movingOrder[i] = mixingFile[i];
            }

            for (int r = 0; r < rounds; r++)
            {
                for (int i = 0; i < movingOrder.Length; i++)
                {
                    int oldpos = mixingFile.IndexOf(movingOrder[i]);
                    mixingFile.RemoveAt(oldpos);
                    long moveOffset = movingOrder[i].item % mixingFile.Count;
                    int newpos = (int)((oldpos + moveOffset + 10 * mixingFile.Count) % mixingFile.Count);
                    mixingFile.Insert(newpos, movingOrder[i]);
                }
            }

            long sum = 0;
            int startPos = 0;
            foreach (MixItem m in mixingFile)
            {
                if (m.item == 0)
                {
                    startPos = mixingFile.IndexOf(m);
                    break;
                }
            }

            sum += mixingFile[(startPos + 1000) % mixingFile.Count].item;
            sum += mixingFile[(startPos + 2000) % mixingFile.Count].item;
            sum += mixingFile[(startPos + 3000) % mixingFile.Count].item;

            return sum;
        }

        public override void Solve()
        {
            Part1Solution = Decrypt(1, 1).ToString();

            Part2Solution = Decrypt(10, 811589153).ToString();
        }
    }
}
