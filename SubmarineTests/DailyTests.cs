using Day01_SonarSweep;
using Day02_Dive;
using Day03_BinaryDiagnostic;
using Day04_GiantSquid;
using Day05_HydrothermalVenture;
using NUnit.Framework;
using System.Collections.Generic;

namespace SubmarineTests
{
    public class DailyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Day01_Test()
        {
            List<int> testMeasurements = new List<int> { 
                199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };

            var testIncreasesResult = SonarSweep.CountIncreasedDepths(testMeasurements);
            var testIncreasesSumsResult = SonarSweep.CountIncreasedDepthsSums(testMeasurements);

            Assert.AreEqual(7, testIncreasesResult);
            Assert.AreEqual(5, testIncreasesSumsResult);
        }

        [Test]
        public void Day02_Test()
        {
            var testMovementsList = new List<string> { 
                "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

            var testEndpointResult = NavigationController.GetNavigationEndpoint(testMovementsList);
            var testEndpointAdvancedResult = NavigationController.GetNavigationEndpointAdvanced(testMovementsList);

            Assert.AreEqual(150, testEndpointResult.Item1 * testEndpointResult.Item2);
            Assert.AreEqual(900, testEndpointAdvancedResult.Item1 * testEndpointAdvancedResult.Item2);
        }

        [Test]
        public void Day03_Test()
        {
            var testDiagnosticData = new List<string> {
                "00100", "11110", "10110", "10111", "10101", "01111",
                "00111", "11100", "10000", "11001", "00010", "01010"};

            var testPowerConsumptionResult = DiagnosticTool.GetPowerConsumption(testDiagnosticData);
            var lifeSupportRatingTest = DiagnosticTool.GetLifeSupportRating(testDiagnosticData);

            Assert.AreEqual(198, testPowerConsumptionResult);
            Assert.AreEqual(230, lifeSupportRatingTest);
        }

        [Test]
        public void Day04_Test()
        {
            var testBingoNumbers = new List<int> {
                7, 4, 9, 5, 11, 17, 23,
                2, 0, 14, 21, 24, 10, 16,
                13, 6, 15, 25, 12, 22, 18,
                20, 8, 19, 3, 26, 1 };

            var testMatrixList = new List<List<int>>
            {
                new List<int>{
                    22, 13, 17, 11, 0,
                    8, 2, 23, 4, 24,
                    21, 9, 14, 16, 7,
                    6, 10, 3, 18, 5,
                    1, 12, 20, 15, 19 },
                new List<int>{
                    3, 15, 0, 2, 22,
                    9, 18, 13, 17, 5,
                    19, 8, 7, 25, 23,
                    20, 11, 10, 24, 4,
                    14, 21, 16, 12, 6 },
                new List<int>{
                    14, 21, 17, 24, 4,
                    10, 16, 15, 9, 19,
                    18, 8, 23, 26, 20,
                    22, 11, 13, 6, 5,
                    2, 0, 12, 3, 7 }
            };

            var testFirstBingoScore = BingoCalculator.CalculateFirstBingoScore(testBingoNumbers, testMatrixList);
            var testLastBingoScore = BingoCalculator.CalculateLastBingoScore(testBingoNumbers, testMatrixList);

            Assert.AreEqual(4512, testFirstBingoScore);
            Assert.AreEqual(1924, testLastBingoScore);
        }

        [Test]
        public void Day05_Test()
        {
            var testCloudLines = new List<string> {
                "0,9 -> 5,9", "8,0 -> 0,8", "9,4 -> 3,4", "2,2 -> 2,1", "7,0 -> 7,4",
                "6,4 -> 2,0", "0,9 -> 2,9", "3,4 -> 1,4", "0,0 -> 8,8", "5,5 -> 8,2" };

            var testBasicCloudsPointsCount = CloudsDetector.DetectCloudsIntersectBasic(testCloudLines, 2);
            var testAdvancedCloudsPointsCount = CloudsDetector.DetectCloudsIntersectAdvanced(testCloudLines, 2);

            Assert.AreEqual(5, testBasicCloudsPointsCount);
            Assert.AreEqual(12, testAdvancedCloudsPointsCount);
        }
    }
}