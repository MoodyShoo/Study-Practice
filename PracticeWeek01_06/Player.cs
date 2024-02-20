using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_06
{
    class Player
    {
        public int hp { get; set; }
        public int maxHp = 500;
        public bool def = false;
        public Player(int hp)
        {
            this.hp = hp;
        }

        public void Heal(int heal)
        {
            if (hp >= maxHp || hp + heal >= maxHp)
            {
                hp = maxHp;
            } 
            else
            {
                hp += heal;
                
            }
            Console.WriteLine($"Игрок использовал Лечебный ветер, восстановив своё здоровье на {heal}.");
        }
        public void Attack(Boss boss, int damage)
        {
            boss.ReciveDamage(damage);
        }
        public void Defense()
        {
            def = true;
            Console.WriteLine("Игрок использовал Защитное парирование.");
        }
        public void Necro(Boss boss, Random rnd)
        {
            Console.WriteLine("Игрок использовал Юный некромант. -20 HP.");
            boss.ReciveDamage(rnd.Next(10, 51));
            boss.ReciveDamage(rnd.Next(10, 51));
            boss.ReciveDamage(rnd.Next(10, 51));
            hp -= 20;
        }
        public void ReciveDamage(int damage)
        {
            hp -= damage;
            Console.WriteLine($"Босс атакует игрока на {damage} ед. урона.");
        }
    }
}
