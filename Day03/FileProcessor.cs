namespace Day03
{
    internal class FileProcessor
    {
        public long NoGearsResult { get; private set; }
        public long WithGearsResult { get; private set; }

        private List<Tuple<int, int>> asterisks = new();

        public FileProcessor(string fileName)
        {
            NoGearsResult = SumNoGears(fileName);
            WithGearsResult = NoGearsResult + SumGearsSubtractValues(fileName);
        }

        private long SumNoGears(string fileName)
        {
            long summary = 0;
            List<string> fileContent = LoadFileWithPadding(fileName);

            for (int lineIndex = 1; lineIndex < fileContent.Count - 1; lineIndex++)
            {
                string upperLine = fileContent[lineIndex - 1];
                string line = fileContent[lineIndex];
                string lowerLine = fileContent[lineIndex + 1];

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


                    int charBeforeNumberIndex = charIndex - numberString.Length - 1;
                    char charBeforeNumber = line[charBeforeNumberIndex];

                    if (IsSpecial(character) || IsSpecial(charBeforeNumber))
                    {
                        summary += uint.Parse(numberString);

                        if (IsAsterisk(character))
                            asterisks.Add(new Tuple<int, int>(charIndex, lineIndex));
                        if (IsAsterisk(charBeforeNumber))
                            asterisks.Add(new Tuple<int, int>(charBeforeNumberIndex, lineIndex));
                    }
                    else
                    {
                        int upperLowerCharIndex = charIndex;
                        int limit = charIndex - numberString.Length - 1;
                        for (; upperLowerCharIndex >= limit; upperLowerCharIndex--)
                        {
                            char upperChar = upperLine[upperLowerCharIndex];
                            char lowerChar = lowerLine[upperLowerCharIndex];
                            if (IsSpecial(upperChar) || IsSpecial(lowerChar))
                            {
                                summary += uint.Parse(numberString);

                                if (IsAsterisk(upperChar))
                                    asterisks.Add(new Tuple<int, int>(upperLowerCharIndex, lineIndex - 1));
                                if (IsAsterisk(lowerChar))
                                    asterisks.Add(new Tuple<int, int>(upperLowerCharIndex, lineIndex + 1));

                                break;
                            }
                        }
                    }

                    numberString = "";
                }
            }

            asterisks = asterisks.Distinct().ToList();

            return summary;
        }

        private long SumGearsSubtractValues(string fileName)
        {
            long summary = 0;
            List<string> fileContent = LoadFileWithPadding(fileName);

            foreach (Tuple<int, int> xy in asterisks)
            {
                int x = xy.Item1;
                int y = xy.Item2;

                List<uint> adjacentNumbers = new();

                for (int currentY = y - 1; currentY <= y + 1; currentY++)
                {
                    string line = fileContent[currentY];
                    for (int currentX = x - 1; currentX <= x + 1; currentX++)
                    {
                        char currentChar = line[currentX];
                        if (!IsDigit(currentChar))  
                            continue;

                        string wholeNumber = currentChar.ToString();
                        int xShiftToLeft = -1;
                        currentChar = line[currentX + xShiftToLeft];
                        while (IsDigit(currentChar))
                        {
                            wholeNumber = currentChar + wholeNumber;
                            xShiftToLeft--;
                            currentChar = line[currentX + xShiftToLeft];
                        }

                        currentChar = line[currentX + 1];
                        while (IsDigit(currentChar))
                        {
                            wholeNumber += currentChar;
                            currentX++;
                            currentChar = line[currentX + 1];
                        }

                        adjacentNumbers.Add(uint.Parse(wholeNumber));
                    }
                }

                if (adjacentNumbers.Count == 2)
                {
                    uint number1 = adjacentNumbers.First();
                    uint number2 = adjacentNumbers.Last();
                    summary += number1 * number2 - number1 - number2;
                }
            }

            return summary;
        }

        private List<string> LoadFileWithPadding(string fileName)
        {
            List<string> fileContent = File.ReadLines(fileName)
                .Select(line => $".{line}.")
                .ToList();
            fileContent.Insert(0, new string('.', fileContent[0].Length));
            fileContent.Add(new string('.', fileContent[0].Length));

            return fileContent;
        }

        private bool IsDigit(char c)
        {
            return c switch
            {
                '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => true,
                _ => false,
            };
        }

        private bool IsDot(char c)
        {
            return c == '.';
        }

        private bool IsSpecial(char c)
        {
            return !IsDot(c) && !IsDigit(c);
        }

        private bool IsAsterisk(char c)
        {
            return c == '*';
        }
    }
}
