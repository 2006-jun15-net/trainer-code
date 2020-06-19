using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Serialization.DataModel;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // (for your program, the starting directory is bin/Debug/netcoreapp3.1)
            string filePath = "../../../data.json";

            List<PlayerStats> data;
            try
            {
                string initialJson = File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<List<PlayerStats>>(initialJson);
            }
            catch (FileNotFoundException)
            {
                data = GetInitialData();
            }

            data[0].Name += "+";

            string json = ConvertToJson(data);

            WriteStringToFile(filePath, json);
        }

        public static void WriteStringToFile(string filePath, string json)
        {
            File.WriteAllText(filePath, json);
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
