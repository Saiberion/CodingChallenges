using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2018
{
    public class Day14 : Day
    {
        static int CreateRecipes(List<int> recipes, ref int elf1, ref int elf2)
        {
            int recs = 1;
            int newScore = recipes[elf1] + recipes[elf2];

            if (newScore > 9)
            {
                recipes.Add(1);
                recs++;
            }
            recipes.Add(newScore % 10);

            elf1 = (elf1 + recipes[elf1] + 1) % recipes.Count;
            elf2 = (elf2 + recipes[elf2] + 1) % recipes.Count;

            return recs;
        }

        static int CreateRecipesTillMatch(List<int> recipes, ref int elf1, ref int elf2, int skillLevel)
        {
            string sequence = skillLevel.ToString();
            long result;
            do
            {
                if (CreateRecipes(recipes, ref elf1, ref elf2) > 1)
                {
                    result = 0;
                    for (int i = sequence.Length; i > 0; i--)
                    {
                        result = result * 10 + recipes[recipes.Count - i - 1];
                    }

                    if (skillLevel == result)
                    {
                        return 2;
                    }
                }

                result = 0;
                for (int i = sequence.Length; i > 0; i--)
                {
                    result = result * 10 + recipes[^i];
                }
                if (skillLevel == result)
                {
                    return 1;
                }
            } while (true);
        }

        public override void Solve()
        {
            long result = 0;
            int skillLevel = int.Parse(Input[0]);

            List<int> recipes = new() { 3, 7 };
            int elf1 = 0;
            int elf2 = 1;

            while (recipes.Count < skillLevel)
            {
                CreateRecipes(recipes, ref elf1, ref elf2);
            }
            while (recipes.Count < (skillLevel + 10))
            {
                CreateRecipes(recipes, ref elf1, ref elf2);
            }

            for (int i = 10; i > 0; i--)
            {
                result = result * 10 + recipes[^i];
            }
            Part1Solution = result.ToString();

            recipes.Clear();
            recipes.Add(3);
            recipes.Add(7);
            elf1 = 0;
            elf2 = 1;

            string sequence = skillLevel.ToString();
            while (recipes.Count < sequence.Length)
            {
                CreateRecipes(recipes, ref elf1, ref elf2);
            }

            int recs = CreateRecipesTillMatch(recipes, ref elf1, ref elf2, skillLevel);

            Part2Solution = (recipes.Count - sequence.Length - recs + 1).ToString();
        }
    }
}
