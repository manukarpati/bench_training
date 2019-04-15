using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    public struct Rational :IComparable<Rational>, IEquatable<Rational>
    {
        private int numerator;
        private int denominator;

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new InvalidOperationException();
            }

            int gcd = GreatestCommonFactor(numerator, denominator);
            this.numerator = numerator/gcd; 
            this.denominator = denominator/gcd;

        }

        private static int GreatestCommonFactor(int x, int y) => y == 0 ? x : GreatestCommonFactor(y, x % y);

        private static int LeastCommonMultiple(int x, int y)
        {
            return (x / GreatestCommonFactor(x, y)) * y;
        }

        public int CompareTo(Rational other)
        {
            return (numerator / (double)denominator).CompareTo(other.numerator / (double)other.denominator); 
        }

        public bool Equals(Rational other)
        {
            return (this.numerator == other.numerator && this.denominator == other.denominator);
        }

        public override string ToString()
        {
            string result = numerator.ToString();
            result += denominator == 1 ? String.Empty : "r" + denominator.ToString(); 

            return result;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int lcm = LeastCommonMultiple(a.denominator, b.denominator);
            return new Rational(a.numerator * (lcm / a.denominator) + b.numerator * (lcm / b.denominator), lcm);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int lcm = LeastCommonMultiple(a.denominator, b.denominator);
            return new Rational(a.numerator * (lcm / a.denominator) - b.numerator * (lcm / b.denominator), lcm);

        }

        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            return new Rational(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        public static Rational operator -(Rational a)
        {
            return new Rational(-a.numerator, a.denominator);
        }

        public static implicit operator Rational (int x)
        {
            return new Rational(x, 1);
        }
    }
}
