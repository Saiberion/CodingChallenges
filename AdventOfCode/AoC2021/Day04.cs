using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2021
{
    public class Day04 : Day
    {
        override public void Solve()
        {
            bool firstWin = false;
            List<int> drawPool = new List<int>();
            List<BingoBoard> boards = new List<BingoBoard>();
            string[] splitted = Input[0].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in splitted)
            {
                drawPool.Add(int.Parse(s));
            }

            for (int i = 2; i < Input.Count; i += 6)
            {
                List<string> bingoBoardLines = new List<string>();
                bingoBoardLines.Add(Input[i]);
                bingoBoardLines.Add(Input[i + 1]);
                bingoBoardLines.Add(Input[i + 2]);
                bingoBoardLines.Add(Input[i + 3]);
                bingoBoardLines.Add(Input[i + 4]);
                boards.Add(new BingoBoard(bingoBoardLines));
            }

            for(int i = 0; i < drawPool.Count; i++)
            {
                foreach(BingoBoard b in boards)
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
