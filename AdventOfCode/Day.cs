using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    abstract public class Day
    {
        public string Part1Solution { get; set; }
        public string Part2Solution { get; set; }
        public string Name { get; set; }
        internal List<string> Input { get; set; }
        public System.Diagnostics.Stopwatch StopWatch { get; set; }
        public bool Enabled { get; set; }

        virtual public void Solve()
        {
            int result = 0;
            Part1Solution = result.ToString();

            Part2Solution = result.ToString();
        }

        internal void Load(string filename)
        {
            StreamReader file = new StreamReader(filename);
            Input = new List<string>();
            string line;

            while ((line = file.ReadLine()) != null)
            {
                Input.Add(line);
            }

            file.Close();
        }
    }
}
