namespace AocHelpers.Models
{
    public class ExtendedPointInfo<T> : PointInfo<T>
    {
        public Direction UsedDirection { get; }

        public ExtendedPointInfo(T point, int x, int y, Direction usedDirection) : base(point, x, y)
        {
            UsedDirection = usedDirection;
        }
    }
}