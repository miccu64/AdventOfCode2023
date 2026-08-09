using Day17;
using Day17.Models;

Boundaries part1Boundaries = new(1, 3);

CostMap part1TestCostMap = new("TestData.txt");
Console.WriteLine($"Part1 test result: {part1TestCostMap.DoDijkstra(part1Boundaries)}, expected: 102");

CostMap part1CostMap = new("Input.txt");
Console.WriteLine($"Part1 result: {part1CostMap.DoDijkstra(part1Boundaries)}");


Boundaries part2Boundaries = new(4, 10);

CostMap part2Test1CostMap = new("TestData.txt");
Console.WriteLine($"Part2 test1 result: {part2Test1CostMap.DoDijkstra(part2Boundaries)}, expected: 94");

CostMap part2Test2CostMap = new("TestData2.txt");
Console.WriteLine($"Part2 test2 result: {part2Test2CostMap.DoDijkstra(part2Boundaries)}, expected: 71");

CostMap part2CostMap = new("Input.txt");
Console.WriteLine($"Part1 result: {part2CostMap.DoDijkstra(part2Boundaries)}");