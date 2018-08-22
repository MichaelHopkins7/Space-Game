using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Program
    {


        static void Main(string[] args)
        {
            bool isGameOver = false; //if a game end triggers this will be changed to true
            string input = ""; //Useful for when we want input

            int cargoSpace = 12; // Setting ship max cargo capacities
            int shipAMCargo = 16; // capacity for ships other than starting ship
            int shipBMCargo = 20;
            int shipCMCargo = 24;

            int cargoCount = 0; // variable for Cargo in ship now

            int creditsNow = 100; //creates value for storing currency amount and sets initial currency. Whole credits only.
            int purchasePrice = 0; //sets up value to use for purchases


            int shipAMSpeed = 6; //setting speeds for other ships
            int shipBMSpeed = 7;
            int shipCMSpeed = 9;
            int warpFactor = 0; //your warp number for a trip
            double formulaSpeed = 0; //will be used to store speed in lightyears from formula

            int totalYears = 0; //trackers for total time spent traveling
            int totalWeeks = 0;
            int totalDays = 0;
            int totalHours = 0;

            int tripYears = 0; //trackers for time spent traveling on current trip
            int tripWeeks = 0;
            int tripDays = 0;
            int tripHours = 0;

            double currentX = 0; //set up tracker for current location to be used to calculate distance
            double currentY = 0; //	and sets up starting coordinates to match starting planet of Earth
            int curShipSpeed = 4; // initial ship max speed
            double totalTravelDistance = 0; // tracks total lifetime travel distance

            string playerLoc = "Earth"; //sets up current location name var and sets Earth for game start
            string destSystem = "";
            double destXCoord = 0;
            double destYCoord = 0;
            double distToDest = 0; //var for travel distance to new coordinates
            double destTravelTime = 0; //var for time spent traveling on a trip

            Console.WriteLine("The Space Game");
            Console.WriteLine("After a lifetime of wandering between planets you have finally");
            Console.WriteLine("decided to pursue your fortune in the interplanetary trade industry. ");
            Console.WriteLine("With Earth being your new home you have decided that the best ");
            Console.WriteLine("trading planets for your success will be The Great Planet and ");
            Console.WriteLine("Alpha Centauri.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("With your life savings(100 credits) and a brand ");
            Console.WriteLine("new ship you head out to make your fortune.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Welcome to the beginning of your space trade.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            do
            {
                do
                {
                    input = "";
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Trade, Travel, Check Status?");
                    Console.WriteLine("Or press \"Enter\" when you are ready to quit.");
                    input = Console.ReadLine();
                    if (input == "Trade")
                    {
                        vendorGreet(playerLoc);
                        
                    }
                    else if (input == "Travel")
                    {
                        destSystem = newPlanet(playerLoc);
                        destXCoord = destX(destSystem);
                        destYCoord = destY(destSystem);
                        warpFactor = requestWF(curShipSpeed);
                        formulaSpeed = WarpSpeed(warpFactor);
                        distToDest = calcDistance(currentX, currentY, destXCoord, destYCoord);
                        totalTravelDistance += distToDest;
                        destTravelTime = travelTime(distToDest, formulaSpeed);
                        convertTime(destTravelTime, ref tripYears, ref tripWeeks, ref tripDays, ref tripHours);
                        Console.WriteLine($"You have arrived at {destSystem}.");
                        Console.Write("It took: ");
                        Console.Write($"{tripYears} Years, ");
                        Console.Write($"{tripWeeks} Weeks, ");
                        Console.Write($"{tripDays} Days, ");
                        Console.Write($"and {tripHours} Hours.");
                        playerLoc = destSystem;
                        currentX = destXCoord;
                        currentY = destYCoord;
                        addTime(tripYears, tripWeeks, tripDays, tripHours, //adds travel time to total time
                            ref totalYears, ref totalWeeks, ref totalDays, ref totalHours);
                        tripYears = 0;
                        tripWeeks = 0;
                        tripDays = 0;
                        tripHours = 0;
                    }
                    else if (input == "Check Status")
                    {
                        Console.WriteLine($"You are at {destSystem}.");
                        Console.Write("You have been traveling for ");
                        Console.Write($"{totalYears} Years, ");
                        Console.Write($"{totalWeeks} Weeks, ");
                        Console.Write($"{totalDays} Days, ");
                        Console.Write($"and {totalHours} Hours.\n");
                        Console.WriteLine($"You have {creditsNow} credits.");
                    }
                    else if (input == "")
                    {
                        isGameOver = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid input.");
                    }

                    if (totalYears >= 40)
                    {
                        isGameOver = true;
                        input = "";
                    }
                    else if ((cargoCount == 0) && (creditsNow == 0))
                    {
                        isGameOver = true;
                        input = "";
                    }

                }
                while (input != "");
            }
            while (!isGameOver);

            Console.WriteLine("You have been traveling for:");
            Console.WriteLine($"Years:{totalYears}");
            Console.WriteLine($"Weeks:{totalWeeks}");
            Console.WriteLine($"Days:{totalDays}");
            Console.WriteLine($"Hours:{totalHours}");

            Console.WriteLine($"You traveled {totalTravelDistance} lightyears!");

            Console.WriteLine($"You had {creditsNow}");
            if (creditsNow > 100)
            {
                Console.WriteLine($"You made {creditsNow - 100}!");
            }
            else if (creditsNow < 100)
            {
                Console.WriteLine($"You lost {100 - creditsNow}.");
            }
            else
            {
                Console.WriteLine($"You broke even.");
            }
        }

        static string newPlanet(string atLocal)
        {
            bool isGood = false;
            Console.WriteLine("Enter the world you wish to travel to from the list.");
            string destName;
            do
            {
                Console.WriteLine("Please enter the destination name as shown with no spaces.");
                Console.WriteLine($"Press \"Enter\" if you do not wish to move.\n");

                Console.WriteLine("Earth"); //Planets list
                Console.WriteLine("Alpha Centauri");
                Console.WriteLine("My Great Planet");

                destName = Console.ReadLine();

                if (destName == "earth")
                {
                    destName = "Earth";
                }
                else if (destName == "alpha centauri")
                {
                    destName = "Alpha Centauri";
                }
                else if (destName == "my great planet")
                {
                    destName = "My Great Planet";
                }

                if (destName == atLocal)
                {
                    Console.WriteLine("You are already there");
                }
                else if (destName == "Earth")
                {
                    isGood = true;
                }
                else if (destName == "Alpha Centauri")
                {
                    isGood = true;
                }
                else if (destName == "My Great Planet")
                {
                    isGood = true;
                }
                else if (destName == "")
                {
                    destName = atLocal;
                    isGood = true;
                }
                else if (destName != "")
                {
                    Console.WriteLine("That is not a supported destination.");
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);
            return destName;
        }

        static double destX(string destName)
        {
            if (destName == "Earth")
            {
                return 0.0;
            }
            else if (destName == "Alpha Centauri")
            {
                return 0.0;
            }
            else
            {
                return -4.6;
            }
        }

        static double destY(string destName)
        {
            if (destName == "Earth" || destName == "earth")
            {
                return 0.0;
            }
            else if (destName == "Alpha Centauri")
            {
                return -4.367;
            }
            else
            {
                return 5;
            }
        }

        static int requestWF(int maxSpeed)
        {
            bool isGood = false;
            int requestedWF = 0;
            do
            {
                isGood = false;
                Console.WriteLine("Please enter the warp factor you wish to travel at.");
                try
                {
                    requestedWF = int.Parse(Console.ReadLine());
                    if (requestedWF > maxSpeed)
                    {
                        Console.WriteLine("Your ship can't go that fast!");
                    }
                    else if (requestedWF < 1)
                    {
                        Console.WriteLine("You need to be going at Warp speeds.");
                    }
                    else
                    {
                        isGood = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an interger.");
                }
            }
            while (!isGood);
            return requestedWF;
        }

        static double WarpSpeed(int warpFactor) => Math.Pow(warpFactor, (10 / 3.0)) + Math.Pow((10 - warpFactor), (-11 / 3.0));

        static double calcDistance(double curX, double curY, double newX, double newY)
        {
            double diffX = Math.Abs(newX - curX);
            double diffY = Math.Abs(newY - curY);
            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        static double travelTime(double distance, double speed) => distance / speed;

        static void convertTime(double time, ref int totYears, ref int totWeeks, ref int totDays, ref int totHours)
        {
            bool isGood = false;
            totYears = 0; //initiate time spent on current trip
            totWeeks = 0;
            totDays = 0;
            totHours = 0;

            do
            {

                isGood = false;
                if (time >= 1) //is trip 1 or more years
                {
                    --time;
                    ++totYears; //add years for year total until time has no years
                    isGood = false;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);
            time *= 365;

            do
            {
                isGood = false;
                if (time >= 1)
                {
                    --time;
                    ++totDays;
                    isGood = false;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);
            totWeeks = totDays / 7;
            totDays %= 7;
            time *= 24;
            do //rounds up hours
            {
                isGood = false;
                if (time > 0)
                {
                    --time;
                    ++totHours;
                    isGood = false;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);

            ++totHours; //you spent at least an hour landing/docking and taking off/undocking 
        }

        static void addTime(int tripYears, int tripWeeks, int tripDays, int tripHours, //taking trip time
                        ref int totYears, ref int totWeeks, ref int totDays, ref int totHours) //to add to total time
        {
            bool isGood = false;
            totYears += tripYears;
            totWeeks += tripWeeks;
            totDays += tripDays;
            totHours += tripHours;

            do // calculates adjustments to values due to totals crossing threshhold to next value and checks 40Year end.
            {
                isGood = false;
                if (totWeeks >= 53)
                {
                    totWeeks -= 53;
                    ++totYears;
                    totDays += 6;
                }
                else if (totDays >= 7)
                {
                    totDays -= 7;
                    ++totWeeks;
                }
                else if (totHours > 24)
                {
                    totHours -= 24;
                    ++totDays;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);
        }

        // Design the vendors for each location
        // Method for labeling each vendor
        static void vendorGreet(string playerAt)
        {
            Console.WriteLine($"Welcome to {playerAt}.");
            Console.WriteLine("Do you want to access the vendor?");
        }

        static void theGreatPlanetInv() // The Great Planet Inventory
        {
            Console.WriteLine("Cargo Name			Cost\n");
            Console.WriteLine("1, 				    5");   //Gold, 		
            Console.WriteLine("2, 				    8");   //Iron, 		
            Console.WriteLine("3, 			        9");   //Selenium, 	
            Console.WriteLine("4, 			        1");   //Platinum, 	
            Console.WriteLine("5, 			        11");   //Titanium, 	;
            Console.WriteLine("6, 			        7");   //Aluminum, 	
            Console.WriteLine("7, 			        10");   //Rhodium, 	;
            Console.WriteLine("8, 			        12");   //Rhuthenium, 	;
            Console.WriteLine("9, 			        3");   //Iridium, 	
        }

        static void earthInv() // Earth Inventory
        {
            Console.WriteLine("Cargo Name			Cost\n");
            Console.WriteLine("Gold				    9");
            Console.WriteLine("Iron 				1");
            Console.WriteLine("Selenium			    6");
            Console.WriteLine("Platinum			    10");
            Console.WriteLine("Titanium			    5");
            Console.WriteLine("Aluminum			    2");
            Console.WriteLine("Rhodium				12");
            Console.WriteLine("Rhuthenium			8");
            Console.WriteLine("Iridium 			    7");
        }

        static void alphaCentuariInv() //Alpha Centauri Inventory
        {
            Console.WriteLine("Cargo Name			Cost\n");
            Console.WriteLine("Gold	 				2");
            Console.WriteLine("Iron					10");
            Console.WriteLine("Selenium				3");
            Console.WriteLine("Platinum				3");
            Console.WriteLine("Titanium			    4");
            Console.WriteLine("Aluminum				12");
            Console.WriteLine("Rhodium				4");
            Console.WriteLine("Rhuthenium			6");
            Console.WriteLine("Iridium				8");
        }

        static void trading(string playerAt, ref int playerMoney, ref int cargoOnShip)
        {
            if (playerAt == "Earth")
            {
                string whatDo = ""
            }
        }
    }

}
