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
        public int Hp { get; set; }
        public int MaxHp = 500;
        public bool Def = false;
        public Player(int hp)
        {
            this.Hp = hp;
        }

        public void Heal(int heal)
        {
            if (Hp >= MaxHp || Hp + heal >= MaxHp)
            {
                Hp = MaxHp;
            } 
            else
            {
                Hp += heal;
                
            }
            Console.WriteLine($"Игрок использовал Лечебный ветер, восстановив своё здоровье на {heal}.");
        }
        public void Attack(Boss boss, int damage)
        {
            boss.ReciveDamage(damage);
        }
        public void Defense()
        {
            Def = true;
            Console.WriteLine("Игрок использовал Защитное парирование.");
        }
        public void Necro(Boss boss, Random rnd)
        {
            Console.WriteLine("Игрок использовал Юный некромант. -20 HP.");
            boss.ReciveDamage(rnd.Next(10, 51));
            boss.ReciveDamage(rnd.Next(10, 51));
            boss.ReciveDamage(rnd.Next(10, 51));
            Hp -= 20;
        }
        public void ReciveDamage(int damage)
        {
            Hp -= damage;
            Console.WriteLine($"Босс атакует игрока на {damage} ед. урона.");
        }
    }
}
