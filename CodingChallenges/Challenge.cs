using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CodingChallenges
{
    abstract public class Challenge
    {
        private bool useTestData = false;

        public string Part1Solution { get; set; }
        public string Part2Solution { get; set; }
        public string Part3Solution { get; set; }
        internal List<string> Input { get; set; }
        internal List<string> PuzzleInput { get; set; }
        internal List<List<string>> TestInput { get; set; }
        public Stopwatch StopWatch { get; set; }
        public bool Enabled { get; set ; }
        public bool UseTestData { get { return useTestData; } set { useTestData = value; Input = value ? TestInput[0] : PuzzleInput; } }
        public List<int> Repetitions { get; set; }

        public Challenge()
        {
            StopWatch = new Stopwatch();
            TestInput = [];
            PuzzleInput = [];
            Repetitions = [];
            string? ns = GetType().Namespace;
            string eventname;
            string eventyear;
            if (!string.IsNullOrEmpty(ns))
            {
                string[] nssplit = ns.Split(['.'], StringSplitOptions.RemoveEmptyEntries);
                eventname = nssplit[^2];
                eventyear = nssplit[^1];
                Load(string.Format("{0}/{1}/inputs/{2}.txt", eventname, eventyear, this.GetType().Name));
                LoadXML(string.Format("{0}/{1}/inputs/{2}.xml", eventname, eventyear, this.GetType().Name));
            }
            Part1Solution = "TBD";
            Part2Solution = "TBD";
            Part3Solution = "TBD";
            Input = PuzzleInput;
        }

        virtual public void Solve()
        {
            
        }

        internal void Load(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader file = new(filename);
                string? line;

                PuzzleInput.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    PuzzleInput.Add(line);
                }

                file.Close();
            }
        }

        internal void LoadXML(string filename)
        {
            if (File.Exists(filename))
            {
                TestInput.Clear();
                PuzzleInput.Clear();

                XmlDocument xmlDocument = new();
                xmlDocument.Load(filename);

                if (xmlDocument.DocumentElement != null)
                {
                    foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                    {
                        List<string> data = [];
                        if ((node.Attributes != null) && (node.Attributes.Count > 0))
                        {
                            foreach (XmlAttribute attr in node.Attributes)
                            {
                                if (attr.Name.Equals("repetitions"))
                                {
                                    Repetitions.Add(int.Parse(attr.InnerText));
                                }
                            }
                        }
                        if (node.Name.Equals("TestData"))
                        {
                            TestInput.Add(data);
                        }
                        else
                        {
                            PuzzleInput = data;
                        }
                        
                        string[] lines = node.InnerText.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);
                        foreach (string l in lines)
                        {
                            data.Add(l);
                        }
                    }
                }
            }
        }
    }
}
