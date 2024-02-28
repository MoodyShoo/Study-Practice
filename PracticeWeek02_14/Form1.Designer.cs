namespace PracticeWeek02_14
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDownSquareSize = new System.Windows.Forms.NumericUpDown();
            this.labelSquare = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSquareSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 0;
            // 
            // numericUpDownSquareSize
            // 
            this.numericUpDownSquareSize.Location = new System.Drawing.Point(500, 28);
            this.numericUpDownSquareSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSquareSize.Name = "numericUpDownSquareSize";
            this.numericUpDownSquareSize.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSquareSize.TabIndex = 1;
            // 
            // labelSquare
            // 
            this.labelSquare.AutoSize = true;
            this.labelSquare.Location = new System.Drawing.Point(501, 9);
            this.labelSquare.Name = "labelSquare";
            this.labelSquare.Size = new System.Drawing.Size(119, 13);
            this.labelSquare.TabIndex = 2;
            this.labelSquare.Text = "Размер квадрата N*N";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(500, 54);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(120, 46);
            this.createButton.TabIndex = 3;
            this.createButton.Text = "Создать";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 427);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.labelSquare);
            this.Controls.Add(this.numericUpDownSquareSize);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSquareSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDownSquareSize;
        private System.Windows.Forms.Label labelSquare;
        private System.Windows.Forms.Button createButton;
    }
}

