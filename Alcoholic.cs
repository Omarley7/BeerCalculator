namespace BeerTab9002
{
    public class Alcoholic
    {
        public Alcoholic(string name, int beerCount = 0, double bill = 0)
        {
            Name = name;
            BeerCount = beerCount;
            Bill = bill;
        }

        public int BeerCount { get; set; }
        public string Name { get; set; }
        public double Bill { get; set; }
    }
}
