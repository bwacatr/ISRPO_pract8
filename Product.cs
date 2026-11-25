using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace pract8
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string name;
        private int price;
        private string description;
        private string category;
        private string brand;
        private ImageSource picPath;

        public string Name
        { 
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(nameof(Price)); }
        }

        public string Description
        { 
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }
        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(nameof(Category)); }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; OnPropertyChanged(nameof(Brand)); }
        }

        public ImageSource PicPath
        {
            get { return picPath; }
            set { picPath = value; OnPropertyChanged(nameof(PicPath)); }
        }
    }
}
