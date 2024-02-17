ulong testResult = ProcessFile("test.txt");
Console.WriteLine($"Test - expected result: 4361, got: {testResult}\n");

ulong part1Result = ProcessFile("input.txt");
Console.WriteLine($"Part 1 result: {part1Result}\n");



ulong ProcessFile(string fileName)
{
    ulong summary = 0;
    string[] fileContent = File.ReadLines(fileName).ToArray();

    for (int lineIndex = 0; lineIndex < fileContent.Length; lineIndex++)
    {
        string line = PadLine(fileContent[lineIndex]);
        string upperLine;
        string lowerLine;

        if (lineIndex == 0)
        {
            upperLine = new string('.', line.Length + 2);
            lowerLine = PadLine(fileContent[lineIndex + 1]);
        }
        else if (lineIndex == fileContent.Length - 1)
        {
            lowerLine = new string('.', line.Length + 2);
            upperLine = PadLine(fileContent[lineIndex - 1]);
        }
        else
        {
            upperLine = PadLine(fileContent[lineIndex - 1]);
            lowerLine = PadLine(fileContent[lineIndex + 1]);
        }

        string numberString = "";
        for (int charIndex = 1; charIndex < line.Length - 1; charIndex++)
        {
            char character = line[charIndex];
            if (IsDot(character))
                continue;

            while (IsDigit(character))
            {
                numberString += character;

                charIndex++;
                character = line[charIndex];
            }

            if (numberString.Length == 0)
                continue;


            char charBeforeNumber = line[charIndex - numberString.Length - 1];
            if (IsSpecial(character) || IsSpecial(charBeforeNumber))
            {
                summary += uint.Parse(numberString);
            }
            else
            {
                int upperLowerCharIndex = charIndex;
                int limit = charIndex - numberString.Length - 1;
                for (; upperLowerCharIndex >= limit; upperLowerCharIndex--)
                {
                    if (IsSpecial(upperLine[upperLowerCharIndex]) || IsSpecial(lowerLine[upperLowerCharIndex]))
                    {
                        summary += uint.Parse(numberString);
                        break;
                    }
                }
            }

            numberString = "";
        }
    }

    return summary;
}

string PadLine(string line)
{
    return $".{line}.";
}

bool IsDigit(char c)
{
    return c switch
    {
        '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => true,
        _ => false,
    };
}

bool IsDot(char c)
{
    return c == '.';
}

bool IsSpecial(char c)
{
    return !IsDot(c) && !IsDigit(c);
}