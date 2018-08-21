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

            double cargoSpace = 6; // Setting ship max cargo capacities
            double shipAMCargo = 8; // capacity for ships other than starting ship
            double shipBMCargo = 10;
            double shipCMCargo = 12;

            double shipCargoCurrent = 0; // variable for Cargo in ship now

            int creditsNow = 100; //creates value for storing currency amount and sets initial currency. Whole credits only.
            int purchasePrice = 0; //sets up value to use for purchases


            int shipAMSpeed = 6; //setting speeds for other ships
            int shipBMSpeed = 7;
            int shipCMSpeed = 9;
            int warpFactor = 0; //your warp number for a trip
            double formulaSpeed = 0; //will be used to store speed in lightyears from formula
            
            int totalYears = 0; //tracking time spent traveling
            int totalWeeks = 0;
            int totalDays = 0;
            int totalHours = 0;
 
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


            Console.WriteLine("Welcome to the beggining of your space trade.");

            do
            {
                do
                {
                    input = "";
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Buy, Sell, or Travel?");
                    Console.WriteLine("Or press \"Enter\" when you are ready to quit.");
                    input = Console.ReadLine();
                    if (input == "Buy")
                    {
                        Console.WriteLine("Not ready yet.");
                    }
                    else if (input == "Sell")
                    {
                        Console.WriteLine("Not ready yet.");
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
                        addTime(destTravelTime, ref totalYears, ref totalWeeks, ref totalDays, ref totalHours);
                        Console.WriteLine($"You have arrived at {destSystem}.");
                        Console.Write("It took: ");
                        Console.Write($"{totalYears} Years, ");
                        Console.Write($"{totalWeeks} Weeks, ");
                        Console.Write($"{totalDays} Days, ");
                        Console.Write($"and {totalHours} Hours.");
                        playerLoc = destSystem;
                        currentX = destXCoord;
                        currentY = destYCoord;
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
                    else if ((shipCargoCurrent == 0) && (creditsNow == 0))
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

        static public string newPlanet(string atLocal)
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

        static public double destX(string destName)
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

        static public double destY(string destName)
        {
            if (destName == "Earth")
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

        static public int requestWF(int maxSpeed)
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

        static public double WarpSpeed(int warpFactor) => Math.Pow(warpFactor, (10 / 3.0)) + Math.Pow((10 - warpFactor), (-11 / 3.0));

        static public double calcDistance(double curX, double curY, double newX, double newY)
        {
            double diffX = Math.Abs(newX - curX);
            double diffY = Math.Abs(newY - curY);
            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        static public double travelTime(double distance, double speed) => distance / speed;

        static public void addTime(double time, ref int totYears, ref int totWeeks, ref int totDays, ref int totHours)
        {
            bool isGood = false;
            int timeYears = 0; //initiate time spent on current trip
            int timeWeeks = 0;
            int timeDays = 0;
            int timeHours = 0;

            do
            {

                isGood = false;
                if (time >= 1) //is trip 1 or more years
                {
                    --time;
                    ++timeYears; //add years for year total until time has no years
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
                    ++timeDays;
                    isGood = false;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);
		    timeWeeks = timeDays / 7;
		    timeDays %= 7;
            time *= 24;
            do //rounds up hours
            {
                isGood = false;
                if (time > 0)
                {
                    --time;
                    ++timeHours;
                    isGood = false;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);

            ++timeHours; //you spent at least an hour landing/docking and taking off/undocking 
		
		    totYears += timeYears;
		    totWeeks += timeWeeks;
		    totDays += timeDays;
		    totHours += timeHours;
		
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
            while (!isGood) ;
		}
    }
}
