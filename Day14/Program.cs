using Day14.Models;

Platform testPlatform1 = new("TestData1.txt");
Console.WriteLine($"Test 1 - result: {testPlatform1.GetWeightAfterTiltNorth()}, expected: 136");

Platform platform1 = new("Input1.txt");
Console.WriteLine($"Part 1 result: {platform1.GetWeightAfterTiltNorth()}");

const long cycles = 1_000_000_000;
PlatformPart2 testPlatform2 = new("Input1.txt");
Console.WriteLine($"Test 2 - result: {testPlatform2.GetWeightAfterCycles(cycles)}, expected: 64");
