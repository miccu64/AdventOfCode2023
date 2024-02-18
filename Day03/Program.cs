using Day03;

FileProcessor fileProcessor = new("test.txt");
Console.WriteLine($"Test - expected no gear result: 4361, got: {fileProcessor.NoGearsResult}\n");
Console.WriteLine($"Test - expected with gear result: 467835, got: {fileProcessor.WithGearsResult}\n");

//ulong part1Result = ProcessFile("input.txt");
//Console.WriteLine($"Part 1 result: {part1Result}\n");



