using AocHelpers.Extensions;
using AocHelpers.Models;

namespace AocHelpers.Tests;

public class DirectionExtensionsTests
{
    [TestCase(Direction.Left, Direction.Right)]
    [TestCase(Direction.Right, Direction.Left)]
    [TestCase(Direction.Up, Direction.Down)]
    [TestCase(Direction.Down, Direction.Up)]
    [Test]
    public void IsOppositeDirection_Are_Opposite(Direction d1, Direction d2)
    {
        // Act / Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(d1.IsOppositeDirection(d2), Is.True);
            Assert.That(d2.IsOppositeDirection(d1), Is.True);
        }
    }

    [TestCase(Direction.Left, Direction.Left)]
    [TestCase(Direction.Left, Direction.Up)]
    [TestCase(Direction.Left, Direction.Down)]
    [TestCase(Direction.Right, Direction.Right)]
    [TestCase(Direction.Right, Direction.Up)]
    [TestCase(Direction.Right, Direction.Down)]
    [TestCase(Direction.Up, Direction.Left)]
    [TestCase(Direction.Up, Direction.Up)]
    [TestCase(Direction.Up, Direction.Right)]
    [TestCase(Direction.Down, Direction.Left)]
    [TestCase(Direction.Down, Direction.Down)]
    [TestCase(Direction.Down, Direction.Right)]
    [Test]
    public void IsOppositeDirection_Are_Not_Opposite(Direction d1, Direction d2)
    {
        // Act / Assert
        using (Assert.EnterMultipleScope())
        {
            Assert.That(d1.IsOppositeDirection(d2), Is.False);
            Assert.That(d2.IsOppositeDirection(d1), Is.False);
        }
    }

    [TestCase(Direction.Left)]
    [TestCase(Direction.Right)]
    [TestCase(Direction.Up)]
    [TestCase(Direction.Down)]
    [Test]
    public void IsOppositeDirection_Null_Is_Not_Opposite(Direction d)
    {
        // Act / Assert
        Assert.That(d.IsOppositeDirection(null), Is.False);
    }
}