using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WordSolver.Dictionary;
using WordSolver.Util;

namespace WordSolver.Gui
{
    /// <summary>
    /// A form used to display the results of a word search
    /// </summary>
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();

            List<String>.Enumerator results = Solutions.Enumerate();
            while (results.MoveNext())
            {
                ListBoxResults.Items.Add(results.Current);
            }
        }
    }
}
