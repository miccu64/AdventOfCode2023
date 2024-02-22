namespace Day05.Models
{
    internal class Map
    {
        public string Name { get; private set; }
        public readonly Dictionary<int, int> SourceToDestination = new();

        public Map(string[] data) { 
        
        }
    }
}
