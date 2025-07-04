using Classwork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//1. Створіть клас MyClass, в якому створіть автовластивість типу int. Створіть клас MyCollection<T>, який реалізує основний функціонал колекції елементів.При створенні MyCollection <T> використовуйте успадкування та реалізацію IEnumerable<T>, IEnumerator<T>.У методі Main наповніть екземпляр колекції елементами MyClass, виконувати двічі обхід цієї колекції з виведенням на екран значень автовластивості елементів колекції.

/*
1.IClonable
2 IComparable
3 IComparer
4 GetEnumerator via yield

Class  Product (назву, дату, ціну)  

Створюєте вашу колекцію продуктів: стестуєте  foreach,  клонування, різні сортировки за назвою, датою, ціною
*/

namespace Classwork
{
    internal class MyCollection<T> : IEnumerable<T>, /*IEnumerator<T>,*/ ICloneable, IComparable<T>
,IComparable, IComparer

    {

        public T[] Items;
        //int position = -1;
        public MyCollection(T[] items)
        {
            Items = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                Items[i] = items[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //public IEnumerator<T> GetEnumerator()
        //{
        //    return this;
        //}

        //bool IEnumerator.MoveNext()
        //{
        //    if (position < Items.Length - 1)
        //    {
        //        position++;
        //        return true;
        //    }
        //    return false;
        //}

        //void IEnumerator.Reset()
        //{
        //    position = -1;
        //}

        //object IEnumerator.Current
        //{
        //    get { return Items[position]; }
        //}

        //public T Current
        //{
        //    get { return Items[position]; }
        //}

        protected virtual void Dispose(bool disposing)
        {
            ((IEnumerator)this).Reset();

        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        public object Clone()
        {
            return new MyCollection<T>(Items);
        }

        public int CompareTo(T? other)
        {
            if (other == null) return 1; 
            if (this.Equals(other)) return 0; 
            return 1; 

        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1; 

            if (ReferenceEquals(this, obj)) return 0; 

            if (obj is MyCollection<T> otherCollection)
            {
                return this.Items.Length.CompareTo(otherCollection.Items.Length);
            }
            throw new ArgumentException("Object is not a MyCollection<T>", nameof(obj));
        }

        public int Compare(object? x, object? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (x is T itemX && y is T itemY)
            {
                return Comparer<T>.Default.Compare(itemX, itemY);
            }
            throw new ArgumentException("Objects are not of type T");
        }
        public override bool Equals(object? obj)
        {   if (obj is MyCollection<T> otherCollection)
            {
                return Items.SequenceEqual(otherCollection.Items);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Items?.GetHashCode() ?? 0;
        }

        public static bool operator ==(MyCollection<T>? left, MyCollection<T>? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(MyCollection<T>? left, MyCollection<T>? right)
        {
            return !(left == right);
        }

        public static bool operator <(MyCollection<T>? left, MyCollection<T>? right)
        {
            if (left is null) return right is not null;
            return left.CompareTo(right) < 0;
        }
        public static bool operator >(MyCollection<T>? left, MyCollection<T>? right)
        {
            if (left is null) return false;
            return left.CompareTo(right) > 0;
        }
        public static bool operator <=(MyCollection<T>? left, MyCollection<T>? right)
        {
            return !(left > right);
        }
        public static bool operator >=(MyCollection<T>? left, MyCollection<T>? right)
        {
            return !(left < right);
        }

        public T this[int index]
        {
            get
            {
                return Items[index];
            }
            set
            {
                Items[index] = value;
            }
        }



    }
}