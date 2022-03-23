using System;
using System.Collections.Generic;
using System.IO;

namespace Day1_SonarSweep
{
    class Day1_SonarSweep
    {
        static void Main(string[] args)
        {
            List<int> testMeasurements = new List<int> { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var testResult = SonarSweep.CountIncreasedDepths(testMeasurements);

            Console.WriteLine($"Test result is {testResult}, must be 7");

            var measurementsFilePath = @"Resources\DepthMeasurements.txt";
            var realMeasurements = GetDepthMeasurementsFromResourceFile(measurementsFilePath);
            var realResult = SonarSweep.CountIncreasedDepths(realMeasurements);

            Console.WriteLine($"Resl result is {realResult}");
        }

        static IEnumerable<int> GetDepthMeasurementsFromResourceFile(string resourceFilePath)
        {
            var measurementsList = new List<int>();

            TextReader textReader = new StreamReader(resourceFilePath);
            {
                string result = textReader.ReadToEnd();
                var splittedResult = result.Split('\n');

                foreach (var measurement in splittedResult)
                {
                    if (!int.TryParse(measurement, out int parsedMeasurement))
                        continue;

                    measurementsList.Add(parsedMeasurement);
                }
            }

            return measurementsList;
        }
    }
}
