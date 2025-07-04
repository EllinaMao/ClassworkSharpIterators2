using static Products.Sort;

namespace Products
{/*Class  Product (назву, дату, ціну)  

Створюєте вашу колекцію продуктів: стестуєте  foreach,  клонування, різні сортировки за назвою, датою, ціною*/
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductList productList = new ProductList();
            productList.AddProduct(new Product("Apple", new DateTime(2023, 12, 3, 0, 0, 0, DateTimeKind.Local), 12.21));
            productList.AddProduct(new Product("Banana", new DateTime(2023, 5, 21, 0, 0, 0, DateTimeKind.Local), 0.80));
            productList.AddProduct(new Product("Cherry", new DateTime(2025, 3, 1, 0, 0, 0, DateTimeKind.Local), 2.50));
            productList.AddProduct(new Product("Date", new DateTime(2027, 12, 1, 0, 0, 0, DateTimeKind.Local), 3.00));

            productList.DisplayProducts();
            Console.WriteLine("\nCloned Product List:");
            ProductList clonedList = (ProductList)productList.Clone();
            clonedList.DisplayProducts();

            Console.WriteLine("\nSorted by Name:");
            productList.products.Sort();
            productList.DisplayProducts();
            Console.WriteLine("\nSorted by Date:");


            Console.WriteLine("\nСортировка по имени:");
            productList.Sort(new SortByName());
            productList.DisplayProducts();

            Console.WriteLine("\nСортировка по дате:");
            productList.Sort(new SortByDate());
            productList.DisplayProducts();

            Console.WriteLine("\nСортировка по цене:");
            productList.Sort(new SortByPrice());
            productList.DisplayProducts();

        }
    }
}
