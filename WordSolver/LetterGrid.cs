using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordSolver
{
    public class LetterGrid
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        private LetterButton[][] Buttons;

        public LetterGrid(int x, int y, int maxX, int maxY)
        {
            X = x;
            Y = y;
            MaxX = maxX;
            MaxY = maxY;
            Buttons = new LetterButton[MaxY][];
            for (int i = 0; i < MaxY; i++)
            {
                Buttons[i] = new LetterButton[MaxY];
                for (int j = 0; j < MaxX; j++)
                {
                    Buttons[i][j] = new LetterButton(j, i);
                }
            }
        }

        public void SetGridSize(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Control[] GetControls()
        {
            Control[] controls = new Control[X * Y];

            int i = 0;
            for (int x = 0; x < X; x++)
            {
                for (int y = 0; y < Y; y++)
                {
                    controls[i++] = Buttons[y][x];
                }
            }

            return controls;
        }

        public void FindWords()
        {

        }
    }
}
