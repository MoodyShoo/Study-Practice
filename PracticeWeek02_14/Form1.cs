using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWeek02_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SquareCells[,] cells = new SquareCells[100, 100];
        public void DrawSquare(int n)
        {

            panel1.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j] = new SquareCells();
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].X = i;
                    cells[i, j].Y = j;
                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDownSquareSize.Value);
            DrawSquare(n);
        }
    }
}
