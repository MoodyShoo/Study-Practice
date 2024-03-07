// Form1.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PracticeIndividualProject
{
    public partial class Form1 : Form
    {
        private Dictionary<Button, bool> Buttons;
        private int counter = 0;
        private bool highlightNumbers = false;
        private DateTime startTime;
        private TimeSpan elapsedTime;

        public Form1()
        {
            InitializeComponent();
            Buttons = new Dictionary<Button, bool>();
            foreach (Control control in this.Controls)
            {
                if (control is Button button && button != startButton)
                {
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatStyle = FlatStyle.Flat;
                    button.UseVisualStyleBackColor = true;
                    button.Visible = true;
                    button.Click += Button_Click;
                    button.Enabled = false;
                    Buttons.Add(button, false);
                }
            }
        }

        void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (!Buttons[button])
            {
                if (int.TryParse(button.Text, out int num))
                {
                    if (num == counter + 1)
                    {
                        counter++;
                        Buttons[button] = true;
                        if (highlightNumbers)
                        {
                            button.BackColor = Color.Green;
                        }
                        UpdateStatus();
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, найдите числа по порядку.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы уже нашли это число!");
            }
        }

        void UpdateStatus()
        {
            if (counter == Buttons.Count)
            {
                timer1.Stop();
                elapsedTime = DateTime.Now - startTime;
                MessageBox.Show($"Вы нашли все числа за {elapsedTime.ToString(@"mm\:ss")} минут.");

                // Предложение сохранить результат
                DialogResult result = MessageBox.Show("Хотите сохранить результат в таблицу лидеров?", "Сохранение результата", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    leaderbaord leaderboardForm = new leaderbaord(false, elapsedTime);
                    leaderboardForm.ShowDialog();
                }
            }
            else
            {
                infoLabel.Text = $"Последнее найденное число: {counter}. Осталось чисел: {Buttons.Count - counter}";
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            labelTime.Text = "00:00";

            var keys = new List<Button>(Buttons.Keys);
            foreach (var key in keys)
            {
                Buttons[key] = false;
                key.BackColor = SystemColors.Control;
            }

            foreach (var button in Buttons.Keys)
            {
                button.Enabled = true;
            }
            timer1.Start();
            infoLabel.Text = "Время пошло!";
        }

        private void highlightNumbersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            highlightNumbers = highlightNumbersToolStripMenuItem.Checked;

            if (!highlightNumbers)
            {
                foreach (var button in Buttons.Keys)
                {
                    button.BackColor = SystemColors.Control;
                }
            }
            else
            {
                foreach (var button in Buttons.Keys)
                {
                    if (Buttons[button])
                    {
                        button.BackColor = Color.Green;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = (DateTime.Now - startTime).ToString(@"mm\:ss");
        }

        private void leaderboardToolStripButton_Click(object sender, EventArgs e)
        {
            leaderbaord leaderboardForm = new leaderbaord(false, elapsedTime); 
            leaderboardForm.ShowDialog();
        }
    }
}
