using Day15.Models.Part2;

namespace Day15Tests;

public class BoxesWrapperTests
{
    [Fact]
    public void Test1()
    {
        // Arrange
        BoxesWrapper boxesWrapper = new();
        string text = File.ReadAllText("TestInput.txt");

        // Act
        long focusingPower = boxesWrapper.Process(text);

        // Assert
        Assert.Equal(145, focusingPower);
    }
}