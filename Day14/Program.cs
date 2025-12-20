using Day14.Models;

Platform testPlatform1 = new("TestData1.txt");
Console.WriteLine($"Test 1 - result: {testPlatform1.GetWeightAfterTiltNorth()}, expected: 136");

Platform platform1 = new("Input1.txt");
Console.WriteLine($"Part 1 result: {platform1.GetWeightAfterTiltNorth()}");
