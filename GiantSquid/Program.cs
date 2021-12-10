using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GiantSquid 
{
    public class Program
    {
        private static List<BingoBoard> boards;

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            boards = new List<BingoBoard>();
            var actions = ParseInput("./input.txt");
            var test = PlayToLose(actions);
            Console.WriteLine(test);
            
        }

        public static int[] ParseInput(string path)
        {
            var rawInput = File.ReadAllText(path);
            var inputData = rawInput.Split("\n\n");
            var winningNumbers = inputData[0].Split(",").Select(x => int.Parse(x)).ToArray();

            //loop through all of the boards  (100)
            for (int i = 1; i < inputData.Length; i++)
            {
                int[,] markers = new int[5, 5];
                var board = inputData[i].Split("\n");
                for (int y = 0; y < board.Length; y++)
                {
                    
                    var markerNumbers = board[y].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    for (int x = 0; x < markerNumbers.Length; x++)
                    {
                        markers[y, x] = markerNumbers[x];
                    }
                }
                ConstructBoard(markers);
                Console.WriteLine("board constructed");
            }
            return winningNumbers;
        }

        public static void ConstructBoard(int[,] markers)
        {
            var board = new BingoBoard();
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    board.grid[x, y] = new Marker { marked = false, value = markers[x, y] };
                }
            }
            boards.Add(board);
        }

        public static int PlayGame(int[] actions)
        {
            int count = 0;
            BingoBoard winner;
            foreach (var mark in actions)
            {
                count++;
                foreach (var board in boards)
                {
                    board.Mark(mark);
                    if (count >= 5)
                    {
                        if (board.CheckWin())
                        {
                            return board.Score(mark);
                        }
                    }
                }
            }

            throw new Exception("no winner");
        }

        public static int PlayToLose(int[] actions)
        {
            int count = 0;
            List<BingoBoard> remove;
            foreach (var mark in actions)
            {
                remove = new();
                count++;
                foreach (var board in boards)
                {
                    board.Mark(mark);
                    if (count >= 5)
                    {
                        if (board.CheckWin())
                        {
                            if (boards.Count > 1)
                            {
                                remove.Add(board);
                            }
                            else
                            {
                                return board.Score(mark); 
                            }
                        }
                    }
                }

                foreach (var removal in remove)
                {
                    boards.Remove(removal);
                }
            }
            throw new Exception("no winner");
        }
    }
}