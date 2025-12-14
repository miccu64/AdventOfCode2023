using Day13.Models;

int testResult1 = PatternHelpers.GetSummary("TestData1.txt");
Console.WriteLine("Part 1 test expected result: 405, got: " + testResult1);

int result1 = PatternHelpers.GetSummary("Input1.txt");
Console.WriteLine("Part 1 result: " + result1);

int testResult2 = PatternHelpers.GetSummary("TestData1.txt", true);
Console.WriteLine("Part 2 test expected result: 400, got: " + testResult2);

int result2 = PatternHelpers.GetSummary("Input1.txt", true);
Console.WriteLine("Part 2 result: " + result2);