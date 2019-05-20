using System;
using System.Collections.Generic;
using Airports.FileHandling;
using System.Linq;



namespace Airports
{
    class Program
    {

        static void Main(string[] args)
        {
            new DataParser().ParseDataFromFile();
            var result = AirportData.Airports;

            ListAllCountriesWithAirportNumber();
            Console.WriteLine("****");
            ListCitiesWithMostAirport();
            Console.WriteLine("****");


            Console.ReadKey();
        }

        static void ListAllCountriesWithAirportNumber()
        {

            var groupedList = AirportData.Airports.
                                            Join(AirportData.Countries, 
                                                    a => a.CountryId, 
                                                    c => c.Id, 
                                                    (a, c) => new {
                                                        CountryName = c.Name,
                                                        AirportId = a.Id })
                                           .GroupBy(c => c.CountryName)
                                           .OrderBy(c => c.Key)
                                           .ToList();
            groupedList.ForEach(a => Console.WriteLine($"{a.Key}: {a.Count()}"));

        }

        static void ListCitiesWithMostAirport()
        {
            var maxAirportNum = AirportData.Airports.GroupBy(a => a.CityId).Max(a => a.Count());
            var cityList = AirportData.Airports.
                                            Join(AirportData.Cities,
                                                    a => a.CityId,
                                                    c => c.Id,
                                                    (a, c) => new {
                                                        CityName = c.Name,
                                                        CountryId = a.CountryId,
                                                        AirportId = a.Id
                                                    })
                                           .GroupBy(c => new { c.CountryId, c.CityName })
                                           .Where(ac => ac.Count() == maxAirportNum)
                                           .Select(c => c.Key.CityName)
                                           .ToList();

            cityList.ForEach(a => Console.WriteLine($"{a} ({maxAirportNum})"));

        }


    }














}
