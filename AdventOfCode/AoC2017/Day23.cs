using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2017
{
    public class Day23 : AoCDay
    {
        enum EOpcodes
        {
            eOpcodeSND,
            eOpcodeSET,
            eOpcodeADD,
            eOpcodeSUB,
            eOpcodeMUL,
            eOpcodeMOD,
            eOpcodeRCV,
            eOpcodeJGZ,
            eOpcodeJNZ
        }

        class Instruction
        {
            public EOpcodes Opcode { get; set; }
            public string Register { get; set; }
            public string Parameter { get; set; }

            public Instruction(string instruction)
            {
                string[] instr = instruction.Split(' ');

                switch (instr[0])
                {
                    case "snd":
                        this.Opcode = EOpcodes.eOpcodeSND;
                        break;
                    case "set":
                        this.Opcode = EOpcodes.eOpcodeSET;
                        break;
                    case "add":
                        this.Opcode = EOpcodes.eOpcodeADD;
                        break;
                    case "sub":
                        this.Opcode = EOpcodes.eOpcodeSUB;
                        break;
                    case "mul":
                        this.Opcode = EOpcodes.eOpcodeMUL;
                        break;
                    case "mod":
                        this.Opcode = EOpcodes.eOpcodeMOD;
                        break;
                    case "rcv":
                        this.Opcode = EOpcodes.eOpcodeRCV;
                        break;
                    case "jgz":
                        this.Opcode = EOpcodes.eOpcodeJGZ;
                        break;
                    case "jnz":
                        this.Opcode = EOpcodes.eOpcodeJNZ;
                        break;
                }

                this.Register = instr[1];

                if (instr.Length > 2)
                {
                    this.Parameter = instr[2];
                }
                else
                {
                    this.Parameter = string.Empty;
                }
            }
        }

        class CoProcessor
        {
            public List<Instruction> Program { get; set; }
            public bool DebugMode { get; set; }
            public int MulCounter { get; private set; }

            public void ThreadFunc()
            {
                Int64 programCounter = 0;
                Dictionary<string, Int64> registerMap = new();

                if (!DebugMode)
                {
                    registerMap.Add("a", 1);
                }

                do
                {
                    Int64 parameter;
                    Instruction instr = Program[(int)programCounter];

                    if (!registerMap.ContainsKey(instr.Register))
                    {
                        if (!Int64.TryParse(instr.Register, out parameter))
                        {
                            registerMap.Add(instr.Register, 0);
                        }
                        else
                        {
                            registerMap.Add(instr.Register, parameter);
                        }
                    }

                    if (!Int64.TryParse(instr.Parameter, out parameter))
                    {
                        if (registerMap.ContainsKey(instr.Parameter))
                        {
                            parameter = registerMap[instr.Parameter];
                        }
                    }

                    switch (instr.Opcode)
                    {
                        case EOpcodes.eOpcodeSND:
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeSET:
                            registerMap[instr.Register] = parameter;
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeADD:
                            registerMap[instr.Register] += parameter;
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeSUB:
                            registerMap[instr.Register] -= parameter;
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeMUL:
                            registerMap[instr.Register] *= parameter;
                            MulCounter++;
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeMOD:
                            registerMap[instr.Register] %= parameter;
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeRCV:
                            programCounter++;
                            break;
                        case EOpcodes.eOpcodeJGZ:
                            if (registerMap[instr.Register] > 0)
                            {
                                programCounter += parameter;
                            }
                            else
                            {
                                programCounter++;
                            }
                            break;
                        case EOpcodes.eOpcodeJNZ:
                            if (registerMap[instr.Register] != 0)
                            {
                                programCounter += parameter;
                            }
                            else
                            {
                                programCounter++;
                            }
                            break;
                    }
                } while ((programCounter >= 0) && (programCounter < Program.Count));
            }
        }

        static int AocAssemblerAsCSharp()
        {
            int b, d, e, h = 0;
            bool f;

            for (b = 108100; b <= (108100 + 17000); b += 17)
            {
                f = false;
                d = 2;
                do
                {
                    e = 2;
                    do
                    {
                        if (d * e == b)
                        {
                            f = true;
                        }
                        else if (d * e > b)
                        {
                            break;
                        }
                        e++;
                    } while (e != b);
                    d++;
                } while (d != b);
                if (f)
                {
                    h++;
                }
            }

            return h;
        }

        public override void Solve()
        {
            List<Instruction> program = new();

            foreach (string line in Input)
            {
                program.Add(new Instruction(line));
            }

            CoProcessor cp1 = new();
            System.Threading.Thread p1 = new(new System.Threading.ThreadStart(cp1.ThreadFunc));
            cp1.Program = program;
            cp1.DebugMode = true;
            p1.Start();
            p1.Join();

            /*CoProcessor cp2 = new CoProcessor();
            System.Threading.Thread p2 = new System.Threading.Thread(new System.Threading.ThreadStart(cp2.ThreadFunc));
            cp2.Program = program;
            cp2.DebugMode = false;
            p2.Start();
            p2.Join();*/

            Part1Solution = cp1.MulCounter.ToString();

            Part2Solution = AocAssemblerAsCSharp().ToString();
        }
    }
}
