using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.value = value;
        }
        private T value;

        public override string ToString()
        => $"{this.value.GetType()}: {this.value}";
    }
}
