using System.Collections.Generic;
using System.Linq;

namespace BeerTab9001
{
    class Tab
    {
        List<Alcoholic> alcoholicList;
        List<string> house;

        public Tab()
        {
            alcoholicList = new List<Alcoholic>();
            house = new List<string>();
            house.Add("Mathias");
            house.Add("Christine");
            house.Add("Omar");
            house.Add("Karim");
        }

        public void Guests()
        {
            int no = UI.GetNumberOfPeps();
            for (int i = 0; i < no; i++)
            {
                UI.Progress(i + 1, no);
                alcoholicList.Add(UI.GetPersonInfo());
            }
        }

        public void HouseMode()
        {
            int i = 0;
            foreach (string p in house)
            {
                UI.Progress(++i, house.Count());
                alcoholicList.Add(new Alcoholic(p, UI.GetBeers(p)));
            }
        }

        public void CloseTab()
        {
            double total = 0;
            int beerCount = + 0;
            foreach (var p in alcoholicList)
            {
                p.Bill = BeerPrice * p.BeerCount;
                UI.PrintBill(p);
                total += p.Bill;
                beerCount += p.BeerCount;
            }
            UI.PrintTotal(total, beerCount);

        }

        public double BeerPrice { get; set; }

    }
}
