﻿using System;
using System.Collections.Generic;
using Airports.FileHandling;
using System.Linq;
using System.Text.RegularExpressions;
using Elect.Location;
using Elect.Location.Models;

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
            FindNearestAirportByUserEnteredGPSData();
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

        static void CalculateClosestAirport(CoordinateModel entered)
        {
            var minDistance = AirportData.Airports
                                        .Min(a => Elect.Location.Coordinate.DistanceUtils.DistanceHelper
                                                .GetDistance(entered, new CoordinateModel(a.Location.Longitude, a.Location.Latitude), UnitOfLengthModel.Kilometer));

            var nearest = AirportData.Airports.
                                            Join(AirportData.Cities,
                                                    a => a.CityId,
                                                    c => c.Id,
                                                    (a, c) => new
                                                    {
                                                        CityName = c.Name,
                                                        AirportName = a.FullName,
                                                        Location = a.Location
                                                    })
                                           .FirstOrDefault(a => Elect.Location.Coordinate.DistanceUtils.DistanceHelper
                                                .GetDistance(entered, new CoordinateModel(a.Location.Longitude, a.Location.Latitude), UnitOfLengthModel.Kilometer)
                                                == minDistance);
            Console.WriteLine($"The nearest airport is {nearest.AirportName} in {nearest.CityName}");
        }

        static void FindNearestAirportByUserEnteredGPSData()
        {
            string enteredData;
            do
            {
                Console.WriteLine("Enter a valid GPS coordinate (longitude, latitude, altitude: use . for decimals, separate with ,)");
                enteredData = Console.ReadLine();

            } while (!ValidGPSCoordinate(enteredData));

            var coordinate = CreateCoordinateFromUserData(enteredData);

            CalculateClosestAirport(coordinate);
        }

        static bool ValidGPSCoordinate(string enteredData)
        {
            string pattern = @"^(-?[\d]+(\.[\d]*)?,\s*){2}-?[\d]+(\.[\d]*)?$";

            return new Regex(pattern).IsMatch(enteredData);
        }

        static CoordinateModel CreateCoordinateFromUserData(string entered)
        {
            var coordinates = entered.Split(",");
            return new CoordinateModel(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
        }

    }














}
