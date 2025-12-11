using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    static internal class PriceCore
    {
        static public int price_ = 0;
        static public int Price { get { return price_; } set { price_ = value; } } //тут был set но я его сломал
        static public List<CheckBox> lst { get; set; } = null;
        static public void price()
        {
            switch (Info.model)
            {
                case "Седан (400 000)":
                    Price = 400000;
                    break;
                case "Кроссовер (1 000 000)":
                    Price = 1000000;
                    break;
                case "Купе (600 000)":
                    Price = 600000;
                    break;
                case "Танк (25 000 000)":
                    Price = 25000000;
                    break;
                case "Джип (1 500 000)":
                    Price = 1500000;
                    break;
            }
            switch (Info.engine)
            {
                case "Электрический (x 2)":
                    Price *= 2;
                    break;
                case "Турбореактивный (x 7)":
                    Price *= 7;
                    break;
            }
            Info.MVobj.Itog.Text = "Стоимость: " + Price.ToString();
            
        }
        static public string options()
        {
            price();
            string s = "Выбранные опции:\n";
            for (int i = 0; i < PriceCore.lst.Count; i++)
            {
                
                CheckBox cb = PriceCore.lst[i];
                if (cb.IsChecked == true)
                {
                    s += cb.Content.ToString() + "\n";
                    if (i == 0)
                    {
                        Price += 100000;
                    }
                    if (i == 1)
                    {
                        Price += 1000000;
                    }
                    if (i == 2)
                    {
                        Price += 300000;
                    }
                    if (i == 3)
                    {
                        Price *= 3;
                    }
                    if (i == 4)
                    {
                        Price *= 2;
                    }
                }
            }
            Info.MVobj.Itog.Text = "Стоимость: " + Price.ToString();
            return s;
        }
    }


    
}
