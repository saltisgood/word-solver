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
            this.ComBoxLetter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheBoxIsRequired = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComBoxPositionRestriction = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ComBoxLetter
            // 
            this.ComBoxLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxLetter.FormattingEnabled = true;
            this.ComBoxLetter.Items.AddRange(new object[] {
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
            "DE",
            "ER",
            "EST",
            "RE",
            "TO",
            "VE"});
            this.ComBoxLetter.Location = new System.Drawing.Point(162, 10);
            this.ComBoxLetter.Name = "ComBoxLetter";
            this.ComBoxLetter.Size = new System.Drawing.Size(183, 21);
            this.ComBoxLetter.TabIndex = 0;
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
            // CheBoxIsRequired
            // 
            this.CheBoxIsRequired.AutoSize = true;
            this.CheBoxIsRequired.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheBoxIsRequired.Location = new System.Drawing.Point(162, 46);
            this.CheBoxIsRequired.Name = "CheBoxIsRequired";
            this.CheBoxIsRequired.Size = new System.Drawing.Size(15, 14);
            this.CheBoxIsRequired.TabIndex = 2;
            this.CheBoxIsRequired.UseVisualStyleBackColor = true;
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
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(36, 134);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(95, 23);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(191, 134);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(95, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
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
            // ComBoxPositionRestriction
            // 
            this.ComBoxPositionRestriction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComBoxPositionRestriction.FormattingEnabled = true;
            this.ComBoxPositionRestriction.Items.AddRange(new object[] {
            "No Restrictions",
            "Start of the word",
            "End of the word"});
            this.ComBoxPositionRestriction.Location = new System.Drawing.Point(162, 77);
            this.ComBoxPositionRestriction.Name = "ComBoxPositionRestriction";
            this.ComBoxPositionRestriction.Size = new System.Drawing.Size(183, 21);
            this.ComBoxPositionRestriction.TabIndex = 7;
            // 
            // LetterSelectForm
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(357, 167);
            this.Controls.Add(this.ComBoxPositionRestriction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheBoxIsRequired);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComBoxLetter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LetterSelectForm";
            this.Text = "Select the letter options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComBoxLetter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheBoxIsRequired;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComBoxPositionRestriction;
    }
}