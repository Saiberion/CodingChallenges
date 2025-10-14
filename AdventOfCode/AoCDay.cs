using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    abstract public class AoCDay
    {
        public string Part1Solution { get; set; }
        public string Part2Solution { get; set; }
        public string Part3Solution { get; set; }
        internal List<string> Input { get; set; }
        public Stopwatch StopWatch { get; set; }
        public bool Enabled { get; set; }

        public AoCDay()
        {
            StopWatch = new Stopwatch();
            Input = [];
            string? ns = GetType().Namespace;
            string nsname;
            if (!string.IsNullOrEmpty(ns))
            {
                string[] nssplit = ns.Split(['.'], StringSplitOptions.RemoveEmptyEntries);
                nsname = nssplit[^1];
                Load(string.Format("{0}/inputs/{1}.txt", nsname, this.GetType().Name));
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
