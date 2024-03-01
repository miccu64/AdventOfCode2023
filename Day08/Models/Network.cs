namespace Day08.Models
{
    internal class Network
    {
        public string Directions { get; private set; }

        public readonly List<Node> Nodes = new();

        public Network(string fileName)
        {
            string[] allData = File.ReadAllLines(fileName);
            Directions = allData[0];

            for (int i = 2; i < allData.Length; i++)
                Nodes.Add(new Node(allData[i]));
        }

        public virtual long Iterate()
        {
            string currentPosition = "AAA";
            string finalPosition = "ZZZ";
            long stepsCount = 0;
            int directionIndex = 0;

            while (currentPosition != finalPosition)
            {
                char direction = Directions[directionIndex];
                Node currentNode = Nodes.Single(node => node.Start == currentPosition);
                currentPosition = currentNode.FindNextNodeName(direction);

                stepsCount++;
                directionIndex++;
                if (directionIndex == Directions.Length)
                    directionIndex = 0;
            }

            return stepsCount;
        }
    }
}
