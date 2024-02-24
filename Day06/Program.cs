using Day06.Models;
using Day06.ModelsPart2;

Contest testContestPart1 = new("test.txt");
long testResultPart1 = testContestPart1.GetWinningCountMultiplied();
Console.WriteLine($"Test part 1 - expected: 288, got: {testResultPart1}");

Contest contestPart1 = new("input.txt");
long resultPart1 = contestPart1.GetWinningCountMultiplied();
Console.WriteLine($"Part 1 - got: {resultPart1}");



ContestPart2 testContestPart2 = new("test.txt");
long testResultPart2 = testContestPart2.GetWinningCountMultiplied();
Console.WriteLine($"Test part 2 - expected: 71503, got: {testResultPart2}");

ContestPart2 contestPart2 = new("input.txt");
long resultPart2 = contestPart2.GetWinningCountMultiplied();
Console.WriteLine($"Part 2 - got: {resultPart2}");