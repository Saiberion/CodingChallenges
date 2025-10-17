using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2021
{
    public class Challenge21 : Challenge
    {
        override public void Solve()
        {
            int[] playerPos = new int[Input.Count];
            int[] playerScore = new int[Input.Count];

            for (int i = 0; i < Input.Count; i++)
            {
                string[] splitted = Input[i].Split([':'], StringSplitOptions.RemoveEmptyEntries);
                playerPos[i] = int.Parse(splitted[1]);
                playerScore[i] = 0;
            }

            int activePlayer = 0;
            int rolls = 0;
            int deterministicDie = 0;
            while (playerScore[0] < 1000 && playerScore[1] < 1000)
            {
                int moves = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (++deterministicDie > 100)
                    {
                        deterministicDie -= 100;
                    }
                    moves += deterministicDie;
                }
                moves %= 10;
                playerPos[activePlayer] += moves;
                if (playerPos[activePlayer] > 10)
                {
                    playerPos[activePlayer] -= 10;
                }
                playerScore[activePlayer] += playerPos[activePlayer];

                activePlayer = (activePlayer + 1) % 2;
                rolls += 3;
            }
            int looseScore = Math.Min(playerScore[0], playerScore[1]);

            Part1Solution = (rolls * looseScore).ToString();
            Part2Solution = "TBD";
        }
    }
}
