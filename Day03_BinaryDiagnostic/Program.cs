using Day03_BinaryDiagnostic.Properties;
using System;
using System.Collections.Generic;

namespace Day03_BinaryDiagnostic
{
    class Program
    {
        static void Main(string[] args)
        {
            var testDiagnosticData = new List<string> { 
                "00100", "11110", "10110", "10111", "10101", "01111",
                "00111", "11100", "10000", "11001", "00010", "01010"};
            var testPowerConsumptionResult = DiagnosticTool.GetPowerConsumption(testDiagnosticData);

            Console.WriteLine($"Test result is {testPowerConsumptionResult}, must be 198");

            var diagnosticData = GetDiganosticDataFromResource();
            var powerConsumptionResult = DiagnosticTool.GetPowerConsumption(diagnosticData);

            Console.WriteLine($"Result is {powerConsumptionResult}");

            var lifeSupportRatingTest = DiagnosticTool.GetLifeSupportRating(testDiagnosticData);

            Console.WriteLine($"Test result is {lifeSupportRatingTest}, must be 230");

            var lifeSupportRating = DiagnosticTool.GetLifeSupportRating(diagnosticData);

            Console.WriteLine($"Result is {lifeSupportRating}");
        }

        static IEnumerable<string> GetDiganosticDataFromResource()
        {
            var resourceData = Resources.DiagnosticData;

            var diagnosticData = resourceData.Split("\r\n");

            return diagnosticData;
        }
    }
}
