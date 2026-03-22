using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    class Skeleton : Enemy
    {
        public Skeleton(int hp, int defence, int damage) : base(hp, defence, damage)
        {
            name = "Скелет";
        }

        public override Uron amount_of_damage()
        {
            Uron a = base.amount_of_damage();
            a.ignore_def = true;
            return a;
        }
    }
}
