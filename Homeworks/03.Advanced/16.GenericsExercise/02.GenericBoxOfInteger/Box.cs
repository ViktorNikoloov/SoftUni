using System;
using System.Collections.Generic;
using System.Text;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.value = value;
        }
        private T value;

        public override string ToString()
        => $"{this.value.GetType()}: {value}";
    }
}
