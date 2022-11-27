namespace Problem04.SinglyLinkedList;

using System;
using System.Collections;
using System.Collections.Generic;

public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

    public SinglyLinkedList()
    {
        this.head = null;
        this.Count = 0;
    }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node toInsert = new(item)
        {
            Next = this.head
        };

        this.head = toInsert;
        this.Count++;
    }

    public void AddLast(T item)
    {
        // 01. Create node
        // 02. Iterate n elements and add to the .Next for the last
        // 03. Increase Count
        Node toInsert = new (item);
        Node current = this.head;

        if (current is null)
        {
            this.head = toInsert;
        }
        else
        {
            while (current.Next is not null)
            {
                current = current.Next;
            }

            current.Next = toInsert;
        }

        this.Count++;
    }

    public T GetFirst()
    {
        this.EnsureNonEmptyList();

        return this.head.Element;
    }

    public T GetLast()
    {
        this.EnsureNonEmptyList();

        Node current = this.head;
        while (current.Next is not null)
        {
            current = current.Next;
        }

        return current.Element;
    }

    public T RemoveFirst()
    {
        this.EnsureNonEmptyList();

        Node current = this.head;
        this.head = this.head.Next;

        this.Count--;

        return current.Element;
    }

    public T RemoveLast()
    {
        this.EnsureNonEmptyList();

        Node current = this.head;
        Node last = null;

        if (current.Next is null)
        {
            last = this.head;
            this.head = null;
        }
        else
        {
            while (current is not null)
            {
                if (current.Next.Next is null)
                {
                    last = current.Next;
                    current.Next = null;
                    break;
                }

                current = current.Next;
            }
        }

        this.Count--;

        return last.Element;
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

    private void EnsureNonEmptyList()
    {
        if (this.Count is 0)
        {
            throw new InvalidOperationException("Linked List is empty!");
        }
    }
}