using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTab9002
{
    class Tab
    {
        List<Alcoholic> alcoholics;
        List<string> house;
        public double BeerPrice { get; set; }

        public Tab(double bPrice)
        {
            BeerPrice = bPrice;
            alcoholics = new List<Alcoholic>();
            house = new List<string>();
            house.Add("Mathias");
            house.Add("Christine");
            house.Add("Omar");
            house.Add("Karim");
        }

        public void AddGuest(int beers, string name)
        {
            double bill = beers * BeerPrice;
            alcoholics.Add(new Alcoholic(name, beers, bill));
        }

        public void AddHouse()
        {
            foreach (string houseP in house)
            {
                alcoholics.Add(new Alcoholic(houseP));
            }
        }

        public bool UpdateAlcoholic(int i, int beers)
        {
            if (i >= alcoholics.Count)
                return false;

            alcoholics[i].BeerCount = beers;
            alcoholics[i].Bill = beers * BeerPrice;
            return true;
        }

        //Retruns [0] total price and [1] total beers
        public double[] CloseTab()
        {
            double[] tab = { 0, 0 };
            foreach (var dranker in alcoholics)
            {
                tab[0] += dranker.Bill;
                tab[1] += dranker.BeerCount;
            }
            return tab;
        }

        public string GetAlcoholicName(int i)
        {
            return (i < alcoholics.Count) ? alcoholics[i].Name : "N/A";
        }

        //returns [0]bill and [1]number of beers.
        public double[] GetAlcoholicNumbers(int i)
        {
            if (i < alcoholics.Count)
                return new double[] { alcoholics[i].Bill, alcoholics[i].BeerCount };

            return new double[] { 0, 0 };
        }
    }
}
