using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode._2019
{
    public class Day02 : Day
    {
        public Day02()
        {
            Load("2019/inputs/day02.txt");
        }

        override public void Solve()
        {
            IntCodeComputer ic = new IntCodeComputer(Input[0]);
            
            Part1Solution = ic.Execute(12, 02).ToString();

            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    if (ic.Execute(noun, verb) == 19690720)
                    {
                        Part2Solution = (noun * 100 + verb).ToString();
                        return;
                    }
                }
            }
        }
    }
}
