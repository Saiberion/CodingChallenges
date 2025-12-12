using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingChallenges
{
    public partial class FormSolverUI : Form
    {
        private readonly Dictionary<string, List<Challenge>> allChallenges = new()
        {
            {
                "AdventOfCode Year2015",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2015.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge15() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge16() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge17() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge18() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge19() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge20() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge21() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge22() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge23() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge24() { Enabled = true },
                    new AdventOfCode.Year2015.Challenge25() { Enabled = true }
                }
            },
            {
                "AdventOfCode Year2016",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2016.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge15() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge16() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge17() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge18() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge19() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge20() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge21() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge22() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge23() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge24() { Enabled = true },
                    new AdventOfCode.Year2016.Challenge25() { Enabled = true }
                }
            },
            {
                "AdventOfCode Year2017",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2017.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge15() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge16() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge17() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge18() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge19() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge20() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge21() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge22() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge23() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge24() { Enabled = true },
                    new AdventOfCode.Year2017.Challenge25() { Enabled = true }
                }
            },
            {
                "AdventOfCode Year2018",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2018.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2018.Challenge15() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge16() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge17() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge18() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge19() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge20() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge21() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge22() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2018.Challenge25() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2019",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2019.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge14() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge15() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge16() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge17() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge18() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge19() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge20() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge21() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge22() { Enabled = true },
                    new AdventOfCode.Year2019.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2019.Challenge25() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2020",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2020.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge15() { Enabled = false },
                    new AdventOfCode.Year2020.Challenge16() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge17() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge18() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge19() { Enabled = false },
                    new AdventOfCode.Year2020.Challenge20() { Enabled = false },
                    new AdventOfCode.Year2020.Challenge21() { Enabled = false },
                    new AdventOfCode.Year2020.Challenge22() { Enabled = true },
                    new AdventOfCode.Year2020.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2020.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2020.Challenge25() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2021",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2021.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge12() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge13() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge15() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge16() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge17() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge18() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge19() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge20() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge21() { Enabled = true },
                    new AdventOfCode.Year2021.Challenge22() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2021.Challenge25() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2022",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2022.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge12() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge15() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge16() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge17() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge18() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge19() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge20() { Enabled = true },
                    new AdventOfCode.Year2022.Challenge21() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge22() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2022.Challenge25() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2023",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2023.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge10() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge12() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge13() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge14() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge15() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge16() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge17() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge18() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge19() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge20() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge21() { Enabled = true },
                    new AdventOfCode.Year2023.Challenge22() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2023.Challenge25() { Enabled = false }
                }
            },
            {
                "EverybodyCodes Year2024",
                new List<Challenge>()
                {
                    new EverybodyCodes.Year2024.Challenge01() { Enabled = true },
                    new EverybodyCodes.Year2024.Challenge02() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge03() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge04() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge05() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge06() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge07() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge08() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge09() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge10() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge11() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge12() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge13() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge14() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge15() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge16() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge17() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge18() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge19() { Enabled = false },
                    new EverybodyCodes.Year2024.Challenge20() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2024",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2024.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge07() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge08() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge10() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge12() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge13() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge14() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge15() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge16() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge17() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge18() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge19() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge20() { Enabled = true },
                    new AdventOfCode.Year2024.Challenge21() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge22() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge23() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge24() { Enabled = false },
                    new AdventOfCode.Year2024.Challenge25() { Enabled = false }
                }
            },
            {
                "AdventOfCode Year2025",
                new List<Challenge>()
                {
                    new AdventOfCode.Year2025.Challenge01() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge02() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge03() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge04() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge05() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge06() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge07() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge08() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge09() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge10() { Enabled = false },
                    new AdventOfCode.Year2025.Challenge11() { Enabled = true },
                    new AdventOfCode.Year2025.Challenge12() { Enabled = true }
                }
            },
        };

        public FormSolverUI()
        {
            InitializeComponent();

            SetDoubleBuffered(tableLayoutPanelDayGrid);
        }

        private void ButtonSolveAllChallenges(object? sender, EventArgs e)
        {
            for (int i = 1; i < tableLayoutPanelDayGrid.RowCount; i++)
            {
                if ((tableLayoutPanelDayGrid.GetControlFromPosition(0, i) is Button b) && (b.Enabled))
                {
                    ButtonSolveSingleChallenge(b, new EventArgs());
                }
            }
        }

        private void ButtonSolveSingleChallenge(object? sender, EventArgs e)
        {
            BackgroundWorker bw = new();
            bw.DoWork += BackgroundWorkerChallengeSolver;
            bw.RunWorkerCompleted += BackgroundWorkerChallengeSolverCompleted;
            bw.ProgressChanged += BackgroundWorkerChallengeSolverProgressChanged;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerAsync(sender);

            if ((sender is Button b) && (b.Parent is TableLayoutPanel tbl))
            {
                TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
                if (tbl.GetControlFromPosition(4, pos.Row) is Label l4)
                {
                    l4.Text = "initialised";
                }
            }

            bw.Dispose();
        }

        private void BackgroundWorkerChallengeSolverProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            if ((e.UserState is Button b) && (b.Parent is TableLayoutPanel tbl))
            {
                TableLayoutPanelCellPosition pos = tbl.GetCellPosition(b);
                if (tbl.GetControlFromPosition(4, pos.Row) is Label l4)
                {
                    l4.Text = "Running";
                }
            }
        }

        private void BackgroundWorkerChallengeSolverCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Result is Button b) && (b.Tag is Challenge d) && (b.Parent is TableLayoutPanel tbl))
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
                if (tbl.GetControlFromPosition(3, pos.Row) is TextBox t3)
                {
                    t3.Text = d.Part3Solution;
                }
                if (tbl.GetControlFromPosition(4, pos.Row) is Label l4)
                {
                    l4.Text = d.StopWatch.Elapsed.ToString();
                }
            }
        }

        private void BackgroundWorkerChallengeSolver(object? sender, DoWorkEventArgs e)
        {
            if ((e.Argument is Button b) && (sender is BackgroundWorker bw))
            {
                bw.ReportProgress(0, b);
                if (b.Tag is Challenge d)
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
            foreach (string dir in Directory.GetDirectories(Directory.GetCurrentDirectory()))
            {
                if (Path.GetFileName(dir).StartsWith("AdventOfCode") || Path.GetFileName(dir).StartsWith("EverybodyCodes"))
                {
                    comboBoxEventSelect.Items.Add(Path.GetFileName(dir));
                }
            }
        }

        private void ComboBoxYearSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Challenge> days;
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
                Name = string.Format("labelCaptionSolutionPart3"),
                Text = "Solution Part 3",
                AutoSize = true
            }, 3, 0);

            tableLayoutPanelDayGrid.Controls.Add(new Label()
            {
                Anchor = AnchorStyles.None,
                Name = string.Format("labelCaptionRuntime"),
                Text = "Durchlaufzeit",
                AutoSize = true
            }, 4, 0);
            tableLayoutPanelDayGrid.RowCount = 1;

            if ((comboBoxEventSelect.SelectedItem != null) && (comboBoxYearSelect.SelectedItem != null))
            {
                string? key = $"{comboBoxEventSelect.SelectedItem} {comboBoxYearSelect.SelectedItem}";
                if (key != null)
                {
                    days = allChallenges[key];

                    for (int i = 0; i < days.Count; i++)
                    {
                        tableLayoutPanelDayGrid.RowCount++;
                        tableLayoutPanelDayGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

                        Button b = new()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("buttonSolveChallenge{0}", i + 1),
                            Text = string.Format("Solve Challenge {0}", i + 1),
                            Size = new Size(120, 25),
                            Tag = days[i],
                            Enabled = days[i].Enabled
                        };
                        b.Click += ButtonSolveSingleChallenge;
                        tableLayoutPanelDayGrid.Controls.Add(b, 0, i + 1);

                        tableLayoutPanelDayGrid.Controls.Add(new TextBox()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("textBoxC{0}P1", i + 1),
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
                            Name = string.Format("textBoxC{0}P2", i + 1),
                            Text = "",
                            AutoSize = true,
                            ReadOnly = true,
                            TextAlign = HorizontalAlignment.Center,
                            BorderStyle = BorderStyle.None,
                            Padding = new Padding(0, 8, 0, 0),
                            Width = 200
                        }, 2, i + 1);

                        tableLayoutPanelDayGrid.Controls.Add(new TextBox()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("textBoxC{0}P3", i + 1),
                            Text = "",
                            AutoSize = true,
                            ReadOnly = true,
                            TextAlign = HorizontalAlignment.Center,
                            BorderStyle = BorderStyle.None,
                            Padding = new Padding(0, 8, 0, 0),
                            Width = 200
                        }, 3, i + 1);

                        tableLayoutPanelDayGrid.Controls.Add(new Label()
                        {
                            Anchor = AnchorStyles.None,
                            Name = string.Format("labelC{0}Perf", i + 1),
                            Text = "",
                            AutoSize = true
                        }, 4, i + 1);
                    }
                }
            }

            Button b2 = new()
            {
                Anchor = AnchorStyles.None,
                Name = "buttonSolveAll",
                Text = "Solve all challenges",
                Size = new Size(120, 25)
            };
            b2.Click += ButtonSolveAllChallenges;
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

        private void ComboBoxEventSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxYearSelect.Items.Clear();

            foreach (string dir in Directory.GetDirectories($"{Directory.GetCurrentDirectory()}/{comboBoxEventSelect.Text}").Reverse())
            {
                if (Path.GetFileName(dir).StartsWith("Year"))
                {
                    comboBoxYearSelect.Items.Add(Path.GetFileName(dir));
                }
            }
        }
    }
}
