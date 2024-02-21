using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Boss
    {
        public int Hp {  get; set; }
        public int MaxHp = 800;

        public Boss(int hp)
        {
            this.Hp = hp;
        }

        public void Attack(Player player, int damage)
        {
            if (!player.Def)
            {
                player.ReciveDamage(damage);
            } 
            else
            {
                damage = damage - damage * (damage / 100);
                player.ReciveDamage(damage);
                ReciveDamage(10);
                player.Def = false;
            }
        }

        public void Heal(int points)
        {
            Hp += points;
            Console.WriteLine($"Босс использовал лечение на {points} HP.");
        }

        public void ReciveDamage(int damage)
        {
            Hp -= damage;
            Console.WriteLine($"Игрок атакует босса на {damage} ед. урона.");
        }
    }
}
