
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxYearSelect = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCaptionSolutionPart1 = new System.Windows.Forms.Label();
            this.labelCaptionSolutionPart2 = new System.Windows.Forms.Label();
            this.labelCaptionRuntime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBoxYearSelect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 450);
            this.tableLayoutPanel1.TabIndex = 0;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tableLayoutPanel2.Controls.Add(this.labelCaptionSolutionPart1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCaptionSolutionPart2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCaptionRuntime, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(554, 417);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelCaptionSolutionPart1
            // 
            this.labelCaptionSolutionPart1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionSolutionPart1.AutoSize = true;
            this.labelCaptionSolutionPart1.Location = new System.Drawing.Point(114, 202);
            this.labelCaptionSolutionPart1.Name = "labelCaptionSolutionPart1";
            this.labelCaptionSolutionPart1.Size = new System.Drawing.Size(76, 13);
            this.labelCaptionSolutionPart1.TabIndex = 1;
            this.labelCaptionSolutionPart1.Text = "Solution Part 1";
            // 
            // labelCaptionSolutionPart2
            // 
            this.labelCaptionSolutionPart2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionSolutionPart2.AutoSize = true;
            this.labelCaptionSolutionPart2.Location = new System.Drawing.Point(215, 202);
            this.labelCaptionSolutionPart2.Name = "labelCaptionSolutionPart2";
            this.labelCaptionSolutionPart2.Size = new System.Drawing.Size(76, 13);
            this.labelCaptionSolutionPart2.TabIndex = 2;
            this.labelCaptionSolutionPart2.Text = "Solution Part 2";
            // 
            // labelCaptionRuntime
            // 
            this.labelCaptionRuntime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaptionRuntime.AutoSize = true;
            this.labelCaptionRuntime.Location = new System.Drawing.Point(394, 202);
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
            this.ClientSize = new System.Drawing.Size(559, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormSolverUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advent of Code Collection";
            this.Load += new System.EventHandler(this.SolverUI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxYearSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelCaptionSolutionPart1;
        private System.Windows.Forms.Label labelCaptionSolutionPart2;
        private System.Windows.Forms.Label labelCaptionRuntime;
    }
}

