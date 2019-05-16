using System;
using System.Collections.Generic;
using Airports.FileHandling;



namespace Airports
{
    class Program
    {

        static void Main(string[] args)
        {

            new DefaultDataReader().ReadDataFromDefaultFile();
            var result = AirportData.Airports;
        }
    }














}
