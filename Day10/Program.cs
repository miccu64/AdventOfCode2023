using Day10.Models;

List<string> testFiles = new() { "test1.txt", "test2.txt", "test3.txt", "test4.txt" };
List<int> testResults = new();

foreach (string file in testFiles)
{
    Area area = new(file);
    testResults.Add(area.FarthestTileOrder());
}

Console.WriteLine($"Test results: {string.Join(", ", testResults)} - expected: 4, 4, 8, 8");

int resultPart1 = new Area("input1.txt").FarthestTileOrder();
Console.WriteLine($"Result part 1: {resultPart1}");
