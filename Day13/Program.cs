// See https://aka.ms/new-console-template for more information

using Day13.Models;

int testResult1 = Pattern.GetSummary("TestData1.txt");
Console.WriteLine("Part 1 test expected result: 405, got: " + testResult1);

int result1 = Pattern.GetSummary("Input1.txt");
Console.WriteLine("Part 1 result: " + result1);