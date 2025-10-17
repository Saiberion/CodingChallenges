using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.AdventOfCode.Year2016
{
    public static class Assembunny
    {
        public static int ExecuteInstructions(List<string> input, int initA, int initB, int initC, int initD)
        {
            int val;
            bool firstOut = true;
            int lastOut = 0;
            int repetitions = 0;
            Dictionary<char, int> registers = new()
            {
                { 'a', initA },
                { 'b', initB },
                { 'c', initC },
                { 'd', initD }
            };

            for (int i = 0; i >= 0 && i < input.Count;)
            {
                string[] splitted = input[i].Split([' '], StringSplitOptions.RemoveEmptyEntries);

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

                        if (i + val >= 0 && i + val < input.Count)
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
                                string[] spl = input[i + val].Split([' '], StringSplitOptions.RemoveEmptyEntries);
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
                    case "out":
                        if (!int.TryParse(splitted[1], out val))
                        {
                            val = registers[splitted[1][0]];
                        }

                        Console.WriteLine("Antenne signal: {0}", val);
                        if (firstOut)
                        {
                            firstOut = false;
                            lastOut = val;
                            repetitions = 0;
                        }
                        else
                        {
                            if (lastOut == val)
                            {
                                return 0;
                            }
                            else
                            {
                                if (lastOut == 0)
                                {
                                    if (val != 1)
                                    {
                                        return 0;
                                    }
                                }
                                else if (lastOut == 1)
                                {
                                    if (val != 0)
                                    {
                                        return 0;
                                    }
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            lastOut = val;
                            if (++repetitions == 50)
                            {
                                return 1;
                            }
                        }
                        i++;
                        break;
                }
            }

            return registers['a'];
        }
    }
}
