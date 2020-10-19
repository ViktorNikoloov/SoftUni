using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class BoxOfT<T>
    {
        public BoxOfT(List<T> list)
        {
            List = list;
        }

        public List<T> List { get; set; } = new List<T>();

        public void SwapIndexes(int firstIndex, int secondIndex)
        {
            T swap = List[firstIndex];
            List[firstIndex] = List[secondIndex];
            List[secondIndex] = swap;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in List)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().Trim();
        }

    }
}
