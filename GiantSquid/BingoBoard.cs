using System.Reflection;

namespace GiantSquid
{
    public class BingoBoard
    {
        public Marker[,] grid { get; set; }

        public BingoBoard()
        {
            grid = new Marker[5, 5];
        }

        public bool CheckWin()
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (grid[x, y].marked)
                    {
                        if (x == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (grid[x, y].marked)
                    {
                        if (y == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }

        public void Mark(int numberToMark)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (grid[x, y].value == numberToMark)
                    {
                        grid[x, y].marked = true;
                        return;
                    }
                }
            }
        }

        public int Score(int lastCalled)
        {
            int unmarkedSum = 0;
            foreach (var marker in grid)
            {
                if (!marker.marked)
                    unmarkedSum += marker.value;
            }

            return lastCalled * unmarkedSum;
        }
    }

    public struct Marker
    {
        public int value { get; set; }
        public bool marked { get; set; }
    }
}