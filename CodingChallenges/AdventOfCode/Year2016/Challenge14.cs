using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2016
{
    public class Challenge14 : Challenge
    {
        readonly MD5 md5 = MD5.Create();
        readonly byte[] lookup = [48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 97, 98, 99, 100, 101, 102];

        byte[] ConvertToReadable(byte[] hash)
        {
            byte[] b = new byte[hash.Length * 2];
            for (int j = 0; j < b.Length; j += 2)
            {
                b[j] = lookup[hash[j / 2] >> 4];
                b[j + 1] = lookup[hash[j / 2] & 0xf];
            }
            return b;
        }

        byte[] GetHash(byte[] toHash, bool stretched)
        {
            byte[] hash = md5.ComputeHash(toHash);

            if (stretched)
            {
                for (int i = 0; i < 2016; i++)
                {
                    hash = md5.ComputeHash(ConvertToReadable(hash));
                }
            }

            /*StringBuilder sb = new StringBuilder();
            foreach(byte by in hash)
            {
                sb.Append((char)lookup[(by >> 4) & 0xf]).Append((char)lookup[by & 0xf]);
            }
            return sb.ToString();*/
            return hash;
        }

        int GenerateOTPs(string salt, int count, bool stretched)
        {
            int generatedKeys = 0;
            Dictionary<int, byte[]> precreatedHashes = [];
            byte[] hash;

            int index = 0;
            while (generatedKeys < count)
            {
                if (!precreatedHashes.TryGetValue(index, out byte[]? value))
                {
                    hash = GetHash(Encoding.ASCII.GetBytes(salt + index), stretched);
                }
                else
                {
                    hash = value;
                    precreatedHashes.Remove(index);
                }

                hash = ConvertToReadable(hash);

                // Find triplets
                for (int i = 0; i < hash.Length - 2; i++)
                {
                    if (hash[i] == hash[i + 1] && hash[i] == hash[i + 2])
                    {
                        // found triplet
                        // search upcoming hashes for matching quintuples
                        for (int j = 1; j <= 1000; j++)
                        {
                            byte[] hash2;

                            if (precreatedHashes.ContainsKey(index + j))
                            {
                                hash2 = precreatedHashes[index + j];
                            }
                            else
                            {
                                hash2 = GetHash(Encoding.ASCII.GetBytes(salt + (index + j)), stretched);
                                precreatedHashes.Add(index + j, hash2);
                            }

                            hash2 = ConvertToReadable(hash2);

                            bool has5InARow = false;
                            for (int k = 0; k < hash2.Length - 4; k++)
                            {
                                if (hash2[k] == hash[i])
                                {
                                    if (hash2[k] == hash2[k + 1] && hash2[k] == hash2[k + 2] && hash2[k] == hash2[k + 3] && hash2[k] == hash2[k + 4])
                                    {
                                        has5InARow = true;
                                        break;
                                    }
                                }
                            }

                            if (!has5InARow)
                            {
                                continue;
                            }

                            generatedKeys++;
                            break;
                        }
                        break;
                    }
                }

                index++;
            }

            precreatedHashes.Clear();

            return index - 1;
        }

        public override void Solve()
        {
            Part1Solution = GenerateOTPs(Input[0], 64, false).ToString();

            Part2Solution = GenerateOTPs(Input[0], 64, true).ToString();
        }
    }
}
