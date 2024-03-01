namespace Day08.Models
{
    internal class Node
    {
        public string Start { get; private set; }
        public string Left { get; private set; }
        public string Right { get; private set; }

        public Node(string data)
        {
            string[] splittedData = data.Split('=');
            Start = splittedData[0].Trim();

            string[] destinations = splittedData[1].Split(",");
            Left = destinations[0].Trim()[1..];
            Right = destinations[1].Trim()[..^1];

            foreach (string s in new[] { Start, Left, Right })
            {
                if (s.Length != 3)
                    throw new Exception("Wrong node data: " + s);
            }
        }

        public string FindNextNodeName(char direction)
        {
            return direction switch
            {
                'L' => Left,
                'R' => Right,
                _ => throw new Exception("Wrong direction: " + direction),
            };
        }
    }
}
