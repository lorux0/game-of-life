namespace GameOfLife;

public class GameOfLife
{
    public string Process(string input)
    {
        return input.Replace("*", ".");
    }
}