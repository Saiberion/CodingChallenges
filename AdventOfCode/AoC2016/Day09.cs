using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2016
{
    public class Day09 : Day
    {
        Int64 DecompressV1(string input)
        {
            int decompressedLength = 0;
            StringBuilder marker = new StringBuilder();
            int scanMode = 0;
            int charsToRead = 1, repetitions = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch (scanMode)
                {
                    case 0: // Text
                        if (input[i] == '(')
                        {
                            scanMode = 1;
                            marker.Clear();
                        }
                        else
                        {
                            decompressedLength++;
                        }
                        break;
                    case 1: // Read marker number of characters
                        if (input[i] == 'x')
                        {
                            scanMode = 2;
                            charsToRead = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 2: // Read marker number of repetitions
                        if (input[i] == ')')
                        {
                            scanMode = 3;
                            repetitions = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 3: // read repetition characters
                        marker.Append(input[i]);
                        if (--charsToRead == 0)
                        {
                            for (int j = 0; j < repetitions; j++)
                            {
                                decompressedLength += marker.Length;
                                scanMode = 0;
                            }
                        }
                        break;
                }
            }

            return decompressedLength;
        }

        Int64 DecompressV2(string input)
        {
            Int64 decompressedLength = 0;
            StringBuilder marker = new StringBuilder();
            int scanMode = 0;
            int charsToRead = 1, repetitions = 0;

            for (int i = 0; i < input.Length; i++)
            {
                switch (scanMode)
                {
                    case 0: // Text
                        if (input[i] == '(')
                        {
                            scanMode = 1;
                            marker.Clear();
                        }
                        else
                        {
                            decompressedLength++;
                        }
                        break;
                    case 1: // Read marker number of characters
                        if (input[i] == 'x')
                        {
                            scanMode = 2;
                            charsToRead = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 2: // Read marker number of repetitions
                        if (input[i] == ')')
                        {
                            scanMode = 3;
                            repetitions = int.Parse(marker.ToString());
                            marker.Clear();
                        }
                        else
                        {
                            marker.Append(input[i]);
                        }
                        break;
                    case 3: // read repetition characters
                        marker.Append(input[i]);
                        if (--charsToRead == 0)
                        {
                            if (marker.ToString().Contains("("))
                            {
                                decompressedLength += repetitions * DecompressV2(marker.ToString());
                            }
                            else
                            {
                                decompressedLength += repetitions * marker.Length;
                            }
                            scanMode = 0;
                        }
                        break;
                }
            }

            return decompressedLength;
        }

        public override void Solve()
        {
            Part1Solution = DecompressV1(Input[0]).ToString();

            Part2Solution = DecompressV2(Input[0]).ToString();
        }
    }
}
