namespace Day02.Models
{
    internal struct CubesSet
    {
        public bool IsSetPossible { get; private set; }

        public CubesSet(string info)
        {
            int blueCount = 0;
            int greenCount = 0;
            int redCount = 0;

            string[] splittedInfo = info.Split(',');
            foreach (string cubesInfo in splittedInfo)
            {
                string[] splittedCubesInfo = cubesInfo.Trim().Split(" ");

                string countString = splittedCubesInfo.First();
                int count = int.Parse(countString);

                string currentColor = splittedCubesInfo[1];
                switch (currentColor)
                {
                    case "blue":
                        blueCount += count;
                        break;
                    case "green":
                        greenCount += count;
                        break;
                    case "red":
                        redCount += count;
                        break;
                }
            }

            int blueMaxCount = 14;
            int greenMaxCount = 13;
            int redMaxCount = 12;

            IsSetPossible = blueCount <= blueMaxCount && greenCount <= greenMaxCount && redCount <= redMaxCount;
        }
    }
}
