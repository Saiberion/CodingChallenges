using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.AoC2021
{
    public class BingoBoard
    {
        readonly int[,] numbers = new int[5, 5];
        readonly bool[,] marked = new bool[5, 5];

        public BingoBoard(List<string> boardData)
        {
            for (int y = 0; y < boardData.Count; y++)
            {
                string[] splitted = boardData[y].Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
                for (int x = 0; x < splitted.Length; x++)
                {
                    numbers[x, y] = int.Parse(splitted[x]);
                    marked[x, y] = false;
                }
            }
        }

        private int[] FindNumber(int drawnNumber)
        {
            for (int y = 0; y < numbers.GetLength(1); y++)
            {
                for (int x = 0; x < numbers.GetLength(0); x++)
                {
                    if (numbers[x, y] == drawnNumber)
                    {
                        return [x, y];
                    }
                }
            }
            return [-1, -1];
        }

        private bool CheckBingo(int x, int y)
        {
            bool bingo = true;
            for (int a = 0; a < 5; a++)
            {
                if (marked[a, y] == false)
                {
                    bingo = false;
                }
            }

            if (bingo == false)
            {
                bingo = true;
                for (int a = 0; a < 5; a++)
                {
                    if (marked[x, a] == false)
                    {
                        bingo = false;
                    }
                }
            }

            if (bingo)
            {
                IsDone = true;
            }

            return bingo;
        }

        public bool Draw(int drawnNumber)
        {
            int[] pos = FindNumber(drawnNumber);
            if (pos[0] >= 0)
            {
                marked[pos[0], pos[1]] = true;
                return CheckBingo(pos[0], pos[1]);
            }
            else
            {
                return false;
            }
        }

        public int GetScore()
        {
            int score = 0;
            for (int y = 0; y < numbers.GetLength(1); y++)
            {
                for (int x = 0; x < numbers.GetLength(0); x++)
                {
                    if (marked[x, y] == false)
                    {
                        score += numbers[x, y];
                    }
                }
            }
            return score;
        }

        public bool IsDone { get; internal set; }
    }
}
