using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventOfCode
{
    public partial class FormSolverUI : Form
    {
        List<Day> days;

        readonly List<Day> days2019 = new List<Day>()
        {
            new _2019.Day01() { Name = "Day 01", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day02() { Name = "Day 02", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day03() { Name = "Day 03", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day04() { Name = "Day 04", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day05() { Name = "Day 05", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day06() { Name = "Day 06", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day07() { Name = "Day 07", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day08() { Name = "Day 08", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day09() { Name = "Day 09", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day10() { Name = "Day 10", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day11() { Name = "Day 11", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day12() { Name = "Day 12", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day13() { Name = "Day 13", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day14() { Name = "Day 14", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day15() { Name = "Day 15", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day16() { Name = "Day 16", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day17() { Name = "Day 17", StopWatch = new Stopwatch(), Enabled = true },
            new _2019.Day18() { Name = "Day 18", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day19() { Name = "Day 19", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day20() { Name = "Day 20", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day21() { Name = "Day 21", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day22() { Name = "Day 22", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day23() { Name = "Day 23", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day24() { Name = "Day 24", StopWatch = new Stopwatch(), Enabled = false },
            new _2019.Day25() { Name = "Day 25", StopWatch = new Stopwatch(), Enabled = false }
        };

        readonly List<Day> days2020 = new List<Day>()
        {
            new _2020.Day01() { Name = "Day 01", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day02() { Name = "Day 02", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day03() { Name = "Day 03", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day04() { Name = "Day 04", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day05() { Name = "Day 05", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day06() { Name = "Day 06", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day07() { Name = "Day 07", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day08() { Name = "Day 08", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day09() { Name = "Day 09", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day10() { Name = "Day 10", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day11() { Name = "Day 11", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day12() { Name = "Day 12", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day13() { Name = "Day 13", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day14() { Name = "Day 14", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day15() { Name = "Day 15", StopWatch = new Stopwatch(), Enabled = false },
            new _2020.Day16() { Name = "Day 16", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day17() { Name = "Day 17", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day18() { Name = "Day 18", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day19() { Name = "Day 19", StopWatch = new Stopwatch(), Enabled = false },
            new _2020.Day20() { Name = "Day 20", StopWatch = new Stopwatch(), Enabled = false },
            new _2020.Day21() { Name = "Day 21", StopWatch = new Stopwatch(), Enabled = false },
            new _2020.Day22() { Name = "Day 22", StopWatch = new Stopwatch(), Enabled = true },
            new _2020.Day23() { Name = "Day 23", StopWatch = new Stopwatch(), Enabled = false },
            new _2020.Day24() { Name = "Day 24", StopWatch = new Stopwatch(), Enabled = false },
            new _2020.Day25() { Name = "Day 25", StopWatch = new Stopwatch(), Enabled = false }
        };

        readonly List<Day> days2021 = new List<Day>()
        {
            new AoC2021.Day01() { Name = "Day 01", Enabled = false },
            new AoC2021.Day02() { Name = "Day 02", Enabled = false },
            new AoC2021.Day03() { Name = "Day 03", Enabled = false },
            new AoC2021.Day04() { Name = "Day 04", Enabled = false },
            new AoC2021.Day05() { Name = "Day 05", Enabled = false },
            new AoC2021.Day06() { Name = "Day 06", Enabled = false },
            new AoC2021.Day07() { Name = "Day 07", Enabled = false },
            new AoC2021.Day08() { Name = "Day 08", Enabled = false },
            new AoC2021.Day09() { Name = "Day 09", Enabled = false },
            new AoC2021.Day10() { Name = "Day 10", Enabled = false },
            new AoC2021.Day11() { Name = "Day 11", Enabled = false },
            new AoC2021.Day12() { Name = "Day 12", Enabled = false },
            new AoC2021.Day13() { Name = "Day 13", Enabled = false },
            new AoC2021.Day14() { Name = "Day 14", Enabled = false },
            new AoC2021.Day15() { Name = "Day 15", Enabled = false },
            new AoC2021.Day16() { Name = "Day 16", Enabled = false },
            new AoC2021.Day17() { Name = "Day 17", Enabled = false },
            new AoC2021.Day18() { Name = "Day 18", Enabled = false },
            new AoC2021.Day19() { Name = "Day 19", Enabled = false },
            new AoC2021.Day20() { Name = "Day 20", Enabled = false },
            new AoC2021.Day21() { Name = "Day 21", Enabled = false },
            new AoC2021.Day22() { Name = "Day 22", Enabled = false },
            new AoC2021.Day23() { Name = "Day 23", Enabled = false },
            new AoC2021.Day24() { Name = "Day 24", Enabled = false },
            new AoC2021.Day25() { Name = "Day 25", Enabled = false }
        };

        public FormSolverUI()
        {
            InitializeComponent();

            SetDoubleBuffered(tableLayoutPanel1);
            SetDoubleBuffered(tableLayoutPanel2);
        }

        private void ButtonSolveAllDays(object sender, EventArgs e)
        {
            for (int i = 1; i < tableLayoutPanel2.RowCount; i++)
            {
                Button b = tableLayoutPanel2.GetControlFromPosition(0, i) as Button;
                if (b.Enabled)
                {
                    ButtonSolveSingleDay(b, new EventArgs());
                }
            }
        }

        private void ButtonSolveSingleDay(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += BackgroundWorkerDaySolver;
            bw.RunWorkerCompleted += BackgroundWorkerDaySolverCompleted;
            bw.ProgressChanged += BackgroundWorkerDaySolverProgressChanged;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(sender);

            Button b = sender as Button;
            TableLayoutPanel tbl = b.Parent as TableLayoutPanel;
            TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
            Label l3 = tbl.GetControlFromPosition(3, pos.Row) as Label;
            l3.Text = "initialised";
            bw.Dispose();
        }

        private void BackgroundWorkerDaySolverProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Button b = e.UserState as Button;
            TableLayoutPanel tbl = b.Parent as TableLayoutPanel;
            TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
            Label l3 = tbl.GetControlFromPosition(3, pos.Row) as Label;
            l3.Text = "Running";
        }

        private void BackgroundWorkerDaySolverCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Button b = e.Result as Button;
            Day d = b.Tag as Day;
            TableLayoutPanel tbl = b.Parent as TableLayoutPanel;
            TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
            Label l1 = tbl.GetControlFromPosition(1, pos.Row) as Label;
            Label l2 = tbl.GetControlFromPosition(2, pos.Row) as Label;
            Label l3 = tbl.GetControlFromPosition(3, pos.Row) as Label;
            l1.Text = d.Part1Solution;
            l2.Text = d.Part2Solution;
            l3.Text = d.StopWatch.Elapsed.ToString();
        }

        private void BackgroundWorkerDaySolver(object sender, DoWorkEventArgs e)
        {
            Button b = e.Argument as Button;
            BackgroundWorker bw = sender as BackgroundWorker;
            bw.ReportProgress(0, b);
            Day d = b.Tag as Day;
            d.StopWatch.Restart();
            d.Solve();
            d.StopWatch.Stop();
            e.Result = b;
        }

        private void SolverUI_Load(object sender, EventArgs e)
        {
            foreach(string dir in Directory.GetDirectories(Directory.GetCurrentDirectory()).Reverse())
            {
                comboBoxYearSelect.Items.Add(Path.GetFileName(dir));
            }
        }

        private void ComboBoxYearSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.RowStyles.Clear();

            tableLayoutPanel2.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionSolutionPart1"),
                Text = "Solution Part 1",
                AutoSize = true
            }, 1, 0);

            tableLayoutPanel2.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionSolutionPart2"),
                Text = "Solution Part 2",
                AutoSize = true
            }, 2, 0);

            tableLayoutPanel2.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionRuntime"),
                Text = "Durchlaufzeit",
                AutoSize = true
            }, 3, 0);
            tableLayoutPanel2.RowCount = 1;

            if (comboBoxYearSelect.SelectedItem.ToString().Equals("2020"))
            {
                days = days2020;
            }
            else if (comboBoxYearSelect.SelectedItem.ToString().Equals("2019"))
            {
                days = days2019;
            }
            else if (comboBoxYearSelect.SelectedItem.ToString().Equals("AoC2021"))
            {
                days = days2021;
            }

            for (int i = 0; i < days.Count; i++)
            {
                tableLayoutPanel2.RowCount++;
                tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                Button b = new Button
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("buttonSolveDay{0}", i + 1),
                    Text = string.Format("Solve day {0}", i + 1),
                    Size = new Size(90, 25),
                    Tag = days[i],
                    Enabled = days[i].Enabled
                };
                b.Click += ButtonSolveSingleDay;
                tableLayoutPanel2.Controls.Add(b, 0, i + 1);

                tableLayoutPanel2.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}P1", i + 1),
                    Text = "",
                    AutoSize = true
                }, 1, i + 1);

                tableLayoutPanel2.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}P2", i + 1),
                    Text = "",
                    AutoSize = true
                }, 2, i + 1);

                tableLayoutPanel2.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}Perf", i + 1),
                    Text = "",
                    AutoSize = true
                }, 3, i + 1);
            }

            Button b2 = new Button
            {
                Anchor = AnchorStyles.None,
                Name = "buttonSolveAll",
                Text = "Solve all days",
                Size = new Size(90, 25)
            };
            b2.Click += ButtonSolveAllDays;
            tableLayoutPanel2.Controls.Add(b2, 0, 0);

            this.CenterToScreen();
        }

        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion
    }
}
