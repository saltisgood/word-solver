using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSolver.Gui
{
    class LetterButtonContextMenu : ContextMenuStrip
    {
        private LetterButton Button;

        public LetterButtonContextMenu(LetterButton button)
            : base()
        {
            Button = button;

            this.Items.AddRange(new ToolStripItem[]
                {
                    new RemoveMenuItem()
                }
            );
        }

        void RemoveButton()
        {
            Button.Remove();
        }

        private class RemoveMenuItem : ToolStripMenuItem
        {
            public RemoveMenuItem()
                : base()
            {
                this.Text = "Remove letter";
                this.Click += click;
            }

            private void click(object sender, EventArgs e)
            {
                LetterButtonContextMenu menu = this.GetCurrentParent() as LetterButtonContextMenu;
                if (menu == null)
                {
                    return;
                }

                menu.RemoveButton();
            }
        }
    }
}
