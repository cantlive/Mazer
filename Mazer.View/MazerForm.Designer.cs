
namespace Mazer.View
{
    partial class MazerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Settings = new System.Windows.Forms.Panel();
            this.numericUpDown_AnimationSpeed = new System.Windows.Forms.NumericUpDown();
            this.button_Animate = new System.Windows.Forms.Button();
            this.button_Generate = new System.Windows.Forms.Button();
            this.numericUpDown_ColumnsCount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_RowsCount = new System.Windows.Forms.NumericUpDown();
            this.comboBox_MazeGenerators = new System.Windows.Forms.ComboBox();
            this.paintPanel_Maze = new Mazer.View.PaintPanel();
            this.label_Rows = new System.Windows.Forms.Label();
            this.label_Columns = new System.Windows.Forms.Label();
            this.label_MazeGeneratorType = new System.Windows.Forms.Label();
            this.label_AnimationSpeed = new System.Windows.Forms.Label();
            this.panel_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnimationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ColumnsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RowsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Settings
            // 
            this.panel_Settings.Controls.Add(this.label_AnimationSpeed);
            this.panel_Settings.Controls.Add(this.label_MazeGeneratorType);
            this.panel_Settings.Controls.Add(this.label_Columns);
            this.panel_Settings.Controls.Add(this.label_Rows);
            this.panel_Settings.Controls.Add(this.numericUpDown_AnimationSpeed);
            this.panel_Settings.Controls.Add(this.button_Animate);
            this.panel_Settings.Controls.Add(this.button_Generate);
            this.panel_Settings.Controls.Add(this.numericUpDown_ColumnsCount);
            this.panel_Settings.Controls.Add(this.numericUpDown_RowsCount);
            this.panel_Settings.Controls.Add(this.comboBox_MazeGenerators);
            this.panel_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Settings.Location = new System.Drawing.Point(0, 0);
            this.panel_Settings.Name = "panel_Settings";
            this.panel_Settings.Size = new System.Drawing.Size(699, 65);
            this.panel_Settings.TabIndex = 0;
            // 
            // numericUpDown_AnimationSpeed
            // 
            this.numericUpDown_AnimationSpeed.Location = new System.Drawing.Point(642, 17);
            this.numericUpDown_AnimationSpeed.Name = "numericUpDown_AnimationSpeed";
            this.numericUpDown_AnimationSpeed.Size = new System.Drawing.Size(47, 23);
            this.numericUpDown_AnimationSpeed.TabIndex = 5;
            this.numericUpDown_AnimationSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // button_Animate
            // 
            this.button_Animate.Location = new System.Drawing.Point(455, 15);
            this.button_Animate.Name = "button_Animate";
            this.button_Animate.Size = new System.Drawing.Size(75, 23);
            this.button_Animate.TabIndex = 4;
            this.button_Animate.Text = "Animate";
            this.button_Animate.UseVisualStyleBackColor = true;
            this.button_Animate.Click += new System.EventHandler(this.button_Animate_Click);
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(374, 15);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(75, 23);
            this.button_Generate.TabIndex = 3;
            this.button_Generate.Text = "Generate";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // numericUpDown_ColumnsCount
            // 
            this.numericUpDown_ColumnsCount.Location = new System.Drawing.Point(76, 33);
            this.numericUpDown_ColumnsCount.Name = "numericUpDown_ColumnsCount";
            this.numericUpDown_ColumnsCount.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown_ColumnsCount.TabIndex = 2;
            this.numericUpDown_ColumnsCount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDown_RowsCount
            // 
            this.numericUpDown_RowsCount.Location = new System.Drawing.Point(76, 7);
            this.numericUpDown_RowsCount.Name = "numericUpDown_RowsCount";
            this.numericUpDown_RowsCount.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown_RowsCount.TabIndex = 1;
            this.numericUpDown_RowsCount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // comboBox_MazeGenerators
            // 
            this.comboBox_MazeGenerators.FormattingEnabled = true;
            this.comboBox_MazeGenerators.Location = new System.Drawing.Point(145, 33);
            this.comboBox_MazeGenerators.Name = "comboBox_MazeGenerators";
            this.comboBox_MazeGenerators.Size = new System.Drawing.Size(223, 23);
            this.comboBox_MazeGenerators.TabIndex = 0;
            // 
            // paintPanel_Maze
            // 
            this.paintPanel_Maze.BackColor = System.Drawing.Color.Black;
            this.paintPanel_Maze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paintPanel_Maze.Location = new System.Drawing.Point(0, 65);
            this.paintPanel_Maze.Name = "paintPanel_Maze";
            this.paintPanel_Maze.Size = new System.Drawing.Size(699, 501);
            this.paintPanel_Maze.TabIndex = 1;
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Location = new System.Drawing.Point(32, 9);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(38, 15);
            this.label_Rows.TabIndex = 6;
            this.label_Rows.Text = "Rows:";
            this.label_Rows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Columns
            // 
            this.label_Columns.AutoSize = true;
            this.label_Columns.Location = new System.Drawing.Point(12, 37);
            this.label_Columns.Name = "label_Columns";
            this.label_Columns.Size = new System.Drawing.Size(58, 15);
            this.label_Columns.TabIndex = 7;
            this.label_Columns.Text = "Columns:";
            // 
            // label_MazeGeneratorType
            // 
            this.label_MazeGeneratorType.AutoSize = true;
            this.label_MazeGeneratorType.Location = new System.Drawing.Point(207, 9);
            this.label_MazeGeneratorType.Name = "label_MazeGeneratorType";
            this.label_MazeGeneratorType.Size = new System.Drawing.Size(115, 15);
            this.label_MazeGeneratorType.TabIndex = 8;
            this.label_MazeGeneratorType.Text = "Maze generator type";
            // 
            // label_AnimationSpeed
            // 
            this.label_AnimationSpeed.AutoSize = true;
            this.label_AnimationSpeed.Location = new System.Drawing.Point(536, 19);
            this.label_AnimationSpeed.Name = "label_AnimationSpeed";
            this.label_AnimationSpeed.Size = new System.Drawing.Size(100, 15);
            this.label_AnimationSpeed.TabIndex = 9;
            this.label_AnimationSpeed.Text = "Animation speed:";
            // 
            // MazerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 566);
            this.Controls.Add(this.paintPanel_Maze);
            this.Controls.Add(this.panel_Settings);
            this.MinimumSize = new System.Drawing.Size(715, 605);
            this.Name = "MazerForm";
            this.Text = "Mazer";
            this.Load += new System.EventHandler(this.MazerForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MazerForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.MazerForm_Resize);
            this.panel_Settings.ResumeLayout(false);
            this.panel_Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnimationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ColumnsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RowsCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Settings;
        private System.Windows.Forms.Button button_Animate;
        private System.Windows.Forms.Button button_Generate;
        private System.Windows.Forms.NumericUpDown numericUpDown_ColumnsCount;
        private System.Windows.Forms.NumericUpDown numericUpDown_RowsCount;
        private System.Windows.Forms.ComboBox comboBox_MazeGenerators;
        private PaintPanel paintPanel_Maze;
        private System.Windows.Forms.NumericUpDown numericUpDown_AnimationSpeed;
        private System.Windows.Forms.Label label_AnimationSpeed;
        private System.Windows.Forms.Label label_MazeGeneratorType;
        private System.Windows.Forms.Label label_Columns;
        private System.Windows.Forms.Label label_Rows;
    }
}