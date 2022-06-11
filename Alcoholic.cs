namespace BeerTab9001
{
    public class Alcoholic
    {
        public Alcoholic(string name, int beerCount = 0)
        {
            Name = name;
            BeerCount = beerCount;
        }

        public int BeerCount { get; set; }
        public string Name { get; set; }
        public double Bill { get; set; }
    }
}
