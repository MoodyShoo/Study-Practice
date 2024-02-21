using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_07
{
    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        private Random random = new Random();

        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveRandomly(char[,] map)
        {
            int dx = random.Next(-1, 2); // Генерируем случайное значение от -1 до 1 для движения по оси X
            int dy = random.Next(-1, 2); // Генерируем случайное значение от -1 до 1 для движения по оси Y

            int newX = X + dx;
            int newY = Y + dy;

            // Проверяем, что новые координаты находятся в пределах карты и являются допустимыми
            if (newX >= 0 && newX < map.GetLength(0) && newY >= 0 && newY < map.GetLength(1) && map[newX, newY] == ' ')
            {
                X = newX;
                Y = newY;
            }
        }
    }
}
