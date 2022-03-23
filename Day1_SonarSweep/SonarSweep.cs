using System.Collections.Generic;
using System.Linq;

namespace Day1_SonarSweep
{
    public static class SonarSweep
    {
        public static int CountIncreasedDepths(IEnumerable<int> measurements)
        {
            if (measurements == null || !measurements.Any())
                return 0;

            var previousDepth = measurements.First();
            var numberOfIncreases = 0;

            for (var i = 1; i < measurements.Count(); i++)
            {
                var currentDepth = measurements.ElementAt(i);

                if (currentDepth > previousDepth)
                    numberOfIncreases++;

                previousDepth = currentDepth;
            }

            return numberOfIncreases;
        }
    }
}
