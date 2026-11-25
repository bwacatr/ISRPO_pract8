
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract8
{
    public class CartItem : INotifyPropertyChanged
    {
        private int _amount;
        public Product Product { get; set; }
        public int Amount
        {
            get => _amount;
            set
            {
                if (value < 1) value = 1;
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        public int TotalPrice => Product.Price * Amount;
        public CartItem(Product product, int amount = 1)
        {
            Product = product;
            _amount = amount;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
