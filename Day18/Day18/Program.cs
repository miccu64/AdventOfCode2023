using Day18.Models;

DigPlan planTestPart1 = new("TestData1.txt");
Console.WriteLine($"Part1 test1 result: {planTestPart1.CountCubicMeters()}, expected: 62");

DigPlan planPart1 = new("Input.txt");
Console.WriteLine($"Part1 result: {planPart1.CountCubicMeters()}");