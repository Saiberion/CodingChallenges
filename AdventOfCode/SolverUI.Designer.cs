
namespace AdventOfCode
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
            this.tableLayoutPanelMainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxYearSelect = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelDayGrid = new System.Windows.Forms.TableLayoutPanel();
            this.labelCaptionSolutionPart1 = new System.Windows.Forms.Label();
            this.labelCaptionSolutionPart2 = new System.Windows.Forms.Label();
            this.labelCaptionRuntime = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainContainer.SuspendLayout();
            this.tableLayoutPanelDayGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMainContainer
            // 
            this.tableLayoutPanelMainContainer.AutoSize = true;
            this.tableLayoutPanelMainContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMainContainer.ColumnCount = 1;
            this.tableLayoutPanelMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMainContainer.Controls.Add(this.comboBoxYearSelect, 0, 0);
            this.tableLayoutPanelMainContainer.Controls.Add(this.tableLayoutPanelDayGrid, 0, 1);
            this.tableLayoutPanelMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainContainer.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMainContainer.Name = "tableLayoutPanelMainContainer";
            this.tableLayoutPanelMainContainer.RowCount = 2;
            this.tableLayoutPanelMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMainContainer.Size = new System.Drawing.Size(667, 450);
            this.tableLayoutPanelMainContainer.TabIndex = 0;
            // 
            // comboBoxYearSelect
            // 
            this.comboBoxYearSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxYearSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearSelect.FormattingEnabled = true;
            this.comboBoxYearSelect.Location = new System.Drawing.Point(3, 3);
            this.comboBoxYearSelect.Name = "comboBoxYearSelect";
            this.comboBoxYearSelect.Size = new System.Drawing.Size(121, 21);
            this.comboBoxYearSelect.TabIndex = 0;
            this.comboBoxYearSelect.SelectedIndexChanged += new System.EventHandler(this.ComboBoxYearSelect_SelectedIndexChanged);
            // 
            // tableLayoutPanelDayGrid
            // 
            this.tableLayoutPanelDayGrid.AutoSize = true;
            this.tableLayoutPanelDayGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDayGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelDayGrid.ColumnCount = 4;
            this.tableLayoutPanelDayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelDayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelDayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelDayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanelDayGrid.Controls.Add(this.labelCaptionSolutionPart1, 1, 0);
            this.tableLayoutPanelDayGrid.Controls.Add(this.labelCaptionSolutionPart2, 2, 0);
            this.tableLayoutPanelDayGrid.Controls.Add(this.labelCaptionRuntime, 3, 0);
            this.tableLayoutPanelDayGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDayGrid.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanelDayGrid.Name = "tableLayoutPanelDayGrid";
            this.tableLayoutPanelDayGrid.RowCount = 1;
            this.tableLayoutPanelDayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDayGrid.Size = new System.Drawing.Size(661, 417);
            this.tableLayoutPanelDayGrid.TabIndex = 1;
            // 
            // labelCaptionSolutionPart1
            // 
            this.labelCaptionSolutionPart1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionSolutionPart1.AutoSize = true;
            this.labelCaptionSolutionPart1.Location = new System.Drawing.Point(164, 202);
            this.labelCaptionSolutionPart1.Name = "labelCaptionSolutionPart1";
            this.labelCaptionSolutionPart1.Size = new System.Drawing.Size(76, 13);
            this.labelCaptionSolutionPart1.TabIndex = 1;
            this.labelCaptionSolutionPart1.Text = "Solution Part 1";
            // 
            // labelCaptionSolutionPart2
            // 
            this.labelCaptionSolutionPart2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionSolutionPart2.AutoSize = true;
            this.labelCaptionSolutionPart2.Location = new System.Drawing.Point(365, 202);
            this.labelCaptionSolutionPart2.Name = "labelCaptionSolutionPart2";
            this.labelCaptionSolutionPart2.Size = new System.Drawing.Size(76, 13);
            this.labelCaptionSolutionPart2.TabIndex = 2;
            this.labelCaptionSolutionPart2.Text = "Solution Part 2";
            // 
            // labelCaptionRuntime
            // 
            this.labelCaptionRuntime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionRuntime.AutoSize = true;
            this.labelCaptionRuntime.Location = new System.Drawing.Point(547, 202);
            this.labelCaptionRuntime.Name = "labelCaptionRuntime";
            this.labelCaptionRuntime.Size = new System.Drawing.Size(69, 13);
            this.labelCaptionRuntime.TabIndex = 3;
            this.labelCaptionRuntime.Text = "Durchlaufzeit";
            // 
            // FormSolverUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.tableLayoutPanelMainContainer);
            this.Name = "FormSolverUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advent of Code Collection";
            this.Load += new System.EventHandler(this.SolverUI_Load);
            this.tableLayoutPanelMainContainer.ResumeLayout(false);
            this.tableLayoutPanelMainContainer.PerformLayout();
            this.tableLayoutPanelDayGrid.ResumeLayout(false);
            this.tableLayoutPanelDayGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainContainer;
        private System.Windows.Forms.ComboBox comboBoxYearSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDayGrid;
        private System.Windows.Forms.Label labelCaptionSolutionPart1;
        private System.Windows.Forms.Label labelCaptionSolutionPart2;
        private System.Windows.Forms.Label labelCaptionRuntime;
    }
}

