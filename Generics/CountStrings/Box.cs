using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGenerics
{
    public class Box<T>
        where T: IComparable
    {
        public Box(T value)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            Type typeValue = Value.GetType();

            string typeValueFullName = typeValue.FullName;

            return $"{typeValueFullName}: {Value}";
        }
    }
}
