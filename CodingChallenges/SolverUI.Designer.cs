﻿
namespace CodingChallenges
{
    partial class FormSolverUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanelMainContainer = new TableLayoutPanel();
            comboBoxYearSelect = new ComboBox();
            comboBoxEventSelect = new ComboBox();
            labelCaptionSolutionPart3 = new Label();
            labelCaptionRuntime = new Label();
            labelCaptionSolutionPart2 = new Label();
            labelCaptionSolutionPart1 = new Label();
            tableLayoutPanelDayGrid = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanelMainContainer.SuspendLayout();
            tableLayoutPanelDayGrid.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMainContainer
            // 
            tableLayoutPanelMainContainer.AutoSize = true;
            tableLayoutPanelMainContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelMainContainer.ColumnCount = 1;
            tableLayoutPanelMainContainer.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelMainContainer.Controls.Add(tableLayoutPanelDayGrid, 0, 1);
            tableLayoutPanelMainContainer.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanelMainContainer.Dock = DockStyle.Fill;
            tableLayoutPanelMainContainer.Location = new Point(0, 0);
            tableLayoutPanelMainContainer.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanelMainContainer.Name = "tableLayoutPanelMainContainer";
            tableLayoutPanelMainContainer.RowCount = 2;
            tableLayoutPanelMainContainer.RowStyles.Add(new RowStyle());
            tableLayoutPanelMainContainer.RowStyles.Add(new RowStyle());
            tableLayoutPanelMainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelMainContainer.Size = new Size(1082, 519);
            tableLayoutPanelMainContainer.TabIndex = 0;
            // 
            // comboBoxYearSelect
            // 
            comboBoxYearSelect.Anchor = AnchorStyles.Left;
            comboBoxYearSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxYearSelect.FormattingEnabled = true;
            comboBoxYearSelect.Location = new Point(152, 3);
            comboBoxYearSelect.Margin = new Padding(4, 3, 4, 3);
            comboBoxYearSelect.Name = "comboBoxYearSelect";
            comboBoxYearSelect.Size = new Size(140, 23);
            comboBoxYearSelect.TabIndex = 2;
            comboBoxYearSelect.SelectedIndexChanged += ComboBoxYearSelect_SelectedIndexChanged;
            // 
            // comboBoxEventSelect
            // 
            comboBoxEventSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEventSelect.FormattingEnabled = true;
            comboBoxEventSelect.Location = new Point(4, 3);
            comboBoxEventSelect.Margin = new Padding(4, 3, 4, 3);
            comboBoxEventSelect.Name = "comboBoxEventSelect";
            comboBoxEventSelect.Size = new Size(140, 23);
            comboBoxEventSelect.TabIndex = 0;
            comboBoxEventSelect.SelectedIndexChanged += ComboBoxEventSelect_SelectedIndexChanged;
            // 
            // labelCaptionSolutionPart3
            // 
            labelCaptionSolutionPart3.Anchor = AnchorStyles.None;
            labelCaptionSolutionPart3.AutoSize = true;
            labelCaptionSolutionPart3.Location = new Point(679, 231);
            labelCaptionSolutionPart3.Margin = new Padding(4, 0, 4, 0);
            labelCaptionSolutionPart3.Name = "labelCaptionSolutionPart3";
            labelCaptionSolutionPart3.Size = new Size(84, 15);
            labelCaptionSolutionPart3.TabIndex = 4;
            labelCaptionSolutionPart3.Text = "Solution Part 3";
            // 
            // labelCaptionRuntime
            // 
            labelCaptionRuntime.Anchor = AnchorStyles.None;
            labelCaptionRuntime.AutoSize = true;
            labelCaptionRuntime.Location = new Point(917, 231);
            labelCaptionRuntime.Margin = new Padding(4, 0, 4, 0);
            labelCaptionRuntime.Name = "labelCaptionRuntime";
            labelCaptionRuntime.Size = new Size(77, 15);
            labelCaptionRuntime.TabIndex = 3;
            labelCaptionRuntime.Text = "Durchlaufzeit";
            // 
            // labelCaptionSolutionPart2
            // 
            labelCaptionSolutionPart2.Anchor = AnchorStyles.None;
            labelCaptionSolutionPart2.AutoSize = true;
            labelCaptionSolutionPart2.Location = new Point(445, 231);
            labelCaptionSolutionPart2.Margin = new Padding(4, 0, 4, 0);
            labelCaptionSolutionPart2.Name = "labelCaptionSolutionPart2";
            labelCaptionSolutionPart2.Size = new Size(84, 15);
            labelCaptionSolutionPart2.TabIndex = 2;
            labelCaptionSolutionPart2.Text = "Solution Part 2";
            // 
            // labelCaptionSolutionPart1
            // 
            labelCaptionSolutionPart1.Anchor = AnchorStyles.None;
            labelCaptionSolutionPart1.AutoSize = true;
            labelCaptionSolutionPart1.Location = new Point(211, 231);
            labelCaptionSolutionPart1.Margin = new Padding(4, 0, 4, 0);
            labelCaptionSolutionPart1.Name = "labelCaptionSolutionPart1";
            labelCaptionSolutionPart1.Size = new Size(84, 15);
            labelCaptionSolutionPart1.TabIndex = 1;
            labelCaptionSolutionPart1.Text = "Solution Part 1";
            // 
            // tableLayoutPanelDayGrid
            // 
            tableLayoutPanelDayGrid.AutoSize = true;
            tableLayoutPanelDayGrid.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanelDayGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanelDayGrid.ColumnCount = 5;
            tableLayoutPanelDayGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tableLayoutPanelDayGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            tableLayoutPanelDayGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            tableLayoutPanelDayGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 233F));
            tableLayoutPanelDayGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 183F));
            tableLayoutPanelDayGrid.Controls.Add(labelCaptionSolutionPart1, 1, 0);
            tableLayoutPanelDayGrid.Controls.Add(labelCaptionSolutionPart2, 2, 0);
            tableLayoutPanelDayGrid.Controls.Add(labelCaptionRuntime, 4, 0);
            tableLayoutPanelDayGrid.Controls.Add(labelCaptionSolutionPart3, 3, 0);
            tableLayoutPanelDayGrid.Dock = DockStyle.Fill;
            tableLayoutPanelDayGrid.Location = new Point(4, 38);
            tableLayoutPanelDayGrid.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanelDayGrid.Name = "tableLayoutPanelDayGrid";
            tableLayoutPanelDayGrid.RowCount = 1;
            tableLayoutPanelDayGrid.RowStyles.Add(new RowStyle());
            tableLayoutPanelDayGrid.Size = new Size(1074, 478);
            tableLayoutPanelDayGrid.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(comboBoxEventSelect);
            flowLayoutPanel1.Controls.Add(comboBoxYearSelect);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1076, 29);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // FormSolverUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1082, 519);
            Controls.Add(tableLayoutPanelMainContainer);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormSolverUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Advent of Code Collection";
            Load += SolverUI_Load;
            tableLayoutPanelMainContainer.ResumeLayout(false);
            tableLayoutPanelMainContainer.PerformLayout();
            tableLayoutPanelDayGrid.ResumeLayout(false);
            tableLayoutPanelDayGrid.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainContainer;
        private System.Windows.Forms.ComboBox comboBoxEventSelect;
        private ComboBox comboBoxYearSelect;
        private TableLayoutPanel tableLayoutPanelDayGrid;
        private Label labelCaptionSolutionPart1;
        private Label labelCaptionSolutionPart2;
        private Label labelCaptionRuntime;
        private Label labelCaptionSolutionPart3;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}

