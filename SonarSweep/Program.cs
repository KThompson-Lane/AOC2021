using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;

namespace SonarSweep
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var depths = ParseInput("./input.txt");
            Console.WriteLine($"there are {PartOne(depths)} measurements that are larger than the previous measurement");
            Console.WriteLine($"there are {PartTwo(depths)} measurement windows that are larger than the previous measurement window");

        }

        public static List<int> ParseInput(string inputPath)
        {
            return System.IO.File.ReadLines(Path.GetFullPath(inputPath)).Select(depth => int.Parse(depth)).ToList();
        }

        public static int PartOne(List<int> depths)
        {
            int? previousDepth = null;
            var count = 0;
            foreach (var depth in depths)
            {
                if (depth > previousDepth)
                {
                    count++;
                }
                previousDepth = depth;
            }

            return count;
        }

        public static int PartTwo(List<int> depths)
        {
            var count = 0;
            var index = 0;
            IEnumerable<int>? previousWindow = null;
            foreach (var depth in depths)
            {
                var measurementWindow = depths.Skip(index++).Take(3);
                if (previousWindow != null)
                {
                    if (measurementWindow.Sum() > previousWindow.Sum())
                    {
                        count++;
                    }
                }
                previousWindow = measurementWindow;
            }
            return count;
        }
    }
}