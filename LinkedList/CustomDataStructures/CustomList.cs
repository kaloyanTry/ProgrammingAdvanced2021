using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


public class CustomList<T> where T : IComparable<T>
{
    private const int DefaultCapacity = 2;
    private T[] elements;

    public int Count { get; set; }
    public int Capacity { get; set; }

    public CustomList(int capacity = DefaultCapacity)
    {
        elements = new T[capacity];
        Count = 0;
        Capacity = capacity;
    }

    public T this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }

            return elements[index];
        }

        set
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index!");
            }

            elements[index] = value;

        }
    }

    private void Resize()
    {
        T[] newElements = new T[Capacity * 2];
        Array.Copy(elements, newElements, Count);
        Capacity = Capacity * 2;
        elements = newElements;
    }

    private void Shift(int index)
    {
        for (int i = index; i <= Count - 1; i++)
        {
            elements[i] = elements[i + 1];
        }
    }

    private void Shrink()
    {
        T[] newElements = new T[Capacity / 2];
        Array.Copy(elements, newElements, Count);
        Capacity = Capacity / 2;
        elements = newElements;

    }

    public void Add(T element)
    {
        if (Count == Capacity)
        {
            Resize();
        }

        elements[Count] = element;
        Count++;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T toRemove = elements[index];

        elements[index] = default(T);
        Shift(index);
        Count--;

        if (Count <= Capacity / 4)
        {
            Shrink();
        }

        return toRemove;
    }

    public void Insert(int index, T element)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (Count == Capacity)
        {
            Resize();
        }

        T[] newElements = new T[Capacity];
        for (int i = 0; i < index; i++)
        {
            newElements[i] = elements[i];
        }

        newElements[index] = element;

        for (int i = index; i < Count; i++)
        {
            newElements[i + 1] = elements[i];
        }

        elements = newElements;
        Count++;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < Count; i++)
        {
            if (element.CompareTo(elements[i]) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void Swap(int firstIndex, int secondIndex)
    {

        if (firstIndex < 0 || firstIndex >= Count)
        {
            throw new ArgumentOutOfRangeException("Invalid index!");
        }

        if (secondIndex < 0 || secondIndex >= Count)
        {
            throw new ArgumentOutOfRangeException("Invalid index!");
        }

        T temp = elements[firstIndex];
        elements[firstIndex] = elements[secondIndex];
        elements[secondIndex] = temp;

    }
}