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
    }
}
