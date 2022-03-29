using Day01_SonarSweep.Properties;
using SubmarineTools;
using System;
using System.Collections.Generic;

namespace Day01_SonarSweep
{
    class Program
    {
        static void Main()
        {
            var realMeasurements = GetDepthMeasurementsFromResourceFile();

            var realResult = SonarSweep.CountIncreasedDepths(realMeasurements);
            Console.WriteLine($"Real result is {realResult}");       

            var realSumsResult = SonarSweep.CountIncreasedDepthsSums(realMeasurements);
            Console.WriteLine($"Real sums result is {realSumsResult}");
        }

        static IEnumerable<int> GetDepthMeasurementsFromResourceFile()
        {
            var measurementsList = new List<int>();
            var splittedResult = SubmarineReader.ReadTextToStringRows(Resources.DepthMeasurements);

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
