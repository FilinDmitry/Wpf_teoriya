using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ISIP223_Filin.model
{
    internal class Player
    {
        public int hp;
        public int max_hp;
        public int defence;
        public int damage;
        public double contr_chance;

        public Player(int max_hp, int defence, int damage, double contr_chance)
        {
            hp = max_hp;
            this.max_hp = max_hp;
            this.defence = defence;
            this.damage = damage;
            this.contr_chance = contr_chance;
        }
        
        public void Regeneration()
        {
            hp = max_hp;
        }
        //
        public void take_damage(Uron uron, TextBlock log)
        {

            int d = uron.damage;
            
            if (Rand.chance(contr_chance))
            {
                log.Text += "\nИгрок увернулся";
                return;
            }
            if (!uron.ignore_def)
            {
                d -= Rand.randint(0, defence);
            }
            
            if (d <= 0)
            {
                log.Text += "\nИгрок не получил урона";
            }
            else 
            {
                hp -= d;
                log.Text += $"\nИгрок получил {d} урона";
                
            }
            if (uron.freeze)
            {
                log.Text += "\nВраг заморозил тебя";
                uron.freeze = false;
                take_damage(uron, log);
                
            }
        }
        //
        public string info()
        {
            return $"Здоровье персонажа {hp} \n";
        }
        public string player_hp()
        {
            return $"HP: {hp}/{max_hp}";
        }
        public string player_defence()
        {
            return $"defence: {defence}";
        }
        public string player_attack()
        {
            return $"damage: {damage}";
        }

        private string stats_def(int def)
        {
            return $"Ваша защита {defence}\tЗащита новой брони {def}";
        }
        private string stats_attack(int attack)
        {
            return $"Ваша атака {damage}\tАтака нового меча {attack}";
        }

        public bool new_weapon()
        {
            int n_damage = Rand.randint(0, 1) * 5 + Rand.randint(0, 1) * 4 + Rand.randint(0, 2) * 3 + Rand.randint(0, 1) + 1;
            MessageBoxResult dialogResult = MessageBox.Show($"Вам выпал новый меч, желаете его взять? \n{stats_attack(n_damage)}", "Выбор оружия", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                damage = n_damage;
                return true;
            }
            return false;
        }

        public bool new_defence()
        {
            int n_def = Rand.randint(0, 1) * 5 + Rand.randint(0, 1) * 4 + Rand.randint(0, 2) * 2 + Rand.randint(0, 1) + 1;
            MessageBoxResult dialogResult = MessageBox.Show($"Вам выпал новый доспех вы хотите взять его? \n{stats_def(n_def)}", "Выбор доспехов", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                defence = n_def;
                return true;
            }
            return false;
        }
        
    }
}
