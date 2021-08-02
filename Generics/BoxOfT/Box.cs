using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        Stack<T> elements;

        public Box()
        {
            elements = new Stack<T>();
        }

        public void Add(T element)
        {
            elements.Push(element);
        }

        public T Remove()
        {
            return  elements.Pop();
        }

        public int Count => elements.Count;
    }
}
