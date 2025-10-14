﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2017
{
    public class Day25 : AoCDay
    {
        enum EStates
        {
            eA,
            eB,
            eC,
            eD,
            eE,
            eF
        }

        public override void Solve()
        {
            int position = 0;
            EStates state = EStates.eA;
            Dictionary<int, int> tape = [];
            int checksum = 0;

            tape.Add(0, 0);

            for (int i = 0; i < 12523873; i++)
            {
                switch (state)
                {
                    case EStates.eA:
                        if (tape[position] == 0)
                        {
                            tape[position] = 1;
                            position++;
                            state = EStates.eB;
                        }
                        else
                        {
                            tape[position] = 1;
                            position--;
                            state = EStates.eE;
                        }
                        break;
                    case EStates.eB:
                        if (tape[position] == 0)
                        {
                            tape[position] = 1;
                            position++;
                            state = EStates.eC;
                        }
                        else
                        {
                            tape[position] = 1;
                            position++;
                            state = EStates.eF;
                        }
                        break;
                    case EStates.eC:
                        if (tape[position] == 0)
                        {
                            tape[position] = 1;
                            position--;
                            state = EStates.eD;
                        }
                        else
                        {
                            tape[position] = 0;
                            position++;
                            state = EStates.eB;
                        }
                        break;
                    case EStates.eD:
                        if (tape[position] == 0)
                        {
                            tape[position] = 1;
                            position++;
                            state = EStates.eE;
                        }
                        else
                        {
                            tape[position] = 0;
                            position--;
                            state = EStates.eC;
                        }
                        break;
                    case EStates.eE:
                        if (tape[position] == 0)
                        {
                            tape[position] = 1;
                            position--;
                            state = EStates.eA;
                        }
                        else
                        {
                            tape[position] = 0;
                            position++;
                            state = EStates.eD;
                        }
                        break;
                    case EStates.eF:
                        if (tape[position] == 0)
                        {
                            tape[position] = 1;
                            position++;
                            state = EStates.eA;
                        }
                        else
                        {
                            tape[position] = 1;
                            position++;
                            state = EStates.eC;
                        }
                        break;
                }
                tape.TryAdd(position, 0);
            }

            foreach (int v in tape.Values)
            {
                checksum += v;
            }

            Part1Solution = checksum.ToString();

            Part2Solution = "Active";
        }
    }
}
