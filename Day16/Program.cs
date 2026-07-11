using Day16;
using Day16.Models;

Layout testLayout1 = new("TestData1.txt");
int testResult1 = testLayout1.Traverse();
Console.WriteLine($"TestResult1: {testResult1}, expected: 46");

Layout layout1 = new("Data1.txt");
int result1 = layout1.Traverse();
Console.WriteLine($"Result1: {result1}");