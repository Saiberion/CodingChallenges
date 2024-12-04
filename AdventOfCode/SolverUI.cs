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
        private readonly Dictionary<string, List<AoCDay>> allAoCDays = new()
        {
            {
                "AoC2015",
                new List<AoCDay>()
                {
                    new AoC2015.Day01() { Enabled = true },
                    new AoC2015.Day02() { Enabled = true },
                    new AoC2015.Day03() { Enabled = true },
                    new AoC2015.Day04() { Enabled = true },
                    new AoC2015.Day05() { Enabled = true },
                    new AoC2015.Day06() { Enabled = true },
                    new AoC2015.Day07() { Enabled = true },
                    new AoC2015.Day08() { Enabled = true },
                    new AoC2015.Day09() { Enabled = true },
                    new AoC2015.Day10() { Enabled = true },
                    new AoC2015.Day11() { Enabled = true },
                    new AoC2015.Day12() { Enabled = true },
                    new AoC2015.Day13() { Enabled = true },
                    new AoC2015.Day14() { Enabled = true },
                    new AoC2015.Day15() { Enabled = true },
                    new AoC2015.Day16() { Enabled = true },
                    new AoC2015.Day17() { Enabled = true },
                    new AoC2015.Day18() { Enabled = true },
                    new AoC2015.Day19() { Enabled = true },
                    new AoC2015.Day20() { Enabled = true },
                    new AoC2015.Day21() { Enabled = true },
                    new AoC2015.Day22() { Enabled = true },
                    new AoC2015.Day23() { Enabled = true },
                    new AoC2015.Day24() { Enabled = true },
                    new AoC2015.Day25() { Enabled = true }
                }
            },
            {
                "AoC2016",
                new List<AoCDay>()
                {
                    new AoC2016.Day01() { Enabled = true },
                    new AoC2016.Day02() { Enabled = true },
                    new AoC2016.Day03() { Enabled = true },
                    new AoC2016.Day04() { Enabled = true },
                    new AoC2016.Day05() { Enabled = true },
                    new AoC2016.Day06() { Enabled = true },
                    new AoC2016.Day07() { Enabled = true },
                    new AoC2016.Day08() { Enabled = true },
                    new AoC2016.Day09() { Enabled = true },
                    new AoC2016.Day10() { Enabled = true },
                    new AoC2016.Day11() { Enabled = true },
                    new AoC2016.Day12() { Enabled = true },
                    new AoC2016.Day13() { Enabled = true },
                    new AoC2016.Day14() { Enabled = true },
                    new AoC2016.Day15() { Enabled = true },
                    new AoC2016.Day16() { Enabled = true },
                    new AoC2016.Day17() { Enabled = true },
                    new AoC2016.Day18() { Enabled = true },
                    new AoC2016.Day19() { Enabled = true },
                    new AoC2016.Day20() { Enabled = true },
                    new AoC2016.Day21() { Enabled = true },
                    new AoC2016.Day22() { Enabled = true },
                    new AoC2016.Day23() { Enabled = true },
                    new AoC2016.Day24() { Enabled = true },
                    new AoC2016.Day25() { Enabled = true }
                }
            },
            {
                "AoC2017",
                new List<AoCDay>()
                {
                    new AoC2017.Day01() { Enabled = true },
                    new AoC2017.Day02() { Enabled = true },
                    new AoC2017.Day03() { Enabled = true },
                    new AoC2017.Day04() { Enabled = true },
                    new AoC2017.Day05() { Enabled = true },
                    new AoC2017.Day06() { Enabled = true },
                    new AoC2017.Day07() { Enabled = true },
                    new AoC2017.Day08() { Enabled = true },
                    new AoC2017.Day09() { Enabled = true },
                    new AoC2017.Day10() { Enabled = true },
                    new AoC2017.Day11() { Enabled = true },
                    new AoC2017.Day12() { Enabled = true },
                    new AoC2017.Day13() { Enabled = true },
                    new AoC2017.Day14() { Enabled = true },
                    new AoC2017.Day15() { Enabled = true },
                    new AoC2017.Day16() { Enabled = true },
                    new AoC2017.Day17() { Enabled = true },
                    new AoC2017.Day18() { Enabled = true },
                    new AoC2017.Day19() { Enabled = true },
                    new AoC2017.Day20() { Enabled = true },
                    new AoC2017.Day21() { Enabled = true },
                    new AoC2017.Day22() { Enabled = true },
                    new AoC2017.Day23() { Enabled = true },
                    new AoC2017.Day24() { Enabled = true },
                    new AoC2017.Day25() { Enabled = true }
                }
            },
            {
                "AoC2018",
                new List<AoCDay>()
                {
                    new AoC2018.Day01() { Enabled = true },
                    new AoC2018.Day02() { Enabled = true },
                    new AoC2018.Day03() { Enabled = true },
                    new AoC2018.Day04() { Enabled = true },
                    new AoC2018.Day05() { Enabled = true },
                    new AoC2018.Day06() { Enabled = true },
                    new AoC2018.Day07() { Enabled = true },
                    new AoC2018.Day08() { Enabled = true },
                    new AoC2018.Day09() { Enabled = true },
                    new AoC2018.Day10() { Enabled = true },
                    new AoC2018.Day11() { Enabled = true },
                    new AoC2018.Day12() { Enabled = true },
                    new AoC2018.Day13() { Enabled = true },
                    new AoC2018.Day14() { Enabled = true },
                    new AoC2018.Day15() { Enabled = false },
                    new AoC2018.Day16() { Enabled = false },
                    new AoC2018.Day17() { Enabled = false },
                    new AoC2018.Day18() { Enabled = false },
                    new AoC2018.Day19() { Enabled = false },
                    new AoC2018.Day20() { Enabled = false },
                    new AoC2018.Day21() { Enabled = false },
                    new AoC2018.Day22() { Enabled = false },
                    new AoC2018.Day23() { Enabled = false },
                    new AoC2018.Day24() { Enabled = false },
                    new AoC2018.Day25() { Enabled = false }
                }
            },
            {
                "AoC2019",
                new List<AoCDay>()
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
                    new AoC2019.Day19() { Enabled = true },
                    new AoC2019.Day20() { Enabled = false },
                    new AoC2019.Day21() { Enabled = false },
                    new AoC2019.Day22() { Enabled = true },
                    new AoC2019.Day23() { Enabled = false },
                    new AoC2019.Day24() { Enabled = false },
                    new AoC2019.Day25() { Enabled = false }
                }
            },
            {
                "AoC2020",
                new List<AoCDay>()
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
                new List<AoCDay>()
                {
                    new AoC2021.Day01() { Enabled = true },
                    new AoC2021.Day02() { Enabled = true },
                    new AoC2021.Day03() { Enabled = true },
                    new AoC2021.Day04() { Enabled = true },
                    new AoC2021.Day05() { Enabled = true },
                    new AoC2021.Day06() { Enabled = true },
                    new AoC2021.Day07() { Enabled = true },
                    new AoC2021.Day08() { Enabled = true },
                    new AoC2021.Day09() { Enabled = true },
                    new AoC2021.Day10() { Enabled = true },
                    new AoC2021.Day11() { Enabled = true },
                    new AoC2021.Day12() { Enabled = false },
                    new AoC2021.Day13() { Enabled = false },
                    new AoC2021.Day14() { Enabled = true },
                    new AoC2021.Day15() { Enabled = false },
                    new AoC2021.Day16() { Enabled = true },
                    new AoC2021.Day17() { Enabled = true },
                    new AoC2021.Day18() { Enabled = false },
                    new AoC2021.Day19() { Enabled = false },
                    new AoC2021.Day20() { Enabled = false },
                    new AoC2021.Day21() { Enabled = true },
                    new AoC2021.Day22() { Enabled = false },
                    new AoC2021.Day23() { Enabled = false },
                    new AoC2021.Day24() { Enabled = false },
                    new AoC2021.Day25() { Enabled = false }
                }
            },
            {
                "AoC2022",
                new List<AoCDay>()
                {
                    new AoC2022.Day01() { Enabled = true },
                    new AoC2022.Day02() { Enabled = true },
                    new AoC2022.Day03() { Enabled = true },
                    new AoC2022.Day04() { Enabled = true },
                    new AoC2022.Day05() { Enabled = true },
                    new AoC2022.Day06() { Enabled = true },
                    new AoC2022.Day07() { Enabled = true },
                    new AoC2022.Day08() { Enabled = true },
                    new AoC2022.Day09() { Enabled = true },
                    new AoC2022.Day10() { Enabled = true },
                    new AoC2022.Day11() { Enabled = true },
                    new AoC2022.Day12() { Enabled = true },
                    new AoC2022.Day13() { Enabled = true },
                    new AoC2022.Day14() { Enabled = true },
                    new AoC2022.Day15() { Enabled = false },
                    new AoC2022.Day16() { Enabled = false },
                    new AoC2022.Day17() { Enabled = false },
                    new AoC2022.Day18() { Enabled = false },
                    new AoC2022.Day19() { Enabled = false },
                    new AoC2022.Day20() { Enabled = true },
                    new AoC2022.Day21() { Enabled = false },
                    new AoC2022.Day22() { Enabled = false },
                    new AoC2022.Day23() { Enabled = false },
                    new AoC2022.Day24() { Enabled = false },
                    new AoC2022.Day25() { Enabled = false }
                }
            },
            {
                "AoC2023",
                new List<AoCDay>()
                {
                    new AoC2023.Day01() { Enabled = true },
                    new AoC2023.Day02() { Enabled = true },
                    new AoC2023.Day03() { Enabled = true },
                    new AoC2023.Day04() { Enabled = true },
                    new AoC2023.Day05() { Enabled = true },
                    new AoC2023.Day06() { Enabled = true },
                    new AoC2023.Day07() { Enabled = true },
                    new AoC2023.Day08() { Enabled = true },
                    new AoC2023.Day09() { Enabled = true },
                    new AoC2023.Day10() { Enabled = true },
                    new AoC2023.Day11() { Enabled = true },
                    new AoC2023.Day12() { Enabled = false },
                    new AoC2023.Day13() { Enabled = false },
                    new AoC2023.Day14() { Enabled = true },
                    new AoC2023.Day15() { Enabled = true },
                    new AoC2023.Day16() { Enabled = true },
                    new AoC2023.Day17() { Enabled = false },
                    new AoC2023.Day18() { Enabled = true },
                    new AoC2023.Day19() { Enabled = false },
                    new AoC2023.Day20() { Enabled = false },
                    new AoC2023.Day21() { Enabled = true },
                    new AoC2023.Day22() { Enabled = false },
                    new AoC2023.Day23() { Enabled = false },
                    new AoC2023.Day24() { Enabled = false },
                    new AoC2023.Day25() { Enabled = false }
                }
            },
            {
                "AoC2024",
                new List<AoCDay>()
                {
                    new AoC2024.Day01() { Enabled = true },
                    new AoC2024.Day02() { Enabled = true },
                    new AoC2024.Day03() { Enabled = true },
                    new AoC2024.Day04() { Enabled = true },
                    new AoC2024.Day05() { Enabled = false },
                    new AoC2024.Day06() { Enabled = false },
                    new AoC2024.Day07() { Enabled = false },
                    new AoC2024.Day08() { Enabled = false },
                    new AoC2024.Day09() { Enabled = false },
                    new AoC2024.Day10() { Enabled = false },
                    new AoC2024.Day11() { Enabled = false },
                    new AoC2024.Day12() { Enabled = false },
                    new AoC2024.Day13() { Enabled = false },
                    new AoC2024.Day14() { Enabled = false },
                    new AoC2024.Day15() { Enabled = false },
                    new AoC2024.Day16() { Enabled = false },
                    new AoC2024.Day17() { Enabled = false },
                    new AoC2024.Day18() { Enabled = false },
                    new AoC2024.Day19() { Enabled = false },
                    new AoC2024.Day20() { Enabled = false },
                    new AoC2024.Day21() { Enabled = false },
                    new AoC2024.Day22() { Enabled = false },
                    new AoC2024.Day23() { Enabled = false },
                    new AoC2024.Day24() { Enabled = false },
                    new AoC2024.Day25() { Enabled = false }
                }
            }
        };

        public FormSolverUI()
        {
            InitializeComponent();

            SetDoubleBuffered(tableLayoutPanelDayGrid);
        }

        private void ButtonSolveAllDays(object? sender, EventArgs e)
        {
            for (int i = 1; i < tableLayoutPanelDayGrid.RowCount; i++)
            {
                if ((tableLayoutPanelDayGrid.GetControlFromPosition(0, i) is Button b) && (b.Enabled))
                {
                    ButtonSolveSingleDay(b, new EventArgs());
                }
            }
        }

        private void ButtonSolveSingleDay(object? sender, EventArgs e)
        {
            BackgroundWorker bw = new();
            bw.DoWork += BackgroundWorkerDaySolver;
            bw.RunWorkerCompleted += BackgroundWorkerDaySolverCompleted;
            bw.ProgressChanged += BackgroundWorkerDaySolverProgressChanged;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(sender);

            if ((sender is Button b) && (b.Parent is TableLayoutPanel tbl))
            {
                TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
                if (tbl.GetControlFromPosition(3, pos.Row) is Label l3)
                {
                    l3.Text = "initialised";
                }
            }

            bw.Dispose();
        }

        private void BackgroundWorkerDaySolverProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if ((e.UserState is Button b) && (b.Parent is TableLayoutPanel tbl))
            {
                TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
                if (tbl.GetControlFromPosition(3, pos.Row) is Label l3)
                {
                    l3.Text = "Running";
                }
            }
        }

        private void BackgroundWorkerDaySolverCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Result is Button b) && (b.Tag is AoCDay d) && (b.Parent is TableLayoutPanel tbl))
            {
                TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
                if (tbl.GetControlFromPosition(1, pos.Row) is TextBox t1)
                {
                    t1.Text = d.Part1Solution;
                }
                if (tbl.GetControlFromPosition(2, pos.Row) is TextBox t2)
                {
                    t2.Text = d.Part2Solution;
                }
                if (tbl.GetControlFromPosition(3, pos.Row) is Label l3)
                {
                    l3.Text = d.StopWatch.Elapsed.ToString();
                }
            }
        }

        private void BackgroundWorkerDaySolver(object? sender, DoWorkEventArgs e)
        {
            if ((e.Argument is Button b) && (sender is BackgroundWorker bw))
            {
                bw.ReportProgress(0, b);
                if (b.Tag is AoCDay d)
                {
                    d.StopWatch.Restart();
                    d.Solve();
                    d.StopWatch.Stop();
                    e.Result = b;
                }
            }
        }

        private void SolverUI_Load(object sender, EventArgs e)
        {
            foreach (string dir in Directory.GetDirectories(Directory.GetCurrentDirectory()).Reverse())
            {
                if (Path.GetFileName(dir).StartsWith("AoC"))
                {
                    comboBoxYearSelect.Items.Add(Path.GetFileName(dir));
                }
            }
        }

        private void ComboBoxYearSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<AoCDay> days;
            tableLayoutPanelDayGrid.SuspendLayout();
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

            if (comboBoxYearSelect.SelectedItem != null)
            {
                string? key = comboBoxYearSelect.SelectedItem.ToString();
                if (key != null)
                {
                    days = allAoCDays[key];

                    for (int i = 0; i < days.Count; i++)
                    {
                        tableLayoutPanelDayGrid.RowCount++;
                        tableLayoutPanelDayGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                        Button b = new()
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

                        tableLayoutPanelDayGrid.Controls.Add(new TextBox()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("textBoxD{0}P1", i + 1),
                            Text = "",
                            AutoSize = true,
                            ReadOnly = true,
                            TextAlign = HorizontalAlignment.Center,
                            BorderStyle = BorderStyle.None,
                            Padding = new Padding(0, 8, 0, 0),
                            Width = 200
                        }, 1, i + 1);

                        tableLayoutPanelDayGrid.Controls.Add(new TextBox()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("textBoxD{0}P2", i + 1),
                            Text = "",
                            AutoSize = true,
                            ReadOnly = true,
                            TextAlign = HorizontalAlignment.Center,
                            BorderStyle = BorderStyle.None,
                            Padding = new Padding(0, 8, 0, 0),
                            Width = 200
                        }, 2, i + 1);

                        tableLayoutPanelDayGrid.Controls.Add(new Label()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("labelD{0}Perf", i + 1),
                            Text = "",
                            AutoSize = true
                        }, 3, i + 1);
                    }
                }            }

            

            Button b2 = new()
            {
                Anchor = AnchorStyles.None,
                Name = "buttonSolveAll",
                Text = "Solve all days",
                Size = new Size(90, 25)
            };
            b2.Click += ButtonSolveAllDays;
            tableLayoutPanelDayGrid.Controls.Add(b2, 0, 0);
            tableLayoutPanelDayGrid.ResumeLayout(false);
            tableLayoutPanelDayGrid.PerformLayout();

            this.CenterToScreen();
        }

        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                return;
            }
            System.Reflection.PropertyInfo? aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp?.SetValue(c, true, null);
        }

        #endregion
    }
}
