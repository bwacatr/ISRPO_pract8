using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace pract8.Pages
{
    /// <summary>
    /// Логика взаимодействия для BucketList.xaml
    /// </summary>
    public partial class BucketList : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string prop) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


        private decimal _discountPercent = 0;
        public ObservableCollection<CartItem> CartItems { get; set; }
        public CartItem? SelectedItem { get; set; }

        private int _totalSum;
        public int TotalSum
        {
            get => _totalSum;
            set
            {
                _totalSum = value;
                OnPropertyChanged(nameof(TotalSum));
            }
        }

        public BucketList()
        {
            InitializeComponent();

            CartItems = ProductList.Cart;
            DataContext = this;
            UpdateTotalSum();
        }

        private void UpdateTotalSum()
        {
            int rawTotal = CartItems.Sum(x => x.TotalPrice);
            TotalSum = (int)(rawTotal * (1 - _discountPercent / 100m));
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Catalog());
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null) 
            {
                var item = CartItems.Remove(SelectedItem);
                UpdateTotalSum();
            }
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
            if (CartItems.Count < 1)
            {
                MessageBox.Show("Выберите товар для оформления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show($"Заказ на сумму {TotalSum} оформлен.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Increase(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.DataContext as CartItem;

            if (item != null) 
            {
                item.Amount++;
                UpdateTotalSum();
            }

            
        }

        private void Decrease(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button?.DataContext as CartItem;

            if (item != null)
            {
                if (item.Amount > 1)
                {
                    item.Amount--;
                    UpdateTotalSum();
                }
                else
                {
                    CartItems.Remove(item);
                    UpdateTotalSum();
                }
                
            }
        }

        private void PromocodeBtn(object sender, RoutedEventArgs e)
        {
            if (txtPromocode.Text == "SALE10")
            {
                _discountPercent = 10;
                MessageBox.Show("Скидка 10%.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (txtPromocode.Text == "SALE20")
            {
                _discountPercent = 20;
                MessageBox.Show("Скидка 20%.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _discountPercent = 0;
                MessageBox.Show("Неверный промокод.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            UpdateTotalSum();
        }
    }
}
