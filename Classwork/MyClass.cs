using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork
{
    internal class MyClass : IComparable<MyClass>
    {
        public int Someth { get; set; }

        public int CompareTo(MyClass? other)
        {
            if (other == null) return 1;
            return this.Someth.CompareTo(other.Someth);
        }
        public override string ToString()
        {
            return $"MyClass: {Someth}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is MyClass other)
            {
                return this.Someth == other.Someth;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Someth.GetHashCode();
        }
        public object Clone()
        {
            return new MyClass { Someth = this.Someth };

        }

        public static int Compare(object? x, object? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            if (x is MyClass itemX && y is MyClass itemY)
            {
                return itemX.Someth.CompareTo(itemY.Someth);
            }
            throw new ArgumentException("Objects are not of type MyClass");
        }

        // Fix for operator == and related issues
        public static bool operator ==(MyClass? left, MyClass? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Someth == right.Someth;
        }

        public static bool operator !=(MyClass? left, MyClass? right)
        {
            return !(left == right);
        }
        public static bool operator <(MyClass? left, MyClass? right)
        {
            if (left is null) return right is not null;
            return left.CompareTo(right) < 0;
        }
        public static bool operator >(MyClass? left, MyClass? right)
        {
            if (left is null) return false;
            return left.CompareTo(right) > 0;
        }
    }
}


