using System;

namespace AocHelpers.Models
{
    [Flags]
    public enum Direction
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8
    }
}