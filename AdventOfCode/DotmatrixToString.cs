using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class DotmatrixToString
    {
        private static string Render4x6(List<int> textCols)
        {
            StringBuilder displayedText = new StringBuilder();
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
                else if ((textCols[i + 0] == 30) && (textCols[i + 1] == 33) && (textCols[i + 2] == 37) && (textCols[i + 3] == 23))
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
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 1))
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
            return displayedText.ToString();
        }

        private static string Render6x10(List<int> textCols)
        {
            StringBuilder displayedText = new StringBuilder();
            for (int i = 0; i < textCols.Count; i += 8)
            {
                if ((textCols[i + 0] == 255) && (textCols[i + 1] == 272) && (textCols[i + 2] == 528) && (textCols[i + 3] == 528) && (textCols[i + 4] == 272) && (textCols[i + 5] == 255))
                {
                    displayedText.Append("A");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 545) && (textCols[i + 2] == 545) && (textCols[i + 3] == 545) && (textCols[i + 4] == 545) && (textCols[i + 5] == 478))
                {
                    displayedText.Append("B");
                }
                /*else if ((textCols[i + 0] == 30) && (textCols[i + 1] == 33) && (textCols[i + 2] == 33) && (textCols[i + 3] == 18))
                {
                    displayedText.Append("C");
                }*/
                /*else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 33) && (textCols[i + 2] == 33) && (textCols[i + 3] == 30))
                {
                    displayedText.Append("D");
                }*/
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 545) && (textCols[i + 2] == 545) && (textCols[i + 3] == 545) && (textCols[i + 4] == 545) && (textCols[i + 5] == 513))
                {
                    displayedText.Append("E");
                }
                /*else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 40) && (textCols[i + 2] == 40) && (textCols[i + 3] == 32))
                {
                    displayedText.Append("F");
                }
                else if ((textCols[i + 0] == 30) && (textCols[i + 1] == 33) && (textCols[i + 2] == 37) && (textCols[i + 3] == 23))
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
                }*/
                else if ((textCols[i + 0] == 6) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 513) && (textCols[i + 4] == 1022) && (textCols[i + 5] == 512))
                {
                    displayedText.Append("J");
                }
                /*else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 8) && (textCols[i + 2] == 22) && (textCols[i + 3] == 33))
                {
                    displayedText.Append("K");
                }
                else if ((textCols[i + 0] == 63) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 1))
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
                }*/
                else if ((textCols[i + 0] == 771) && (textCols[i + 1] == 204) && (textCols[i + 2] == 48) && (textCols[i + 3] == 48) && (textCols[i + 4] == 204) && (textCols[i + 5] == 771))
                {
                    displayedText.Append("X");
                }
                /*else if ((textCols[i + 0] == 56) && (textCols[i + 1] == 7) && (textCols[i + 2] == 8) && (textCols[i + 3] == 48))
                {
                    displayedText.Append("Y");
                }
                else if ((textCols[i + 0] == 35) && (textCols[i + 1] == 37) && (textCols[i + 2] == 41) && (textCols[i + 3] == 49))
                {
                    displayedText.Append("Z");
                }*/
                else
                {
                    displayedText.Append("?");
                }
            }
            return displayedText.ToString();
        }

        public static string Render(int[,] display)
        {
            List<int> textCols = new List<int>();
            for (int x = 0; x < display.GetLength(0); x++)
            {
                int pattern = 0;
                for (int y = 0; y < display.GetLength(1); y++)
                {
                    pattern <<= 1;
                    pattern += display[x, y];
                }
                textCols.Add(pattern);
            }

            if (display.GetLength(1) == 6)
            {
                return Render4x6(textCols);
            }
            else if (display.GetLength(1) == 10)
            {
                return Render6x10(textCols);
            }
            else
            {
                return "unknow format";
            }
        }
    }
}
