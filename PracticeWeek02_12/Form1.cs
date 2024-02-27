using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWeek02_12
{
    public partial class Form1 : Form
    {
        private const string FilePath = "savedSudoku.txt";
        public Form1()
        {
            InitializeComponent();
            createCells();
            this.FormClosing += Form1_FormClosing;
            LoadSavedCellValuesFromFile();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            startNewGame();
            UnhighlightAllCells();
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            HighlightDuplicates();
        }

        private void HighlightDuplicates()
        {
            List<int> rowsWithDuplicates = new List<int>();
            List<int> columnsWithDuplicates = new List<int>();
            List<Tuple<int, int>> squaresWithDuplicates = new List<Tuple<int, int>>();

            // Проверка строк
            for (int i = 0; i < 9; i++)
            {
                List<int> valuesInRow = new List<int>();
                for (int j = 0; j < 9; j++)
                {
                    if (!string.IsNullOrEmpty(cells[i, j].Text) && int.TryParse(cells[i, j].Text, out int value))
                    {
                        if (valuesInRow.Contains(value))
                        {
                            rowsWithDuplicates.Add(i);
                            break;
                        }
                        else
                        {
                            valuesInRow.Add(value);
                        }
                    }
                }
            }

            // Проверка столбцов
            for (int j = 0; j < 9; j++)
            {
                List<int> valuesInColumn = new List<int>();
                for (int i = 0; i < 9; i++)
                {
                    if (!string.IsNullOrEmpty(cells[i, j].Text) && int.TryParse(cells[i, j].Text, out int value))
                    {
                        if (valuesInColumn.Contains(value))
                        {
                            columnsWithDuplicates.Add(j);
                            break;
                        }
                        else
                        {
                            valuesInColumn.Add(value);
                        }
                    }
                }
            }

            // Проверка квадратов 3 на 3
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    List<int> valuesInSquare = new List<int>();
                    for (int x = i; x < i + 3; x++)
                    {
                        for (int y = j; y < j + 3; y++)
                        {
                            if (!string.IsNullOrEmpty(cells[x, y].Text) && int.TryParse(cells[x, y].Text, out int value))
                            {
                                if (valuesInSquare.Contains(value))
                                {
                                    squaresWithDuplicates.Add(new Tuple<int, int>(i, j));
                                    break;
                                }
                                else
                                {
                                    valuesInSquare.Add(value);
                                }
                            }
                        }
                    }
                }
            }


            // Подсветка всех строк с дубликатами
            foreach (int row in rowsWithDuplicates)
            {
                HighlightRow(row);
            }

            // Подсветка всех столбцов с дубликатами
            foreach (int col in columnsWithDuplicates)
            {
                HighlightColumn(col);
            }

            // Подсветка всех квадратов с дубликатами
            foreach (var square in squaresWithDuplicates)
            {
                HighlightSquare(square.Item1, square.Item2);
            }

            // Снятие подсветки, если дубликатов нет
            if (rowsWithDuplicates.Count == 0 && columnsWithDuplicates.Count == 0 && squaresWithDuplicates.Count == 0)
            {
                UnhighlightAllCells();
            }
        }
        private void HighlightRow(int row)
        {
            for (int j = 0; j < 9; j++)
            {
                cells[row, j].BackColor = Color.Red;
            }
        }

        private void HighlightColumn(int col)
        {
            for (int i = 0; i < 9; i++)
            {
                cells[i, col].BackColor = Color.Red;
            }
        }

        private void HighlightSquare(int startX, int startY)
        {
            for (int i = startX; i < startX + 3; i++)
            {
                for (int j = startY; j < startY + 3; j++)
                {
                    cells[i, j].BackColor = Color.Red;
                }
            }
        }

        private void UnhighlightAllCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                }
            }
        }

        private void startNewGame()
        {
            loadValues();
            showRandomValuesHints(25);
        }

        private void loadValues()
        {
            foreach (var cell in cells)
            {
                cell.Clear();
            }
            findValueForNextCell(0, -1);
        }

        Random random = new Random();

        private void showRandomValuesHints(int hintsCount)
        {
            for (int i = 0; i < hintsCount; i++)
            {
                var rX = random.Next(9);
                var rY = random.Next(9);

                cells[rX, rY].Text = cells[rX, rY].Value.ToString();
            }
        }

        private bool findValueForNextCell(int i, int j)
        {
            if (++j > 8)
            {
                j = 0;

                if (++i > 8)
                    return true;
            }

            var value = 0;
            var numsLeft = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            do
            {
                if (numsLeft.Count < 1)
                {
                    cells[i, j].Value = 0;
                    return false;
                }

                value = numsLeft[random.Next(0, numsLeft.Count)];
                cells[i, j].Value = value;

                numsLeft.Remove(value);
            }
            while (!isValidNumber(value, i, j) || !findValueForNextCell(i, j));

            return true;
        }

        private bool isValidNumber(int value, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != y && cells[x, i].Value == value)
                    return false;

                if (i != x && cells[i, y].Value == value)
                    return false;
            }

            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && cells[i, j].Value == value)
                        return false;
                }
            }

            return true;
        }
        SudokuCell[,] cells = new SudokuCell[9, 9];

        private void createCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new SudokuCell();
                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(40, 40);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].Location = new Point(i * 40, j * 40);
                    cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].X = i;
                    cells[i, j].Y = j;

                    cells[i, j].KeyPress += cell_keyPressed;

                    panelSudoku.Controls.Add(cells[i, j]);
                }
            }
        }
        private void cell_keyPressed(object sender, KeyPressEventArgs e)
        {
            var cell = sender as SudokuCell;

            if (cell.IsLocked)
                return;

            int value;

            if (int.TryParse(e.KeyChar.ToString(), out value))
            {
                if (value == 0)
                    cell.Clear();
                else
                    cell.Text = value.ToString();

                cell.ForeColor = SystemColors.ControlDarkDark;
            }
        }

        private void SaveCellValuesToFile()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        writer.WriteLine(cells[i, j].Text);
                    }
                }
            }
        }

        private void LoadSavedCellValuesFromFile()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            string value = reader.ReadLine();
                            if (value != null)
                            {
                                cells[i, j].Text = value;
                            }
                        }
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCellValuesToFile();
        }
    }
}