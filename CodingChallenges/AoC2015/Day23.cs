﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    public class Day23 : AoCDay
    {
        private static int RunProgram(List<string[]> instructions, bool part2)
        {
            int offset;
            Dictionary<string, int> registers = new()
            {
                { "a", 0 },
                { "b", 0 }
            };

            if (part2)
            {
                registers["a"] = 1;
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                switch (instructions[i][0])
                {
                    case "hlf":
                        registers[instructions[i][1]] /= 2;
                        break;
                    case "tpl":
                        registers[instructions[i][1]] *= 3;
                        break;
                    case "inc":
                        registers[instructions[i][1]]++;
                        break;
                    case "jmp":
                        offset = int.Parse(instructions[i][1]) - 1;
                        i += offset;
                        break;
                    case "jie":
                        if ((registers[instructions[i][1]] % 2) == 0)
                        {
                            offset = int.Parse(instructions[i][2]) - 1;
                            i += offset;
                        }
                        break;
                    case "jio":
                        if (registers[instructions[i][1]] == 1)
                        {
                            offset = int.Parse(instructions[i][2]) - 1;
                            i += offset;
                        }
                        break;
                }
            }

            return registers["b"];
        }

        override public void Solve()
        {
            List<string[]> instructions = [];

            foreach (string s in Input)
            {
                string[] splitted = s.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
                instructions.Add(splitted);
            }

            Part1Solution = RunProgram(instructions, false).ToString();
            Part2Solution = RunProgram(instructions, true).ToString();
        }
    }
}
