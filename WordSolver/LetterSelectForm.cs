using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSolver
{
    public partial class LetterSelectForm : Form
    {
        private LetterButton Button;

        public LetterSelectForm(LetterButton button)
        {
            Button = button;
            InitializeComponent();

            letterComBox.SelectedIndex = (int)Button.SelectedLetter;
            requiredCheBox.Checked = Button.IsRequired;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button.SelectedLetter = (LetterUtil.Letter)letterComBox.SelectedIndex;
            Button.Text = LetterUtil.ConvertToString(Button.SelectedLetter);
            Button.IsRequired = requiredCheBox.Checked;

            if (Button.IsRequired)
            {
                Button.BackColor = SystemColors.ControlDark;
            }
            else
            {
                Button.BackColor = SystemColors.Control;
            }
        }
    }
}
