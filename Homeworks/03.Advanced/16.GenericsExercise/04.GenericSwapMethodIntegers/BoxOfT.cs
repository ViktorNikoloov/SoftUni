using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class BoxOfT<T>
    {
        public BoxOfT()
        {
            Values = new List<T>();
        }

        public List<T> Values { get; set; }

        public void Swap(int firstIndex, int secondIndex)
        {
            bool isInRange = 0 <= firstIndex && firstIndex < Values.Count && 0 <= secondIndex && secondIndex < Values.Count;
            if (!isInRange)
            {
                throw new InvalidOperationException("Values are not in range !");
            }

            T swap = Values[firstIndex];
            Values[firstIndex] = Values [secondIndex];
            Values[secondIndex] = swap;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().Trim();
        }

    }
}
