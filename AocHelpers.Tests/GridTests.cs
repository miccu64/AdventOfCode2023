using AocHelpers.Models;

namespace AocHelpers.Tests;

public class GridTests
{
    private Grid<TestRecord> _grid;

    [SetUp]
    public void Setup()
    {
        _grid = new Grid<TestRecord>("TestFile1.txt", c => new TestRecord(c));
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

    [TestCase(Direction.Down, 0, 0, 0, 1, '3')]
    [TestCase(Direction.Up, 0, 1, 0, 0, '1')]
    [TestCase(Direction.Left, 1, 0, 0, 0, '1')]
    [TestCase(Direction.Right, 0, 0, 1, 0, '2')]
    [Test]
    public void TryTraverse_Returns_Expected_Result(
        Direction direction,
        int x,
        int y,
        int expectedX,
        int expectedY,
        char expectedValue
    )
    {
        // Act
        ExtendedPointInfo<TestRecord>? info = _grid.TryTraverse(x, y, direction);

        // Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(info, Is.Not.Null);
            Assert.That(info.UsedDirection, Is.EqualTo(direction));
            Assert.That(info.X, Is.EqualTo(expectedX));
            Assert.That(info.Y, Is.EqualTo(expectedY));
            Assert.That(info.Point.C, Is.EqualTo(expectedValue));
        }
    }

    [Test]
    public void Throws_On_Uneven_Array()
    {
        // Act / Assert
        Assert.Throws<ArgumentException>(() =>
        {
            Grid<TestRecord> _ = new("UnevenArray.txt", c => new TestRecord(c));
        });
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