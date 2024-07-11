using Lab04_OOP.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_OOP.Memento
{
    public class ProductMemento
    {
        public ObservableCollection<Product> Products { get; private set; }

        public ProductMemento(ObservableCollection<Product> Products)
        {
            this.Products = new ObservableCollection<Product>(Products);
        }
    }
}
