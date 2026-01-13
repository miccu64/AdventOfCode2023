using Day15.Models;
using Day15.Models.Part2;

string text = File.ReadAllText("Input.txt");

Hasher hasher = new();
long result1 = hasher.Hash(text);
Console.WriteLine("Result part 1: " + result1);

long result2 = new BoxesWrapper().Process(text);
Console.WriteLine("Result part 2: " + result2);