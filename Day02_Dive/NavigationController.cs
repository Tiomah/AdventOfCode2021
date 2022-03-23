using System.Collections.Generic;

namespace Day02_Dive
{
    public static class NavigationController
    {
        public static (int, int) GetNavigationEndpoint(IEnumerable<string> navigationCommands)
        {
            (int, int) resultEndpoint = (0, 0);

            foreach (var command in navigationCommands)
            {
                var splittedCommand = command.Split(' ');

                switch (splittedCommand[0])
                {
                    case "forward":
                        resultEndpoint.Item1 += int.Parse(splittedCommand[1]);
                        break;
                    case "up":
                        resultEndpoint.Item2 -= int.Parse(splittedCommand[1]);
                        if (resultEndpoint.Item2 < 0) resultEndpoint.Item2 = 0;
                        break;
                    case "down":
                        resultEndpoint.Item2 += int.Parse(splittedCommand[1]);
                        break;
                }
            }

            return resultEndpoint;
        } 

        public static (int, int) GetNavigationEndpointAdvanced(IEnumerable<string> navigationCommands)
        {
            (int, int) resultEndpoint = (0, 0);

            int aim = 0;

            foreach (var command in navigationCommands)
            {
                var splittedCommand = command.Split(' ');

                switch (splittedCommand[0])
                {
                    case "forward":
                        var movePoints = int.Parse(splittedCommand[1]);
                        resultEndpoint.Item1 += movePoints;
                        resultEndpoint.Item2 += aim * movePoints;
                        if (resultEndpoint.Item2 < 0) resultEndpoint.Item2 = 0;
                        break;
                    case "up":
                        aim -= int.Parse(splittedCommand[1]);
                        break;
                    case "down":
                        aim += int.Parse(splittedCommand[1]);
                        break;
                }
            }

            return resultEndpoint;
        }
    }
}
