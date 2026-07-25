using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AocHelpers.Models;

namespace AocHelpers
{
    public class Grid<T>
    {
        private readonly T[,] _layout;

        public int Width => _layout.GetLength(0);
        public int Height => _layout.GetLength(1);
        public IEnumerable<T> AllPoints => _layout.Cast<T>();
        public T this[int x, int y] => _layout[y, x];

        public Grid(string fileName, Func<char, T> cellBuilder)
        {
            string[] text = File.ReadAllLines(fileName);

            int width = text[0].Length;
            int height = text.Length;

            _layout = new T[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _layout[x, y] = cellBuilder(text[x][y]);
                }
            }
        }

        public PointInfo<T>? TryTraverse(int x, int y, Direction direction)
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
            return new PointInfo<T>(point, newCoordinates.x, newCoordinates.y, direction);
        }
    }
}