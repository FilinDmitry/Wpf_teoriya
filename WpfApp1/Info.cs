using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static internal class Info
    {
        public static List<Tovar> cart = new List<Tovar>();
        public static MainWindow MW;

        public static void summa()
        {
            if (MW != null)
            {
                decimal price = cart.Sum(item => item.Price);
                
                MW.Cena.Text = "Сумма: " + price.ToString();
            }
            }
    };

    
}
