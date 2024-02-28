﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWeek02_13
{
    public partial class Form1 : Form
    {
        const int buttonSize = 40;
        const int crossWidth = 7;
        const int crossHeight = 7;
        const int centerSize = 3;

        public Form1()
        {
            InitializeComponent();
            DrawCross();
            Check();
        }

        GameTiles[,] tiles = new GameTiles[7,7];
        private void DrawCross()
        {
            panel1.Controls.Clear();

            for (int i = 0; i < crossWidth; i++)
            {
                for (int j = 0; j < crossHeight; j++)
                {
                    // Проверяем, что мы находимся на границе креста
                    if ((i >= (crossWidth - centerSize) / 2 && i < (crossWidth + centerSize) / 2) || (j >= (crossHeight - centerSize) / 2 && j < (crossHeight + centerSize) / 2))
                    {
                        tiles[i, j] = new GameTiles();
                        tiles[i, j].Size = new Size(buttonSize, buttonSize);
                        tiles[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                        tiles[i, j].X = i;
                        tiles[i, j].Y = j;
                        panel1.Controls.Add(tiles[i, j]);
                    }
                }
            }
        }

        private void Check()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (tiles[i, j] != null)
                    {
                        tiles[i, j].Text = $"{i},{j}";
                    }
                }
            }
        }
    }
}
