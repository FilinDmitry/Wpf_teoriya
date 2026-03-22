using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Filin.model
{
    internal class Game
    {
        Player player = new Player(Rand.randint(40, 60), Rand.randint(2, 4), Rand.randint(4, 6), 0.1);

        public void game()
        {
            start_menu();
            for (int i = 0; i < 10; i++)
            {
                gameplay();
                if (player.hp == 0) { return; }
            }
            boss();
            if (player.hp == 0) { return; }
            end();
        }

        public void start_menu() 
        {
            Console.WriteLine("'''Герой КИПФИН'''");
            Console.WriteLine("'''Версия 0.3'''");
            Console.WriteLine("Приготовьтесь к игре\n");
            wait();
        }

        public void boss()
        {
            Console.WriteLine("Ты чувствуешь дрожь по спине");
            Console.WriteLine("ОНО ПРЯМО ПЕРЕД ТОБОЙ");
            battle(GenEnemy.Choice_boss());
        }
        public void gameplay()
        {
            int deistv = Rand.randint(0, 1);
            switch (deistv)
            {
                case 0:
                    get_tools();
                    break;
                case 1:
                    Console.WriteLine("Сейчас махыч будет");
                    //Thread.Sleep(1000);
                    battle(GenEnemy.Choice_enemy());
                    if (player.hp <= 0) { end(); return; }
                    break;
            }
            wait();
        }
        public void battle(Enemy enemy)
        {
            Console.WriteLine($"Ваш противник {enemy.name}");
            while (true)
            {
                    Console.WriteLine("Игрок ударил");
                    //Thread.Sleep(500);
                    bool contrattack = Rand.chance(player.contr_chance);
                    if (contrattack)
                    {
                        Console.WriteLine("Персонаж успешно контратаковал");
                        enemy.take_damage(player.damage);
                        wait();
                        continue;
                    }
                    enemy.take_damage(player.damage);
                    if (enemy.hp <= 0)
                    {
                        Console.WriteLine("Этому бро надо было тренироваться, враг убит");
                        break;
                    }
                    player.take_damage(enemy.amount_of_damage());

                
                if (player.hp <= 0)
                {
                    Console.WriteLine("Враг убил тебя");
                    return;
                }

                wait();
                player.info();
                enemy.info();
            }
        }
        public void get_tools()
        {
            int a = Rand.randint(0, 3);
            Console.Clear();
            switch (a)
            {
                case 0:
                    player.Regeneration();
                    break;
                case 1:
                    player.new_weapon();
                    break;
                case 2:
                    player.new_defence();
                    break;
            }
        }
        public void end()
        {
            //Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Поздравляем с победой, следите за новостями: https://t.me/+2hokw8kg4fM4NGY6");
        }
        public void wait()
        {
            Console.WriteLine("Для продолжения нажмите enter");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
