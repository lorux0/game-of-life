using System;
using System.Linq;

namespace GameOfLife;

public class GameOfLife
{
    private int width;
    private int height;
    private string[] rows;
    private string[] output;

    public string Process(string input)
    {
        rows = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        output = rows.ToArray();
        width = rows[0].Length;
        height = rows.Length;

        for (var w = 0; w < width; w++)
        {
            for (var h = 0; h < height; h++)
            {
                var currentCell = rows[h][w];
                var isAlive = currentCell == '*';

                if (isAlive)
                {
                    var aliveNeighbors = 0;
                    
                    if (IsCellAlive(w - 1, h - 1))
                        aliveNeighbors++;
                    if (IsCellAlive(w, h - 1))
                        aliveNeighbors++;
                    if (IsCellAlive(w + 1, h - 1))
                        aliveNeighbors++;
                    if (IsCellAlive(w - 1, h))
                        aliveNeighbors++;
                    if (IsCellAlive(w + 1, h))
                        aliveNeighbors++;
                    if (IsCellAlive(w - 1, h + 1))
                        aliveNeighbors++;
                    if (IsCellAlive(w, h + 1))
                        aliveNeighbors++;
                    if (IsCellAlive(w + 1, h + 1))
                        aliveNeighbors++;

                    if (aliveNeighbors < 2)
                        output[h] = output[h].Remove(w, 1).Insert(w, ".");
                    if (aliveNeighbors > 3)
                        output[h] = output[h].Remove(w, 1).Insert(w, ".");
                }
            }
        }

        return string.Join('\n', output) + "\n";
    }

    private bool IsCellAlive(int x, int y)
    {
        if (x < 0) return false;
        if (x >= width) return false;
        if (y < 0) return false;
        if (y >= height) return false;
        return rows[y][x] == '*';
    }
}