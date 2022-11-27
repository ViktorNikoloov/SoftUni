namespace Problem02.Stack;

using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IAbstractStack<T>
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

    private Node top;

    public Stack()
    {
        this.top = null;
        this.Count = 0;
    }

    public int Count { get; private set; }

    public bool Contains(T item)
    {
        Node current = this.top;

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

    public T Peek()
    {
        this.ValidateNotEmpty();

        return this.top.Element;
    }

    public T Pop()
    {
        this.ValidateNotEmpty();

        T item = this.top.Element;

        this.top = this.top.Next;
        this.Count--;

        return item;
    }

    public void Push(T item)
    {
        Node newTop = new Node(item);
        newTop.Next = this.top;

        this.top = newTop;
        this.Count++;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.top;

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

    private void ValidateNotEmpty()
    {
        if (this.top is null)
        {
            throw new InvalidOperationException("Stack is empty!");
        }
    }
}