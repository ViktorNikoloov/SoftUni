namespace Problem01.List;

using System;
using System.Collections;
using System.Collections.Generic;

public class List<T> : IAbstractList<T>
{
    private const int DEFAULT_CAPACITY = 4;
    private T[] _items;

    public List()
        : this(DEFAULT_CAPACITY) {
    }

    public List(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        this._items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            this.ValidateIndex(index);
            return this._items[index];
        }
        set
        {
            this.ValidateIndex(index);
            this._items[index] = value;
        }
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        this.GrowIfNecessary();
        
        this._items[this.Count++] = item;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (item.Equals(this._items[i]))
            {
                return true;
            }
        }

        return false;
    }


    public int IndexOf(T item)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this._items[i].Equals(item))
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        this.ValidateIndex(index);
        this.GrowIfNecessary();

        for (int i = this.Count; i > index; i--)
        {
            this._items[i] = this._items[i - 1];
        }

        this._items[index] = item;
        this.Count++;
    }

    public bool Remove(T item)
    {
        int index = this.IndexOf(item);

        if (index == -1)
        {
            return false;
        }

        this.RemoveAt(index);

        return true;
    }

    public void RemoveAt(int index)
    {
        this.ValidateIndex(index);
        for (int i = index; i < this.Count - 1; i++)
        {
            this._items[i] = this._items[i + 1];
        }

        this._items[this.Count - 1] = default;
        this.Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this._items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void GrowIfNecessary()
    { 
        if (this.Count == this._items.Length)
        {
            this._items = this.Grow();
        }
    }

    private T[] Grow()
    {
        T[] newItems = new T[this.Count * 2];

        for (int i = 0; i < this._items.Length; i++)
        {
            newItems[i] = this._items[i];
        }

        return newItems;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException("Index is outside the bounds!");
        }
    }
}