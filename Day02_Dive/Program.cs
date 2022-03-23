using Day02_Dive.Properties;
using System;
using System.Collections.Generic;

namespace Day02_Dive
{
    class Program
    {
        static void Main(string[] args)
        {
            var testMovementsList = new List<string> { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            var testEndpointResult = NavigationController.GetNavigationEndpoint(testMovementsList);

            Console.WriteLine($"Test result is {testEndpointResult.Item1 * testEndpointResult.Item2}, must be 150");

            var movementCommandsList = Resources.Movements;
            var splittedCommands = movementCommandsList.Split('\n');
            var endpointResult = NavigationController.GetNavigationEndpoint(splittedCommands);

            Console.WriteLine($"Real result is {endpointResult.Item1 * endpointResult.Item2}");

            var testEndpointAdvancedResult = NavigationController.GetNavigationEndpointAdvanced(testMovementsList);

            Console.WriteLine($"Advanced test result is {testEndpointAdvancedResult.Item1 * testEndpointAdvancedResult.Item2}, must be 900");

            var endpointAdvancedResult = NavigationController.GetNavigationEndpointAdvanced(splittedCommands);

            Console.WriteLine($"Real result is {endpointAdvancedResult.Item1 * endpointAdvancedResult.Item2}");
        }
    }
}
