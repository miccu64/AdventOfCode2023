namespace Day02.Models
{
    internal struct CubesSet
    {
        public bool IsSetPossible { get; private set; }
        public uint BlueCount { get; private set; }
        public uint GreenCount { get; private set; }
        public uint RedCount { get; private set; }

        public CubesSet(string info)
        {
            string[] splittedInfo = info.Split(',');
            foreach (string cubesInfo in splittedInfo)
            {
                string[] splittedCubesInfo = cubesInfo.Trim().Split(" ");

                string countString = splittedCubesInfo.First();
                uint count = uint.Parse(countString);

                string currentColor = splittedCubesInfo[1];
                switch (currentColor)
                {
                    case "blue":
                        BlueCount = count;
                        break;
                    case "green":
                        GreenCount = count;
                        break;
                    case "red":
                        RedCount = count;
                        break;
                }
            }

            int blueMaxCount = 14;
            int greenMaxCount = 13;
            int redMaxCount = 12;

            IsSetPossible = BlueCount <= blueMaxCount && GreenCount <= greenMaxCount && RedCount <= redMaxCount;
        }
    }
}
