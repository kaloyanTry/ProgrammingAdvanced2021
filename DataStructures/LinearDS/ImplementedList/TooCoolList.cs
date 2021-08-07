using System;
using System.Collections.Generic;
using System.Text;

namespace _02.LinearDS
{
    public class TooCoolList<T>
    {
        private T[] tooArray;
        private int tooIndex;

        public TooCoolList(int arrayLenght = 4)
        {
            tooArray = new T[arrayLenght];
        }

        public T this[int i]
        {
            get 
            { 
                return tooArray[i]; 
            }
            set 
            { 
                tooArray[i] = value; 
            }
        }


        public int Count => tooIndex;

        public int InternalTooCount => tooArray.Length;

        public void Add(T element)
        {
            if (tooIndex == tooArray.Length)
            {
                tooArray = DoubledTooArraySize(tooArray);
            }

            tooArray[tooIndex++] = element;
        }

        private T[] DoubledTooArraySize(T[] tooArray)
        {
            T[] doubledTooArray = new T[tooArray.Length * 2];

            for (int i = 0; i < tooArray.Length; i++)
            {
                doubledTooArray[i] = tooArray[i];
            }

            return doubledTooArray;
        }
    }
}
