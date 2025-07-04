using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    internal static class Sort
    {
        public class SortByName : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return string.Compare(x?.name, y?.name);
            }
        }

        // Сортировка по дате
        public class SortByDate : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return DateTime.Compare(x?.date ?? DateTime.MinValue, y?.date ?? DateTime.MinValue);
            }
        }

        // Сортировка по цене
        public class SortByPrice : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                return (x?.price ?? 0).CompareTo(y?.price ?? 0);
            }
        }

    }
}
