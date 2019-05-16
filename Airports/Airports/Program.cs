using System;
using System.Collections.Generic;
using Airports.FileHandling;



namespace Airports
{
    class Program
    {

        static void Main(string[] args)
        {
            new DataParser().ParseDataFromFile();
            var result = AirportData.Airports;
        }
    }














}
