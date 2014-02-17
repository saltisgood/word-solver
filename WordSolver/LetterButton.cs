using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WordSolver
{
    public class LetterButton : Button
    {
        public LetterUtil.Letter SelectedLetter = LetterUtil.Letter.A;
        public bool IsRequired = false;

        public LetterButton(int x, int y) : base()
        {
            this.Size = new System.Drawing.Size(100, 100);
            this.Font = new Font("Calibri", 40, FontStyle.Bold);
            this.Text = "A";

            this.Location = new Point(105 * x, 105 * y);

            this.Click += new EventHandler(onClick);
            this.MouseEnter += new EventHandler(mouseEnter);
            this.MouseLeave += new EventHandler(mouseLeave);
            this.UseVisualStyleBackColor = false;
        }

        private void onClick(object sender, EventArgs e)
        {
            new LetterSelectForm(this).ShowDialog();
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.ButtonHighlight;
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            if (IsRequired)
            {
                this.BackColor = SystemColors.ControlDark;
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
        }
    }
}
