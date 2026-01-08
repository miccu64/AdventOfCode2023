using Day15.Models;

string text = File.ReadAllText("Input.txt");

Hasher hasher = new();
long result1 = hasher.Hash(text);
Console.WriteLine("Result part 1: " + result1);