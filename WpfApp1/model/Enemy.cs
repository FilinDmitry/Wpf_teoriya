using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    abstract class Enemy
    {
        public string name;
        public int hp;
        public int max_hp;
        public int defence;
        public int damage;
        public bool is_alive = true;
        public bool freeze = false;
        public bool ignore_def = false;
        

        public Enemy(int hp, int defence, int damage)
        {
            this.hp = hp;
            max_hp = hp;
            this.defence = defence;
            this.damage = damage;
        }

        public void info()
        {
                Console.WriteLine($"Здоровье {name} = {hp}");
        }
        public virtual void take_damage(int d)
        {
            d -= Rand.randint(0, defence);
            if (d <= 0)
            {
                Console.WriteLine("Враг не получил урона");
            }
            else
            {
                Console.WriteLine($"Враг получил {d} урона");
                hp -= d;
                if (hp <= 0)
                { is_alive = false; }
            }
        }

        public virtual Uron amount_of_damage()
        {
            return new Uron(damage);
        }


    }
}
