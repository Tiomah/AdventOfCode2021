using Day04_GiantSquid.Properties;
using SubmarineTools;
using System;

namespace Day04_GiantSquid
{
    class Program
    {
        static void Main()
        {
            var bingoInput = SubmarineReader.ReadTextToBingoMatrixes(Resources.BingoTables);

            var firstBingoScore = BingoCalculator.CalculateFirstBingoScore(bingoInput.Item1, bingoInput.Item2);
            Console.WriteLine($"First bingo score is {firstBingoScore}");

            var lastBingoScore = BingoCalculator.CalculateLastBingoScore(bingoInput.Item1, bingoInput.Item2);
            Console.WriteLine($"Last bingo score is {lastBingoScore}");
        }
    }
}
