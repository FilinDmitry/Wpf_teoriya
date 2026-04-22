using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ProductDisplayModel
    {
        public Product product { get; set; }
        public int count { get; set; } = 1; 

        private string Pricer()
        {
            if (product.Discount == 0 || product.IsFreezeDiscount)
            {
                return string.Empty;
            }
            else return product.Price.ToString();
        }

        private string GetColor()
        {
            if (product.Discount < 15 || product.IsFreezeDiscount)
            {
                return "White";
            }
            else return "LightGreen";
        }

        public decimal Price => product.Price * (100 - product.Discount * Convert.ToInt32(!product.IsFreezeDiscount))/100;
        public string PriceNoDisc => Pricer();

        public string Color => GetColor();
    }
}
