using Classwork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//1. Створіть клас MyClass, в якому створіть автовластивість типу int. Створіть клас MyCollection<T>, який реалізує основний функціонал колекції елементів.При створенні MyCollection <T> використовуйте успадкування та реалізацію IEnumerable<T>, IEnumerator<T>.У методі Main наповніть екземпляр колекції елементами MyClass, виконувати двічі обхід цієї колекції з виведенням на екран значень автовластивості елементів колекції.

namespace Classwork
{
    internal class MyCollection<T> : IEnumerable<T>, IEnumerator<T>, ICloneable
    {

        public T[] Items;
        int position = -1;
        public MyCollection(T[] items)
        {
            Items = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                Items[i] = items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        bool IEnumerator.MoveNext()
        {
            if (position < Items.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return Items[position]; }
        }

        public T Current
        {
            get { return Items[position]; }
        }

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

        //public object Clone()
        //{
        //    T[] Items2 = new T[Items.Length];
        //    for (int i = 0; i < Items.Length; i++)
        //    {
        //        Items2[i] = Items[i];
        //    }

        //    return new MyCollection<T>(Items2);
        //}
        public object Clone()
        {
            return new MyCollection<T>(Items);
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