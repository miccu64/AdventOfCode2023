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