using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2016
{
    public class Day08 : Day
    {
        readonly StringBuilder displayedText = new StringBuilder();
        int DisplayControl(List<string> input)
        {
            int[,] display = new int[50, 6];

            foreach (string s in input)
            {
                string[] splitted = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (splitted[0])
                {
                    case "rect":
                        string[] dim = splitted[1].Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);
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

            List<int> textCols = new List<int>();
            for(int x = 0; x < display.GetLength(0); x++)
            {
                int pattern = 0;
                for (int y = 0; y < display.GetLength(1); y++)
                {
                    pattern <<= 1;
                    pattern += display[x, y];
                }
                textCols.Add(pattern);
            }

            displayedText.Clear();
            for (int i = 0; i < textCols.Count; i += 5)
            {
                if ((textCols[i + 0] == 31) && (textCols[i + 1] == 36) && (textCols[i + 2] == 36) && (textCols[i + 3] == 31))
                {
                    displayedText.Append("A");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 41) && (textCols[i + 2] == 41) && (textCols[i + 3] == 22))
                {
                    displayedText.Append("B");
                }
                else if ((textCols[i + 0] == 30) && (textCols[i + 1] == 33) && (textCols[i + 2] == 33) && (textCols[i + 3] == 18))
                {
                    displayedText.Append("C");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 33) && (textCols[i + 2] == 33) && (textCols[i + 3] == 30))
                {
                    displayedText.Append("D");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 41) && (textCols[i + 2] == 41) && (textCols[i + 3] == 33))
                {
                    displayedText.Append("E");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 40) && (textCols[i + 2] == 40) && (textCols[i + 3] == 32))
                {
                    displayedText.Append("F");
                }
                else if ((textCols[i + 0] == 30) && (textCols[i + 1] == 33) && (textCols[i + 2] == 37) && (textCols[i + 3] == 16))
                {
                    displayedText.Append("G");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 8) && (textCols[i + 2] == 8) && (textCols[i + 3] == 63))
                {
                    displayedText.Append("H");
                }
                else if ((textCols[i + 0] == 33) && (textCols[i + 1] == 63) && (textCols[i + 2] == 33) && (textCols[i + 3] == 33))
                {
                    displayedText.Append("I");
                }
                else if ((textCols[i + 0] == 2) && (textCols[i + 1] == 1) && (textCols[i + 2] == 33) && (textCols[i + 3] == 62))
                {
                    displayedText.Append("J");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 8) && (textCols[i + 2] == 22) && (textCols[i + 3] == 33))
                {
                    displayedText.Append("K");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 8) && (textCols[i + 2] == 1) && (textCols[i + 3] == 1))
                {
                    displayedText.Append("L");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 24) && (textCols[i + 2] == 24) && (textCols[i + 3] == 63))
                {
                    displayedText.Append("M");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 24) && (textCols[i + 2] == 6) && (textCols[i + 3] == 63))
                {
                    displayedText.Append("N");
                }
                else if ((textCols[i + 0] == 30) && (textCols[i + 1] == 33) && (textCols[i + 2] == 33) && (textCols[i + 3] == 30))
                {
                    displayedText.Append("O");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 36) && (textCols[i + 2] == 36) && (textCols[i + 3] == 24))
                {
                    displayedText.Append("P");
                }
                else if ((textCols[i + 0] == 28) && (textCols[i + 1] == 34) && (textCols[i + 2] == 34) && (textCols[i + 3] == 29))
                {
                    displayedText.Append("Q");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 36) && (textCols[i + 2] == 38) && (textCols[i + 3] == 25))
                {
                    displayedText.Append("R");
                }
                else if ((textCols[i + 0] == 25) && (textCols[i + 1] == 37) && (textCols[i + 2] == 37) && (textCols[i + 3] == 34))
                {
                    displayedText.Append("S");
                }
                else if ((textCols[i + 0] == 32) && (textCols[i + 1] == 63) && (textCols[i + 2] == 32) && (textCols[i + 3] == 32))
                {
                    displayedText.Append("T");
                }
                else if ((textCols[i + 0] == 62) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 62))
                {
                    displayedText.Append("U");
                }
                else if ((textCols[i + 0] == 62) && (textCols[i + 1] == 2) && (textCols[i + 2] == 2) && (textCols[i + 3] == 62))
                {
                    displayedText.Append("V");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 6) && (textCols[i + 2] == 6) && (textCols[i + 3] == 63))
                {
                    displayedText.Append("W");
                }
                else if ((textCols[i + 0] == 51) && (textCols[i + 1] == 12) && (textCols[i + 2] == 12) && (textCols[i + 3] == 51))
                {
                    displayedText.Append("X");
                }
                else if ((textCols[i + 0] == 56) && (textCols[i + 1] == 7) && (textCols[i + 2] == 8) && (textCols[i + 3] == 48))
                {
                    displayedText.Append("Y");
                }
                else if ((textCols[i + 0] == 35) && (textCols[i + 1] == 37) && (textCols[i + 2] == 41) && (textCols[i + 3] == 49))
                {
                    displayedText.Append("Z");
                }
                else
                {
                    displayedText.Append("?");
                }
            }

            return activePixels;
        }

        public override void Solve()
        {
            Part1Solution = DisplayControl(Input).ToString();

            Part2Solution = displayedText.ToString();
        }
    }
}
