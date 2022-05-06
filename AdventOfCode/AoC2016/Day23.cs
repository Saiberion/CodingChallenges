using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2016
{
    public class Day23 : Day
    {
        int ExecuteInstructions(List<string> input, int initA, int initB, int initC, int initD)
        {
            int val;
            Dictionary<char, int> registers = new Dictionary<char, int>
            {
                { 'a', initA },
                { 'b', initB },
                { 'c', initC },
                { 'd', initD }
            };

            for (int i = 0; (i >= 0) && (i < input.Count);)
            {
                string[] splitted = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (splitted[0])
                {
                    case "cpy":
                        if (int.TryParse(splitted[1], out val))
                        {
                            registers[splitted[2][0]] = val;
                        }
                        else
                        {
                            registers[splitted[2][0]] = registers[splitted[1][0]];
                        }
                        i++;
                        break;
                    case "inc":
                        registers[splitted[1][0]]++;
                        i++;
                        break;
                    case "dec":
                        registers[splitted[1][0]]--;
                        i++;
                        break;
                    case "jnz":
                        if (!int.TryParse(splitted[2], out val))
                        {
                            val = registers[splitted[2][0]];
                        }

                        if (int.TryParse(splitted[1], out int cond))
                        {
                            if (cond != 0)
                            {
                                i += val;
                            }
                            else
                            {
                                i++;
                            }
                        }
                        else
                        {
                            if (registers[splitted[1][0]] != 0)
                            {
                                i += val;
                            }
                            else
                            {
                                i++;
                            }
                        }
                        break;
                    case "tgl":
                        if (!int.TryParse(splitted[1], out val))
                        {
                            val = registers[splitted[1][0]];
                        }

                        if (((i + val) >= 0) && ((i + val) < input.Count))
                        {
                            if (input[i + val].StartsWith("inc"))
                            {
                                input[i + val] = input[i + val].Remove(0, 3).Insert(0, "dec");
                            }
                            else if (input[i + val].StartsWith("dec"))
                            {
                                input[i + val] = input[i + val].Remove(0, 3).Insert(0, "inc");
                            }
                            else if (input[i + val].StartsWith("tgl"))
                            {
                                string[] spl = input[i + val].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                if (spl.Length == 2)
                                {
                                    input[i + val] = input[i + val].Remove(0, 3).Insert(0, "inc");
                                }
                                else if (spl.Length == 3)
                                {
                                    input[i + val] = input[i + val].Remove(0, 3).Insert(0, "jnz");
                                }
                            }
                            else if (input[i + val].StartsWith("jnz"))
                            {
                                input[i + val] = input[i + val].Remove(0, 3).Insert(0, "cpy");
                            }
                            else if (input[i + val].StartsWith("cpy"))
                            {
                                input[i + val] = input[i + val].Remove(0, 3).Insert(0, "jnz");
                            }
                        }

                        i++;
                        break;
                }
            }

            return registers['a'];
        }

        public override void Solve()
        {
            Part1Solution = ExecuteInstructions(new List<string>(Input), 7, 0, 0, 0).ToString();

            Part2Solution = ExecuteInstructions(new List<string>(Input), 12, 0, 0, 0).ToString();
        }
    }
}
