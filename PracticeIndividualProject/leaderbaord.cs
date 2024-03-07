// leaderbaord.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PracticeIndividualProject
{
    public partial class leaderbaord : Form
    {
        private const string leaderboardFilePath = "leaderboard.txt";
        private List<LeaderboardEntry> leaderboardEntries;
        private bool disableInput;
        private TimeSpan gameElapsedTime;

        public leaderbaord(bool disableInput, TimeSpan GameElapsedTime)
        {
            InitializeComponent();
            this.disableInput = disableInput;
            this.gameElapsedTime = GameElapsedTime;
            labelTime.Text = GameElapsedTime.ToString();
            leaderboardEntries = new List<LeaderboardEntry>();
            dataGridViewLeaderboard.Columns.Add("NameColumn", "Name");
            dataGridViewLeaderboard.Columns.Add("TimeColumn", "Time");
            LoadLeaderboard();
            UpdateLeaderboardDisplay();

            if (disableInput)
            {
                textBoxName.Enabled = false;
                buttonSave.Enabled = false;
                textBoxName.Text = "Ввод результата недоступен";
            }
            dataGridViewLeaderboard.ReadOnly = true;
        }


        private void LoadLeaderboard()
        {
            if (File.Exists(leaderboardFilePath))
            {
                string[] lines = File.ReadAllLines(leaderboardFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        TimeSpan time;

                        if (TimeSpan.TryParse(parts[1], out time))
                        {
                            leaderboardEntries.Add(new LeaderboardEntry(name, time));
                        }
                    }
                }
            }
        }

        private void SaveLeaderboard()
        {
            using (StreamWriter writer = new StreamWriter(leaderboardFilePath))
            {
                foreach (LeaderboardEntry entry in leaderboardEntries)
                {
                    writer.WriteLine($"{entry.Name},{entry.Time}");
                }
            }
        }

        private void UpdateLeaderboardDisplay()
        {
            dataGridViewLeaderboard.Rows.Clear();
            foreach (LeaderboardEntry entry in leaderboardEntries)
            {
                dataGridViewLeaderboard.Rows.Add(entry.Name, entry.Time);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim(); 
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, введите имя перед сохранением результата.");
                return; 
            }
            TimeSpan time = gameElapsedTime; 

            leaderboardEntries.Add(new LeaderboardEntry(name, time));
            leaderboardEntries.Sort((x, y) => x.Time.CompareTo(y.Time));

            SaveLeaderboard();
            UpdateLeaderboardDisplay();

            MessageBox.Show("Результат успешно сохранен в таблицу лидеров!");
        }

        private void buttonViewLeaderboard_Click(object sender, EventArgs e)
        {
            UpdateLeaderboardDisplay();
            this.Show();
        }
    }

    public class LeaderboardEntry
    {
        public string Name { get; }
        public TimeSpan Time { get; }

        public LeaderboardEntry(string name, TimeSpan time)
        {
            Name = name;
            Time = time;
        }
    }
}
