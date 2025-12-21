using Day14.Models;

Platform testPlatform1 = new("TestData1.txt");
Console.WriteLine($"Test 1 - result: {testPlatform1.GetWeightAfterTiltNorth()}, expected: 136");

Platform platform1 = new("Input1.txt");
Console.WriteLine($"Part 1 result: {platform1.GetWeightAfterTiltNorth()}");

PlatformPart2 testPlatform2 = new("TestData1.txt");
Console.WriteLine($"Test 2 - result after 1 cycles: {testPlatform2.GetWeightAfterCycles(1)}, expected: 87");
Console.WriteLine($"Test 2 - result after 2 cycles: {testPlatform2.GetWeightAfterCycles(1)}, expected: 69");
Console.WriteLine($"Test 2 - result after 3 cycles: {testPlatform2.GetWeightAfterCycles(1)}, expected: 69");
