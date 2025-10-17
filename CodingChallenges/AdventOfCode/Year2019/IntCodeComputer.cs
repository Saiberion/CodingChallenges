using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.AdventOfCode.Year2019
{
    public class IntCodeComputer
    {
        internal long[] baseProgram;
        internal long[] memory = [];
        internal long relativeBase;
        internal Queue<long> input = [];
        internal Queue<long> output = [];
        Task? runningTask;

        void ResetMemory()
        {
            memory = new long[baseProgram.Length];
            Array.Copy(baseProgram, 0, memory, 0, baseProgram.Length);
        }

        public IntCodeComputer(string input)
        {
            string[] splitted = input.Split([',']);
            baseProgram = new long[splitted.Length + splitted.Length * 10];
            for (int i = 0; i < splitted.Length; i++)
            {
                baseProgram[i] = long.Parse(splitted[i]);
            }
            ResetMemory();
        }

        long Addition(long[] memDup, long p1, long m1, long p2, long m2)
        {
            long val1, val2;
            if (m1 == 0)
            {
                val1 = memDup[p1];
            }
            else if (m1 == 1)
            {
                val1 = p1;
            }
            else
            {
                val1 = memDup[relativeBase + p1];
            }

            if (m2 == 0)
            {
                val2 = memDup[p2];
            }
            else if (m2 == 1)
            {
                val2 = p2;
            }
            else
            {
                val2 = memDup[relativeBase + p2];
            }
            return val1 + val2;
        }

        long Multiply(long[] memDup, long p1, long m1, long p2, long m2)
        {
            long val1, val2;
            if (m1 == 0)
            {
                val1 = memDup[p1];
            }
            else if (m1 == 1)
            {
                val1 = p1;
            }
            else
            {
                val1 = memDup[relativeBase + p1];
            }

            if (m2 == 0)
            {
                val2 = memDup[p2];
            }
            else if (m2 == 1)
            {
                val2 = p2;
            }
            else
            {
                val2 = memDup[relativeBase + p2];
            }
            return val1 * val2;
        }

        long Jump(long[] memDup, long ip, long p1, long m1, long p2, long m2, bool ifTrue)
        {
            long val1, val2;
            if (m1 == 0)
            {
                val1 = memDup[p1];
            }
            else if (m1 == 1)
            {
                val1 = p1;
            }
            else
            {
                val1 = memDup[relativeBase + p1];
            }

            if (m2 == 0)
            {
                val2 = memDup[p2];
            }
            else if (m2 == 1)
            {
                val2 = p2;
            }
            else
            {
                val2 = memDup[relativeBase + p2];
            }

            if (!(val1 != 0 ^ ifTrue))
            {
                ip = val2;
            }
            else
            {
                ip += 3;
            }

            return ip;
        }

        long LessThan(long[] memDup, long p1, long m1, long p2, long m2)
        {
            long val1, val2;
            if (m1 == 0)
            {
                val1 = memDup[p1];
            }
            else if (m1 == 1)
            {
                val1 = p1;
            }
            else
            {
                val1 = memDup[relativeBase + p1];
            }

            if (m2 == 0)
            {
                val2 = memDup[p2];
            }
            else if (m2 == 1)
            {
                val2 = p2;
            }
            else
            {
                val2 = memDup[relativeBase + p2];
            }

            if (val1 < val2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        long Equal(long[] memDup, long p1, long m1, long p2, long m2)
        {
            long val1, val2;
            if (m1 == 0)
            {
                val1 = memDup[p1];
            }
            else if (m1 == 1)
            {
                val1 = p1;
            }
            else
            {
                val1 = memDup[relativeBase + p1];
            }

            if (m2 == 0)
            {
                val2 = memDup[p2];
            }
            else if (m2 == 1)
            {
                val2 = p2;
            }
            else
            {
                val2 = memDup[relativeBase + p2];
            }

            if (val1 == val2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        void Run(/*long[] memDup, Queue<long> input, Queue<long> output*/)
        {
            long ip = 0;
            bool running = true;
            long[] parameterModes = new long[3];
            long opcode;

            relativeBase = 0;

            while (running)
            {
                parameterModes[0] = 0;
                parameterModes[1] = 0;
                parameterModes[2] = 0;
                opcode = memory[ip] % 100;
                long parameters = memory[ip] / 100;

                for (int i = 0; parameters > 0; i++)
                {
                    parameterModes[i] = parameters % 10;
                    parameters /= 10;
                }

                switch (opcode)
                {
                    case 1:
                        if (parameterModes[2] == 0)
                        {
                            memory[memory[ip + 3]] = Addition(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        else
                        {
                            memory[relativeBase + memory[ip + 3]] = Addition(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        ip += 4;
                        break;
                    case 2:
                        if (parameterModes[2] == 0)
                        {
                            memory[memory[ip + 3]] = Multiply(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        else
                        {
                            memory[relativeBase + memory[ip + 3]] = Multiply(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        ip += 4;
                        break;
                    case 3:
                        if (parameterModes[0] == 0)
                        {
                            while (input.Count == 0)
                            {
                                Thread.Yield();
                            }
                            memory[memory[ip + 1]] = input.Dequeue();
                        }
                        else if (parameterModes[0] == 2)
                        {
                            memory[relativeBase + memory[ip + 1]] = input.Dequeue();
                        }
                        ip += 2;
                        break;
                    case 4:
                        if (parameterModes[0] == 0)
                        {
                            output.Enqueue(memory[memory[ip + 1]]);
                        }
                        else if (parameterModes[0] == 1)
                        {
                            output.Enqueue(memory[ip + 1]);
                        }
                        else
                        {
                            output.Enqueue(memory[relativeBase + memory[ip + 1]]);
                        }
                        ip += 2;
                        break;
                    case 5:
                        ip = Jump(memory, ip, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1], true);
                        break;
                    case 6:
                        ip = Jump(memory, ip, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1], false);
                        break;
                    case 7:
                        if (parameterModes[2] == 0)
                        {
                            memory[memory[ip + 3]] = LessThan(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        else
                        {
                            memory[relativeBase + memory[ip + 3]] = LessThan(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        ip += 4;
                        break;
                    case 8:
                        if (parameterModes[2] == 0)
                        {
                            memory[memory[ip + 3]] = Equal(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        else
                        {
                            memory[relativeBase + memory[ip + 3]] = Equal(memory, memory[ip + 1], parameterModes[0], memory[ip + 2], parameterModes[1]);
                        }
                        ip += 4;
                        break;
                    case 9:
                        if (parameterModes[0] == 0)
                        {
                            relativeBase += memory[memory[ip + 1]];
                        }
                        else if (parameterModes[0] == 1)
                        {
                            relativeBase += memory[ip + 1];
                        }
                        else if (parameterModes[0] == 2)
                        {
                            relativeBase += memory[relativeBase + memory[ip + 1]];
                        }
                        ip += 2;
                        break;
                    case 99:
                        ip++;
                        running = false;
                        break;
                }
            }
            //System.Threading.Thread.Sleep(5000);
        }

        public long Execute(int noun, int verb)
        {
            ResetMemory();
            memory[1] = noun;
            memory[2] = verb;

            Run();

            return memory[0];
        }

        public long Execute(Queue<long> input)
        {
            this.input = input;
            output = new Queue<long>();
            ResetMemory();
            runningTask = Task.Run(Run);
            runningTask.Wait();

            long result = long.MinValue;
            while (output.Count > 0)
            {
                result = output.Dequeue();
            }

            return result;
        }

        public Queue<long> Execute()
        {
            input = new Queue<long>();
            output = new Queue<long>();
            ResetMemory();
            runningTask = Task.Run(Run);
            runningTask.Wait();

            return output;
        }

        public void ExecuteAsync(Queue<long> input, Queue<long> output)
        {
            this.input = input;
            this.output = output;
            ResetMemory();
            runningTask = Task.Run(Run);
        }

        public void ExecuteAsync(Queue<long> input, Queue<long> output, long mem0Modifier)
        {
            this.input = input;
            this.output = output;
            ResetMemory();
            memory[0] = mem0Modifier;
            runningTask = Task.Run(Run);
        }

        public bool IsProgramHalted()
        {
            if (runningTask != null)
            {
                return runningTask.Status == TaskStatus.RanToCompletion;
            }
            return false;
        }
    }
}
