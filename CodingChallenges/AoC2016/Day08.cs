using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2016
{
    public class Day08 : AoCDay
    {
        string displayedText = "";
        int DisplayControl(List<string> input)
        {
            int[,] display = new int[50, 6];

            foreach (string s in input)
            {
                string[] splitted = s.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                switch (splitted[0])
                {
                    case "rect":
                        string[] dim = splitted[1].Split(['x'], StringSplitOptions.RemoveEmptyEntries);
                        for (int x = 0; x < int.Parse(dim[0]); x++)
                        {
                            for (int y = 0; y < int.Parse(dim[1]); y++)
                            {
                                display[x, y] = 1;
                            }
                        }
                        break;
                    case "rotate":
                        switch (splitted[1])
                        {
                            case "column":
                                int col = int.Parse(splitted[2].Remove(0, 2));
                                for (int rot = 0; rot < int.Parse(splitted[4]); rot++)
                                {
                                    int tmp = display[col, display.GetLength(1) - 1];
                                    for (int i = display.GetLength(1) - 2; i >= 0; i--)
                                    {
                                        display[col, i + 1] = display[col, i];
                                    }
                                    display[col, 0] = tmp;
                                }
                                break;
                            case "row":
                                int row = int.Parse(splitted[2].Remove(0, 2));
                                for (int rot = 0; rot < int.Parse(splitted[4]); rot++)
                                {
                                    int tmp = display[display.GetLength(0) - 1, row];
                                    for (int i = display.GetLength(0) - 2; i >= 0; i--)
                                    {
                                        display[i + 1, row] = display[i, row];
                                    }
                                    display[0, row] = tmp;
                                }
                                break;
                        }
                        break;
                }
            }

            int activePixels = 0;
            for (int y = 0; y < display.GetLength(1); y++)
            {
                for (int x = 0; x < display.GetLength(0); x++)
                {
                    activePixels += display[x, y];
                }
            }

            displayedText = DotmatrixToString.Render(display);

            return activePixels;
        }

        public override void Solve()
        {
            Part1Solution = DisplayControl(Input).ToString();

            Part2Solution = displayedText.ToString();
        }
    }
}
