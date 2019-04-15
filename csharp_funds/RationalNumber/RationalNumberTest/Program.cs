using System;
using RationalNumber;

namespace RationalNumberTest
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 2;
            int b = 7;
            int c = 5;
            int d = 10;

            Rational x = new Rational(a, b);
            Rational y = new Rational(c, d);
            Rational z = c;

            Console.WriteLine("x=" + x);
            Console.WriteLine("y=" + y);
            Console.WriteLine("z=" + z);

            Console.WriteLine("x is equals z?" + x.Equals(z));
            Console.WriteLine("x is equals x?" + x.Equals(x));
            Console.WriteLine("x compared to z?" + x.CompareTo(z));



            Console.WriteLine("x+y=" + (x+y));
            Console.WriteLine("y-x=" + (y - x));
            Console.WriteLine("x*y=" + (x * y));
            Console.WriteLine("x/y=" + (x / y));
            Console.WriteLine("-z=" + -z);

            Console.ReadKey();
        }


    }
}
