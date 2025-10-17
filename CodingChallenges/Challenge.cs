using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    abstract public class Challenge
    {
        public string Part1Solution { get; set; }
        public string Part2Solution { get; set; }
        public string Part3Solution { get; set; }
        internal List<string> Input { get; set; }
        public Stopwatch StopWatch { get; set; }
        public bool Enabled { get; set; }

        public Challenge()
        {
            StopWatch = new Stopwatch();
            Input = [];
            string? ns = GetType().Namespace;
            string eventname;
            string eventyear;
            if (!string.IsNullOrEmpty(ns))
            {
                string[] nssplit = ns.Split(['.'], StringSplitOptions.RemoveEmptyEntries);
                eventname = nssplit[^2];
                eventyear = nssplit[^1];
                Load(string.Format("{0}/{1}/inputs/{2}.txt", eventname, eventyear, this.GetType().Name));
            }
            Part1Solution = "TBD";
            Part2Solution = "TBD";
            Part3Solution = "TBD";
        }

        virtual public void Solve()
        {
            int result = 0;
            Part1Solution = result.ToString();

            Part2Solution = result.ToString();
        }

        internal void Load(string filename)
        {
            StreamReader file = new(filename);
            string? line;
            
            Input.Clear();
            while ((line = file.ReadLine()) != null)
            {
                Input.Add(line);
            }

            file.Close();
        }
    }
}
