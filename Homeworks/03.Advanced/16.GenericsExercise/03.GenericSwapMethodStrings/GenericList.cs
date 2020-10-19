using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    public class GenericList<T>
    {
        public GenericList(List<T> list)
        {
            List = list;
        }

        public List<T> List { get; set; } = new List<T>();

        public void SwapIndexes(int firstIndex, int secondIndex)
        {
            T tempValue = List[firstIndex];
            List[firstIndex] = List[secondIndex];
            List[secondIndex] = tempValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var str in List)
            {
                sb.AppendLine($"{str.GetType()}: {str}");
            }

           return sb.ToString().Trim();

        }



    }
}
