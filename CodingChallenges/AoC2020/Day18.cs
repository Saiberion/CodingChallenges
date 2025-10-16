using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2020
{
    public class Day18 : AoCDay
    {
        private int exprIdx = 0;
        private long Evaluate(string expr)
        {
            long result;
            long[] operands = new long[2];
            int opIdx = 0;
            int operation = 0;
            for (int i = exprIdx; i < expr.Length; i++)
            {
                switch (expr[i])
                {
                    case ' ':
                        break;
                    case '+':
                        operation = 0;
                        break;
                    case '*':
                        operation = 1;
                        break;
                    case '(':
                        exprIdx = i + 1;
                        operands[opIdx++] = Evaluate(expr);
                        while (expr[i++] != ')') ;
                        i = exprIdx;
                        break;
                    case ')':
                        exprIdx = i;
                        return operands[0];
                    default:
                        operands[opIdx++] = int.Parse(expr[i].ToString());
                        break;
                }

                if (opIdx == 2)
                {
                    if (operation == 0)
                    {
                        result = operands[0] + operands[1];
                    }
                    else
                    {
                        result = operands[0] * operands[1];
                    }
                    operands[0] = result;
                    opIdx = 1;
                }
            }
            return operands[0];
        }

        override public void Solve()
        {
            long sum = 0;

            for (int i = 0; i < Input.Count; i++)
            {
                exprIdx = 0;
                long val = Evaluate(Input[i]);
                System.Diagnostics.Debug.WriteLine(string.Format("Result of line {0}: {1}", i + 1, val));
                sum += val;
            }

            Part1Solution = sum.ToString();
            Part2Solution = "TBD";
        }
    }
}
