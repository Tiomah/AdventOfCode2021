using Day01_SonarSweep.Properties;
using System;
using System.Collections.Generic;

namespace Day01_SonarSweep
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> testMeasurements = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var testResult = SonarSweep.CountIncreasedDepths(testMeasurements);

            Console.WriteLine($"Test result is {testResult}, must be 7");

            var realMeasurements = GetDepthMeasurementsFromResourceFile();
            var realResult = SonarSweep.CountIncreasedDepths(realMeasurements);

            Console.WriteLine($"Resl result is {realResult}");

            var testSumsResult = SonarSweep.CountIncreasedDepthsSums(testMeasurements);

            Console.WriteLine($"Test result is {testSumsResult}, must be 5");

            var realSumsResult = SonarSweep.CountIncreasedDepthsSums(realMeasurements);

            Console.WriteLine($"Resl result is {realSumsResult}");
        }

        static IEnumerable<int> GetDepthMeasurementsFromResourceFile()
        {
            var measurementsList = new List<int>();
            var depthMeasurements = Resources.DepthMeasurements;

            var splittedResult = depthMeasurements.Split('\n');

            foreach (var measurement in splittedResult)
            {
                if (!int.TryParse(measurement, out int parsedMeasurement))
                    continue;

                measurementsList.Add(parsedMeasurement);
            }

            return measurementsList;
        }
    }
}
