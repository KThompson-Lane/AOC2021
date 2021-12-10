using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;

namespace BinaryDiagnostic // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = ParseInput("./input.txt");
            Console.WriteLine(PartOne(input));
            Console.WriteLine(PartTwo(input));
        }

        public static string[] ParseInput(string path)
        {
            var diagnosticReport = File.ReadAllLines(path);
            return diagnosticReport;
        }
        
        public static int PartOne(string[] diagnosticReport)
        {
            string gammaRate = "", epsilonRate = "";
            for (int x = 0; x < diagnosticReport[0].Length; x++)
            {
                int ones = 0, zeroes = 0;
                for (int y = 0; y < diagnosticReport.Length; y++)
                {
                    if (diagnosticReport[y][x] == '1')
                    {
                        ones++;
                    }
                    else
                    {
                        zeroes++;
                    }
                }

                gammaRate = String.Concat(gammaRate, (ones>zeroes ? '1':'0'));
                epsilonRate = String.Concat(epsilonRate, (ones>zeroes ? '0':'1'));

            }

            return (Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2));
        }

        public static int PartTwo(string[] diagnosticReport)
        {
            var oxygenRating = FindOxygenRating(diagnosticReport);
            var scrubberRating = FindScrubberRating(diagnosticReport);
            return oxygenRating*scrubberRating;
        }

        public static int FindOxygenRating(string[] diagnosticReport)
        {
            bool found = false;
            while (!found)
            {
                //loop over each character
                for (int x = 0; x < diagnosticReport[0].Length; x++)
                {
                    int ones = 0, zeroes = 0;
                    //loop over each diagnostic
                    for (int y = 0; y < diagnosticReport.Length; y++)
                    {
                        //count zeroes and ones
                        if (diagnosticReport[y][x] == '1')
                        {
                            ones++;
                        }
                        else
                        {
                            zeroes++;
                        }
                    }
                    char mostCommonBit;
                    if (ones >= zeroes)
                    {
                        mostCommonBit = '1';
                    }
                    else
                    {
                        mostCommonBit = '0';
                    }

                    diagnosticReport = diagnosticReport.Where(s => s[x] == mostCommonBit).ToArray();
                    if (diagnosticReport.Length == 1)
                    {
                        found = true;
                        break;
                    }
                }
            }
            var result = diagnosticReport[0];
            return Convert.ToInt32(result, 2);
        }

        public static int FindScrubberRating(string[] diagnosticReport)
        {
            bool found = false;
            while (!found)
            {
                //loop over each character
                for (int x = 0; x < diagnosticReport[0].Length; x++)
                {
                    int ones = 0, zeroes = 0;
                    //loop over each diagnostic
                    for (int y = 0; y < diagnosticReport.Length; y++)
                    {
                        //count zeroes and ones
                        if (diagnosticReport[y][x] == '1')
                        {
                            ones++;
                        }
                        else
                        {
                            zeroes++;
                        }
                    }
                    char leastCommonbit;
                    if (ones >= zeroes)
                    {
                        leastCommonbit = '0';
                    }
                    else
                    {
                        leastCommonbit = '1';
                    }

                    diagnosticReport = diagnosticReport.Where(s => s[x] == leastCommonbit).ToArray();
                    if (diagnosticReport.Length == 1)
                    {
                        found = true;
                        break;
                    }
                }
            }
            var result = diagnosticReport[0];
            return Convert.ToInt32(result, 2);
        }
    }
}