using Day05.Models;

Almanac testAlmanac = new("test.txt");
long testResultPart1 = testAlmanac.FindLowestLocationNumber();
Console.WriteLine($"Test part 1 - expected value: 35, got: {testResultPart1}");

Almanac almanac = new("input.txt");
long resultPart1 = almanac.FindLowestLocationNumber();
Console.WriteLine($"Part 1 - got: {resultPart1}");



AlmanacPart2 testAlmanacPart2 = new("test.txt");
long testResultPart2 = testAlmanacPart2.FindLowestLocationNumber();
Console.WriteLine($"Test part 2 - expected value: 46, got: {testResultPart2}");

AlmanacPart2 almanacPart2 = new("input.txt");
long resultPart2 = almanacPart2.FindLowestLocationNumber();
Console.WriteLine($"Part 2 - got: {resultPart2}");