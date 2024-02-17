using System.Text;

Dictionary<string, uint> wordsNumbers = new()
{
    { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, {"five", 5 }, {"six", 6 }, {"seven", 7 }, {"eight", 8}, {"nine", 9}
};

ulong resultOnlyDigits = 0;
ulong resultWithWords = 0;

string fileName = "input.txt";
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
{
    string? line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<uint> numbersInLine = new();
        List<uint> numbersAndWordsInLine = new();

        string remainLetters = "";
        foreach (char character in line)
        {
            if (uint.TryParse(character.ToString(), out uint number))
            {
                numbersInLine.Add(number);
                numbersAndWordsInLine.Add(number);
                remainLetters = "";
            }
            else
            {
                remainLetters += character;

                if (remainLetters.Length < 3)
                    continue;

                foreach (var wordNumber in wordsNumbers)
                {
                    if (remainLetters.EndsWith(wordNumber.Key))
                    {
                        numbersAndWordsInLine.Add(wordNumber.Value);
                        break;
                    }
                }
            }
        }

        resultOnlyDigits += GetLineResult(numbersInLine);
        resultWithWords += GetLineResult(numbersAndWordsInLine);
    }
}

Console.WriteLine($"Result from only digits: {resultOnlyDigits}");
Console.WriteLine($"Result with words included: {resultWithWords}");

static uint GetLineResult(List<uint> values)
{
    if (values.Count == 0)
        return 0;

    uint number1 = values.First();
    uint number2 = values.Last();
    return (10 * number1) + number2;
}