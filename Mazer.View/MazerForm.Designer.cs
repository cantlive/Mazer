
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
            this.panel_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnimationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ColumnsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_RowsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Settings
            // 
            this.panel_Settings.Controls.Add(this.numericUpDown_AnimationSpeed);
            this.panel_Settings.Controls.Add(this.button_Animate);
            this.panel_Settings.Controls.Add(this.button_Generate);
            this.panel_Settings.Controls.Add(this.numericUpDown_ColumnsCount);
            this.panel_Settings.Controls.Add(this.numericUpDown_RowsCount);
            this.panel_Settings.Controls.Add(this.comboBox_MazeGenerators);
            this.panel_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Settings.Location = new System.Drawing.Point(0, 0);
            this.panel_Settings.Name = "panel_Settings";
            this.panel_Settings.Size = new System.Drawing.Size(800, 67);
            this.panel_Settings.TabIndex = 0;
            // 
            // numericUpDown_AnimationSpeed
            // 
            this.numericUpDown_AnimationSpeed.Location = new System.Drawing.Point(94, 40);
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
            this.button_Animate.Location = new System.Drawing.Point(232, 38);
            this.button_Animate.Name = "button_Animate";
            this.button_Animate.Size = new System.Drawing.Size(75, 23);
            this.button_Animate.TabIndex = 4;
            this.button_Animate.Text = "button2";
            this.button_Animate.UseVisualStyleBackColor = true;
            this.button_Animate.Click += new System.EventHandler(this.button_Animate_Click);
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(232, 11);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(75, 23);
            this.button_Generate.TabIndex = 3;
            this.button_Generate.Text = "button1";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // numericUpDown_ColumnsCount
            // 
            this.numericUpDown_ColumnsCount.Location = new System.Drawing.Point(12, 41);
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
            this.numericUpDown_RowsCount.Location = new System.Drawing.Point(12, 12);
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
            this.comboBox_MazeGenerators.Location = new System.Drawing.Point(94, 11);
            this.comboBox_MazeGenerators.Name = "comboBox_MazeGenerators";
            this.comboBox_MazeGenerators.Size = new System.Drawing.Size(121, 23);
            this.comboBox_MazeGenerators.TabIndex = 0;
            // 
            // paintPanel_Maze
            // 
            this.paintPanel_Maze.BackColor = System.Drawing.Color.Black;
            this.paintPanel_Maze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paintPanel_Maze.Location = new System.Drawing.Point(0, 67);
            this.paintPanel_Maze.Name = "paintPanel_Maze";
            this.paintPanel_Maze.Size = new System.Drawing.Size(800, 474);
            this.paintPanel_Maze.TabIndex = 1;
            // 
            // MazerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.paintPanel_Maze);
            this.Controls.Add(this.panel_Settings);
            this.Name = "MazerForm";
            this.Text = "Mazer";
            this.Load += new System.EventHandler(this.MazerForm_Load);
            this.panel_Settings.ResumeLayout(false);
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
    }
}