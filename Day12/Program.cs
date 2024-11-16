using Day12.Models;

ConditionRecord testRecord = new("TestData.txt");
Console.WriteLine($"Test part 1 - expected: 21, got: {testRecord.SumArrangements()}");

ConditionRecord record = new("input.txt");
Console.WriteLine($"Part 1 - got: {record.SumArrangements()}");