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

        public static int GetLifeSupportRating(IEnumerable<string> diagnosticData)
        {
            if (diagnosticData == null || !diagnosticData.Any())
                return 0;

            var oxygenGeneratorRatingData = diagnosticData.ToList();
            var c02ScrubberRatingData = diagnosticData.ToList();

            var oxygenGeneratorCode = string.Empty;
            var c02ScrubberRatingCode = string.Empty;

            for (int i = 0;  i < oxygenGeneratorRatingData.First().Length; i++)
            {
                oxygenGeneratorRatingData = GetRemainingData(oxygenGeneratorRatingData, i, true);

                if (oxygenGeneratorRatingData.Count == 1)
                {
                    oxygenGeneratorCode = oxygenGeneratorRatingData.First();
                    break;
                }
                else if (oxygenGeneratorRatingData.Count < 1)
                {
                    break;
                }
            }

            for (int i = 0; i < c02ScrubberRatingData.First().Length; i++)
            {
                c02ScrubberRatingData = GetRemainingData(c02ScrubberRatingData, i, false);

                if (c02ScrubberRatingData.Count == 1)
                {
                    c02ScrubberRatingCode = c02ScrubberRatingData.First();
                    break;
                }
                else if (c02ScrubberRatingData.Count < 1)
                {
                    break;
                }
            }

            var oxygenGeneratorRating = Convert.ToInt32(oxygenGeneratorCode, 2);
            var c02ScrubberRating = Convert.ToInt32(c02ScrubberRatingCode, 2);

            var lifeSupportRating = oxygenGeneratorRating * c02ScrubberRating;

            return lifeSupportRating;
        }

        private static List<string> GetRemainingData(IEnumerable<string> diagnosticData, int position, bool isMostFrequentBit)
        {
            var diagnosticColumn = string.Empty; 

            foreach (var diagnosticRow in diagnosticData)
            {
                diagnosticColumn += diagnosticRow[position];
            }

            // This part I should do correctly

            var frequentBitValue = 0;

            if (isMostFrequentBit)
            {
                var groupsOfBitValues = diagnosticColumn.GroupBy(x => x).OrderByDescending(x => x.Count());

                if (groupsOfBitValues.First().Count() == groupsOfBitValues.ElementAt(1).Count())
                    frequentBitValue = 1;
                else if (groupsOfBitValues.First().Key == '1')
                    frequentBitValue = 1;
            }
            else
            {
                var groupsOfBitValues = diagnosticColumn.GroupBy(x => x).OrderBy(x => x.Count());

                if (groupsOfBitValues.First().Count() == groupsOfBitValues.ElementAt(1).Count())
                    frequentBitValue = 0;
                else if (groupsOfBitValues.First().Key == '1')
                    frequentBitValue = 1;
            }

            // ===============================

            var charBitValue = char.Parse(frequentBitValue.ToString());
            var resultData = diagnosticData.Where(row => row[position] == charBitValue).ToList();

            return resultData;
        }
    }
}
