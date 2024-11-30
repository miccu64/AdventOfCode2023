using Day12.Models;

ConditionRecord testRecord = new("TestData.txt");
Console.WriteLine($"Test part 1 - expected: 21, got: {testRecord.SumArrangements()}");

ConditionRecord record = new("input.txt");
Console.WriteLine($"Part 1 - got: {record.SumArrangements()}");

ConditionRecordPart2 testPart2Record = new("TestData.txt");
Console.WriteLine($"Test part 2 - expected: 525152, got: {testPart2Record.SumArrangements()}");

ConditionRecordPart2 recordPart2 = new("input.txt");
Console.WriteLine($"Part 2 - got: {recordPart2.SumArrangements()}");
