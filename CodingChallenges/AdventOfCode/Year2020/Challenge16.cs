using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AdventOfCode.Year2020
{
    public class TicketField(string name, int min1, int max1, int min2, int max2)
    {
        public string Name { get; set; } = name;
        public int Min1 { get; set; } = min1;
        public int Min2 { get; set; } = min2;
        public int Max1 { get; set; } = max1;
        public int Max2 { get; set; } = max2;
    }

    public class Challenge16 : Challenge
    {
        override public void Solve()
        {
            int readSection = 0;
            List<TicketField> ticketFields = [];
            List<int> myTicketValues = [];
            List<List<int>> nearbyTickets = [];
            List<List<int>> nearbyValidTickets = [];
            foreach (string s in Input)
            {
                if (string.IsNullOrEmpty(s))
                {
                    readSection++;
                }
                else
                {
                    string[] splitted;
                    switch (readSection)
                    {
                        case 0:
                            splitted = s.Split([": ", "-", " or "], StringSplitOptions.RemoveEmptyEntries);
                            ticketFields.Add(new TicketField(splitted[0], int.Parse(splitted[1]), int.Parse(splitted[2]), int.Parse(splitted[3]), int.Parse(splitted[4])));
                            break;
                        case 1:
                            if (!s.StartsWith("your"))
                            {
                                splitted = s.Split([","], StringSplitOptions.RemoveEmptyEntries);
                                foreach (string s2 in splitted)
                                {
                                    myTicketValues.Add(int.Parse(s2));
                                }
                            }
                            break;
                        case 2:
                            if (!s.StartsWith("nearby"))
                            {
                                List<int> ticket = [];
                                splitted = s.Split([","], StringSplitOptions.RemoveEmptyEntries);
                                foreach (string s2 in splitted)
                                {
                                    ticket.Add(int.Parse(s2));
                                }
                                nearbyTickets.Add(ticket);
                            }
                            break;
                    }
                }
            }

            List<int> validNumbers = [];
            foreach (TicketField t in ticketFields)
            {
                for (int i = t.Min1; i <= t.Max1; i++)
                {
                    if (!validNumbers.Contains(i))
                    {
                        validNumbers.Add(i);
                    }
                }
                for (int i = t.Min2; i <= t.Max2; i++)
                {
                    if (!validNumbers.Contains(i))
                    {
                        validNumbers.Add(i);
                    }
                }
            }

            validNumbers.Sort();

            int errorRate = 0;
            foreach (List<int> l in nearbyTickets)
            {
                bool isValid = true;
                foreach (int i in l)
                {
                    if (!validNumbers.Contains(i))
                    {
                        errorRate += i;
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    nearbyValidTickets.Add(l);
                }
            }
            Part1Solution = errorRate.ToString();

            for (int i = 0; i < ticketFields.Count; i++)
            {
                for (int a = 0; a < nearbyValidTickets.Count; a++)
                {
                    for (int b = 0; b < nearbyValidTickets[a].Count; b++)
                    {
                        if (nearbyValidTickets[a][b] >= ticketFields[i].Min1 && nearbyValidTickets[a][b] <= ticketFields[i].Max1 ||
                            nearbyValidTickets[a][b] >= ticketFields[i].Min2 && nearbyValidTickets[a][b] <= ticketFields[i].Max2)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }

            Part2Solution = "TBD";
        }
    }
}
