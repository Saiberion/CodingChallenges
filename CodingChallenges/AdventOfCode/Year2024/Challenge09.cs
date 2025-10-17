using CodingChallenges.AdventOfCode.Year2016;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2024
{
    public class Challenge09 : Challenge
    {
        private static List<int> FillDisk(string map)
        {
            List<int> disk = [];
            bool mapValIsFile = true;
            int nextFileID = 0;
            
            foreach (char c in map)
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
                if (mapValIsFile)
                {
                    nextFileID++;
                }
            }
            return disk;
        }

        private static void BlockCompact(List<int> disk)
        {
            int nextFreeBlock = 0;
            for (; disk[nextFreeBlock] != -1; nextFreeBlock++) ;
            for (int i = disk.Count - 1; i > nextFreeBlock; i--)
            {
                disk[nextFreeBlock] = disk[i];
                disk[i] = -1;
                for (; disk[nextFreeBlock] != -1; nextFreeBlock++) ;
            }
        }

        private static void FileCompact(List<int> disk)
        {
            int nextFreeBlock = 0;
            int nextFreeBlockSize = -1;
            int fileToMove = disk[^1];
            int fileSize = 0;
            List<int> copiedIDs = [];

            for (int f = disk.Count - 1; f >= 0; f--)
            {
                // i still have to figure out how to skip ids I already moved
                if (disk[f] < fileToMove && !copiedIDs.Contains(disk[f]))
                {
                    if (fileSize == 0)
                    {
                        if (disk[f] != -1)
                        {
                            fileSize = 1;
                            fileToMove = disk[f];
                        }
                    }
                    else
                    {
                        // new file ID, try to move current ID first
                        for (int e = 0; e < f; e++)
                        {
                            if (nextFreeBlockSize < 0)
                            {
                                if (disk[e] == -1)
                                {
                                    nextFreeBlock = e;
                                    nextFreeBlockSize = 1;
                                }
                            }
                            else
                            {
                                if (disk[e] == -1)
                                {
                                    nextFreeBlockSize++;
                                }
                                else
                                {
                                    // new data begin from here on, check if space is enough for fileToMove to fit
                                    if (nextFreeBlockSize >= fileSize)
                                    {
                                        copiedIDs.Add(disk[f + 1]);
                                        for (int s = 0; s < fileSize; s++)
                                        {
                                            disk[nextFreeBlock + s] = disk[f + 1 + s];
                                            disk[f + 1 + s] = -1;
                                        }
                                        nextFreeBlockSize = -1;
                                        break;
                                    }
                                    nextFreeBlockSize = -1;
                                }
                            }
                        }
                        if (disk[f] != -1)
                        {
                            fileToMove = disk[f];
                            fileSize = 1;
                        }
                        else
                        {
                            fileSize = 0;
                        }
                    }
                }
                else
                {
                    if (disk[f] != -1 && disk[f] != fileToMove)
                    {
                        fileSize++;
                    }
                }
            }
        }

        private static long CalculateChecksum(List<int> disk)
        {
            long checksum = 0;
            for (int i = 0; i < disk.Count; i++)
            {
                if (disk[i] != -1)
                {
                    checksum += i * disk[i];
                }
            }
            return checksum;
        }

        public override void Solve()
        {
            List<int> disk;

            disk = FillDisk(Input[0]);
            BlockCompact(disk);
            Part1Solution = CalculateChecksum(disk).ToString();

            disk = FillDisk(Input[0]);
            FileCompact(disk);
            Part2Solution = CalculateChecksum(disk).ToString();
        }
    }
}
