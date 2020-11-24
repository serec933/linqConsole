using System;
using System.Collections.Generic;
using System.Text;

namespace linqConsole
{
    public static class StringExtensions
    {
        public static double ToDouble(this string value)
        {
            double.TryParse(value, out double cd);
            //this string riconosce che stiamo estendo
            return cd;
        }
        public static string WithPrefix(this string value, string prefix)
        {
            return $"{prefix}-{value}";
            //$ = string interpolation
        }
    }
}
