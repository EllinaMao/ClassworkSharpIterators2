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
    }
}


