using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    internal class Uron
    {
        public bool freeze = false;
        public bool ignore_def = false;
        public int damage;

        public Uron(int damage)
        { this.damage = damage; }
    }
    

}
