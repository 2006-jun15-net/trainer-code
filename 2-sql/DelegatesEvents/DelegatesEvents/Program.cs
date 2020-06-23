using System;
using System.Collections.Generic;
using System.Linq;
using DelegatesEvents.Extensions;

namespace DelegatesEvents
{
    // this declares a new type (just like the class Program { } bit does)
    // which can be the type of a variable
    public delegate void StringAction(string text);

    class Program
    {
        // events are another kind of "member" like properties, fields, and methods.
        // an event supports three operations:
        //   - subscribe +=
        //   - unsubscribe -=
        //   - call/publish ()

        // implement logging with an event:
        public static event Action<string> Log;
        //public static List<Action<string>> Log;
        // it looks like a field sort of. but every event needs a void-return delegate type to define what 
        // parameters can and will be sent along with the event.

        // in this example, it lets us have some separation of concerns so
        // that my Main method can decide HOW to log (by subscribing)
        // and other code can decide WHAT to log and WHEN (by calling)

        static void Main(string[] args)
        {
            // C# is an object-oriented language

            // one thing it takes from functional programming
            // is an ability to treat a function/method as just another piece of data like int or Product etc.

            // in C# when we're treating methods as data, we call them "delegates"
            // and we have "delegate types" that represent groups of those delegate values.
            // any delegate can fit in a delegate type based on having the same return type and method parameter types.

            // two ways to say the same thing:
            Log += s => Console.WriteLine(s);
            Log += Console.WriteLine;
            // (since i subscribed twice, both "event handlers" will run)

            Console.WriteLine("Hello World!");

            //Action<string> theMethodItself = Console.WriteLine;
            StringAction theMethodItself = Console.WriteLine;

            theMethodItself("text to print");

            theMethodItself = PrintInUppercase;

            theMethodItself("text to print");

            PrintAllStrings(false, "adsf", "asdf", "");

            var strings = new List<string> { "abc", "b", "c3" };

            // C# provides a way to write a quick disposable "method" called lambda expression
            //ProcessStrings(strings, Console.WriteLine);
            ProcessStrings(strings, x => x.ToLower(), Console.WriteLine);

            // the most useful built-in delegate types are Func and Action

            // Func<int, int, string>   : method that takes two ints and returns a string
            // Action<int, int, string> : method that takes two ints and a string and returns nothing (void)

            // this overload of the Sort method takes a Comparison<string>
            // which is a delegate type meaning, take two strings, return an int to indicate the sort order you want.
            strings.Sort((s1, s2) => s2.Length - s1.Length);

            // C# lets you write "extension methods"
            // these are really just static methods, but they APPEAR to be added on to an existing type.

            "asdf".PrintInLowercase();

            // that method will only be visible on the type in files which have imported the right namespace.
            100.ToString();


            // C# has a great collection of sequence-processing methods called LINQ
            // "language-integrated query"
            // it's really just a class full of extension methods for the IEnumerable interface.
            //    (the one that all collections implement)
            LinqDemo();
        }

        static void LinqDemo()
        {
            var strings = new List<string> { "abc", "b", "c3", "" };

            // get the first element matching some condition
            strings.First(x => x.Length < 2); // first element shorter than 2 characters - returns "b"

            // LINQ methods fit into one of a few categories
            // 1. the ones that return some concrete value - e.g. First, Average, Max, Min, Count, Sum
            //      these ones run "right away"
            // 2. the ones that return a sequence (IEnumerable) - e.g. Select, Where, OrderBy, Distinct
            //      these ones don't run "yet" - the collection will only really be processed if you loop over it later.
            //      this is called "deferred execution"
            // 3. stuff that returns a concrete collection e.g. ToList()
            //      these ones run "right away" as well -- by calling ToList at the right times,
            //      you can take control over that "deferred execution" behavior.

            // none of them ever modify the original list.


            IEnumerable<string> results = strings.Where(x => x[0] == 'a'); // all elements having first character as 'a'


            IEnumerable<char> results2 = strings
                .Where(s => s.Length > 0)
                .Select(s => s[0]) // Select converts each element into something new
                .OrderByDescending(c => c); // use the default sorting of chars, but in reverse
            // the first characters of the strings, in reverse alphabetical order: c, b, a

            foreach (var item in results2)
            {
                Console.WriteLine(item);
            }

            // LINQ has two syntaxes - all that is the "method syntax"
            // there's also the "query syntax"
            var results3 = from s in strings
                           where s.Length > 0
                           select s[0]; // some methods dont have an equivalent in query syntax

            // in different contexts, sometimes the sequence processing stuff is converted into something besides
            // regular C#. for example there is "LINQ to SQL". (there's two copies of each LINQ method, one for
            // IEnumerable, one for IQueryable. the weird stuff like that is on IQueryable.)
        }

        static void ProcessStrings(IEnumerable<string> collection, Func<string, string> modify, Action<string> action)
        {
            foreach (string str in collection)
            {
                string newString = modify(str);

                // bit unsafe way to call an event...
                // if there are no subscribers, then you get a null reference exception from firing
                Log("modified string is: " + newString);

                // ?. and ?? are two useful operators in C#
                
                action(newString);
            }
        }

        static void PrintInUppercase(string text)
        {
            Console.WriteLine(text.ToUpper());
        }

        static void PrintAllStrings(bool uppercase, params string[] strings)
        {
            foreach (var item in strings)
            {
                if (uppercase)
                    PrintInUppercase(item);
                else
                    Console.WriteLine(item);
            }
        }
    }
}
