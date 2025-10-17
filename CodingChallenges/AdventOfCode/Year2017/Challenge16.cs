using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2017
{
    class DanceMove
    {
        public char Move { get; set; }
        public List<object> Operands { get; set; }

        public DanceMove(string move)
        {
            string[] tmp;
            Move = move[0];
            Operands = [];
            switch (Move)
            {
                case 's':
                    Operands.Add(int.Parse(move.Remove(0, 1)));
                    break;
                case 'x':
                    tmp = move.Remove(0, 1).Split('/');
                    Operands.Add(int.Parse(tmp[0]));
                    Operands.Add(int.Parse(tmp[1]));
                    break;
                case 'p':
                    tmp = move.Remove(0, 1).Split('/');
                    Operands.Add(tmp[0]);
                    Operands.Add(tmp[1]);
                    break;
            }
        }
    }

    public class Challenge16 : Challenge
    {
        public override void Solve()
        {
            string dance = Input[0];

            List<char> dancers = [];
            for (int i = 0; i < 16; i++)
            {
                dancers.Add(Convert.ToChar('a' + i));
            }
            string[] danceMoves = dance.Split(',');
            List<DanceMove> listDanceMoves = [];
            for (int i = 0; i < danceMoves.Length; i++)
            {
                listDanceMoves.Add(new DanceMove(danceMoves[i]));
            }

            List<string> dancePattern = [];
            StringBuilder sb = new();
            int indA, indB;
            char tmp;
            int repeatsAfter = 0;

            for (int i = 0; i < dancers.Count; i++)
            {
                sb.Append(dancers[i]);
            }
            dancePattern.Add(sb.ToString());

            do
            {
                for (int i = 0; i < listDanceMoves.Count; i++)
                {
                    switch (listDanceMoves[i].Move)
                    {
                        case 's':
                            int rotate = (int)listDanceMoves[i].Operands[0];
                            dancers = dancers.Skip(dancers.Count - rotate)
                            .Take(rotate)
                            .Concat(dancers.Take(dancers.Count - rotate))
                            .ToList();
                            break;
                        case 'x':
                            indA = (int)listDanceMoves[i].Operands[0];
                            indB = (int)listDanceMoves[i].Operands[1];
                            char a = dancers[indA];
                            char b = dancers[indB];
                            dancers[indA] = b;
                            dancers[indB] = a;
                            break;
                        case 'p':
                            indA = dancers.IndexOf(((string)listDanceMoves[i].Operands[0])[0]);
                            indB = dancers.IndexOf(((string)listDanceMoves[i].Operands[1])[0]);
                            tmp = dancers[indA];
                            dancers[indA] = dancers[indB];
                            dancers[indB] = tmp;
                            break;
                    }
                }

                sb.Clear();
                for (int i = 0; i < dancers.Count; i++)
                {
                    sb.Append(dancers[i]);
                }
                dancePattern.Add(sb.ToString());
            } while (!dancePattern[0].Equals(dancePattern[++repeatsAfter]));
            dancePattern.RemoveAt(repeatsAfter - 1);

            Part1Solution = dancePattern[1];
            Part2Solution = dancePattern[1000000 % repeatsAfter];
        }
    }
}
