using NUnit.Framework;

namespace GameOfLife;

public class GameOfLifeShould
{
    private GameOfLife game;

    [SetUp]
    public void Setup()
    {
        game = new GameOfLife();
    }

    [Test]
    public void Nothing()
    {
        var input =
            "...\n" +
            "...\n" +
            "...\n";

        string output = game.Process(input);
        
        Assert.AreEqual(input, output);
    }

    [Test]
    public void CellWithLowAmountOfNeighborsShouldDie()
    {
        var input =
            "...\n" +
            ".*.\n" +
            ".*.\n";
        
        string output = game.Process(input);
        
        string expectedResult =
            "...\n" +
            "...\n" +
            "...\n";
        
        Assert.AreEqual(expectedResult, output);
    }
}