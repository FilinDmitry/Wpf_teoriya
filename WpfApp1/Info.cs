using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    static internal class Info
    {
        /*public static List<Tovar> cart = new List<Tovar>();
        public static MainWindow MW;

        public static void summa()
        {
            if (MW != null)
            {
                decimal price = cart.Sum(item => item.Price);
                
                MW.Cena.Text = "Сумма: " + price.ToString();
            }
        }

        public static string text_info()
        {
            string text = "";
            foreach (Tovar tovar in cart)
            {
                text += $"{tovar.Name} {tovar.Price} \n";
            }
            return text;
        }

        public static void write_data(string FIO, string Adres, string email)
        {
            int kol = Core.Context.Order.Count() + 1;
            Order order = new Order()
            {
                ID = kol,
                FIO = FIO,
                Adres = Adres,
                email = email,
            };
            Core.Context.Order.Add(order);

            foreach (Tovar tovar in cart)
            {
                Order_Tovar order_Tovar = new Order_Tovar()
                {
                    Order = kol,
                    Tovar = tovar.ID
                };
                Core.Context.Order_Tovar.Add(order_Tovar);
            }
            Core.Context.SaveChanges();
        }
        */
    };
        
    
}
