using Day05.Models;

Almanac testAlmanac = new("test.txt");
ulong testResultPart1 = testAlmanac.FindLowestLocationNumber();
Console.WriteLine($"Test part 1 - expected value: 35, got: {testResultPart1}");

Almanac almanac = new("input.txt");
ulong resultPart1 = almanac.FindLowestLocationNumber();
Console.WriteLine($"Part 1 - got: {resultPart1}");

