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
                else if ((textCols[i + 0] == 510) && (textCols[i + 1] == 513) && (textCols[i + 2] == 513) && (textCols[i + 3] == 513) && (textCols[i + 4] == 513) && (textCols[i + 5] == 516))
                {
                    displayedText.Append("C");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 513) && (textCols[i + 2] == 513) && (textCols[i + 3] == 513) && (textCols[i + 4] == 513) && (textCols[i + 5] == 510))
                {
                    displayedText.Append("D");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 545) && (textCols[i + 2] == 545) && (textCols[i + 3] == 545) && (textCols[i + 4] == 545) && (textCols[i + 5] == 513))
                {
                    displayedText.Append("E");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 544) && (textCols[i + 2] == 544) && (textCols[i + 3] == 544) && (textCols[i + 4] == 544) && (textCols[i + 5] == 512))
                {
                    displayedText.Append("F");
                }
                else if ((textCols[i + 0] == 510) && (textCols[i + 1] == 513) && (textCols[i + 2] == 513) && (textCols[i + 3] == 529) && (textCols[i + 4] == 529) && (textCols[i + 5] == 286))
                {
                    displayedText.Append("G");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 16) && (textCols[i + 2] == 16) && (textCols[i + 3] == 16) && (textCols[i + 4] == 16) && (textCols[i + 5] == 1023))
                {
                    displayedText.Append("H");
                }
                else if ((textCols[i + 0] == 513) && (textCols[i + 1] == 513) && (textCols[i + 2] == 513) && (textCols[i + 3] == 1023) && (textCols[i + 4] == 513) && (textCols[i + 5] == 513))
                {
                    displayedText.Append("I");
                }
                else if ((textCols[i + 0] == 6) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 513) && (textCols[i + 4] == 1022) && (textCols[i + 5] == 512))
                {
                    displayedText.Append("J");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 32) && (textCols[i + 2] == 80) && (textCols[i + 3] == 136) && (textCols[i + 4] == 260) && (textCols[i + 5] == 515))
                {
                    displayedText.Append("K");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 1) && (textCols[i + 4] == 1) && (textCols[i + 5] == 1))
                {
                    displayedText.Append("L");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 256) && (textCols[i + 2] == 192) && (textCols[i + 3] == 192) && (textCols[i + 4] == 256) && (textCols[i + 5] == 1023))
                {
                    displayedText.Append("M");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 384) && (textCols[i + 2] == 96) && (textCols[i + 3] == 24) && (textCols[i + 4] == 6) && (textCols[i + 5] == 1023))
                {
                    displayedText.Append("N");
                }
                else if ((textCols[i + 0] == 510) && (textCols[i + 1] == 513) && (textCols[i + 2] == 513) && (textCols[i + 3] == 513) && (textCols[i + 4] == 513) && (textCols[i + 5] == 510))
                {
                    displayedText.Append("O");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 544) && (textCols[i + 2] == 544) && (textCols[i + 3] == 544) && (textCols[i + 4] == 544) && (textCols[i + 5] == 448))
                {
                    displayedText.Append("P");
                }
                else if ((textCols[i + 0] == 504) && (textCols[i + 1] == 516) && (textCols[i + 2] == 516) && (textCols[i + 3] == 527) && (textCols[i + 4] == 517) && (textCols[i + 5] == 504))
                {
                    displayedText.Append("Q");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 560) && (textCols[i + 2] == 552) && (textCols[i + 3] == 548) && (textCols[i + 4] == 546) && (textCols[i + 5] == 449))
                {
                    displayedText.Append("R");
                }
                else if ((textCols[i + 0] == 449) && (textCols[i + 1] == 545) && (textCols[i + 2] == 545) && (textCols[i + 3] == 529) && (textCols[i + 4] == 529) && (textCols[i + 5] == 526))
                {
                    displayedText.Append("S");
                }
                else if ((textCols[i + 0] == 512) && (textCols[i + 1] == 512) && (textCols[i + 2] == 512) && (textCols[i + 3] == 1023) && (textCols[i + 4] == 512) && (textCols[i + 5] == 512))
                {
                    displayedText.Append("T");
                }
                else if ((textCols[i + 0] == 1022) && (textCols[i + 1] == 1) && (textCols[i + 2] == 1) && (textCols[i + 3] == 1) && (textCols[i + 4] == 1) && (textCols[i + 5] == 1022))
                {
                    displayedText.Append("U");
                }
                else if ((textCols[i + 0] == 1020) && (textCols[i + 1] == 2) && (textCols[i + 2] == 1) && (textCols[i + 3] == 1) && (textCols[i + 4] == 2) && (textCols[i + 5] == 1020))
                {
                    displayedText.Append("V");
                }
                else if ((textCols[i + 0] == 1023) && (textCols[i + 1] == 2) && (textCols[i + 2] == 12) && (textCols[i + 3] == 12) && (textCols[i + 4] == 2) && (textCols[i + 5] == 1023))
                {
                    displayedText.Append("W");
                }
                else if ((textCols[i + 0] == 771) && (textCols[i + 1] == 204) && (textCols[i + 2] == 48) && (textCols[i + 3] == 48) && (textCols[i + 4] == 204) && (textCols[i + 5] == 771))
                {
                    displayedText.Append("X");
                }
                else if ((textCols[i + 0] == 896) && (textCols[i + 1] == 64) && (textCols[i + 2] == 32) && (textCols[i + 3] == 63) && (textCols[i + 4] == 64) && (textCols[i + 5] == 896))
                {
                    displayedText.Append("Y");
                }
                else if ((textCols[i + 0] == 519) && (textCols[i + 1] == 521) && (textCols[i + 2] == 529) && (textCols[i + 3] == 545) && (textCols[i + 4] == 577) && (textCols[i + 5] == 897))
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
