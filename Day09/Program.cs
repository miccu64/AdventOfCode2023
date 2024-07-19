using Day09.Models;

static long GetResult(string fileName)
{
    long result = 0;
    List<string> lines = File.ReadLines(fileName).ToList();
    foreach (string line in lines)
    {
        result += new History(line).GetLatestValue();
    }
    return result;
}

string testFile = "test1.txt";
long testResult = GetResult(testFile);
Console.WriteLine("Test result: " + testResult);

string file = "input.txt";
long result = GetResult(file);
Console.WriteLine("Result: " + result);


