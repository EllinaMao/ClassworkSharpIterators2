    namespace Classwork
    {
        /*
         //1. Створіть клас MyClass, в якому створіть автовластивість типу int. Створіть клас MyCollection<T>, який реалізує основний функціонал колекції елементів.При створенні MyCollection <T> використовуйте успадкування та реалізацію IEnumerable<T>, IEnumerator<T>.У методі Main наповніть екземпляр колекції елементами MyClass, виконувати двічі обхід цієї колекції з виведенням на екран значень автовластивості елементів колекції.
          */
        internal class Program
        {
            static void Main(string[] args)
            {
            MyClass[] myClasses = new MyClass[]
            {
                new MyClass { Someth = 1 },
                new MyClass { Someth = 2 },
                new MyClass { Someth = 3 },
                new MyClass { Someth = 4 },
                new MyClass { Someth = 5 },
            };
            MyCollection<MyClass> myCollection = new MyCollection<MyClass>(myClasses);

                Console.WriteLine("First iteration:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item.Someth);
                }
                Console.WriteLine("Second iteration:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item.Someth);
                }

            }
        }
    }
