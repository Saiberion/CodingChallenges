﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AoC2017
{
    public class KnotHash
    {
        private const int listLength = 256;
        private int currentPosition;
        private int skipSize;

        private void Reset()
        {
            currentPosition = 0;
            skipSize = 0;
        }

        private void HashingRound(List<byte> knotHash, List<byte> inputLengths)
        {
            foreach (int i in inputLengths)
            {
                List<byte> segment;

                if ((currentPosition + i) > knotHash.Count)
                {
                    int elementsTillEndOfList = knotHash.Count - currentPosition;
                    int remainingElementsFromStartOfList = i - elementsTillEndOfList;

                    segment = knotHash.GetRange(currentPosition, elementsTillEndOfList);
                    segment.AddRange(knotHash.GetRange(0, remainingElementsFromStartOfList));
                    segment.Reverse();
                    knotHash.RemoveRange(currentPosition, elementsTillEndOfList);
                    knotHash.AddRange(segment.GetRange(0, elementsTillEndOfList));
                    knotHash.RemoveRange(0, remainingElementsFromStartOfList);
                    knotHash.InsertRange(0, segment.GetRange(elementsTillEndOfList, remainingElementsFromStartOfList));
                }
                else
                {
                    segment = knotHash.GetRange(currentPosition, i);
                    segment.Reverse();
                    knotHash.RemoveRange(currentPosition, i);
                    knotHash.InsertRange(currentPosition, segment);
                }

                currentPosition += i + skipSize;
                while (currentPosition >= listLength)
                {
                    currentPosition -= listLength;
                }
                skipSize++;
            }
        }

        public int GetHashChecksum(string stream)
        {
            List<byte> inputLengths = [];
            List<byte> knotHash = [];

            this.Reset();

            foreach (string s in stream.Split(','))
            {
                inputLengths.Add(byte.Parse(s));
            }

            for (int i = 0; i < KnotHash.listLength; i++)
            {
                knotHash.Add((byte)i);
            }

            this.HashingRound(knotHash, inputLengths);

            return knotHash[0] * knotHash[1];
        }

        public string GetHashString(string input)
        {
            List<byte> inputLengths = [];
            List<byte> knotHash = [];
            List<byte> denseHash = [];

            this.Reset();

            inputLengths.AddRange(Encoding.ASCII.GetBytes(input));

            foreach (string s in "17,31,73,47,23".Split(','))
            {
                inputLengths.Add(byte.Parse(s));
            }

            for (int i = 0; i < KnotHash.listLength; i++)
            {
                knotHash.Add((byte)i);
            }

            for (int i = 0; i < 64; i++)
            {
                this.HashingRound(knotHash, inputLengths);
            }

            for (int i = 0; i < 16; i++)
            {
                byte xorblock = 0;
                for (int j = 0; j < 16; j++)
                {
                    xorblock ^= knotHash[i * 16 + j];
                }
                denseHash.Add(xorblock);
            }

            StringBuilder sb = new();
            foreach (byte b in denseHash)
            {
                sb.Append(string.Format("{0:x2}", b));
            }

            return sb.ToString();
        }
    }
}
