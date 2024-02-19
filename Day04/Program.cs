using Day04.Models;

long testResult = 0;
string[] testData = File.ReadAllLines("test.txt");
foreach (string line in testData)
    testResult += new Card(line).Points;

Console.WriteLine($"Test - expected: 13, got: {testResult}\n");

long result = 0;
string[] data = File.ReadAllLines("input.txt");
foreach (string line in data)
    result += new Card(line).Points;

Console.WriteLine($"Result: {result}");



Dictionary<int, Card> testCards = testData.Select(line => new Card(line)).ToDictionary(card => card.Id);
long testSummary = Card.FindWonCardsCount(testCards.Keys.ToList(), testCards);
Console.WriteLine($"Test part 2 - expected: 30, got: {testSummary}\n");

Dictionary<int, Card> cards = data.Select(line => new Card(line)).ToDictionary(card => card.Id);
long summary = Card.FindWonCardsCount(cards.Keys.ToList(), cards);
Console.WriteLine($"Part 2 result: {summary}");