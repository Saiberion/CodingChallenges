using AdventOfCode;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2017
{
    enum EOpcodes
    {
        eOpcodeSND,
        eOpcodeSET,
        eOpcodeADD,
        eOpcodeMUL,
        eOpcodeMOD,
        eOpcodeRCV,
        eOpcodeJGZ
    }

    class InstructionD18
    {
        public EOpcodes Opcode { get; set; }
        public string Register { get; set; }
        public string Parameter { get; set; }

        public InstructionD18(string instruction)
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

    class DuetThread
    {
        public List<InstructionD18> Program { get; set; }
        public int ID { get; set; }
        public BlockingCollection<Int64> SendQueue { get; set; }
        public BlockingCollection<Int64> ReceiveQueue { get; set; }
        public int SendCounter { get; private set; }

        public void ThreadFunc()
        {
            Int64 programCounter = 0;
            Dictionary<string, Int64> registerMap = new();
            BlockingCollection<Int64> sndQ = this.SendQueue;
            BlockingCollection<Int64> rcvQ = this.ReceiveQueue;

            SendCounter = 0;
            registerMap.Add("p", this.ID);

            do
            {
                Int64 parameter;
                InstructionD18 instr = Program[(int)programCounter];

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
                        sndQ.Add(registerMap[instr.Register]);
                        SendCounter++;
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
                    case EOpcodes.eOpcodeMUL:
                        registerMap[instr.Register] *= parameter;
                        programCounter++;
                        break;
                    case EOpcodes.eOpcodeMOD:
                        registerMap[instr.Register] %= parameter;
                        programCounter++;
                        break;
                    case EOpcodes.eOpcodeRCV:
                        if (rcvQ.TryTake(out parameter, 200))
                        {
                            registerMap[instr.Register] = parameter;
                            programCounter++;
                        }
                        else
                        {
                            programCounter = -1;
                        }
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
                }
            } while ((programCounter >= 0) && (programCounter < Program.Count));
        }
    }

    public class Day18 : AoCDay
    {
        public override void Solve()
        {
            List<InstructionD18> program = new();
            Dictionary<string, Int64> registerMap = new();
            Int64 programCounter = 0;
            Int64 lastFrequency = 0;

            foreach (string line in Input)
            {
                program.Add(new InstructionD18(line));
            }

            do
            {
                InstructionD18 instr = program[(int)programCounter];

                if (!registerMap.ContainsKey(instr.Register))
                {
                    registerMap.Add(instr.Register, 0);
                }

                if (!Int64.TryParse(instr.Parameter, out Int64 parameter))
                {
                    if (registerMap.ContainsKey(instr.Parameter))
                    {
                        parameter = registerMap[instr.Parameter];
                    }
                }

                switch (instr.Opcode)
                {
                    case EOpcodes.eOpcodeSND:
                        lastFrequency = registerMap[instr.Register];
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
                    case EOpcodes.eOpcodeMUL:
                        registerMap[instr.Register] *= parameter;
                        programCounter++;
                        break;
                    case EOpcodes.eOpcodeMOD:
                        registerMap[instr.Register] %= parameter;
                        programCounter++;
                        break;
                    case EOpcodes.eOpcodeRCV:
                        if (registerMap[instr.Register] != 0)
                        {
                            Part1Solution = lastFrequency.ToString();
                            programCounter = -1;
                        }
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
                }
            } while ((programCounter >= 0) && (programCounter < program.Count));

            // Damn snd and rcv do something completely different :-)

            DuetThread dt1 = new();
            DuetThread dt2 = new();

            System.Threading.Thread p1 = new(new System.Threading.ThreadStart(dt1.ThreadFunc));
            System.Threading.Thread p2 = new(new System.Threading.ThreadStart(dt2.ThreadFunc));

            dt1.Program = program;
            dt2.Program = program;

            dt1.ID = 0;
            dt2.ID = 1;

            dt1.SendQueue = new BlockingCollection<Int64>();
            dt2.SendQueue = new BlockingCollection<Int64>();

            dt1.ReceiveQueue = dt2.SendQueue;
            dt2.ReceiveQueue = dt1.SendQueue;

            p1.Start();
            p2.Start();

            p1.Join();
            p2.Join();

            Part2Solution = dt2.SendCounter.ToString();
        }
    }
}
