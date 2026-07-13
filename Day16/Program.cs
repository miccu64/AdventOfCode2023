using Day16;

LayoutSummarizerPart1 testSummarizer1 = new("TestData1.txt");
Console.WriteLine($"TestResult1: {testSummarizer1.Traverse()}, expected: 46");

LayoutSummarizerPart1 layout1 = new("Data1.txt");
Console.WriteLine($"Result1: {layout1.Traverse()}");


LayoutSummarizerPart2 testSummarizer2 = new("TestData1.txt");
Console.WriteLine($"TestResult2: {testSummarizer2.Traverse()}, expected: 51");

LayoutSummarizerPart2 layout2 = new("Data1.txt");
Console.WriteLine($"Result2: {layout2.Traverse()}");