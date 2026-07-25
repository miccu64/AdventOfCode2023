namespace AocHelpers.Models
{
    public class PointInfo<T>
    {
        public T Point { get; }
        public int X { get; }
        public int Y { get; }
        public Direction UsedDirection { get; }

        public PointInfo(T point, int x, int y, Direction usedDirection)
        {
            Point = point;
            X = x;
            Y = y;
            UsedDirection = usedDirection;
        }
    }
}