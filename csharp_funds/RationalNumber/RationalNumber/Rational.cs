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

            int gcd = Gcd(numerator, denominator);
            this.numerator = numerator/gcd; 
            this.denominator = denominator/gcd;

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

        private static int Gcd(int x, int y) => y == 0 ? x : Gcd(y, x % y);

    }
}
