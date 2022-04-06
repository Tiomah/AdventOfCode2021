using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day05_HydrothermalVenture
{
    public static class CloudsDetector
    {
        public static int DetectCloudsIntersectBasic(IEnumerable<string> lineStringList, int detectionValue)
        {
            if (lineStringList == null || !lineStringList.Any() || detectionValue < 0)
                return 0;

            var lineList = ConvertStringsToLines(lineStringList);

            var coordinatesNetMap = new Dictionary<(int, int), int>();

            foreach (var line in lineList)
            {
                if (line.Item1.X == line.Item2.X)
                {
                    var topPoint = Math.Min(line.Item1.Y, line.Item2.Y);
                    var bottomPoint = Math.Max(line.Item1.Y, line.Item2.Y);

                    for (int i = 0; i <= bottomPoint - topPoint; i++)
                    {
                        var key = (line.Item1.X, topPoint + i);

                        if (coordinatesNetMap.ContainsKey(key))
                        {
                            coordinatesNetMap[key]++;
                        }
                        else
                        {
                            coordinatesNetMap[key] = 1;
                        }
                    }
                } 
                else if (line.Item1.Y == line.Item2.Y)
                {
                    var leftPoint = Math.Min(line.Item1.X, line.Item2.X);
                    var rightPoint = Math.Max(line.Item1.X, line.Item2.X);

                    for (int i = 0; i <= rightPoint - leftPoint; i++)
                    {
                        var key = (leftPoint + i, line.Item1.Y);

                        if (coordinatesNetMap.ContainsKey(key))
                        {
                            coordinatesNetMap[key]++;
                        }
                        else
                        {
                            coordinatesNetMap[key] = 1;
                        }
                    }
                }
            }

            var resultCloudedPointsCount = coordinatesNetMap.Where(p => p.Value >= detectionValue).Count();

            return resultCloudedPointsCount;
        }

        public static int DetectCloudsIntersectAdvanced(IEnumerable<string> lineStringList, int detectionValue)
        {
            if (lineStringList == null || !lineStringList.Any() || detectionValue < 0)
                return 0;

            var lineList = ConvertStringsToLines(lineStringList);

            var coordinatesNetMap = new Dictionary<(int, int), int>();

            foreach (var line in lineList)
            {
                if (line.Item1.X == line.Item2.X)
                {
                    var topPoint = Math.Min(line.Item1.Y, line.Item2.Y);
                    var bottomPoint = Math.Max(line.Item1.Y, line.Item2.Y);

                    for (int i = 0; i <= bottomPoint - topPoint; i++)
                    {
                        var key = (line.Item1.X, topPoint + i);

                        if (coordinatesNetMap.ContainsKey(key))
                        {
                            coordinatesNetMap[key]++;
                        }
                        else
                        {
                            coordinatesNetMap[key] = 1;
                        }
                    }
                }
                else if (line.Item1.Y == line.Item2.Y)
                {
                    var leftPoint = Math.Min(line.Item1.X, line.Item2.X);
                    var rightPoint = Math.Max(line.Item1.X, line.Item2.X);

                    for (int i = 0; i <= rightPoint - leftPoint; i++)
                    {
                        var key = (leftPoint + i, line.Item1.Y);

                        if (coordinatesNetMap.ContainsKey(key))
                        {
                            coordinatesNetMap[key]++;
                        }
                        else
                        {
                            coordinatesNetMap[key] = 1;
                        }
                    }
                }
                else if (Math.Abs(line.Item1.X - line.Item2.X) == Math.Abs(line.Item1.Y - line.Item2.Y))
                {
                    var xStep = line.Item1.X < line.Item2.X ? 1 : -1;
                    var yStep = line.Item1.Y < line.Item2.Y ? 1 : -1;

                    var difference = Math.Abs(line.Item1.X - line.Item2.X);

                    for (int i = 0; i <= difference; i++)
                    {
                        var key = (line.Item1.X + i * xStep, line.Item1.Y + i * yStep);

                        if (coordinatesNetMap.ContainsKey(key))
                        {
                            coordinatesNetMap[key]++;
                        }
                        else
                        {
                            coordinatesNetMap[key] = 1;
                        }
                    }
                }
            }

            var resultCloudedPointsCount = coordinatesNetMap.Where(p => p.Value >= detectionValue).Count();

            return resultCloudedPointsCount;
        }

        private static IEnumerable<(Point, Point)> ConvertStringsToLines(IEnumerable<string> lineStringList)
        {
            var pointsStringList = new List<string>();
            var lineList = new List<(Point, Point)>();

            foreach (var stringLine in lineStringList)
            {
                pointsStringList.AddRange(stringLine.Split(" -> ").SelectMany(s => s.Split(',')));
            }

            if (pointsStringList.Count % 4 != 0)
                return lineList;

            for (int i = 0; i < pointsStringList.Count; i += 4)
            {
                lineList.Add(
                    (new Point(int.Parse(pointsStringList[i]), int.Parse(pointsStringList[i + 1])),
                    new Point(int.Parse(pointsStringList[i + 2]), int.Parse(pointsStringList[i + 3]))));
            }

            return lineList;
        }
    }
}
