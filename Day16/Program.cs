using Day16.Models;

Layout testLayout1 = new("TestData1.txt");
int testResult1 = testLayout1.Traverse();
Console.WriteLine($"TestResult1: {testResult1}, expected: 46");