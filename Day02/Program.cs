using Day02.Models;
using System.Text;

string fileName = "input.txt";
ulong idSummary = 0;
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
{
    string? line;
    while ((line = streamReader.ReadLine()) != null)
    {
        Game game = new(line);
        if (game.IsGamePossible)
            idSummary += game.Id;
    }
}

Console.WriteLine(idSummary);