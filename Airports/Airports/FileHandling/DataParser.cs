using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Airports.FileHandling
{
    public class DataParser
    {
        private string cityFileName = "cities.txt";
        private string airportFileName = "airports.txt";
        private string countryFileName = "countries.txt";



        public bool ParseDataFromFile()
        {


            if (IsAllFileExists())
            {
                ParseDataFromJson<City>(cityFileName, AirportData.Cities);
            }
            else
            {
                new DefaultDataReader().ReadDataFromDefaultFile();

            }


            return true;
        }

        private bool IsAllFileExists()
        {
            return IsFileExists(countryFileName) && IsFileExists(cityFileName) && IsFileExists(airportFileName);
        }
        private bool IsFileExists(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\", fileName);
            return File.Exists(path);
        }

        private bool ParseDataFromJson<T>(string fileName, List<T> collection)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\", fileName);
            var text = File.ReadAllText(path);
            collection = JsonConvert.DeserializeObject<List<T>>(text);



            return true;
        }

    }
}
