using Day08.Models;
using Day08.ModelsPart2;

Network testNetwork1 = new("test1.txt");
long testResult1 = testNetwork1.Iterate();
Console.WriteLine("Test 1 part 1 - expected: 2, got: " + testResult1);

Network testNetwork2 = new("test2.txt");
long testResult2 = testNetwork2.Iterate();
Console.WriteLine("Test 2 part 1 - expected: 6, got: " + testResult2);

Network network = new("input.txt");
long networkResult = network.Iterate();
Console.WriteLine("Part 1 - got: " + networkResult);



NetworkPart2 testNetworkPart2 = new("test3.txt");
long testResultPart2 = testNetworkPart2.Iterate();
Console.WriteLine("Test 3 part 2 - expected: 6, got: " + testResultPart2);

NetworkPart2 networkPart2 = new("input.txt");
long resultPart2 = networkPart2.Iterate();
Console.WriteLine("Part 2 - got: " + resultPart2);
