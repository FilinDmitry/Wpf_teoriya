using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    internal class Player
    {
        public int hp;
        public int max_hp;
        public int defence;
        public int damage;
        public double contr_chance;

        public Player(int max_hp, int defence, int damage, double contr_chance)
        {
            hp = max_hp;
            this.max_hp = max_hp;
            this.defence = defence;
            this.damage = damage;
            this.contr_chance = contr_chance;
        }
        public void Regeneration()
        {
            Console.WriteLine("Вам выпало зелье лечения от поноса");
            hp = max_hp;
            Console.WriteLine("Здоровье восстановлено");
            Console.WriteLine($"Здоровье персонажа {hp}");
        }
        public void take_damage(Uron uron)
        {

            int d = uron.damage;
            
            if (Rand.chance(contr_chance))
            {
                Console.WriteLine("Игрок увернулся");
                return;
            }
            if (!uron.ignore_def)
            {
                d -= Rand.randint(0, defence);
            }
            
            if (d <= 0)
            {
                Console.WriteLine("Игрок не получил урона");
            }
            else 
            {
                hp -= d;
                Console.WriteLine($"Игрок получил {d} урона");
                
            }
            if (uron.freeze)
            {
                Console.WriteLine("Враг заморозил тебя");
                uron.freeze = false;
                take_damage(uron);
                
            }
        }

        public void info()
        {
            Console.WriteLine($"Здоровье персонажа {hp} \n");
        }

        public void stats_def(int def)
        {
            Console.WriteLine($"Ваша защита {defence}\tЗащита новой брони {def}");
        }
        public void stats_attack(int attack)
        {
            Console.WriteLine($"Ваша атака {damage}\tАтака нового меча {attack}");
        }

        public void new_weapon()
        {
            Console.WriteLine("Вам выпал новый меч, желаете его взять? (1-да, 0-нет)");
            int n_damage = Rand.randint(0, 1) * 5 + Rand.randint(0, 1) * 4 + Rand.randint(0, 2) * 3 + Rand.randint(0, 1) + 1;
            stats_attack(n_damage);
            string s = Console.ReadLine();
            if (s == "1")
            {
                damage = n_damage;
            }
        }

        public void new_defence()
        {
            Console.WriteLine("Вам выпал новая броня, хотите ее экипировать? (1-да, 0-нет)");
            int n_def = Rand.randint(0, 1) * 5 + Rand.randint(0, 1) * 4 + Rand.randint(0, 2) * 2 + Rand.randint(0, 1) + 1;
            stats_def(n_def);
            string s = Console.ReadLine();
            if (s == "1")
            {
                defence = n_def;
            }
        }
        
    }
}
