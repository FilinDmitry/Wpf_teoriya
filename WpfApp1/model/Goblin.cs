using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    class Goblin : Enemy
    {
        public double crit_chance;
        public Goblin(int hp, int defence, int damage, double crit_chance) : base(hp, defence, damage)
        {
            name = "Гоблин";
            this.crit_chance = crit_chance;
        }
        public override Uron amount_of_damage()
        {
            if (Rand.chance(crit_chance))
            {
                Console.WriteLine("Враг замахнулся посильнее");
                Uron a = base.amount_of_damage();
                a.damage *= 2;
                return a;
            }
            else { return base.amount_of_damage(); }

        }

    }
}
