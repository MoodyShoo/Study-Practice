using Task_07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }

        public Player(int x, int y, int health)
        {
            X = x;
            Y = y;
            Health = health;
        }

        public void DecreaseHealth(int amount, ref bool gameEnd)
        {
            Health -= amount;
            if (Health <= 0)
            {
                gameEnd = true;
            }
        }
    }
}
