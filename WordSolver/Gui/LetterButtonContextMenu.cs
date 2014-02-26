using System;
using System.Windows.Forms;

namespace WordSolver.Gui
{
    /// <summary>
    /// An extension to ContextMenuStrip that is used on a right-click of the LetterButton
    /// </summary>
    class LetterButtonContextMenu : ContextMenuStrip
    {
        /// <summary>
        /// The letter button associated with this object
        /// </summary>
        private LetterButton Button;



        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="button">The button which hosts this context menu</param>
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



        /// <summary>
        /// The method to be called when the remove letter menu item is called
        /// </summary>
        private void RemoveButton()
        {
            Button.Remove();
        }



        /// <summary>
        /// The item to be displayed in the context menu. An extension of ToolStripMenuItem.
        /// </summary>
        private class RemoveMenuItem : ToolStripMenuItem
        {
            /// <summary>
            /// Default constructor
            /// </summary>
            public RemoveMenuItem()
                : base()
            {
                this.Text = "Remove letter";
                this.Click += click;
            }



            /// <summary>
            /// The click handler for this menu item
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
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
