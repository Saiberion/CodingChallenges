using CodingChallenges;
using CodingChallenges.AdventOfCode.Year2021;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2025
{
    public class Challenge10 : Challenge
    {
        private static int PressButtons(int target, int current, List<int> buttons, List<int> reachedStates)
        {
            int res;
            if (target == current)
            {
                return 1;
            }

            if (reachedStates.Contains(current))
            {
                return 0;
            }

            foreach(int b in buttons)
            {
                //current ^= b;
                reachedStates.Add(current);
                res = PressButtons(target, current ^ b, buttons, reachedStates);
                if (res != 0)
                {
                    return res + 1;
                }
            }
            return 0;
        }

        public override void Solve()
        {
            List<int> targetLeds = [];
            List<List<int>> buttons = [];
            foreach (string line in Input)
            {
                string[] machineInfo = line.Split(['[', ']', '(', ')', '{', '}', ' '], StringSplitOptions.RemoveEmptyEntries);

                int target = 0;
                foreach (char c in machineInfo[0])
                {
                    target <<= 1;
                    if (c == '#')
                    {
                        target |= 1;
                    }
                }
                targetLeds.Add(target);
                buttons.Add([]);
                for ( int i = 1; i < machineInfo.Length - 1; i++)
                {
                    int button = 0;
                    string[] wiredButtons = machineInfo[i].Split([','], StringSplitOptions.RemoveEmptyEntries);
                    foreach (string b in wiredButtons)
                    {
                        button |= 1 << int.Parse(b);
                    }
                    buttons[^1].Add(button);
                }
            }

            int presses = PressButtons(targetLeds[0], 0, buttons[0], []);

            Part1Solution = "TBD";

            Part2Solution = "TBD";

            Part3Solution = "";
        }
    }
}
