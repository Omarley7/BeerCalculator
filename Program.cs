namespace BeerTab9001
{
    class Program
    {
        

        static void Main(string[] args)
        {

            Tab tab = new Tab(); 

            UI.ShowIntro();
            tab.BeerPrice = UI.GetBeerPrice();

            switch (UI.GetMode()) {
                case 1:
                    //House Only
                    tab.HouseMode();
                    tab.CloseTab();
                    break;
                case 2:
                    //House +
                    tab.HouseMode();
                    tab.Guests();
                    tab.CloseTab();
                    break;
                case 3:
                    //Guests
                    tab.Guests();
                    tab.CloseTab();
                    break;
                case 0:
                    //Exit program
                    break;
            }
        }
    }
}
