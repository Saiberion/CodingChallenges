using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day08 : AoCDay
    {
        override public void Solve()
        {
            int lengthInput = 0;
            int lengthDecoded = 0;
            StringBuilder sb = new();
            foreach (string s in Input)
            {
                lengthInput += s.Length;

                string str = s.Remove(s.Length - 1, 1).Remove(0, 1);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\\')
                    {
                        if ((str[i + 1] == '\\') || (str[i + 1] == '\"'))
                        {
                            str = str.Remove(i, 1);
                        }
                        else if (str[i + 1] == 'x')
                        {
                            str = str.Remove(i, 3);
                        }
                    }
                }
                lengthDecoded += str.Length;

                sb.Append('\"');
                for (int i = 0; i < s.Length; i++)
                {
                    if ((s[i] == '\\') || (s[i] == '\"'))
                    {
                        sb.Append('\\');
                    }
                    sb.Append(s[i]);
                }
                sb.Append('\"');
            }
            Part1Solution = (lengthInput - lengthDecoded).ToString();
            Part2Solution = (sb.Length - lengthInput).ToString();
        }
    }
}
