using Day07.Models;
using Day07.ModelsPart2;

Game testGame = new("test.txt");
Console.WriteLine("Test part 1 - expected: 6440, got: " + testGame.Result);

Game game = new("input.txt");
Console.WriteLine("Part 1 - got: " + game.Result);



GamePart2 testGamePart2 = new("test.txt");
Console.WriteLine("Test part 2 - expected: 5905, got: " + testGamePart2.Result);

GamePart2 gamePart2 = new("input.txt");
Console.WriteLine("Part 2 - got: " + gamePart2.Result);