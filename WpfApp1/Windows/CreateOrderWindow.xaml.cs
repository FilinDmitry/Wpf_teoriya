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
using System.Xml.Linq;
using WpfApp1.Pages;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        List<ProductDisplayModel> productsLst;
        NavigationService navigation;
        public CreateOrderWindow(List<ProductDisplayModel> products, NavigationService n)
        {
            navigation = n;
            InitializeComponent();
            productsLst = products;
            Calend.DisplayDateStart = DateTime.Today;
            Calend.DisplayDateEnd = DateTime.Today.AddDays(7);
            Calend.SelectedDate = DateTime.Today.AddDays(1);
            Oplata.ItemsSource = Core.Context.PaymentType.Select(i => i.Name).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Oplata.SelectedItem == null)
            {
                MessageBox.Show("Выбирите тип оплаты");
                return;
            }
            PaymentType payment = Core.Context.PaymentType.First(i => i.Name == Oplata.SelectedItem.ToString());
            GetWindow(this).Close();
            Order order = new Order()
            {
                Date = (DateTime)Calend.SelectedDate,
                UserID = Authorization.cur_user.ID,
                PaymentType = payment.ID,
                Price = productsLst.Sum(i => i.Price * i.count),
            };
            Core.Context.Order.Add(order);
            Core.Context.SaveChanges();
            foreach (ProductDisplayModel p in productsLst)
            {
                OrderProduct orderProduct = new OrderProduct()
                {
                    OrderID = order.ID,
                    ProductID = p.product.ID,
                    Amount = p.count
                };
                Core.Context.OrderProduct.Add(orderProduct);

            }
            Core.Context.SaveChanges();
            MessageBox.Show("Заказ успешно создан");
            navigation.Navigate(new StartPage());
        }
    }
}
