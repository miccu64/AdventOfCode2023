using Day11.Models;

Image testPart1Image = new("TestData1.txt");
Console.WriteLine($"Test part 1 - expected: 374, got: {testPart1Image.FindSumOfShortestPaths()}");

Image part1Image = new("input.txt");
Console.WriteLine($"Part 1 - got: {part1Image.FindSumOfShortestPaths()}");
