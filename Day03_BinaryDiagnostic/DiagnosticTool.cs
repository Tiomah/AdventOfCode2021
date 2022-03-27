using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03_BinaryDiagnostic
{
    public static class DiagnosticTool
    {
        public static int GetPowerConsumption(IEnumerable<string> diagnosticData)
        {
            if (diagnosticData == null || !diagnosticData.Any())
                return 0;

            var columnData = Enumerable.Repeat(string.Empty, diagnosticData.First().Length).ToArray();

            foreach (var diagnosticRow in diagnosticData)
            {
                for (int i = 0; i < diagnosticRow.Length; i++)
                {
                    columnData[i] += diagnosticRow[i];
                }
            }

            var gammaRateCode = string.Empty;
            var epsiloneRateCode = string.Empty;

            foreach (var column in columnData)
            {
                var binaryValue = column.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                gammaRateCode += binaryValue;
                epsiloneRateCode += Math.Abs(1 - char.GetNumericValue(binaryValue));
            }

            var gammaRate = Convert.ToInt32(gammaRateCode, 2);
            var epsilonRate = Convert.ToInt32(epsiloneRateCode, 2);

            var resultPowerConsumption = gammaRate * epsilonRate;

            return resultPowerConsumption;
        }
    }
}
