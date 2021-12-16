using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MyApp
{
    public class Grid
    {
        public Dictionary<coordinate, int> grid;
        public Grid()
        {
            grid = new();
        }

        public void MarkVent(coordinate start, coordinate end)
        {
            //check if horizontal
            if (start.y == end.y)
            {
                if (start.x < end.x)
                {
                    //going left to right
                    int distance = end.x - start.x;
                    for (int i = 0; i <= distance; i++)
                    {
                        coordinate coord = new();
                        coord.x = start.x + i;
                        coord.y = start.y;

                        if (grid.ContainsKey(coord))
                        {
                            grid[coord] +=1;
                        }
                        else
                        {
                            grid.Add(coord, 1);
                        }
                    }
                }
                else
                {
                    //right to left
                    int distance = start.x - end.x;
                    for (int i = 0; i <= distance; i++)
                    {
                        coordinate coord = new();
                        coord.x = start.x - i;
                        coord.y = start.y;

                        if (grid.ContainsKey(coord))
                        {
                            grid[coord] +=1;
                        }
                        else
                        {
                            grid.Add(coord, 1);
                        }
                    }
                }
            }
            else if(start.x == end.x)
            {
                if (start.y < end.y)
                {
                    //going bottom up
                    int distance = end.y - start.y;
                    for (int i = 0; i <= distance; i++)
                    {
                        coordinate coord = new();
                        coord.y = start.y + i;
                        coord.x = start.x;

                        if (grid.ContainsKey(coord))
                        {
                            grid[coord] +=1;
                        }
                        else
                        {
                            grid.Add(coord, 1);
                        }
                    }
                }
                else
                {
                    //top down
                    int distance = start.y - end.y;
                    for (int i = 0; i <= distance; i++)
                    {
                        coordinate coord = new();
                        coord.y = start.y - i;
                        coord.x = start.x;

                        if (grid.ContainsKey(coord))
                        {
                            grid[coord] +=1;
                        }
                        else
                        {
                            grid.Add(coord, 1);
                        }
                    }
                }
            }
        }

        public int HowManyOverlaps()
        {
            return grid.Count(c => c.Value >= 2);
        }
    }

    public struct coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}