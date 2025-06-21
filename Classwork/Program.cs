    namespace Classwork
    {
        /*
         //1. Створіть клас MyClass, в якому створіть автовластивість типу int. Створіть клас MyCollection<T>, який реалізує основний функціонал колекції елементів.При створенні MyCollection <T> використовуйте успадкування та реалізацію IEnumerable<T>, IEnumerator<T>.У методі Main наповніть екземпляр колекції елементами MyClass, виконувати двічі обхід цієї колекції з виведенням на екран значень автовластивості елементів колекції.
          */
        internal class Program
        {
            static void Main(string[] args)
            {
            MyClass[] myClasses =
            [
                new () { Someth = 1 },
                new () { Someth = 2 },
                new () { Someth = 3 },
                new () { Someth = 4 },
                new () { Someth = 5 },
            ];

            MyCollection<MyClass> myCollection = new (myClasses);

                Console.WriteLine("Первый проход:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item.Someth);
                }
                Console.WriteLine("Второй:");
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item.Someth);
                }

            Console.WriteLine("Третий елемент: {0}",myCollection[2].Someth);


            MyCollection<MyClass> myCollection2 = (MyCollection<MyClass>)myCollection.Clone();

            Console.WriteLine("Клон:");
            foreach (var item in myCollection2)
            {
                Console.WriteLine(item.Someth);
            }


        }
        }
    }
