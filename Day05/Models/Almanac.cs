namespace Day05.Models
{
    internal class Almanac
    {
        public readonly Dictionary<int, Map> Maps = new();

        public readonly List<int> Seeds;

        public Almanac(string fileName) { 
            string[] data = File.ReadAllLines(fileName);

            string[] seedData = data[0].Split(' ')[1..];
            Seeds = seedData.Select(int.Parse).ToList();

            int currentStart = 2;
            for(int i = currentStart; i<data.Length; i++) {
                if (!string.IsNullOrEmpty(data[i]))
                    continue;



            }
        }
    }
}
