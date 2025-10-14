﻿using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2015
{
    class Item
    {
        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
    }

    class Player
    {
        public int Hitpoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
    }

    public class Day21 : AoCDay
    {
        private static bool Fight(Player p, Player b)
        {
            int dmgDealtP = p.Attack - b.Defense;
            if (dmgDealtP <= 0)
            {
                dmgDealtP = 1;
            }
            int dmgDealtB = b.Attack - p.Defense;
            if (dmgDealtB <= 0)
            {
                dmgDealtB = 1;
            }

            return dmgDealtP >= dmgDealtB;
        }

        override public void Solve()
        {
            List<Item> weapons =
            [
                new Item {Cost = 8, Damage = 4, Armor = 0 },
                new Item {Cost = 10, Damage = 5, Armor = 0 },
                new Item {Cost = 25, Damage = 6, Armor = 0 },
                new Item {Cost = 40, Damage = 7, Armor = 0 },
                new Item {Cost = 74, Damage = 8, Armor = 0 }
            ];

            List<Item> armors =
            [
                new Item {Cost = 0, Damage = 0, Armor = 0 },
                new Item {Cost = 13, Damage = 0, Armor = 1 },
                new Item {Cost = 31, Damage = 0, Armor = 2 },
                new Item {Cost = 53, Damage = 0, Armor = 3 },
                new Item {Cost = 75, Damage = 0, Armor = 4 },
                new Item {Cost = 102, Damage = 0, Armor = 5 }
            ];

            List<Item> rings =
            [
                new Item {Cost = 0, Damage = 0, Armor = 0 },
                new Item {Cost = 25, Damage = 1, Armor = 0 },
                new Item {Cost = 50, Damage = 2, Armor = 0 },
                new Item {Cost = 100, Damage = 3, Armor = 0 },
                new Item {Cost = 20, Damage = 0, Armor = 1 },
                new Item {Cost = 40, Damage = 0, Armor = 2 },
                new Item {Cost = 80, Damage = 0, Armor = 3 }
            ];

            List<int> costsWin = [];
            List<int> costsLose = [];

            for (int w = 0; w < weapons.Count; w++)
            {
                for (int a = 0; a < armors.Count; a++)
                {
                    for (int r1 = 0; r1 < rings.Count; r1++)
                    {
                        for (int r2 = 0; r2 < rings.Count; r2++)
                        {
                            if ((r1 > 0) && (r1 == r2))
                            {
                                continue;
                            }

                            Player p = new()
                            {
                                Hitpoints = 100,
                                Attack = weapons[w].Damage + armors[a].Damage + rings[r1].Damage + rings[r2].Damage,
                                Defense = weapons[w].Armor + armors[a].Armor + rings[r1].Armor + rings[r2].Armor
                            };

                            Player b = new() { Hitpoints = 100, Attack = 8, Defense = 2 };
                            if (Fight(p, b))
                            {
                                costsWin.Add(weapons[w].Cost + armors[a].Cost + rings[r1].Cost + rings[r2].Cost);
                            }
                            else
                            {
                                costsLose.Add(weapons[w].Cost + armors[a].Cost + rings[r1].Cost + rings[r2].Cost);
                            }
                        }
                    }
                }
            }

            int min = int.MaxValue;
            foreach (int c in costsWin)
            {
                min = Math.Min(min, c);
            }

            int max = int.MinValue;
            foreach (int c in costsLose)
            {
                max = Math.Max(max, c);
            }

            Part1Solution = min.ToString();
            Part2Solution = max.ToString();
        }
    }
}
