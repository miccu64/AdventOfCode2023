using Day08.Models;

Network testNetwork1 = new("test1.txt");
long testResult1 = testNetwork1.Iterate();
Console.WriteLine("Test 1 part 1 - expected: 2, got: " + testResult1);

Network testNetwork2 = new("test2.txt");
long testResult2 = testNetwork2.Iterate();
Console.WriteLine("Test 2 part 1 - expected: 6, got: " + testResult2);

Network network = new("input.txt");
long networkResult = network.Iterate();
Console.WriteLine("Part 1 - got: " + networkResult);