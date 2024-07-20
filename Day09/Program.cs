using Day09.Models;

static Tuple<long, long> GetResult(string fileName)
{
    long resultFirst = 0;
    long resultLast = 0;
    List<string> lines = File.ReadLines(fileName).ToList();
    foreach (string line in lines)
    {
        History history = new(line);
        resultFirst += history.GetFirstValue();
        resultLast += history.GetLatestValue();
    }
    return new Tuple<long, long>(resultFirst, resultLast);
}

string testFile = "test1.txt";
Tuple<long, long> testResult = GetResult(testFile);
Console.WriteLine("Test result part 1: " + testResult.Item2);
Console.WriteLine("Test result part 2: " + testResult.Item1);

string file = "input.txt";
Tuple<long, long> result = GetResult(file);
Console.WriteLine("Result part 1: " + result.Item2);
Console.WriteLine("Result part 2: " + result.Item1);
