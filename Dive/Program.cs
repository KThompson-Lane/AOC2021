using System;
using System.Collections.Generic;
using System.IO;

namespace Dive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var instructions = ParseInput("./input.txt");
            Console.WriteLine($"Horizontal position multiplied by depth is: {PartOne(instructions)}");
            Console.WriteLine($"Final horizontal position multiplied by final depth is: {PartTwo(instructions)}");

        }

        public static List<KeyValuePair<string, int>> ParseInput(string inputPath)
        {
            var inputStrings = System.IO.File.ReadLines(Path.GetFullPath(inputPath));
            List<KeyValuePair<string, int>> instructions = new();
            foreach (var instructionString in inputStrings)
            {
                var segments = instructionString.Split(' ');
                instructions.Add(new KeyValuePair<string, int>(segments[0], int.Parse(segments[1])));
            }

            return instructions;
        }

        public static int PartOne(List<KeyValuePair<string, int>>  instructions)
        {
            int horizontalPosition = 0, depth = 0;
            foreach (var instruction in instructions)
            {
                switch (instruction.Key)
                {
                    case "forward":
                        horizontalPosition += instruction.Value;
                        break;
                    case "down":
                        depth += instruction.Value;
                        break;
                    case "up":
                        depth -= instruction.Value;
                        break;
                    default:
                        throw new Exception("unexpected instruction");
                }
            }
            return horizontalPosition * depth;
        }
        
        public static int PartTwo(List<KeyValuePair<string, int>>  instructions)
        {
            int horizontalPosition = 0, depth = 0, aim = 0;
            foreach (var instruction in instructions)
            {
                switch (instruction.Key)
                {
                    case "forward":
                        horizontalPosition += instruction.Value;
                        depth += aim * instruction.Value;
                        break;
                    case "down":
                        aim += instruction.Value;
                        break;
                    case "up":
                        aim -= instruction.Value;
                        break;
                    default:
                        throw new Exception("unexpected instruction");
                }
            }
            return horizontalPosition * depth;
        }
    }
}