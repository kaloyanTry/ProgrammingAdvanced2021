using System;

namespace DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            DateModifier modifier = new DateModifier();

            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            Console.WriteLine(modifier.CalculateDifferenceBetweenTwoDates(firstInput, secondInput));
        }
    }
}
