using System;

namespace BeerTab9002
{
    public static class UI
    {
        public static void ShowIntro()
        {
            Console.WriteLine(25*'*');
            Console.WriteLine("---Beer calculator 9001 Pro Plus Max XL QuadS---");
        }

        public static double GetBeerPrice()
        {
            Console.Write("Input current beer price: ");
            double price = GetPositiveDouble("You don't get paid for drinking!");
            Console.WriteLine("The beerprice is set to: {0:C}", price);
            return price;
        }

        public static int GetMode()
        {
            Console.WriteLine("House only" + "\t" + "type 1");
            Console.WriteLine("House +" + "\t \t" + "type 2");
            Console.WriteLine("Custom" + "\t \t" +  "type 3");
            Console.WriteLine("Exit" + "\t \t" + "type 0");

            string input = Console.ReadLine();
            int mode;

            while (true)
            {
                while (!Int32.TryParse(input, out mode))
                {
                    Console.WriteLine("Error! Please only input numbers in this field!");
                    input = Console.ReadLine();
                }

                if (mode <= 3 && mode >= 0)
                {
                    Console.Clear();
                    return mode;
                }

                Console.WriteLine("Please input a number between 0 and 3");
                input = Console.ReadLine();
            }
        }

        public static int GetActualBeerCount()
        {
            Console.WriteLine("How many beers did you actually drink?");
            return GetPositiveInt("Just a whole positive number please");
        }

        public static void PrintBill(string Name, double Bill, int BeerCount)
        {
            Console.WriteLine(String.Format("{0,-25} {1:C} for {2} beers", $"{Name} owes", Bill, BeerCount));
        }

        public static void PrintTotal(double total, int beerCount)
        {
            Console.WriteLine();
            Console.WriteLine("Gives a total of {0,2:C} in {1} beers", total, beerCount);
            Console.ReadKey();
        }

       

        public static int GetPersonInfo(out string name)
        {
            Console.WriteLine("You are about to add a person:");
            while (true)
            {
                Console.Write("Enter name: ");
                name = Console.ReadLine();
                int beers = GetBeers(name);

                Console.WriteLine("Is information above corret? Y/N");
                string input = Console.ReadLine();
                if (input.ToUpper() == "Y")
                    return beers;

                else
                    Console.WriteLine("Okay, starting over");
            }
        }

        public static int GetNumberOfPeps()
        {
            Console.WriteLine("How many alcholics would you like to add?");
            Console.Write("Number: ");
            int n = GetPositiveInt("Don't try to be smart with me and your negative numbers!");
            Console.Clear();
            return n;
        }

        public static int GetBeers(string name)
        {
            Console.Write($"Number of beers {name} had: ");
            return GetPositiveInt("Don't try to be smart with me and your negative numbers!");
        }

        public static void Progress(int index, int limit)
        {
            Console.WriteLine($"Adding {index} of {limit}");
        }

        #region PrivateHelp
        static int GetPositiveInt(string errorMsg)
        {
            string input = Console.ReadLine();

            int number;
            while (true)
            {
                while (!Int32.TryParse(input, out number))
                {
                    Console.WriteLine($"Please ony input decimal numbers. {input} is not accepted.");
                    input = Console.ReadLine();
                }

                if (number >= 0)
                    return number;

                Console.WriteLine(errorMsg);
                Console.Write("Number: ");
                input = Console.ReadLine();
            }
        }

        static double GetPositiveDouble(string errorMsg)
        {
            string input = Console.ReadLine();

            double number;
            while (true)
            {
                while (!Double.TryParse(input, out number))
                {
                    Console.WriteLine($"Please ony input whole numbers. {input} is not accepted.");
                    input = Console.ReadLine();
                }

                if (number >= 0)
                    return number;

                Console.WriteLine(errorMsg);
                Console.Write("Number: ");
                input = Console.ReadLine();
            }
        }
        #endregion
    }
}
