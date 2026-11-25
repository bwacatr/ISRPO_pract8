
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {

        public ObservableCollection<Product> Products { get; set; }
        public Product? SelectedProduct { get; set; }

        private ObservableCollection<Product> _allProducts;

        public Catalog()
        {
            if (ProductList.Products.Count == 0)
            {
                ProductList.Products.Add(new Product()
                {
                    Name = "Игровой ноутбук",
                    Description = "Мощный игровой ноутбук с производительной видеокартой, " +
                    "плавным экраном и эффективным охлаждением.",
                    Price = 100000,
                    Brand = "MSI",
                    Category = "Ноутбук",
                    PicPath = new BitmapImage(new Uri("pack://application:,,,/pract8;component/Images/Laptop.png", UriKind.Absolute))
                });

                ProductList.Products.Add(new Product()
                {
                    Name = "Игровой компьютер",
                    Description = "Производительный игровой ПК с мощной видеокартой, " +
                    "быстрым процессором и продуманным охлаждением",
                    Price = 150000,
                    Brand = "Ardor Gaming",
                    Category = "Компьтер",
                    PicPath = new BitmapImage(new Uri("pack://application:,,,/pract8;component/Images/Computer.png", UriKind.Absolute))
                });

                ProductList.Products.Add(new Product()
                {
                    Name = "Телефон",
                    Description = "Современный смартфон с ярким безрамочным дисплеем, " +
                    "мощным процессором и продвинутой камерой",
                    Price = 60000,
                    Brand = "Apple",
                    Category = "Телефон",
                    PicPath = new BitmapImage(new Uri("pack://application:,,,/pract8;component/Images/Phone.png", UriKind.Absolute))
                });

                ProductList.Products.Add(new Product()
                {
                    Name = "Игровая мышка",
                    Description = "Эргономичная игровая мышь с высокоточным оптическим сенсором, " +
                    "мгновенным откликом переключателей и настраиваемой RGB-подсветкой",
                    Price = 5000,
                    Brand = "Logitech",
                    Category = "Периферия",
                    PicPath = new BitmapImage(new Uri("pack://application:,,,/pract8;component/Images/Mouse.png", UriKind.Absolute))
                });

                ProductList.Products.Add(new Product()
                {
                    Name = "Игровая клавиатура",
                    Description = "Надёжная игровая клавиатура с отзывчивыми механическими переключателями",
                    Price = 7000,
                    Brand = "Aula",
                    Category = "Периферия",
                    PicPath = new BitmapImage(new Uri("pack://application:,,,/pract8;component/Images/Keyboard.png", UriKind.Absolute))
                });
            }

            InitializeComponent();

            _allProducts = new ObservableCollection<Product>(ProductList.Products);
            Products = new ObservableCollection<Product>(ProductList.Products);

            DataContext = this;
        }

        public Catalog(string productName) : this()
        {
            

           


            var foundProducts = Products.Where(p => p.Name.ToLower().Contains(productName)).ToList();

            if (foundProducts.Any())
            {
                UpdateList(foundProducts);
            }

        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            
            var button = sender as Button;

            var product = button?.DataContext as Product;

            if (product != null)
            {
                var existingItem = ProductList.Cart.FirstOrDefault(b => b.Product == product);
                if (existingItem != null)
                {
                    existingItem.Amount++;
                }
                else
                {
                    ProductList.Cart.Add(new CartItem(product));
                }
                MessageBox.Show($"«{product.Name}» добавлен в корзину.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            if (GroupComboBox.SelectedIndex == 0)
            {
                var sorted = Products.OrderBy(p => p.Price).ToList();
                UpdateList(sorted);
            }
            else if (GroupComboBox.SelectedIndex == 1)
            {
                var sorted = Products.OrderBy(p => p.Brand).ToList();
                UpdateList(sorted);
            }
            else
            {
                var sorted = Products.OrderBy(p => p.Category).ToList();
                UpdateList(sorted);
            }
            
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Products.Clear();
            foreach (var p in _allProducts) Products.Add(p);
        }

        

        private void UpdateList(List<Product> newList)
        {
            Products.Clear();
            foreach (var p in newList) Products.Add(p);
        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListView, e.OriginalSource as DependencyObject) as ListViewItem;
            if (item == null)
            {
                (sender as ListView).SelectedItem = null;
            }
        }

        private void ProductListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedProduct == null) return;
            NavigationService.Navigate(new ProductDetails(SelectedProduct));
        }
    }
}
