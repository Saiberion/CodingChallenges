using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
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
                    Opcode = EOpcodes.eOpcodeSND;
                    break;
                case "set":
                    Opcode = EOpcodes.eOpcodeSET;
                    break;
                case "add":
                    Opcode = EOpcodes.eOpcodeADD;
                    break;
                case "mul":
                    Opcode = EOpcodes.eOpcodeMUL;
                    break;
                case "mod":
                    Opcode = EOpcodes.eOpcodeMOD;
                    break;
                case "rcv":
                    Opcode = EOpcodes.eOpcodeRCV;
                    break;
                case "jgz":
                    Opcode = EOpcodes.eOpcodeJGZ;
                    break;
            }

            Register = instr[1];

            if (instr.Length > 2)
            {
                Parameter = instr[2];
            }
            else
            {
                Parameter = string.Empty;
            }
        }
    }

    class DuetThread
    {
        public List<InstructionD18> Program { get; set; } = [];
        public int ID { get; set; }
        public BlockingCollection<long> SendQueue { get; set; } = [];
        public BlockingCollection<long> ReceiveQueue { get; set; } = [];
        public int SendCounter { get; private set; }

        public void ThreadFunc()
        {
            long programCounter = 0;
            Dictionary<string, long> registerMap = [];
            BlockingCollection<long> sndQ = SendQueue;
            BlockingCollection<long> rcvQ = ReceiveQueue;

            SendCounter = 0;
            registerMap.Add("p", ID);

            do
            {
                long parameter;
                InstructionD18 instr = Program[(int)programCounter];

                if (!registerMap.ContainsKey(instr.Register))
                {
                    if (!long.TryParse(instr.Register, out parameter))
                    {
                        registerMap.Add(instr.Register, 0);
                    }
                    else
                    {
                        registerMap.Add(instr.Register, parameter);
                    }
                }

                if (!long.TryParse(instr.Parameter, out parameter))
                {
                    if (registerMap.TryGetValue(instr.Parameter, out long value))
                    {
                        parameter = value;
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
            } while (programCounter >= 0 && programCounter < Program.Count);
        }
    }

    public class Challenge18 : Challenge
    {
        public override void Solve()
        {
            List<InstructionD18> program = [];
            Dictionary<string, long> registerMap = [];
            long programCounter = 0;
            long lastFrequency = 0;

            foreach (string line in Input)
            {
                program.Add(new InstructionD18(line));
            }

            do
            {
                InstructionD18 instr = program[(int)programCounter];

                if (!registerMap.TryGetValue(instr.Register, out long value))
                {
                    value = 0;
                    registerMap.Add(instr.Register, value);
                }

                if (!long.TryParse(instr.Parameter, out long parameter))
                {
                    if (registerMap.TryGetValue(instr.Parameter, out long value2))
                    {
                        parameter = value2;
                    }
                }

                switch (instr.Opcode)
                {
                    case EOpcodes.eOpcodeSND:
                        lastFrequency = value;
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
            } while (programCounter >= 0 && programCounter < program.Count);

            // Damn snd and rcv do something completely different :-)

            DuetThread dt1 = new();
            DuetThread dt2 = new();

            Thread p1 = new(new ThreadStart(dt1.ThreadFunc));
            Thread p2 = new(new ThreadStart(dt2.ThreadFunc));

            dt1.Program = program;
            dt2.Program = program;

            dt1.ID = 0;
            dt2.ID = 1;

            dt1.SendQueue = [];
            dt2.SendQueue = [];

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
