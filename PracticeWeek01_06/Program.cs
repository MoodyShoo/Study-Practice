/* Задача 6
 * Легенда: Вы – теневой маг (можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний, которые вы можете использовать против Босса. 
 * Вы должны уничтожить босса и только после этого будет вам покой. 
 * Формально: перед вами босс, у которого есть определенное количество жизней и определенный ответный урон. 
 * У вас есть не менее 5-и заклинаний для нанесения урона боссу. 
 * Программа завершается только после смерти босса или смерти пользователя. 
 */

using Task_06;
using static System.Net.Mime.MediaTypeNames;

namespace Task_06
{
    class Program
    {
        static void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayRulesFrame("Игра: Победи Босса");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayRulesFrame("Условия");
            Console.ResetColor();
            Console.WriteLine("Максимальное HP у босса - 800\n"+
                              "Максимальное HP у игрока - 500\n"+
                              "Случайным образом выбирается игрок, делающий первый ход\n"+
                              "Наносимый боссом урон случайнен, также босс при низком здоровье может использовать спосбность: Лечение с задержкой на 3 такта");

            Console.WriteLine("--------------------------------------------------------------------------------------------------------\n");
            Console.ForegroundColor= ConsoleColor.Green;
            DisplayRulesFrame("Способности игрока");
            Console.ResetColor();
            Console.WriteLine("1 - Атакующий вихрь: Наносит 120 урона.\n" +
                              "2 - Лечебный ветер: Восстанавливает от 40 до 100 HP.\n" +
                              "3 - Защитное парирование: Снижает урон босса на 50% и наносит 10 ответного урона\n" +
                              "4 - Юный некромант: Призвает трёх мертвецов которые наносят от 10 до 50 урона боссу. Отнимает у игрока 20 HP\n" +
                              "5 - Запрет хода босса: Босс не может делать ход на протяжении двух тактов. Задержка на использование 5 тактов\n");
        }
        static void DisplayRulesFrame(string text)
        {
            int width = text.Length;
            Console.WriteLine(new string('-', width+4));
            Console.WriteLine($"| {text} |");
            Console.WriteLine(new string('-', width+4));
        }


        static void GameLoop(Player player, Boss boss, bool PlayerMove, Random rnd)
        {
            int tact = 1;
            int bossCooldown = 0;
            int playerCooldown = 0;
            int cooldown = 0;
            
            while (player.hp > 0 && boss.hp > 0)
            {
                Console.WriteLine($"Игровой такт № - {tact}");
                Console.WriteLine($"Осталось здоровья у игрока - {player.hp} HP\n" +
                                  $"Осталось здоровья у босса - {boss.hp} HP");

                if (PlayerMove)
                {
                    Console.WriteLine("Атакаует игрок");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            player.Attack(boss, 120);
                            break;
                        case 2:
                            player.Heal(rnd.Next(40, 101));
                            break;
                        case 3:
                            player.Defense();
                            break;
                        case 4:
                            player.Necro(boss, rnd);
                            break;
                        case 5:
                            if (playerCooldown <= 0)
                            {
                                cooldown = 2;
                                playerCooldown = 5;
                                Console.WriteLine("Игрок выбрал Запрет хода босса. Босс не может ходит 2 такта.");
                            } 
                            else 
                            {
                                Console.WriteLine("Вы выбрали Запрет хода босса во время куладануа.\n" +
                                                  "Вы пропускаете ход!");
                            }
                            break;

                    }
                }

                if (!PlayerMove && cooldown <= 0)
                {
                    Console.WriteLine("Атакаует босс");
                    if (boss.hp <= 30 && boss.hp > 0 && bossCooldown == 0)
                    {
                        boss.Heal(120);
                        bossCooldown = 3;
                    } 
                    else
                    {
                        boss.Attack(player, rnd.Next(10, 88));
                    }

                }

                if (player.hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("У вас закончились HP. Вы прогирали!");
                    Console.ResetColor();
                }

                if (boss.hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("У босса не осталось HP. Вы выиграли!");
                    Console.ResetColor();
                }

                ++tact;

                if (cooldown > 0)
                {
                    --cooldown;
                }
                if (playerCooldown > 0)
                {
                    --playerCooldown;
                }
                if (bossCooldown > 0)
                {
                    --bossCooldown;
                }

                Console.WriteLine();
                if (playerCooldown <= 0)
                {
                    PlayerMove = !PlayerMove;
                }
            }
        }


        static void Main(string[] args)
        {
            Random rnd = new Random();
            Player player = new Player(rnd.Next(100, 501));
            Boss boss = new Boss(rnd.Next(250, 801));
            DisplayRules();
            bool playerMove = rnd.Next(0, 2) == 0;
            GameLoop(player, boss, playerMove, rnd);
        }
    }
}
