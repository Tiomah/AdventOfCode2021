using Day03_BinaryDiagnostic.Properties;
using SubmarineTools;
using System;

namespace Day03_BinaryDiagnostic
{
    class Program
    {
        static void Main()
        {
            var diagnosticData = SubmarineReader.ReadTextToStringRows(Resources.DiagnosticData);

            var powerConsumptionResult = DiagnosticTool.GetPowerConsumption(diagnosticData);
            Console.WriteLine($"Power consumption result is {powerConsumptionResult}");

            var lifeSupportRating = DiagnosticTool.GetLifeSupportRating(diagnosticData);
            Console.WriteLine($"Life support rating result is {lifeSupportRating}");
        }
    }
}
