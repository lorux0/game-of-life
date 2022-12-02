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

    // 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
    [TestCase("...\n.*.\n.*.\n")]
    [TestCase(".*.\n...\n.*.\n")]
    public void UndercrowdedCellShouldDie(string input)
    {
        string expectedResult =
            "...\n" +
            "...\n" +
            "...\n";

        Assert.AreEqual(expectedResult, game.Process(input));
    }

    // 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
    [TestCase("***\n**.\n...\n", "*.*\n*..\n...\n")]
    [TestCase("**.\n**.\n.*.\n", "**.\n...\n.*.\n")]
    public void OvercrowdedCellShouldDie(string input, string expectedResult)
    {
        Assert.AreEqual(expectedResult, game.Process(input));
    }

    // 3. Any live cell with two or three live neighbours lives on to the next generation.
    [TestCase("**.\n*..\n.**\n", "**.\n*..\n.*.\n")]
    [TestCase("**.\n*..\n...\n", "**.\n*..\n...\n")]
    public void CellWithTwoOrThreeFriendsShouldSurvive(string input, string expectedResult)
    {
        Assert.AreEqual(expectedResult, game.Process(input));
    }
    
    // 4. Any dead cell with exactly three live neighbours becomes a live cell.
    [Test]
    public void OvercrowdedDeadCellShouldResurrect()
    {
        var input =
            ".*.\n" +
            "**.\n" +
            "...\n";
        
        string expectedResult =
            "**.\n" +
            "**.\n" +
            "...\n";
        
        Assert.AreEqual(expectedResult, game.Process(input));
    }
}