using Day11.Models;

Image testPart1Image = new("TestData1.txt", 2);
Console.WriteLine($"Test part 1 - expected: 374, got: {testPart1Image.FindSumOfShortestPaths()}");

Image part1Image = new("input.txt", 1);
Console.WriteLine($"Part 1 - got: {part1Image.FindSumOfShortestPaths()}");

Image testPart2Image = new("TestData1.txt", 10);
Console.WriteLine($"Test part 2 - expected: 1030, got: {testPart2Image.FindSumOfShortestPaths()}");

Image part2Image = new("input.txt", 1000000);
Console.WriteLine($"Part 2 - got: {part2Image.FindSumOfShortestPaths()}");