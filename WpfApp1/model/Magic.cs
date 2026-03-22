using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    class Magic : Enemy
    {
        public double freeze_chance;
        public Magic(int hp, int defence, int damage, double freeze_chance) : base(hp, defence, damage)
        {
            name = "Маг";
            this.freeze_chance = freeze_chance;
        }

        public override Uron amount_of_damage()
        {
            Uron a = base.amount_of_damage();
            if (Rand.chance(freeze_chance))
            { a.freeze = true; }
            return a;
        }


    }
}
