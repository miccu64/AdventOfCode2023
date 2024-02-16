using System.Text;

ulong result = 0;
string fileName = "input.txt";
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
{
    string? line;
    while ((line = streamReader.ReadLine()) != null)
    {
        List<uint> numbersInLine = new();
        foreach (char character in line)
        {
            if (uint.TryParse(character.ToString(), out uint number))
                numbersInLine.Add(number);
        }

        if (numbersInLine.Count == 1)
        {
            uint number = numbersInLine.Single();
            result += (10 * number) + number;
        }
        else if (numbersInLine.Count >= 2)
        {
            uint number1 = numbersInLine.First();
            uint number2 = numbersInLine.Last();
            result += (10 * number1) + number2;
        }
    }
}

Console.WriteLine(result);