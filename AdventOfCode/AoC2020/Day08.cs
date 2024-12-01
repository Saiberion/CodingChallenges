using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public enum EBootCodeInstructions
    {
        acc,
        jmp,
        nop
    }

    public enum EInstructionResult
    {
        looped,
        finished,
        running
    }

    public class BootCode
    {
        public List<EBootCodeInstructions> Instructions { get; set; }
        public List<int> Arguments { get; set; }
        public List<bool> Executed { get; set; }
        public int Accumulator { get; set; }

        private int programCounter = 0;
        private int fixedInstr = -1;

        public BootCode()
        {
            Instructions = new List<EBootCodeInstructions>();
            Arguments = new List<int>();
            Executed = new List<bool>();
            Accumulator = 0;
        }

        public void AddInstruction(string instr)
        {
            string[] splitted = instr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (splitted[0].Equals("acc"))
            {
                Instructions.Add(EBootCodeInstructions.acc);
            }
            else if (splitted[0].Equals("jmp"))
            {
                Instructions.Add(EBootCodeInstructions.jmp);
            }
            else if (splitted[0].Equals("nop"))
            {
                Instructions.Add(EBootCodeInstructions.nop);
            }
            Arguments.Add(int.Parse(splitted[1]));
            Executed.Add(false);
        }

        public EInstructionResult Next()
        {
            try
            {
                if (Executed[programCounter])
                {
                    return EInstructionResult.looped;
                }
                else
                {
                    Executed[programCounter] = true;
                    switch (Instructions[programCounter])
                    {
                        case EBootCodeInstructions.acc:
                            Accumulator += Arguments[programCounter++];
                            break;
                        case EBootCodeInstructions.jmp:
                            programCounter += Arguments[programCounter];
                            break;
                        case EBootCodeInstructions.nop:
                            programCounter++;
                            break;
                    }
                    return EInstructionResult.running;
                }
            }
            catch
            {
                // should only happen when next step is beyond current instruction list
                return EInstructionResult.finished;
            }
        }

        public void Reset()
        {
            Accumulator = 0;
            programCounter = 0;
            for (int i = 0; i < Executed.Count; i++)
            {
                Executed[i] = false;
            }
        }

        public void RunWithSelfRepair()
        {
            EInstructionResult res;
            while (true)
            {
                while ((res = Next()) == EInstructionResult.running) ;
                if (res == EInstructionResult.looped)
                {
                    Reset();
                    if (fixedInstr != -1)
                    {
                        // restore fix
                        if (Instructions[fixedInstr] == EBootCodeInstructions.jmp)
                        {
                            Instructions[fixedInstr] = EBootCodeInstructions.nop;
                        }
                        else if (Instructions[fixedInstr] == EBootCodeInstructions.nop)
                        {
                            Instructions[fixedInstr] = EBootCodeInstructions.jmp;
                        }
                    }

                    // find next jmp/nop to fix
                    for (int i = (fixedInstr + 1); i < Instructions.Count; i++)
                    {
                        if ((Instructions[i] == EBootCodeInstructions.jmp) || (Instructions[i] == EBootCodeInstructions.nop))
                        {
                            fixedInstr = i;
                            if (Instructions[fixedInstr] == EBootCodeInstructions.jmp)
                            {
                                Instructions[fixedInstr] = EBootCodeInstructions.nop;
                            }
                            else if (Instructions[fixedInstr] == EBootCodeInstructions.nop)
                            {
                                Instructions[fixedInstr] = EBootCodeInstructions.jmp;
                            }
                            break;
                        }
                    }
                }
                else if (res == EInstructionResult.finished)
                {
                    return;
                }
            }
        }
    }

    public class Day08 : AoCDay
    {
        override public void Solve()
        {
            BootCode code = new();
            for (int i = 0; i < Input.Count; i++)
            {
                code.AddInstruction(Input[i]);
            }

            while (code.Next() == EInstructionResult.running) ;
            Part1Solution = code.Accumulator.ToString();

            code.Reset();

            code.RunWithSelfRepair();
            Part2Solution = code.Accumulator.ToString();
        }
    }
}
