using Day02.Models;
using System.Text;

ulong idSummary = 0;
ulong powerSummary = 0;

string fileName = "input.txt";
using (var fileStream = File.OpenRead(fileName))
using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true))
{
    string? line;
    while ((line = streamReader.ReadLine()) != null)
    {
        Game game = new(line);
        powerSummary += game.GamePower;
        if (game.IsGamePossible)
            idSummary += game.Id;
    }
}

Console.WriteLine($"Sum of possible games IDs: {idSummary}");
Console.WriteLine($"Sum of powers: {powerSummary}");