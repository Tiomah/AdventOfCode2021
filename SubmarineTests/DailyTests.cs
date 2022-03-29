using Day01_SonarSweep;
using Day02_Dive;
using Day03_BinaryDiagnostic;
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

            Assert.AreEqual(testIncreasesResult, 7);
            Assert.AreEqual(testIncreasesSumsResult, 5);
        }

        [Test]
        public void Day02_Test()
        {
            var testMovementsList = new List<string> { 
                "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };

            var testEndpointResult = NavigationController.GetNavigationEndpoint(testMovementsList);
            var testEndpointAdvancedResult = NavigationController.GetNavigationEndpointAdvanced(testMovementsList);

            Assert.AreEqual(testEndpointResult.Item1 * testEndpointResult.Item2, 150);
            Assert.AreEqual(testEndpointAdvancedResult.Item1 * testEndpointAdvancedResult.Item2, 900);
        }

        [Test]
        public void Day03_Test()
        {
            var testDiagnosticData = new List<string> {
                "00100", "11110", "10110", "10111", "10101", "01111",
                "00111", "11100", "10000", "11001", "00010", "01010"};

            var testPowerConsumptionResult = DiagnosticTool.GetPowerConsumption(testDiagnosticData);
            var lifeSupportRatingTest = DiagnosticTool.GetLifeSupportRating(testDiagnosticData);

            Assert.AreEqual(testPowerConsumptionResult, 198);
            Assert.AreEqual(lifeSupportRatingTest, 230);
        }
    }
}