using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day04 : AoCDay
    {
        override public void Solve()
        {
            bool firstWin = false;
            List<int> drawPool = new();
            List<BingoBoard> boards = new();
            string[] splitted = Input[0].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in splitted)
            {
                drawPool.Add(int.Parse(s));
            }

            for (int i = 2; i < Input.Count; i += 6)
            {
                List<string> bingoBoardLines = new()
                {
                    Input[i],
                    Input[i + 1],
                    Input[i + 2],
                    Input[i + 3],
                    Input[i + 4]
                };
                boards.Add(new BingoBoard(bingoBoardLines));
            }

            for (int i = 0; i < drawPool.Count; i++)
            {
                foreach (BingoBoard b in boards)
                {
                    if (b.IsDone == false)
                    {
                        if (b.Draw(drawPool[i]))
                        {
                            if (firstWin == false)
                            {
                                firstWin = true;
                                Part1Solution = (b.GetScore() * drawPool[i]).ToString();
                            }
                            Part2Solution = (b.GetScore() * drawPool[i]).ToString();
                        }
                    }
                }
            }
        }
    }
}
