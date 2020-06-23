using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesEvents.Extensions
{
    public static class ExtensionMethods
    {
        public static void PrintInLowercase(this string text)
        {
            Console.WriteLine(text.ToLower());
        }

        // 4.Multiply(2) == 8; // extension method
        // Multiply(4, 2) == 8; // regular static method
        public static int Multiply(this int x, int y)
        {
            return x * y;
        }
        // extension methods are just "syntactic sugar" for static methods
    }
}
