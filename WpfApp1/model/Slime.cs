using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ISIP223_Filin.model
{
    class Slime : Enemy
    {
        public int dop_defence = 2;
        public Slime(int hp, int defence, int damage, string img_source) : base(hp, defence, damage, img_source)
        {
            name = "Слайм";
        }

        public override void take_damage(int d, TextBlock log)
        {
            base.take_damage(d - dop_defence, log);
        }
    }

}
