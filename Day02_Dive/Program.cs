using Day02_Dive.Properties;
using SubmarineTools;
using System;

namespace Day02_Dive
{
    class Program
    {
        static void Main()
        {
            var splittedCommands = SubmarineReader.ReadTextToStringRows(Resources.Movements);

            var endpointResult = NavigationController.GetNavigationEndpoint(splittedCommands);
            Console.WriteLine($"Real endpoint result is {endpointResult.Item1 * endpointResult.Item2}");

            var endpointAdvancedResult = NavigationController.GetNavigationEndpointAdvanced(splittedCommands);
            Console.WriteLine($"Real advanced endpoint result is {endpointAdvancedResult.Item1 * endpointAdvancedResult.Item2}");
        }
    }
}
