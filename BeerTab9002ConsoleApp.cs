using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTab9002
{
    class BeerTab9002ConsoleApp
    {
        Tab tab;
        public BeerTab9002ConsoleApp()
        {
            UI.ShowIntro();
            tab = new Tab(UI.GetBeerPrice());
        }

        public void Run()
        {
            switch(UI.GetMode())
            {
                case 1:
                    //House Only
                    HouseMode();
                    Bill();
                    break;
                case 2:
                    //House +
                    HouseMode();
                    GuestMode();
                    Bill();
                    break;
                case 3:
                    //Guests
                    GuestMode();
                    Bill();
                    break;
                case 0:
                    return;
            }

            ActualBeers();
        }

        private void ActualBeers()
        {
            int unaccountedBeers = UI.GetActualBeerCount() - (int)tab.CloseTab()[1];
            //Write new extra pr. person.
            //Update house
            //Give new total for every
        }

        private void Bill()
        {
            double[] bill = tab.CloseTab();
            string name;

            for (int i = 0; "N/A" != (name = tab.GetAlcoholicName(i)); i++)
            {
                double[] pbill = tab.GetAlcoholicNumbers(i);
                UI.PrintBill(name, pbill[0], (int)pbill[1]);
            }

            UI.PrintTotal(bill[0], (int)bill[1]);
        }

        private void GuestMode()
        {
            int peps = UI.GetNumberOfPeps();
            string name = "N/A";
            for (int i = 0; i < peps; i++)
                tab.AddGuest(beers: UI.GetPersonInfo(out name), name);
        }

        void HouseMode()
        {
            tab.AddHouse();
            for (int i = 0; i < 4; i++)
            {
                if(!tab.UpdateAlcoholic(i, UI.GetBeers(tab.GetAlcoholicName(i))))
                {
#if DEBUG
                    Console.WriteLine("ERROR!! HouseMode IndexOverflow");
#endif
                    break;
                }
            }
        }
    }
}
