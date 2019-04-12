using System;
using System.Collections.Generic;

namespace RomanNumberConverter
{
    public static class RomanConverter
    {
        private static SortedList<int, string> romanValues = new SortedList<int, string>() {

          { 1,"I"},
          { 4, "IV"},
          { 5, "V"},
          { 9, "IX"},
          { 10, "X"},
          { 40, "XL"},
          { 50, "L"},
          { 90,"XC"},
          { 100,"C"},
          { 400, "CD"},
          { 500, "D"},
          { 900, "CM"},
          { 1000, "M"},
        };

        public static string ToRoman(this int number)
        {
            if (number < 1 || number > 3999)
            {
                return "invalid number";
            }

            string result = "";

            for(int i= romanValues.Count-1; i>=0; i--)
            {
                if(number >= romanValues.Keys[i])
                {
                    int times = number / romanValues.Keys[i];

                    for( int j = 0; j < times; j++)
                    {
                        result += romanValues.Values[i];
                    }

                    number = number % romanValues.Keys[i];
                }
            }

            return result;
        }

    }

}
