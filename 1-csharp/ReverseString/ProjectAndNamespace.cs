// in C#, a project is for "physical" organization of classes/stuff
//   a project is compiled as one unit and deployed or run as one unit
//   one project is compiled into exactly one assembly
// in C#, a namespace is for "logical" organization of classes/stuff
//   a project could have many namespaces
//   but also, many projects could contribute classes to one
// usually, folder structure in a project
//  matches namespace structure

using System;

namespace OneNamespace
{
    class Program
    {
        static void Method()
        {
            Console.WriteLine();
            var x = new OtherNamespace.Program();
            var y = new Program();
        }
    }
}

namespace OtherNamespace
{
    class Program
    {

    }
}
