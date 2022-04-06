using Day05_HydrothermalVenture.Properties;
using SubmarineTools;
using System;

namespace Day05_HydrothermalVenture
{
    class Program
    {
        static void Main()
        {
            var cloudLinesInput = SubmarineReader.ReadTextToStringRows(Resources.CloudLines);
            var detectionValue = 2;

            var resultBasicCloudsPointsCount = CloudsDetector.DetectCloudsIntersectBasic(cloudLinesInput, detectionValue);
            Console.WriteLine($"Result of the basic cloud detection with {detectionValue} density is {resultBasicCloudsPointsCount}");

            var resultAdvancedCloudsPointsCount = CloudsDetector.DetectCloudsIntersectAdvanced(cloudLinesInput, detectionValue);
            Console.WriteLine($"Result of the advanced cloud detection with {detectionValue} density is {resultAdvancedCloudsPointsCount}");
        }
    }
}
