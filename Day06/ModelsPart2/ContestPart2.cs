using Day06.Models;

namespace Day06.ModelsPart2
{
    internal class ContestPart2 : Contest
    {
        public ContestPart2(string fileName) : base(fileName) { }

        protected override long[] GetNumbers(string text)
        {
            long[] numbers = base.GetNumbers(text);
            string joinedNumbers = string.Join("", numbers.Select(num => num.ToString()));
            return new long[] { long.Parse(joinedNumbers) };
        }
    }
}
