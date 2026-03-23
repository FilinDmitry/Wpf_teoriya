using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ISIP223_Filin.model;
namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        int level = 0;
        Enemy cur_enemy;
        Player player = new Player(Rand.randint(40, 60), Rand.randint(2, 4), Rand.randint(4, 6), 0.1);
        bool is_battle = false;
        public GamePage()
        {

            InitializeComponent();
            Enemy e = GenEnemy.Choice_enemy();
            EnemyImg.Source = new BitmapImage(new Uri(e.img_source, UriKind.Relative));
            HPTB.Text = player.player_hp();
            AttackTB.Text = player.player_attack();
            DefenceTB.Text = player.player_defence();
            
        }

        private void AttackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!is_battle)
            {
                gameplay();
            }
        }

        private void DefendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!is_battle)
            {
                gameplay();
            }
        }


        public void boss()
        {
            cur_enemy = GenEnemy.Choice_boss();
            Logs.Text = $"Ты встретился с боссом {cur_enemy.name}";
            //battle(cur_enemy);

        }

        public void gameplay()
        {
            if (level == 10)
            { 
                boss();
                level++;
                return;    
            }
            LevelTB.Text = $"Level: {++level}";
            int deistv = Rand.randint(0, 1);
            switch (deistv)
            {
                case 0:
                    get_tools();
                    break;
                case 1:
                    cur_enemy = GenEnemy.Choice_enemy();
                    Logs.Text = $"Ты встретился с врагом {cur_enemy.name}";
                    //battle(cur_enemy);
                    if (player.hp <= 0) { return; }
                    break;
            }
        }

        public void get_tools()
        {
            int a = Rand.randint(0, 3);

            switch (a)
            {
                case 0:
                    player.Regeneration();
                    Logs.Text += "\nВы востановили здоровье";
                    break;
                case 1:
                    if (player.new_weapon())
                    {
                        AttackTB.Text = player.player_attack();
                    }
                    Logs.Text += "\nВы нашли оружие";
                    break;
                case 2:
                    if (player.new_defence())
                    {
                        DefenceTB.Text = player.player_defence();
                    }
                    Logs.Text += "\nВы нашли броню";
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
          

        

        
    }
}
