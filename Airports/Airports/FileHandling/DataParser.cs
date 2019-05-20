using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utilities;

namespace Airports.FileHandling
{
    public class DataParser
    {




        public bool ParseDataFromFile()
        {


            if (IsAllFileExists())
            {
                AirportData.Cities = ParseDataFromJson<City>(Constants.CityFileName);
                AirportData.Countries = ParseDataFromJson<Country>(Constants.CountryFileName);
                AirportData.Airports = ParseDataFromJson<Airport>(Constants.AirportFileName);

            }
            else
            {
                new DefaultDataReader().ReadDataFromDefaultFile();

            }


            return true;
        }

        private bool IsAllFileExists()
        {
            return IsFileExists(Constants.CountryFileName) && IsFileExists(Constants.CityFileName) && IsFileExists(Constants.AirportFileName);
        }
        private bool IsFileExists(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\", fileName);
            return File.Exists(path);
        }

        private List<T> ParseDataFromJson<T>(string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\", fileName);
            var text = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(text);
        }

    }
}
