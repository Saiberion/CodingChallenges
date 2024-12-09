using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2024
{
    public class Day09 : AoCDay
    {
        public override void Solve()
        {
            List<long> disk = [];
            bool mapValIsFile = true;
            long nextFileID = 0;
            
            // fill disk
            foreach (char c in Input[0])
            {
                int blockSize = int.Parse(c.ToString());
                for (int i = 0; i < blockSize; i++)
                {
                    if (mapValIsFile)
                    {
                        disk.Add(nextFileID);
                    }
                    else
                    {
                        disk.Add(-1);
                    }
                }
                mapValIsFile = !mapValIsFile;
                if(mapValIsFile)
                {
                    nextFileID++;
                }
            }

            // compact disk
            int nextFreeBlock = 0;
            for (; disk[nextFreeBlock] != -1; nextFreeBlock++) ;
            for (int i = disk.Count - 1; i > nextFreeBlock; i--)
            {
                disk[nextFreeBlock] = disk[i];
                disk[i] = -1;
                for (; disk[nextFreeBlock] != -1; nextFreeBlock++) ;
            }

            // calculate checksum
            long checksum = 0;
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] != -1)
                {
                    checksum += i * disk[i];
                }
            }
            Part1Solution = checksum.ToString();

            Part2Solution = "TBD";
        }
    }
}
