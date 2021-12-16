using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private static Grid grid = new Grid();
        public static void Main(string[] args)
        {
            ParseInput("./input.txt");
            Console.WriteLine(grid.HowManyOverlaps());
        }

        public static void ParseInput(string path)
        {
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var coordinates = line.Split(" -> ");
                var startCoord = coordinates[0].Split(",");
                coordinate start = new coordinate();
                start.x = int.Parse(startCoord[0]);
                start.y = int.Parse(startCoord[1]);
                var endCoord = coordinates[1].Split(",");
                coordinate end = new coordinate();
                end.x = int.Parse(endCoord[0]);
                end.y = int.Parse(endCoord[1]);
                grid.MarkVent(start, end);
            }
        }
    }
}