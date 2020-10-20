using System;

namespace _05.GenericCountMethodStrings
{
    class Program
    {
        class Box<T>
        where T : IComparable
        {
            public Box()
            {
                List = new List<T>();
            }

            public List<T> List { get; set; }

            public int GetCompared(T element)
            {
                int counter = 0;

                foreach (var value in List)
                {
                    if (value.CompareTo(element) > 0)
                    {
                        counter++;
                    }
                }

                return counter;
            }

        }
    }
}
