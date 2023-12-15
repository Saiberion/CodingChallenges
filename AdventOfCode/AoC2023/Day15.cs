using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace AoC2023
{
    public class Lens
    {
        public string Label { get; internal set; }
        public int FocalLength { get; internal set; }
        public int Operation { get; internal set; }

        public Lens(string sequence)
        {
            string[] lensData = sequence.Split(new char[] { '=', '-' }, StringSplitOptions.RemoveEmptyEntries);
            Label = lensData[0];
            if (lensData.Length > 1)
            {
                FocalLength = int.Parse(lensData[1]);
                Operation = 1;
            }
            else
            {
                FocalLength = -1;
                Operation = -1;
            }
        }
    }

    public class Day15 : Day
    {
        public static int GetHash(string sequence)
        {
            int hash = 0;
            foreach (char c in sequence)
            {
                hash += c;
                hash *= 17;
                hash %= 256;
            }
            return hash;
        }

        public override void Solve()
        {
            string[] initialisationSequence = Input[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int hashCheck = 0;
            foreach (string s in initialisationSequence)
            {
                hashCheck += GetHash(s);
            }

            Part1Solution = hashCheck.ToString();

            List<Lens>[] boxes = new List<Lens>[256];
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new List<Lens>();
            }

            foreach (string s in initialisationSequence)
            {
                Lens lens = new(s);
                int labelHash = GetHash(lens.Label);
                List<Lens> l = boxes[labelHash];
                if (lens.Operation < 0)
                {
                    for(int i = 0; i < l.Count; i++)
                    {
                        if (l[i].Label.Equals(lens.Label))
                        {
                            l.RemoveAt(i);
                            break;
                        }
                    }
                }
                else
                {
                    int labelIdx = -1;
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (l[i].Label.Equals(lens.Label))
                        {
                            labelIdx = i;
                            break;
                        }
                    }
                    if (labelIdx < 0)
                    {
                        l.Add(lens);
                    }
                    else
                    {
                        l.RemoveAt(labelIdx);
                        l.Insert(labelIdx, lens);
                    }
                }
            }

            int totalFocus = 0;
            for (int b = 0; b < boxes.Length; b++)
            {
                for (int l = 0; l < boxes[b].Count; l++)
                {
                    totalFocus += (b + 1) * (l + 1) * boxes[b][l].FocalLength;
                }
                
            }

            Part2Solution = totalFocus.ToString();
        }
    }
}
