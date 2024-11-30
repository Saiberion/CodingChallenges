using AdventOfCode;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2017
{
    public class Day21 : Day
    {
        static string FlipHorizontal(string grid)
        {
            // .#./..#/###
            string[] rows = grid.Split('/');
            string[] newRows = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                newRows[i] = string.Join("", rows[i].Reverse());
            }

            return string.Join<string>("/", newRows);
        }

        static string FlipVertical(string grid)
        {
            // .#./..#/###
            string[] rows = grid.Split('/');
            string[] newRows = new string[rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                newRows[rows.Length - i - 1] = rows[i];
            }

            return string.Join<string>("/", newRows);
        }

        static string Rotate(string grid)
        {
            // .#./..#/###
            string[] rows = grid.Split('/');
            char[,] newRows = new char[rows.Length, rows.Length];

            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    newRows[rows.Length - j - 1, i] = rows[i][j];
                }
            }

            string[] sNewRows = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows.Length; j++)
                {
                    sNewRows[i] += newRows[i, j];
                }
            }

            string result = string.Join("/", sNewRows);
            return result;
        }

        static string CopyFrom(string[] grid, int startRow, int startColumn, int num)
        {
            string[] section = new string[num];
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    section[i] += grid[i + startRow][j + startColumn];
                }
            }

            return string.Join("/", section);
        }

        static void CopyTo(string[] grid, string section, int size, int startRow)
        {
            string[] rows = section.Split('/');
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[startRow + i] += rows[i][j];
                }
            }
        }

        static string[] EnhanceStep(string[] grid, ConcurrentDictionary<string, string> rules, int size)
        {
            int newSize = size + 1;

            string[] newGrid = new string[grid.Length / size * newSize];

            for (int j = 0; j * size < grid.Length; j++)
            {
                for (int k = 0; k * size < grid.Length; k++)
                {
                    string section = CopyFrom(grid, j * size, k * size, size);
                    CopyTo(newGrid, rules[section], newSize, j * newSize);
                }
            }

            return newGrid;
        }

        static string[] Enhance(int iterations, string[] grid, ConcurrentDictionary<string, string> rules)
        {
            for (int i = 0; i < iterations; i++)
            {
                if (grid.Length % 2 == 0)
                {
                    grid = EnhanceStep(grid, rules, size: 2);
                }
                else // % 3 == 0
                {
                    grid = EnhanceStep(grid, rules, size: 3);
                }
            }

            return grid;
        }

        static int CountOn(string[] grid)
        {
            int countOn = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    if (grid[i][j] == '#')
                    {
                        countOn++;
                    }
                }
            }

            return countOn;
        }

        public override void Solve()
        {
            List<string> rules = Input;

            var separators = new char[] { ' ', '=', '>' };

            ConcurrentDictionary<string, string> rulesMap = new();

            foreach (var rule in rules)
            {
                var tokens = rule.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string from = tokens[0];
                string to = tokens[1];

                rulesMap.TryAdd(from, to);
                rulesMap.TryAdd(FlipHorizontal(from), to);
                rulesMap.TryAdd(FlipVertical(from), to);

                for (int i = 0; i < 3; i++)
                {
                    var newFrom = Rotate(from);
                    rulesMap.TryAdd(newFrom, to);
                    rulesMap.TryAdd(FlipHorizontal(newFrom), to);
                    rulesMap.TryAdd(FlipVertical(newFrom), to);

                    from = newFrom;
                }
            }

            string[] grid = new string[]
            {
            ".#.",
            "..#",
            "###",
            };

            grid = Enhance(iterations: 5, grid: grid, rules: rulesMap);

            Part1Solution = CountOn(grid).ToString();

            grid = new string[]
            {
            ".#.",
            "..#",
            "###",
            };
            grid = Enhance(iterations: 18, grid: grid, rules: rulesMap);

            Part2Solution = CountOn(grid).ToString();
        }
    }
}
