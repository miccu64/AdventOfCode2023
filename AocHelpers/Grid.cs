using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AocHelpers.Models;

namespace AocHelpers
{
    public class Grid<T>
    {
        private readonly T[,] _layout;

        public int Width => _layout.GetLength(0);
        public int Height => _layout.GetLength(1);

        public IReadOnlyList<PointInfo<T>> AllPoints { get; }

        // jagged arrays takes [Y, X] dimensions 
        public T this[int x, int y] => _layout[y, x];

        public Grid(string fileName, Func<char, T> cellBuilder)
        {
            string[] text = File.ReadAllLines(fileName);

            int width = text[0].Length;
            int height = text.Length;

            List<PointInfo<T>> points = new List<PointInfo<T>>();

            _layout = new T[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    T cell = cellBuilder(text[y][x]);
                    _layout[y, x] = cell;

                    points.Add(new PointInfo<T>(cell, x, y));
                }
            }

            AllPoints = points;
        }

        /// <summary>
        /// Try to traverse in given direction by 1 field in given direction.
        /// </summary>
        /// <returns>ExtendedPointInfo if traversal possible; null when coordinates out of bounds.</returns>
        public ExtendedPointInfo<T>? TryTraverse(int x, int y, Direction direction)
        {
            (int x, int y) newCoordinates = direction switch
            {
                Direction.Up => (x, y - 1),
                Direction.Down => (x, y + 1),
                Direction.Left => (x - 1, y),
                Direction.Right => (x + 1, y),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

            bool isOutOfBounds = newCoordinates.x < 0 || newCoordinates.x >= Width || newCoordinates.y < 0 ||
                                 newCoordinates.y >= Height;
            if (isOutOfBounds)
                return null;

            T point = this[newCoordinates.x, newCoordinates.y];
            return new ExtendedPointInfo<T>(point, newCoordinates.x, newCoordinates.y, direction);
        }

        /// <summary>
        /// Prints grid to console for debugging purposes.
        /// </summary>
        /// <param name="printFunc">Function stating what should be printed.</param>
        public void PrintGridToConsole(Func<T, string> printFunc)
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(printFunc(this[x, y]).PadRight(4));
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}