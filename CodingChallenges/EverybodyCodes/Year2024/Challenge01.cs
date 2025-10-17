using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.EverybodyCodes.Year2024
{
    public class Challenge01 : Challenge
    {
        private int OrderPotions(string enemyOrder, int enemyGroupSize)
        {
            int potions = 0;

            int a = 0, b = 1, c = 3, d = 5;

            for (int i = 0; i < enemyOrder.Length; i += enemyGroupSize)
            {
                int extra = enemyGroupSize - 1;
                int enemies = 0;
                
                for (int j = 0; j < enemyGroupSize; j++)
                {
                    switch (enemyOrder[i + j])
                    {
                        case 'A':
                            enemies++;
                            potions += a;
                            break;
                        case 'B':
                            enemies++;
                            potions += b;
                            break;
                        case 'C':
                            enemies++;
                            potions += c;
                            break;
                        case 'D':
                            enemies++;
                            potions += d;
                            break;
                        case 'x':
                            extra -= 1;
                            break;
                    }
                }
                potions += extra * enemies;
            }

            return potions;
        }

        public override void Solve()
        {
            Part1Solution = OrderPotions(Input[0], 1).ToString();
            Part2Solution = OrderPotions(Input[1], 2).ToString();
            Part3Solution = OrderPotions(Input[2], 3).ToString();
        }
    }
}
