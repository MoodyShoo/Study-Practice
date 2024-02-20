using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Boss
    {
        public int hp {  get; set; }
        public int maxHp = 800;

        public Boss(int hp)
        {
            this.hp = hp;
        }

        public void Attack(Player player, int damage)
        {
            if (!player.def)
            {
                player.ReciveDamage(damage);
            } 
            else
            {
                damage = damage - damage * (damage / 100);
                player.ReciveDamage(damage);
                ReciveDamage(10);
                player.def = false;
            }
        }

        public void Heal(int points)
        {
            hp += points;
            Console.WriteLine($"Босс использовал лечение на {points} HP.");
        }

        public void ReciveDamage(int damage)
        {
            hp -= damage;
            Console.WriteLine($"Игрок атакует босса на {damage} ед. урона.");
        }
    }
}
