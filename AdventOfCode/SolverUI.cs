using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private Dictionary<string, List<Day>> allAoCDays = new Dictionary<string, List<Day>>()
        {
            {
                "AoC2019",
                new List<Day>()
                {
                    new AoC2019.Day01() { Enabled = true },
                    new AoC2019.Day02() { Enabled = true },
                    new AoC2019.Day03() { Enabled = true },
                    new AoC2019.Day04() { Enabled = true },
                    new AoC2019.Day05() { Enabled = true },
                    new AoC2019.Day06() { Enabled = true },
                    new AoC2019.Day07() { Enabled = true },
                    new AoC2019.Day08() { Enabled = true },
                    new AoC2019.Day09() { Enabled = true },
                    new AoC2019.Day10() { Enabled = true },
                    new AoC2019.Day11() { Enabled = true },
                    new AoC2019.Day12() { Enabled = true },
                    new AoC2019.Day13() { Enabled = true },
                    new AoC2019.Day14() { Enabled = false },
                    new AoC2019.Day15() { Enabled = false },
                    new AoC2019.Day16() { Enabled = false },
                    new AoC2019.Day17() { Enabled = true },
                    new AoC2019.Day18() { Enabled = false },
                    new AoC2019.Day19() { Enabled = false },
                    new AoC2019.Day20() { Enabled = false },
                    new AoC2019.Day21() { Enabled = false },
                    new AoC2019.Day22() { Enabled = false },
                    new AoC2019.Day23() { Enabled = false },
                    new AoC2019.Day24() { Enabled = false },
                    new AoC2019.Day25() { Enabled = false }
                }
            },
            {
                "AoC2020",
                new List<Day>()
                {
                    new AoC2020.Day01() { Enabled = true },
                    new AoC2020.Day02() { Enabled = true },
                    new AoC2020.Day03() { Enabled = true },
                    new AoC2020.Day04() { Enabled = true },
                    new AoC2020.Day05() { Enabled = true },
                    new AoC2020.Day06() { Enabled = true },
                    new AoC2020.Day07() { Enabled = true },
                    new AoC2020.Day08() { Enabled = true },
                    new AoC2020.Day09() { Enabled = true },
                    new AoC2020.Day10() { Enabled = true },
                    new AoC2020.Day11() { Enabled = true },
                    new AoC2020.Day12() { Enabled = true },
                    new AoC2020.Day13() { Enabled = true },
                    new AoC2020.Day14() { Enabled = true },
                    new AoC2020.Day15() { Enabled = false },
                    new AoC2020.Day16() { Enabled = true },
                    new AoC2020.Day17() { Enabled = true },
                    new AoC2020.Day18() { Enabled = true },
                    new AoC2020.Day19() { Enabled = false },
                    new AoC2020.Day20() { Enabled = false },
                    new AoC2020.Day21() { Enabled = false },
                    new AoC2020.Day22() { Enabled = true },
                    new AoC2020.Day23() { Enabled = false },
                    new AoC2020.Day24() { Enabled = false },
                    new AoC2020.Day25() { Enabled = false }
                }
            },
            {
                "AoC2021",
                new List<Day>()
                {
                    new AoC2021.Day01() { Enabled = true },
                    new AoC2021.Day02() { Enabled = true },
                    new AoC2021.Day03() { Enabled = true },
                    new AoC2021.Day04() { Enabled = true },
                    new AoC2021.Day05() { Enabled = false },
                    new AoC2021.Day06() { Enabled = false },
                    new AoC2021.Day07() { Enabled = false },
                    new AoC2021.Day08() { Enabled = false },
                    new AoC2021.Day09() { Enabled = false },
                    new AoC2021.Day10() { Enabled = false },
                    new AoC2021.Day11() { Enabled = false },
                    new AoC2021.Day12() { Enabled = false },
                    new AoC2021.Day13() { Enabled = false },
                    new AoC2021.Day14() { Enabled = false },
                    new AoC2021.Day15() { Enabled = false },
                    new AoC2021.Day16() { Enabled = false },
                    new AoC2021.Day17() { Enabled = false },
                    new AoC2021.Day18() { Enabled = false },
                    new AoC2021.Day19() { Enabled = false },
                    new AoC2021.Day20() { Enabled = false },
                    new AoC2021.Day21() { Enabled = false },
                    new AoC2021.Day22() { Enabled = false },
                    new AoC2021.Day23() { Enabled = false },
                    new AoC2021.Day24() { Enabled = false },
                    new AoC2021.Day25() { Enabled = false }
                }
            }
        };

        public FormSolverUI()
        {
            InitializeComponent();

            SetDoubleBuffered(tableLayoutPanelMainContainer);
            SetDoubleBuffered(tableLayoutPanelDayGrid);
        }

        private void ButtonSolveAllDays(object sender, EventArgs e)
        {
            for (int i = 1; i < tableLayoutPanelDayGrid.RowCount; i++)
            {
                Button b = tableLayoutPanelDayGrid.GetControlFromPosition(0, i) as Button;
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
            List<Day> days;
            tableLayoutPanelDayGrid.Controls.Clear();
            tableLayoutPanelDayGrid.RowStyles.Clear();

            tableLayoutPanelDayGrid.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionSolutionPart1"),
                Text = "Solution Part 1",
                AutoSize = true
            }, 1, 0);

            tableLayoutPanelDayGrid.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionSolutionPart2"),
                Text = "Solution Part 2",
                AutoSize = true
            }, 2, 0);

            tableLayoutPanelDayGrid.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionRuntime"),
                Text = "Durchlaufzeit",
                AutoSize = true
            }, 3, 0);
            tableLayoutPanelDayGrid.RowCount = 1;

            days = allAoCDays[comboBoxYearSelect.SelectedItem.ToString()];

            for (int i = 0; i < days.Count; i++)
            {
                tableLayoutPanelDayGrid.RowCount++;
                tableLayoutPanelDayGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

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
                tableLayoutPanelDayGrid.Controls.Add(b, 0, i + 1);

                tableLayoutPanelDayGrid.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}P1", i + 1),
                    Text = "",
                    AutoSize = true
                }, 1, i + 1);

                tableLayoutPanelDayGrid.Controls.Add(new Label()
                {
                    Anchor = AnchorStyles.None,
                    Name = string.Format("labelD{0}P2", i + 1),
                    Text = "",
                    AutoSize = true
                }, 2, i + 1);

                tableLayoutPanelDayGrid.Controls.Add(new Label()
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
            tableLayoutPanelDayGrid.Controls.Add(b2, 0, 0);

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
