using Day17;

CostMap costMapTest1 = new("TestData.txt");
Console.WriteLine($"Part1 test result: {costMapTest1.DoDijkstra()}, expected: 102");

// CostMap costMap1 = new("Input.txt");
// Console.WriteLine($"Part1 result: {costMap1.DoDijkstra()}");