using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    abstract internal class EnemyFabric
    {
        abstract public Enemy Create();
    }

    class MagicFabric : EnemyFabric
    {
        public override Enemy Create()
        {
            return new Magic(Rand.randint(10, 15), Rand.randint(2, 3), Rand.randint(3, 5), 0.2);
        }
    }

    class GoblinFabric : EnemyFabric
    {
        public override Enemy Create()
        {
            return new Goblin(Rand.randint(8, 12), Rand.randint(3, 4), Rand.randint(4, 6), 0.2);
        }
    }

    class SkeletonFabric : EnemyFabric
    {
        public override Enemy Create()
        {
            return new Skeleton(Rand.randint(13, 18), Rand.randint(1, 3), Rand.randint(2, 4));
        }
    }

    class SlimeFabric : EnemyFabric
    {
        public override Enemy Create()
        {
            return new Slime(Rand.randint(15, 22), Rand.randint(2, 3), Rand.randint(1, 4));
        }
    }

    

    

    
    

    
    
}
