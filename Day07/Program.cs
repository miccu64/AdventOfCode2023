using Day07.Models;

Game testGame = new("test.txt");
Console.WriteLine("Test part 1 - expected: 6440, got: " + testGame.Result);

Game game = new("input.txt");
Console.WriteLine("Part 1 - got: " + game.Result);
