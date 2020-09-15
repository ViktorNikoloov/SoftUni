using System;

namespace Circle_Area_and_Perimeter_ЛицеПериметърНаКръг_
{
    class Program
    {
        static void Main(string[] args)
        {
            //condition
            //Напишете програма, която чете от конзолата число r и пресмята и отпечатва лицето и периметъра на кръг.

            //input
            //която чете от конзолата число r 
            double r = double.Parse(Console.ReadLine());

            //calculation
            //S=π.r2(area - лице)
            //P= 2*(π*r)
            double S = Math.PI * (r * r);
            double P = 2 * Math.PI * r;

            //output
            //форматирате изхода в следния вид: "<calculated area>"  "<calculated parameter>"
            //Форматирайте изходните данни до втория знак след десетичната запетая.
            Console.WriteLine($"{S:F2}");
            Console.WriteLine($"{P:F2}");

        }
    }
}
