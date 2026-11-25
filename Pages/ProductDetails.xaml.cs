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

namespace pract8.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Page
    {
        Product Product { get; set; }
        public ProductDetails(Product product)
        {
            InitializeComponent();
            Product = product;
            DataContext = Product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            var currentProduct = Product;

            if (currentProduct != null)
            {
                var existingItem = ProductList.Cart.FirstOrDefault(b => b.Product == currentProduct);
                if (existingItem != null)
                {
                    if (int.TryParse(txtAmount.Text, out int result))
                    {
                        
                        
                        existingItem.Amount += result;

                        MessageBox.Show($"«{currentProduct.Name}, {result}» добавлен в корзину.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Введите кол-во товара", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
                else
                {
                    if (int.TryParse(txtAmount.Text, out int result))
                    {


                        ProductList.Cart.Add(new CartItem(currentProduct, result));

                        MessageBox.Show($"«{currentProduct.Name}, {result}» добавлен в корзину.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                }
                
            }
        }
    }
}
