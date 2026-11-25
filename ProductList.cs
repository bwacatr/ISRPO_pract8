
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract8
{
    class ProductList
    {
        public static ObservableCollection<Product> Products { get; } = new();
        public static ObservableCollection<CartItem> Cart { get; } = new();
    }
}
