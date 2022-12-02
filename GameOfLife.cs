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

        for (var x = 0; x < width; x++)
        for (var y = 0; y < height; y++)
        {
            var aliveNeighbors = CountAliveNeighbors(x, y);

            if (IsAlive(x, y) && aliveNeighbors is < 2 or > 3)
                Kill(x, y);
            else if (aliveNeighbors == 3)
                Revive(x, y);
        }

        return string.Join('\n', output) + "\n";
    }

    private bool IsAlive(int x, int y) =>
        rows[y][x] == '*';

    private void Revive(int x, int y) =>
        output[y] = output[y].Remove(x, 1).Insert(x, "*");

    private void Kill(int x, int y) =>
        output[y] = output[y].Remove(x, 1).Insert(x, ".");

    private int CountAliveNeighbors(int x, int y)
    {
        var aliveNeighbors = 0;

        if (IsCellAlive(x - 1, y - 1))
            aliveNeighbors++;
        if (IsCellAlive(x, y - 1))
            aliveNeighbors++;
        if (IsCellAlive(x + 1, y - 1))
            aliveNeighbors++;
        if (IsCellAlive(x - 1, y))
            aliveNeighbors++;
        if (IsCellAlive(x + 1, y))
            aliveNeighbors++;
        if (IsCellAlive(x - 1, y + 1))
            aliveNeighbors++;
        if (IsCellAlive(x, y + 1))
            aliveNeighbors++;
        if (IsCellAlive(x + 1, y + 1))
            aliveNeighbors++;
        return aliveNeighbors;
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