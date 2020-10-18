using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            stack = new Stack<T>();
        }

        private Stack<T> stack;

        public int Count
        => stack.Count;
        //{
        //    get
        //    {
        //        return stack.Count;
        //    }
        //}

        public void Add(T element)
        => stack.Push(element);
        

        public T Remove()
        => stack.Pop();

        public void Print()
        => Console.WriteLine(string.Join(", ", stack));
        

    }
}
