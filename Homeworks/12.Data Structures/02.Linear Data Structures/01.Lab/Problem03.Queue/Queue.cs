namespace Problem03.Queue;

using System;
using System.Collections;
using System.Collections.Generic;

public class Queue<T> : IAbstractQueue<T>
{
    private class Node
    {
        public T Element { get; set; }
        public Node Next { get; set; }

        public Node(T element, Node next)
        {
            this.Element = element;
            this.Next = next;
        }

        public Node(T element)
        {
            this.Element = element;
        }
    }

    private Node head;

    public Queue()
    {
        this.head = null;
        this.Count = 0;
    }

    public int Count { get; private set; }

    public bool Contains(T item)
    {
        Node current = this.head;
        while (current is not null)
        {
            if (current.Element.Equals(item))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public T Dequeue()
    {
        this.EnsureIfNotEmpty();

        Node head = this.head;
        this.head = head.Next;

        this.Count--;

        return head.Element;
    }

    public void Enqueue(T item)
    {
        Node newElement = new(item);
        Node head = this.head;

        if (head is null)
        {
            this.head = newElement;
        }
        else
        {
            while (head.Next is not null)
            {
                head = head.Next;
            }
            
            head.Next = newElement; 
        }

        this.Count++;
    }

    public T Peek()
    {
        this.EnsureIfNotEmpty();

        return this.head.Element;
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
    {
        return this.GetEnumerator();
    }

    private void EnsureIfNotEmpty()
    {
        if (this.Count is 0)
        {
            throw new InvalidOperationException("Queue is empty!");
        }
    }
}