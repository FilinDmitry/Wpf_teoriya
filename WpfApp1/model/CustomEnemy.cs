using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    class CustomEnemy : Enemy
    {
        public double crit_chance;
        public double freeze_chance;
        public bool ignore_defence;
        public int dop_defence;
        public CustomEnemy(string name, int hp, int defence, int damage, string img_source, double crit_chance = 0, double freeze_chance = 0, bool ignore_defence = false, int dop_defence = 0)
            : base(hp, defence, damage, img_source)
        {
            this.name = name;
            this.crit_chance = crit_chance;
            this.freeze_chance = freeze_chance;
            this.ignore_defence = ignore_defence;
        }

        public override void take_damage(int d)
        {
            base.take_damage(d - dop_defence);
        }

        public override Uron amount_of_damage()
        {
            Uron a = base.amount_of_damage();
            if (Rand.chance(freeze_chance))
            { a.freeze = true; }

            if (Rand.chance(crit_chance))
            {
                Console.WriteLine("Враг замахнулся посильнее");
                a.damage *= 2;   
            }
            return a;
        }


    }
}
