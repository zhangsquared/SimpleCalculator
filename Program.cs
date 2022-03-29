using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCalculator test = new MyCalculator();
        
            Console.WriteLine(test.EvaluatePostfix("3 5 2 * +")); // 13
            Console.WriteLine(test.EvaluatePostfix("2 3 * 70 7 / +")); // 16
            
            Console.WriteLine(test.InfixToPostfix("2 * 3 + 4 * 5")); // 2 3 * 4 5 * +
            Console.WriteLine(test.InfixToPostfix("(2 - 3 + 40)*(5 + 6 * 7)")); // 2 3 - 40 + 5 6 7 * + *
            Console.WriteLine(test.EvaluateInfix("2 * 3 + 4 * 5")); // 26
            Console.WriteLine(test.EvaluateInfix("20 - 3 + 4 - 5 * 6")); // -9
            Console.WriteLine(test.EvaluateInfix("2 + ((3  + 8 / (4 /2))+ 70 * (4 + 7)) / 4")); // 196.25

            Console.ReadLine();
        }
    }
}

