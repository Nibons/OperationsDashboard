using System;
using OperationsDashboard.Common;

namespace DataSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Redis_Hostname: " + EnvVar.AsString("Redis_Hostname"));
            Console.WriteLine("Redis_Port: " + EnvVar.AsString("Redis_Port"));
            Console.WriteLine("BoM_CsvFileName: " + EnvVar.AsString("BoM_CsvFileName"));
            var BomLoaded = new BoMServerMapping();
        }
    }
}
