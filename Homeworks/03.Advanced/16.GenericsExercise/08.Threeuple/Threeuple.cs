using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 firstvalue, T2 secondvalue, T3 thirdvalue)
        {
            FirstValue = firstvalue;
            SecondValue = secondvalue;
            ThirdValue = thirdvalue;
        }

        public T1 FirstValue { get; set; }

        public T2 SecondValue { get; set; }

        public T3 ThirdValue { get; set; }

        public override string ToString()
        => $"{FirstValue} -> {SecondValue} -> {ThirdValue}";
    }
}
