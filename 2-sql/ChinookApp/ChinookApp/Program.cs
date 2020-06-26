using System;
using System.Collections.Generic;
using System.Linq;
using ChinookApp.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChinookApp
{
    class Program
    {
        // Entity Framework Core
        // database-first approach steps...
        /*
         * 1. have a data access library project separate from the startup application project.
         *    (with a project reference from the latter to the former).
         * 2. install Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.SqlServer
         *    to both projects.
         * 3. using Git Bash / terminal, from the data access project folder run (split into several lines for clarity):
         *    dotnet ef dbcontext scaffold <connection-string-in-quotes>
         *      Microsoft.EntityFrameworkCore.SqlServer
         *      --startup-project <path-to-startup-project-folder>
         *      --force
         *      --output-dir Entities
         *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
         *    (if you don't have dotnet ef installed, run: "dotnet tool install --global dotnet-ef")
         *    (this will fail if your projects do not compile)
         * 4. delete the DbContext.OnConfiguring method from the scaffolded code.
         *    (so that the connection string is not put on the public internet)
         * 5. any time you change the structure of the tables (DDL), go to step 3.
         */


        // for this code to compile, you need to add a gitignored file SecretConfiguration.cs like:

        /*
        namespace ChinookApp
        {
            internal class SecretConfiguration
            {
                internal const string ConnectionString = "your connection string here";
            }
        }
         */

        // Entity Framework configures itself at runtime
        // from three sources -
        // (1) OnModelConfiguring method (fluent API)
        // (2) DataAnnotations attributes on the entity classes
        // (3) conventions
        //      - e.g.: if a type named "X" has a property named either "Id" or "XId",
        //            it will be assumed to be the primary key

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static readonly DbContextOptions<ChinookContext> Options = new DbContextOptionsBuilder<ChinookContext>()
            .UseLoggerFactory(MyLoggerFactory)
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .Options;

        static void Main(string[] args)
        {
            DisplayData();

            //Console.WriteLine("\nAdding some data...");
            //AddSomeDataFromUserInput();

            //DisplayData();

            //Console.WriteLine("\nUpdating some data...");
            //UpdateSomeData();

            //DisplayData();

            //Console.WriteLine("\nDeleting some data...");
            //DeleteSomeData();

            //DisplayData();
        }

        public static void DeleteSomeData()
        {
            // there's actually no way to delete in EF without first fetching the object.
            // first, get the thing, then, remove it from its DbSet, then SaveChanges
        }

        public static void UpdateSomeData()
        {
            // every object that you pull from the context is "tracked" by the context
            // when you call SaveChanges, the context will send all changes that have been
            // noticed automatically on the tracked entities
        }

        public static void AddSomeDataFromUserInput()
        {
            // for adding, you also don't need to worry about foreign key values.
            // you can add/change relationships between objects via the navigation
        }

        public static void DisplayData()
        {
            using var context = new ChinookContext(Options);

            //List<Employee> salespeople = context.Employee
            //    .ToList() // it generates the SQL and fetches the objects
            //    .Where(e => e.Title.Contains("sales")) // this is now running in .NET, not in SQL
            //    .ToList();

            //List<Employee> salespeople = context.Employee
            //    .Where(e => e.Title.Contains("sales")) // this will be translated to SQL
            //    .ToList(); // it generates the SQL and fetches the objects

            //foreach (Employee person in salespeople)
            //{
            //    Console.WriteLine($"{person.Title} {person.FirstName} {person.LastName}");
            //}

            // EF by default only loads the data from one table at a time.
            //    therefore, the navigation properties will be null or empty.
            // if you need those properties to be filled in, you have to tell EF somehow.
            
            // there are three ways to tell EF to fill them in:
            //  1. eager loading (do this one): call Include (and maybe ThenInclude) methods
            //        (telling EF in the query itself to join with other tables)
            //  2. lazy loading (avoid this one): can be enabled in the dbcontext options...
            //       it will load each navigation property in the moment you access it.
            //       for very simple cases, minimal convenience
            //       for anything more complicated, the performance impact is too much
            //          (N+1 problem)
            //  3. explicit loading (rarely needed): given an actual object taken from the context
            //        we can tell EF to fill in individual properties

            // good practice with entity framework:
            // 1. pay attention to when the query is actually sent to the DB (e.g. ToList())
            // 2. try to get all the data you need at a given moment in one query rather than several.
            // 3. use eager loading (Include) rather than lazy or explicit.
            // 4. avoid using foreign key values when the navigation properties work instead.

            List<Student> students = context.Student
                .Include(s => s.Enrollment)
                    .ThenInclude(e => e.Course)
                .ToList();

            foreach (var student in students)
            {
                // bad code - inefficiently coding a join by hand in C#
                // the whole point of ORM is avoiding this kind of code
                //var courseIds = context.Enrollment
                //    .Where(e => e.StudentId == student.Id)
                //    .Select(e => e.CourseId)
                //    .ToList();
                //var courses = context.Course
                //    .Where(c => courseIds.Contains(c.Id))
                //    .Select(c => c.CourseNumber);
                var courses = student.Enrollment.Select(e => e.Course.CourseNumber);

                var coursesString = string.Join(", ", courses);
                Console.WriteLine($"[{student.Id}] {student.Name}: {coursesString}");
            }
        }
    }
}
