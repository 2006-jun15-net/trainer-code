using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serialization.DataModel;

namespace Serialization
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // (for your program, the starting directory is bin/Debug/netcoreapp3.1)
            string filePath = "../../../data.json";

            List<PlayerStats> data;
            try
            {
                string initialJson = await File.ReadAllTextAsync(filePath);
                data = JsonConvert.DeserializeObject<List<PlayerStats>>(initialJson);
            }
            catch (FileNotFoundException)
            {
                data = GetInitialData();
            }

            data[0].Name += "+";

            string json = ConvertToJson(data);

            await WriteStringToFileAsync(filePath, json);

            // at this point,the file is definitely written
        }

        // when doing something async:
        // 1. call the Async version of whatever library method.
        // 2. await that Task.
        // 3. mark the current method with the async modifier.
        // 4. if the method returns type T, change it to return type Task<T>
        //    if it returns void, change it to return type Task
        // 5. as a matter of convention, add the Async suffix to your method name.
        // (continue again from step 1 on the parts of your code that are now broken)
        public async static Task WriteStringToFileAsync(string filePath, string json)
        {
            //await File.WriteAllTextAsync(filePath, json);
            // for more control over the file I/O, we would usually open a FileStream object.

            // the CLR manages the memory for all the CLR objects with garbage collection.
            //    (otherwise, there would be memory leaks any time i failed to manually clean up any object.)

            // any time you have .NET code open or access some resource OUTSIDE the CLR
            //  (like the hard drive), you do need to manually tell it when you are done to avoid problems.
            // the IDisposable interface is implemented by any class which you need to do this for.

            //FileStream fileStream = null;
            try
            {
                // if you are fine with the resource not being disposed until the variable goes out of scope...
                // you can use this form of the using statement.
                using var fileStream = new FileStream(filePath, FileMode.Create);

                //fileStream. // pretend i finished the code
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
            //finally
            //{
            //    // what if an exception is thrown at any point beforehand?
            //    //if (fileStream != null)
            //    //{
            //    //    fileStream.Dispose();
            //    //}
            //    fileStream?.Dispose();
            //    // C# has an operator "?." which calls a method (or accesses a property/field/etc.)
            //    // but only if the thing to the left is not null.
            //    // the finally block always runs whether there was no exception, a caught exception, or an uncaught exception.
            //}
            // C# has a "using statement" to replace the boilerplate "resource = null, try, finally, resource.Dispose"
            //using (var fileStream = new FileStream(filePath, FileMode.Create))
            //{

            //} // right here, at the closing brace, is effectively "finally { resource?.Dispose() }"
        }

        /// <summary>
        /// Serialize the objects into a string in JSON format
        /// </summary>
        /// <param name="data">the data</param>
        /// <returns>serialized JSON</returns>
        public static string ConvertToJson(List<PlayerStats> data)
        {
            // in .NET Core, we use a program called NuGet
            // to resolve dependencies and download them from registries (usually NuGet.org)

            return JsonConvert.SerializeObject(data, Formatting.Indented);

            // can customize with optional parameters to that method
            // or, with attributes on the PlayerStats class and properties themselves.
        }

        private static List<PlayerStats> GetInitialData()
        {
            //var thePlayerStatistics = new PlayerStats
            //{
            //    ArcLocations = null,
            //    FreeThrowPercentage = 1000,
            //    PointsPerGame = 12
            //};

            return new List<PlayerStats>
            {
                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocations = new Dictionary<int, double>
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                },
                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocations = new Dictionary<int, double>
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                },
                new PlayerStats
                {
                    Name = "Lebron James",
                    FreeThrowPercentage = 65,
                    PointsPerGame = 25,
                    ArcLocations = new Dictionary<int, double>
                    {
                        [-150] = 30,
                        [-120] = 30,
                        [-90] = 30
                    }
                }
            };
        }
    }
}
