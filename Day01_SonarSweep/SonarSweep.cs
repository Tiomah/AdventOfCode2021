using System.Collections.Generic;
using System.Linq;

namespace Day01_SonarSweep
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

        public static int CountIncreasedDepthsSums(IEnumerable<int> measurements)
        {
            if (measurements == null || measurements.Count() < 4)
                return 0;

            var previousDepthSum = measurements.ElementAt(0) + measurements.ElementAt(1) + measurements.ElementAt(2);
            var numberOfIncreases = 0;

            for (var i = 3; i < measurements.Count(); i++)
            {
                var currentDepthSum = measurements.ElementAt(i - 2) + measurements.ElementAt(i - 1) + measurements.ElementAt(i);

                if (currentDepthSum > previousDepthSum)
                    numberOfIncreases++;

                previousDepthSum = currentDepthSum;
            }

            return numberOfIncreases;
        }
    }
}
