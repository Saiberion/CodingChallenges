﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    class Ingredient(int cap, int dur, int fla, int tex, int cal)
    {
        public int Capacity { get; set; } = cap;
        public int Durability { get; set; } = dur;
        public int Flavour { get; set; } = fla;
        public int Texture { get; set; } = tex;
        public int Calories { get; set; } = cal;
    }

    public class Day15 : AoCDay
    {
        override public void Solve()
        {
            List<Ingredient> ingredients = [];
            int bestCookieScore = int.MinValue;
            int bestLightCookieScore = int.MinValue;

            foreach (string s in Input)
            {
                string[] splitted = s.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
                ingredients.Add(new Ingredient(int.Parse(splitted[2]), int.Parse(splitted[4]), int.Parse(splitted[6]), int.Parse(splitted[8]), int.Parse(splitted[10])));
            }

            for (int a = 0; a < 101; a++)
            {
                for (int b = 0; b < (101 - a); b++)
                {
                    for (int c = 0; c < (101 - a - b); c++)
                    {
                        int d = 100 - a - b - c;
                        int capacity = ingredients[0].Capacity * a + ingredients[1].Capacity * b + ingredients[2].Capacity * c + ingredients[3].Capacity * d;
                        int durability = ingredients[0].Durability * a + ingredients[1].Durability * b + ingredients[2].Durability * c + ingredients[3].Durability * d;
                        int flavour = ingredients[0].Flavour * a + ingredients[1].Flavour * b + ingredients[2].Flavour * c + ingredients[3].Flavour * d;
                        int texture = ingredients[0].Texture * a + ingredients[1].Texture * b + ingredients[2].Texture * c + ingredients[3].Texture * d;
                        int calories = ingredients[0].Calories * a + ingredients[1].Calories * b + ingredients[2].Calories * c + ingredients[3].Calories * d;

                        int currentScore = capacity < 1 || durability < 1 || flavour < 1 || texture < 1 ? 0 : capacity * durability * flavour * texture;
                        bestCookieScore = Math.Max(bestCookieScore, currentScore);

                        if (calories == 500)
                        {
                            bestLightCookieScore = Math.Max(bestLightCookieScore, currentScore);
                        }
                    }
                }
            }

            Part1Solution = bestCookieScore.ToString();
            Part2Solution = bestLightCookieScore.ToString();
        }
    }
}
