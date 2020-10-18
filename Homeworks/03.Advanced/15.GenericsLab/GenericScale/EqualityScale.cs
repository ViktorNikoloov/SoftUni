using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T right;
        private T left;

        public EqualityScale(T right, T left)
        {
            this.right = right;
            this.left = left;
        }

        public bool AreEqual()
        => right.Equals(left);
            
        
    }
}
