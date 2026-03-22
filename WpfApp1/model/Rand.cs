using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model

{

    internal class Rand
    {
        
        public static Random rand = new Random();

        public static int randint(int min, int max)
        {

            return rand.Next(min, max+1);
        }
        
        public static bool chance(double d)
        {
            return d >= rand.NextDouble();            
        }
    }

}
