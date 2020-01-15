using System;

public class ReadLib
{
    public ReadLib()
    {
    }

    public static List<City> ReadInCSV(string absolutePath)
    {
        List<City> result = new List<City>();
        using (var reader = new StreamReader(absolutePath))
        {
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.TypeConverterCache.AddConverter(typeof(double), new EmptyDouble());
                csv.Configuration.RegisterClassMap<CityMap>();
                //csv.Configuration.RegisterClassMap<CityMap>;

                while (csv.Read())
                {
                    result.Add(csv.GetRecord<City>());
                }
            }
            return result;
        }
    }
}
