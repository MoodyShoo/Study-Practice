using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracticeWeek02_14
{
    public partial class Form1 : Form
    {
        private SquareCells[,] cells;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawSquare(int n)
        {
            panel1.Controls.Clear();
            cells = new SquareCells[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cells[i, j] = new SquareCells();
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].X = i;
                    cells[i, j].Y = j;
                    cells[i, j].status = CellStatus.Healthy;
                    cells[i, j].BackColor = Color.White; // Белый цвет
                    panel1.Controls.Add(cells[i, j]);
                }
            }

            // Задаем начальное состояние, сделав центральную клетку зараженной
            int centerX = n / 2;
            int centerY = n / 2;
            cells[centerX, centerY].status = CellStatus.Infected;
            cells[centerX, centerY].BackColor = Color.Red; // Красный цвет для зараженной клетки
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDownSquareSize.Value);
            if (n % 2 != 0)
            {
                DrawSquare(n);
            }
            else
            {
                MessageBox.Show("Введите нечётное число (Для красоты :D)", "Неверные данные");
            }
        }
    }
}
