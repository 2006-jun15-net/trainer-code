using System;

namespace ReverseString
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a string: ");
            string text = Console.ReadLine();
            Console.WriteLine(ReverseString(text));
        }

        static string ReverseString(string s)
        {
            var array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
