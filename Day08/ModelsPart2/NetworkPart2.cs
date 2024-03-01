using Day08.Models;

namespace Day08.ModelsPart2
{
    internal class NetworkPart2 : Network
    {
        public NetworkPart2(string fileName) : base(fileName) { }

        public override long Iterate()
        {
            long stepsCount = 0;
            int directionIndex = 0;
            List<string> currentPositions = Nodes.Where(node => node.Start.EndsWith('A'))
                .Select(node => node.Start)
                .ToList();

            while (!currentPositions.All(pos => pos.EndsWith('Z')))
            {
                char direction = Directions[directionIndex];
                List<Node> currentNodes = Nodes.Where(node => currentPositions.Contains(node.Start)).ToList();
                currentPositions = currentNodes.Select(node => node.FindNextNodeName(direction)).ToList();

                stepsCount++;
                directionIndex++;
                if (directionIndex == Directions.Length)
                    directionIndex = 0;
            }

            return stepsCount;
        }
    }
}
