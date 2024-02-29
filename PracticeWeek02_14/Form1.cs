using System;
using System.Drawing;
using System.Windows.Forms;

namespace PracticeWeek02_14
{
    public partial class Form1 : Form
    {
        private SquareCells[,] cells; 
        private int gridSize; 
        private int infectionDuration = 6; 
        private int immunityDuration = 4; 
        private Random random = new Random(); 
        private int interval = 1000; 

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = interval; 
        }
        private void DrawSquare(int n) 
        {
            panel1.Controls.Clear();
            gridSize = n;
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
                    cells[i, j].BackColor = Color.White; 
                    panel1.Controls.Add(cells[i, j]); 
                }
            }

            int centerX = n / 2;
            int centerY = n / 2;
            cells[centerX, centerY].status = CellStatus.Infected;
            cells[centerX, centerY].BackColor = Color.Red;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(numericUpDownSquareSize.Value);
            if (n % 2 != 0)
            {
                DrawSquare(n);
                if (Convert.ToInt32(numericUpDownInterval.Value) != 0){
                    timer1.Interval = 1000 * Convert.ToInt32(numericUpDownInterval.Value);
                } else
                {
                    timer1.Interval = interval;
                }
                
                timer1.Start(); 
            }
            else
            {
                MessageBox.Show("Введите нечетное число (Для красоты :D)", "Неверные данные");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (cells[i, j].status == CellStatus.Infected)
                    {
                        SpreadInfection(i, j);
                        UpdateCellStatus(i, j);
                    }
                    else if (cells[i, j].status == CellStatus.Immune)
                    {
                        if (cells[i, j].immunityCount == immunityDuration)
                        {
                            cells[i, j].status = CellStatus.Healthy;
                            cells[i, j].BackColor = Color.White; 
                            cells[i, j].immunityCount = 0;
                        }
                        else
                        {
                            // Установить зеленый цвет для клеток с иммунитетом
                            cells[i, j].BackColor = Color.Green;
                            cells[i, j].immunityCount++;
                        }
                    }
                }
            }
        }


    private void SpreadInfection(int x, int y)
        {
            for (int i = Math.Max(0, x - 1); i <= Math.Min(gridSize - 1, x + 1); i++)
            {
                for (int j = Math.Max(0, y - 1); j <= Math.Min(gridSize - 1, y + 1); j++)
                {
                    if ((i == x || j == y) && (i != x || j != y))
                    {
                        if (cells[i, j].status == CellStatus.Healthy && random.NextDouble() < 0.5)
                        {
                            cells[i, j].status = CellStatus.Infected;
                            cells[i, j].BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void UpdateCellStatus(int x, int y)
        {
            if (cells[x, y].status == CellStatus.Infected)
            {
                if (cells[x, y].immunityCount == infectionDuration)
                {
                    cells[x, y].status = CellStatus.Immune;
                    cells[x, y].BackColor = Color.Green; 
                    cells[x, y].immunityCount = 0;
                }
                else
                {
                    cells[x, y].immunityCount++;
                }
            }
            else if (cells[x, y].status == CellStatus.Immune)
            {
                if (cells[x, y].immunityCount == immunityDuration)
                {
                    cells[x, y].status = CellStatus.Healthy;
                    cells[x, y].BackColor = Color.White;
                    cells[x, y].immunityCount = 0;
                }
                else
                {
                    cells[x, y].immunityCount++;
                }
            }
        }
    }

    public enum CellStatus
    {
        Healthy,
        Infected,
        Immune
    }

    public class SquareCells : Button
    {
        public int X;
        public int Y;
        public CellStatus status;
        public int immunityCount; 

        public SquareCells()
        {
            status = CellStatus.Healthy;
        }
    }
}
