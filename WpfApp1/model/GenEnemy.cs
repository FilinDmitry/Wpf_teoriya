using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    static internal class GenEnemy
    {
        static List<EnemyFabric> list = new List<EnemyFabric>
            {   new MagicFabric(),
                new SkeletonFabric(),
                new GoblinFabric(),
                new SlimeFabric()
            };
        
        static List<Enemy> boss_list = new List<Enemy>
        {
            new CustomEnemy("Перминов", 30, 5, 5, "/images/Perminov.png",  crit_chance: 0.6),
            new CustomEnemy("Демкина", 300, 10, 10, "/images/Porche.jpg",  crit_chance: 0.5, ignore_defence: true, freeze_chance: 0.5),
            new CustomEnemy("Скелет с редбуллом", 40, 3, 6, "/images/BossSkelet.jpg",  ignore_defence: true),
            new CustomEnemy("Фанат 1С", 25, 2, 10, "/images/1С.jpg",  freeze_chance: 0.1, crit_chance: 0.25)
        };
        public static Enemy Choice_enemy()
        {
            int c = list.Count();
            return list[Rand.randint(0, c-1)].Create();
        }
        public static Enemy Choice_boss()
        {
            int c = boss_list.Count();
            return boss_list[Rand.randint(0, c - 1)];


        }
    }
}
