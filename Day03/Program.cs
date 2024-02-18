using Day03;

FileProcessor fileProcessorTest = new("test.txt");
Console.WriteLine($"Test - expected no gear result: 4361, got: {fileProcessorTest.NoGearsResult}");
Console.WriteLine($"Test - expected gear result: 467835, got: {fileProcessorTest.GearRatio}\n");

FileProcessor fileProcessor = new("input.txt");
Console.WriteLine($"No gear result: {fileProcessor.NoGearsResult}");
Console.WriteLine($"Gear result: {fileProcessor.GearRatio}\n");
