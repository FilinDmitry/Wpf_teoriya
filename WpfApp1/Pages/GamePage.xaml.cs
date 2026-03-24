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
        int level = 1;
        Enemy cur_enemy = GenEnemy.Choice_enemy();
        Player player = new Player(Rand.randint(40, 60), Rand.randint(2, 4), Rand.randint(4, 6), 0.1);
        bool is_battle = true;
        public GamePage()
        {
            InitializeComponent();
            Logs.Text = $"Ты встретился с врагом {cur_enemy.name}";
            HPTB.Text = player.player_hp();
            AttackTB.Text = player.player_attack();
            DefenceTB.Text = player.player_defence();
            update_info();
        }

        private void AttackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!is_battle)
            {
                gameplay('a');
            }
            else battle('a');
        }

        private void DefendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!is_battle)
            {
                gameplay('d');
            }
            else battle('d');
        }


        public void boss(char choice)
        {
            cur_enemy = GenEnemy.Choice_boss();
            Logs.Text = $"Ты встретился с врагом {cur_enemy.name}";
            battle(choice);

        }

        public void gameplay(char choice)
        {
            if (level % 10 == 0)
            {
                boss(choice);
                is_battle = true;
                LevelTB.Text = $"Level: {level++}";
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
                    is_battle = true;
                    Logs.Text = $"Ты встретился с врагом {cur_enemy.name}";
                    update_info();
                    battle(choice);
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
                    Logs.Text = "Вы востановили здоровье";
                    break;
                case 1:
                    if (player.new_weapon())
                    {
                        AttackTB.Text = player.player_attack();
                    }
                    Logs.Text = "Вы нашли оружие";
                    break;
                case 2:
                    if (player.new_defence())
                    {
                        DefenceTB.Text = player.player_defence();
                    }
                    Logs.Text = "Вы нашли броню";
                    break;
            }
        }
        
        private void battle(char choice)
        {
            
            bool contrattack = Rand.chance(player.contr_chance);
            if (choice == 'a')
            {
                cur_enemy.take_damage(player.damage);
            }
            else if (contrattack)
            {
                Logs.Text += ("\nПерсонаж успешно контратаковал");
                cur_enemy.take_damage(player.damage);
                update_info();
                return;
            }
            
            if (cur_enemy.hp <= 0)
            {
                Logs.Text += ("\nЭтому бро надо было тренироваться, враг убит");
                EnemyImg.Source = new BitmapImage(new Uri("/images/lose.jpg", UriKind.Relative));
                EnemyImg.ToolTip = "Тут мог быть труп врага, но РОСКОМНАДЗОР";
                is_battle = false;
                EnemyHP.Text = cur_enemy.hp_info();
                return;
            }
            player.take_damage(cur_enemy.amount_of_damage());
            update_info();
            if (player.hp <= 0)
            {
                NavigationService.Navigate(new EndPage());
                return;
            }
              
                
        }
            
        private void update_info()
        {
            EnemyImg.Source = new BitmapImage(new Uri(cur_enemy.img_source, UriKind.Relative));
            EnemyImg.ToolTip = cur_enemy.info();
            EnemyHP.Text = cur_enemy.hp_info();
            HPTB.Text = player.player_hp();
        }

        

        
    }
}
