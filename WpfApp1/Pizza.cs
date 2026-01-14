using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static internal class Pizza
    {
        public static string name = "";
        public static int price = 0;
        public static int cheese = 0;
        public static int becon = 0;
        public static int mushroom = 0;
        public static string size = "дефолт";
        

        static public int summa_1()
        {
            return price;
        }

        static public int summa_2()
        {
            double mod = 1;
            switch (size)
            {
                case "Маленькая * 1":
                    mod = 1;
                    break;
                case "Средняя * 1.2":
                    mod = 1.2;
                    break;
                case "Большая * 1.4":
                    mod = 1.4;
                    break;
            }
            return (int)(price * mod + cheese * 50 + becon * 80 + mushroom * 40);
        }
        static public string zakaz()
        {
            return $"{name}, цена = {summa_2()}, size = {size}, доп сыр = {cheese}, доп бекон = {becon}, доп грибы = {mushroom}";
        }
    };

    
}
