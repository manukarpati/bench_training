using Airports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utilities;


namespace Airports.FileHandling
{
    public class DefaultDataReader
    {
        private int latestCityId = 0;
        private int latestCountryId = 0;

              

        public bool ReadDataFromDefaultFile()
        {
            bool result = false;

            if(AirportData.TimeZones.Count <= 0)
            {
                ReadTimeZonesFromFile();
            }

            string defaultPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\airports.dat");

            using(var sr = new StreamReader(defaultPath))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (IsValidLine(line))
                    {
                        try
                        {
                            var airport = MapToAirport(line);
                            AirportData.Airports.Add(airport);
                        }
                        catch (Exception ex)
                        {
                            //logging
                            CustomLogger.log.Warning($"{ex.TargetSite}, Exception happened parsing {line}");
                        }

                    }
                    else
                    {
                        //logging
                        CustomLogger.log.Error($"Not valid data - skipped {line}");

                    }
                }
                result = true;
            }

            SerializeIntoJson();

            return result;
        }

        private bool IsValidLine(string line)
        {

            string pattern = @"[0-9]{1,5},
                            (""[-\w\s]+?"",){3}
                            (""[A-Z]{3}""),
                            (""[A-Z]{4}""),
                            ([-0-9.]+?,){3}";
            Regex regex = new Regex(pattern,RegexOptions.IgnorePatternWhitespace);

            return regex.IsMatch(line);
        }

        private Airport MapToAirport(string line)
        {
            var words = line.Split(",").Select(w => w.Replace("\"", "")).ToArray();

            var location = CreateLocationFromString(words[8], words[7], words[6]);
            var country = CreateCountryFromString(words[3]);
            var airportId = int.Parse(words[0]);
            var timezoneName = GetTimeZoneNameForAirport(airportId);

            var city = CreateCityFromString(words[2], country.Id, timezoneName);
            
            return new Airport()
            {
                Id = airportId,
                Name = words[1],
                CityId = city.Id,
                CountryId = country.Id,
                IATACode = words[4],
                ICAOCode = words[5],
                Location = location,
                TimeZoneName = timezoneName
            };

        }

        private Location CreateLocationFromString(string altitude, string latitude, string longitude)
        {
            return new Location()
            {
                Altitude = float.Parse(altitude),
                Latitude = float.Parse(latitude),
                Longitude = float.Parse(longitude)
            };
        }



        private Country CreateCountryFromString(string name)
        {
            Country country = AirportData.Countries.FirstOrDefault(c => c.Name == name);

            if(country == null)
            {
                var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(c => new RegionInfo(c.Name));
                var englishRegion = regions.FirstOrDefault(region => region.EnglishName.Contains(name));

                country = new Country()
                                { Id = ++latestCountryId,
                                Name = name,
                                TwoLetterISOCode = englishRegion.TwoLetterISORegionName,
                                ThreeLetterISOCode = englishRegion.ThreeLetterISORegionName };

                AirportData.Countries.Add(country);
            }

            return country;
        }

        private string GetTimeZoneNameForAirport(int airportId)
        {
            return AirportData.TimeZones[airportId];
        }

        private City CreateCityFromString(string name, int countryId, string timezone)
        {
            City city = AirportData.Cities.FirstOrDefault(c => c.Name == name);
            if (city == null)
            {
                city = new City()
                {
                    Id = ++latestCityId,
                    CountryId = countryId,
                    Name = name,
                    TimeZoneName = timezone
                };
                AirportData.Cities.Add(city);
            }

            return city;
        }

        private bool ReadTimeZonesFromFile()
        {
            string defaultPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\timezoneinfo.json");

            var text = File.ReadAllText(defaultPath);
            var jArray = ((JArray)JsonConvert.DeserializeObject<dynamic>(text));
            AirportData.TimeZones = jArray.ToDictionary(j => (int)j["AirportId"], j => (string)j["TimeZoneInfoId"]);

            return true;
        }

        private bool SerializeIntoJson()
        {
            WriteJsonToFile(AirportData.Cities, "cities.txt");
            WriteJsonToFile(AirportData.Countries, "countries.txt");
            WriteJsonToFile(AirportData.Airports, "airports.txt");

            return true;
        }

        private void WriteJsonToFile<T>(List<T> collection, string fileName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\Files\", fileName);

            var json = JsonConvert.SerializeObject(collection, Formatting.Indented);

            File.WriteAllText(path, json);
        }






    }
}
