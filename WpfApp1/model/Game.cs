using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ISIP223_Filin.model
{
    internal class Game
    {
        static TextBlock logs;
        int level = 0;
        Enemy cur_enemy;
        public Player player = new Player(Rand.randint(40, 60), Rand.randint(2, 4), Rand.randint(4, 6), 0.1);

        public void game(TextBlock logs_tb)
        {
            logs = logs_tb;
            cur_enemy = GenEnemy.Choice_enemy();
            logs.Text = $"Ты встретился с врагом {cur_enemy.name}";
            //while (true)
            {

                //gameplay();
                level++;
                if (level % 10 == 0) 
                {
                    level++;
                    boss();
                }
                //if (player.hp == 0) { break; }
            }
            
            if (player.hp == 0) { return; }
            end();
        }

        public void boss()
        {
            cur_enemy = GenEnemy.Choice_boss();
            logs.Text = $"Ты встретился с боссом { cur_enemy.name}";
            //battle(cur_enemy);
            
        }
        public void gameplay()
        {
            int deistv = Rand.randint(0, 2);
            switch (deistv)
            {
                case 0:
                    //get_tools();
                    break;
                case 1:
                    cur_enemy = GenEnemy.Choice_enemy();
                    logs.Text = $"Ты встретился с врагом {cur_enemy.name}";
                    //battle(cur_enemy);
                    if (player.hp <= 0) { end(); return; }
                    break;
            }
        }
        /*public void battle(Enemy enemy)
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
                player.info();
                enemy.info();
            }
        }
        */
        public void get_tools()
        {
            int a = Rand.randint(0, 3);
            
            switch (a)
            {
                case 0:
                    player.Regeneration();
                    logs.Text += "\nВы востановили здоровье";
                    break;
                case 1:
                    player.new_weapon();
                    logs.Text += "\nВы нашли оружие";
                    break;
                case 2:
                    player.new_defence();
                    logs.Text += "\nВы нашли броню";
                    break;
            }
        }
        public void end()
        {
            //Thread.Sleep(1500);
            //Console.Clear();
            Console.WriteLine("Поздравляем с победой, следите за новостями: https://t.me/+2hokw8kg4fM4NGY6");
        }
        
    }
}
