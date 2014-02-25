using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSolver.Util;
using WordSolver.Dictionary;

namespace WordSolver.Gui
{
    public partial class Results : Form
    {
        private DictTree Tree;

        public Results(DictTree tree)
        {
            InitializeComponent();

            List<String>.Enumerator results = Solutions.Enumerate();
            while (results.MoveNext())
            {
                listBox1.Items.Add(results.Current);
            }

            Tree = tree;
        }
    }
}
