using Day15.Models;

namespace Day15Tests;

public class HasherTests
{
    [Fact]
    public void SingleLetterHash()
    {
        // Arrange
        const string text = "H";
        Hasher hasher = new();

        // Act
        long result = hasher.Hash(text);

        // Assert
        Assert.Equal(200, result);
    }

    [Fact]
    public void MultipleLettersHash()
    {
        // Arrange
        const string text = "HASH";
        Hasher hasher = new();

        // Act
        long result = hasher.Hash(text);

        // Assert
        Assert.Equal(52, result);
    }

    [Fact]
    public void SequenceHash()
    {
        // Arrange
        string text = File.ReadAllText("TestInput.txt");
        Hasher hasher = new();

        // Act
        long result = hasher.Hash(text);

        // Assert
        Assert.Equal(1320, result);
    }
}