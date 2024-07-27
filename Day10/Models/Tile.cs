namespace Day10.Models
{
    internal class Tile
    {
        public int Order { get; set; }

        public SignEnum Sign { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool LeftConnect { get; private set; }
        public bool RightConnect { get; private set; }
        public bool UpConnect { get; private set; }
        public bool DownConnect { get; private set; }

        public Tile(char sign, int x, int y)
        {
            Sign = (SignEnum)sign;
            Order = 0;
            X = x;
            Y = y;

            LeftConnect = false;
            RightConnect = false;
            UpConnect = false;
            DownConnect = false;

            switch (Sign)
            {
                case SignEnum.DownLeft:
                    DownConnect = true;
                    LeftConnect = true;
                    break;
                case SignEnum.DownRight:
                    DownConnect = true;
                    RightConnect = true;
                    break;
                case SignEnum.UpDown:
                    UpConnect = true;
                    DownConnect = true;
                    break;
                case SignEnum.UpLeft:
                    UpConnect = true;
                    LeftConnect = true;
                    break;
                case SignEnum.UpRight:
                    UpConnect = true;
                    RightConnect = true;
                    break;
                case SignEnum.LeftRight:
                    LeftConnect = true;
                    RightConnect = true;
                    break;
                case SignEnum.Start:
                    LeftConnect = true;
                    RightConnect = true;
                    UpConnect = true;
                    DownConnect = true;
                    break;
            }
        }
    }
}
