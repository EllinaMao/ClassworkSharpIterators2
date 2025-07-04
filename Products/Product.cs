using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{/*Class  Product (назву, дату, ціну)  

Створюєте вашу колекцію продуктів: стестуєте  foreach,  клонування, різні сортировки за назвою, датою, ціною*/
    internal class Product : ICloneable, IComparable<Product>, IComparable, IComparer<Product>, IEnumerable<Product>
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public double price { get; set; }

        public Product()
        {
            name = "Unknown";
            date = DateTime.Now;
            price = 0.0;
        }
        public Product(string name, DateTime date, double price)
        {
            this.name = name;
            this.date = date;
            this.price = price;
        }

        public override string ToString()
        {
            return $"Product: {name}, Date: {date.ToShortDateString()}, Price: {price}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Product other)
            {
                return this.name == other.name && this.date == other.date && this.price == other.price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name?.GetHashCode() ?? 0, date.GetHashCode(), price.GetHashCode());
        }
        public object Clone()
        {
            return new Product(name, date, price);
        }
        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return this.name.CompareTo(other.name);
        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (obj is Product otherProduct)
            {
                return this.CompareTo(otherProduct);
            }
            throw new ArgumentException("Object is not a Product", nameof(obj));
        }
        public int Compare(Product? x, Product? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.name.CompareTo(y.name);
        }

        public IEnumerator<Product> GetEnumerator()
        {
            yield return this;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public static bool operator ==(Product? left, Product? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Product? left, Product? right)
        {
            return !(left == right);
        }
        public static bool operator <(Product? left, Product? right)
        {
            if (left is null) return right is not null;
            return left.CompareTo(right) < 0;
        }
        public static bool operator >(Product? left, Product? right)
        {
            if (left is null) return false;
            return left.CompareTo(right) > 0;
        }
        public static bool operator <=(Product? left, Product? right)
        {
            return left < right || left == right;
        }
        public static bool operator >=(Product? left, Product? right)
        {
            return left > right || left == right;

        }
    }
}
