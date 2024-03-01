using Day08.Models;

namespace Day08.ModelsPart2
{
    internal class NetworkPart2 : Network
    {
        public NetworkPart2(string fileName) : base(fileName) { }

        public override long Iterate()
        {
            List<string> starts = Nodes.Where(node => node.Start.EndsWith('A'))
                .Select(node => node.Start)
                .ToList();
            Dictionary<string, Dictionary<string, long>> startsWithEnds = new();

            foreach (string start in starts)
            {
                long stepsCount = 0;
                int directionIndex = 0;
                Dictionary<string, long> endsWithSteps = new();
                string currentPosition = start;

                do
                {
                    char direction = Directions[directionIndex];
                    Node currentNode = Nodes.Single(node => node.Start == currentPosition);
                    currentPosition = currentNode.FindNextNodeName(direction);

                    stepsCount++;
                    directionIndex++;
                    if (directionIndex == Directions.Length)
                        directionIndex = 0;

                    if (endsWithSteps.ContainsKey(currentPosition))
                        break;

                    if (currentPosition.EndsWith('Z'))
                        endsWithSteps[currentPosition] = stepsCount;
                }
                while (currentPosition != start);

                startsWithEnds[start] = endsWithSteps;
            }

            long[] allLengths = startsWithEnds.SelectMany(x => x.Value).Select(x => x.Value).ToArray();
            return LeastCommonMultiple(allLengths);
        }

        static long LeastCommonMultiple(long[] numbers)
        {
            static long greatestCommonDivisor(long a, long b) => b == 0 ? a : greatestCommonDivisor(b, a % b);
            static long lcm(long a, long b) => Math.Abs(a * b) / greatestCommonDivisor(a, b);

            return numbers.Aggregate(lcm);
        }
    }
}
