using Cities;
using Csv;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace csv.Tests
{
    [TestClass()]
    public class ReadcsvTests
    {
        [TestMethod()]
        public void ReadInCSVTest()
        {
            string file_name = "capital";
            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModel> myList = ReadCsv.ReadCsvFile<CityModel, CityMap>(path, doubleTypeConversion);
            
            IEnumerable<CityModel> countryCapitalQuery = from s in myList
                                      where s.Capital.Equals("primary")
                                      orderby s.Country ascending
                                      select s;
           
            // SOme Update
            foreach (CityModel city in countryCapitalQuery)
            {
                Debug.Write(city.Country + ": " + city.City_name + Environment.NewLine);
            }
           
            writecsv.WritecsvFile<CityModel>(countryCapitalQuery, file_name);

            var QSCount = (from city in countryCapitalQuery
                           select city).Count();
            Debug.Write(QSCount);

            Assert.AreEqual(15493, myList.Count());

            
        }
    }
}