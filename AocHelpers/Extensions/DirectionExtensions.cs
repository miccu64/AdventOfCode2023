using AocHelpers.Models;

namespace AocHelpers.Extensions
{
    public static class DirectionExtensions
    {
        public static bool IsOppositeDirection(this Direction direction, Direction otherDirection)
        {
            return (direction | otherDirection) switch
            {
                Direction.Down | Direction.Up => true,
                Direction.Left | Direction.Right => true,
                _ => false
            };
        }
    }
}