namespace Problem02.DoublyLinkedList;

using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IAbstractLinkedList<T>
{
    private class Node
    {
        public T Element { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T element)
        {
            Element = element;
        }
    }

    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
        this.Count = 0;
    }

    public void AddFirst(T item)
    {
        Node current = new(item);

        if (this.head is null)
        {
            this.head = current;
            this.tail = current;
        }
        else
        {
            this.head.Previous = current;
            current.Next = this.head;
            this.head = current;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node current = new(item);

        if (this.head is null)
        {
            this.head = current;
            this.tail = current;
        }
        else
        {
            current.Previous = this.tail;
            this.tail.Next = current;
            this.tail = current;
        }

        this.Count++;
    }

    public T GetFirst()
    {
        this.EnsureIfNotEmpty();
        return this.head.Element;
    }

    public T GetLast()
    {
        this.EnsureIfNotEmpty();
        return this.tail.Element;
    }

    public T RemoveFirst()
    {
        this.EnsureIfNotEmpty();

        Node firstElement = this.head;
        if (firstElement.Next is null)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.head = this.head.Next;
            this.head.Previous = null;
        }

        this.Count--;

        return firstElement.Element;
    }

    public T RemoveLast()
    {
        this.EnsureIfNotEmpty();

        Node lastElement = this.tail;
        if (lastElement.Previous is null)
        {
            this.head = null;
            this.tail = null;
        }
        else
        {
            this.tail = this.tail.Previous;
            this.tail.Next = null;
        }

        this.Count--;

        return lastElement.Element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.head;
        while (current is not null)
        {
            yield return current.Element;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    => this.GetEnumerator();
    

    private void EnsureIfNotEmpty()
    {
        if (this.Count is 0)
        {
            throw new InvalidOperationException("Doubly Linked List should not be empty!");
        }
    }
}