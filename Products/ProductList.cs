using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Products
{
    internal class ProductList : ICloneable, IEnumerable<Product>, IComparer<Product>

    {/*Class  Product (назву, дату, ціну)  

Створюєте вашу колекцію продуктів: стестуєте  foreach,  клонування, різні сортировки за назвою, датою, ціною*/
        public List<Product> products;
        public ProductList()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                products.Add(product);
            }
        }
        public void RemoveProduct(Product product)
        {
            if (product != null)
            {
                products.Remove(product);
            }
        }
        public void DisplayProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        public Product GetProduct(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                return products[index];
            }
            throw new IndexOutOfRangeException("Index is out of range.");
        }

        public object Clone()
        {
            ProductList clonedList = new ProductList();
            foreach (var product in products)
            {
                clonedList.AddProduct((Product)product.Clone());
            }
            return clonedList;
        }
        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Compare(Product? x, Product? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            // Sort by name first, then by date, and finally by price
            int nameComparison = x.name.CompareTo(y.name);
            if (nameComparison != 0) return nameComparison;
            int dateComparison = x.date.CompareTo(y.date);
            if (dateComparison != 0) return dateComparison;
            return x.price.CompareTo(y.price);
        }

        //cортировки
        public void Sort(IComparer<Product> comparer)
        {
            products.Sort(comparer);
        }
        public Comparison<Product> GetDateComparison()
        {
            return (x, y) => x.date.CompareTo(y.date);
        }

        public Comparison<Product> GetNameComparison()
        {
            return (x, y) => x.name.CompareTo(y.date);
        }

        public Comparison<Product> GetPriceComparison()
        {
            return (x, y) => x.price.CompareTo(y.date);
        }


    }


}
