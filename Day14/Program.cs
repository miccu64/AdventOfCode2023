using Day14.Models;

Platform testPlatform1 = new("TestData1.txt");
Console.WriteLine($"Test 1 - result: {testPlatform1.GetWeightAfterTiltNorth()}, expected: 136");

Platform platform1 = new("Input1.txt");
Console.WriteLine($"Part 1 result: {platform1.GetWeightAfterTiltNorth()}");

PlatformPart2 testPlatform2 = new("TestData1.txt");
Console.WriteLine($"Test 2 - result after 1 cycles: {testPlatform2.GetWeightAfterCycles(1)}, expected: 87");
Console.WriteLine($"Test 2 - result after 2 cycles: {testPlatform2.GetWeightAfterCycles(1)}, expected: 69");
Console.WriteLine($"Test 2 - result after 3 cycles: {testPlatform2.GetWeightAfterCycles(1)}, expected: 69");

const long cycles = 1_000_000_000;
PlatformPart2 testPlatform3 = new("TestData1.txt");
Console.WriteLine($"Test 2 - result: {testPlatform3.GetWeightAfterCycles(cycles)}, expected: 64");

PlatformPart2 platform2 = new("Input1.txt");
Console.WriteLine($"Part 2 result: {platform2.GetWeightAfterCycles(cycles)}");