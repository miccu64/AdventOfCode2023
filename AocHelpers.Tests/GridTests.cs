using AocHelpers.Models;

namespace AocHelpers.Tests;

public class GridTests
{
    private Grid<TestRecord> _grid;
    private const string FileName = "TestFile1.txt";

    [SetUp]
    public void Setup()
    {
        _grid = new Grid<TestRecord>(FileName, c => new TestRecord(c));
    }

    [Test]
    public void Matches_Values_By_Indexer()
    {
        // Act / Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_grid[0, 0].C, Is.EqualTo('1'));
            Assert.That(_grid[1, 0].C, Is.EqualTo('2'));
            Assert.That(_grid[0, 1].C, Is.EqualTo('3'));
            Assert.That(_grid[1, 1].C, Is.EqualTo('4'));
            Assert.That(_grid[0, 2].C, Is.EqualTo('5'));
            Assert.That(_grid[1, 2].C, Is.EqualTo('6'));
        }
    }

    [Test]
    public void Dimensions_Matches()
    {
        // Act / Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(_grid.Height, Is.EqualTo(3));
            Assert.That(_grid.Width, Is.EqualTo(2));
        }
    }

    [Test]
    public void AllPoints_Returns_All_Points()
    {
        // Act / Assert
        Assert.That(_grid.AllPoints.Distinct().Count(), Is.EqualTo(6));
    }

    [TestCaseSource(nameof(_outOfBoundsCases))]
    [Test]
    public void Throws_When_Index_Out_Of_Range(int x, int y)
    {
        // Act / Assert
        Assert.Throws<IndexOutOfRangeException>(() =>
        {
            TestRecord _ = _grid[x, y];
        });
    }

    [Test]
    public void PrintGridToConsole_Does_Not_Throw()
    {
        // Act / Assert
        Assert.DoesNotThrow(() => _grid.PrintGridToConsole(t => t.C.ToString()));
    }

    [Test]
    public void TryTraverse_Throws_On_Unknown_Direction()
    {
        // Arrange
        const Direction nonExistingDirection = 0;

        // Act / Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _grid.TryTraverse(0, 0, nonExistingDirection));
    }

    [Test]
    public void TryTraverse_Returns_Null_When_Out_Of_Bounds()
    {
        // Act / Assert
        Assert.That(_grid.TryTraverse(-1, 0, Direction.Down), Is.Null);
    }

    private static object[] _outOfBoundsCases =
    [
        new object[] { -1, 0 },
        new object[] { 0, -1 },
        new object[] { -1, -1 },
        new object[] { 2, 0 },
        new object[] { 0, 3 }
    ];

    private record TestRecord(char C);
}