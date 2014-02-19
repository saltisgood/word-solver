namespace WordSolver.Gui
{
    partial class LetterSelectForm
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
            this.letterComBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.requiredCheBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.restrictionCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // letterComBox
            // 
            this.letterComBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.letterComBox.FormattingEnabled = true;
            this.letterComBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "AR",
            "CH",
            "ER",
            "EST",
            "RE",
            "TO",
            "VE"});
            this.letterComBox.Location = new System.Drawing.Point(162, 10);
            this.letterComBox.Name = "letterComBox";
            this.letterComBox.Size = new System.Drawing.Size(183, 21);
            this.letterComBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the letter to use: ";
            // 
            // requiredCheBox
            // 
            this.requiredCheBox.AutoSize = true;
            this.requiredCheBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.requiredCheBox.Location = new System.Drawing.Point(162, 46);
            this.requiredCheBox.Name = "requiredCheBox";
            this.requiredCheBox.Size = new System.Drawing.Size(15, 14);
            this.requiredCheBox.TabIndex = 2;
            this.requiredCheBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Is Required?";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(36, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(191, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Word Position Restrictions:";
            // 
            // restrictionCombo
            // 
            this.restrictionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.restrictionCombo.FormattingEnabled = true;
            this.restrictionCombo.Items.AddRange(new object[] {
            "No Restrictions",
            "Start of the word",
            "End of the word"});
            this.restrictionCombo.Location = new System.Drawing.Point(162, 77);
            this.restrictionCombo.Name = "restrictionCombo";
            this.restrictionCombo.Size = new System.Drawing.Size(183, 21);
            this.restrictionCombo.TabIndex = 7;
            // 
            // LetterSelectForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(357, 167);
            this.Controls.Add(this.restrictionCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.requiredCheBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.letterComBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LetterSelectForm";
            this.Text = "Select the letter options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox letterComBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox requiredCheBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox restrictionCombo;
    }
}