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

namespace WordSolver.Gui
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();

            List<String>.Enumerator results = Solutions.Enumerate();
            while (results.MoveNext())
            {
                listBox1.Items.Add(results.Current);
            }
        }
    }
}
