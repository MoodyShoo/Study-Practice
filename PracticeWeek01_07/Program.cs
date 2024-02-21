using System;
using System.IO;

namespace Task_07
{
    class Program
    {
        static bool gameEnd = false;
        static char[,] map;
        static Player player;
        static int exitX, exitY;
        static Enemy[] enemies;

        static void ReadMap(string mapName)
        {
            string[] lines = File.ReadAllLines($"{mapName}.txt");
            map = new char[lines.Length, lines[0].Length];

            bool playerSpawned = false;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                    if (map[i, j] == 'S')
                    {
                        if (playerSpawned)
                        {
                            throw new InvalidOperationException("Карта содержит несколько точек спауна игрока.");
                        }

                        player = new Player(i, j, 100);
                        playerSpawned = true;
                    }
                    else if (map[i, j] == 'X')
                    {
                        exitX = i;
                        exitY = j;
                    }
                }
            }

            if (!playerSpawned)
            {
                throw new InvalidOperationException("Карта не содержит точки спауна игрока.");
            }
        }

        static void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == player.X && j == player.Y)
                    {
                        Console.Write('P');
                    }
                    else if (IsEnemyPosition(i, j))
                    {
                        Console.Write('E');
                    }
                    else
                    {
                        Console.Write(map[i, j]);
                    }
                }
                Console.WriteLine();
            }

            DrawHealthBar(player.Health);
        }

        static void DrawHealthBar(int health)
        {
            Console.SetCursorPosition(0, map.GetLength(0) + 1);
            Console.Write("Health: [");
            for (int i = 0; i < health / 10; i++)
            {
                Console.Write("#");
            }
            for (int i = 0; i < (100 - health) / 10; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("]");
        }

        static void MovePlayer(int dx, int dy)
        {
            int newPlayerX = player.X + dx;
            int newPlayerY = player.Y + dy;

            // Проверяем, не выходит ли игрок за границы карты
            if (newPlayerX >= 0 && newPlayerX < map.GetLength(0) && newPlayerY >= 0 && newPlayerY < map.GetLength(1))
            {
                // Проверяем, не является ли новая позиция стеной
                if (map[newPlayerX, newPlayerY] != '▛' && map[newPlayerX, newPlayerY] != '▀' && map[newPlayerX, newPlayerY] != '▌' && map[newPlayerX, newPlayerY] != '█' && map[newPlayerX, newPlayerY] != '▐' &&
                    map[newPlayerX, newPlayerY] != '▄' && map[newPlayerX, newPlayerY] != '▟')
                {
                    player.X = newPlayerX;
                    player.Y = newPlayerY;

                    // Проверяем, не достиг ли игрок выхода
                    if (player.X == exitX && player.Y == exitY)
                    {
                        gameEnd = true;
                    }
                }
            }

            // Проверка столкновения с врагами
            foreach (Enemy enemy in enemies)
            {
                if (enemy.X == player.X && enemy.Y == player.Y)
                {
                    player.DecreaseHealth(20, ref gameEnd); // Уменьшаем здоровье игрока на 20 единиц
                }
            }
        }

        static bool IsEnemyPosition(int x, int y)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.X == x && enemy.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        static void SpawnEnemies(int count)
        {
            Random random = new Random();

            enemies = new Enemy[count];
            for (int i = 0; i < count; i++)
            {
                int x = random.Next(0, map.GetLength(0));
                int y = random.Next(0, map.GetLength(1));

                while (map[x, y] != ' ')
                {
                    x = random.Next(0, map.GetLength(0));
                    y = random.Next(0, map.GetLength(1));
                }

                enemies[i] = new Enemy(x, y);
            }
        }

        static void MoveEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.MoveRandomly(map);
            }
        }

        static void Main(string[] args)
        {
            try
            {
                ReadMap("map");
                SpawnEnemies(3); // Здесь указываем количество врагов

                while (!gameEnd)
                {
                    Console.Clear();
                    DrawMap();

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            MovePlayer(-1, 0);
                            break;
                        case ConsoleKey.DownArrow:
                            MovePlayer(1, 0);
                            break;
                        case ConsoleKey.LeftArrow:
                            MovePlayer(0, -1);
                            break;
                        case ConsoleKey.RightArrow:
                            MovePlayer(0, 1);
                            break;
                    }

                    MoveEnemies();
                }

                Console.Clear();
                DrawMap();
                Console.WriteLine("Game Over!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
