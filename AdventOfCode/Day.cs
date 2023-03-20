using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        internal List<string> Input { get; set; }
        public Stopwatch StopWatch { get; set; }
        public bool Enabled { get; set; }

        public Day()
        {
            StopWatch = new Stopwatch();
            Load(string.Format("{0}/inputs/{1}.txt", this.GetType().Namespace, this.GetType().Name));
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
