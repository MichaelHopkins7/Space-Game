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

            Ship myShip;
            myShip = new Ship(3, 12, 6, 10, 10);
            Travel myUniverse;
            myUniverse = new Travel(200, 0);
            Player_Stats player;
            player = new Player_Stats(100, 0, 0, 0, 0, 0);
            bool isGameOver = false; //if a game end triggers this will be changed to true
            string input = ""; //Useful for when we want input


            int[,] cargoItems = new int[24, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 },
                { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 },
                { 0, 0 }, { 0, 0 }, { 0, 0 } }; //to store type and amount of cargo in slots
            
            int shipSpeed = 3; // initial ship max speed
            double speed = 0; //will be used to store speed in lightyears from formula

            int totalYears = 0; //trackers for total time spent traveling
            int totalWeeks = 0;
            int totalDays = 0;
            int totalHours = 0;

            int tripYears = 0; //trackers for time spent traveling on current trip
            int tripWeeks = 0;
            int tripDays = 0;
            int tripHours = 0;

            int[] prices = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            double curXC = 0; //set up tracker for current location to be used to calculate distance
            double curYC = 0; //	and sets up starting coordinates to match starting planet of Earth
            double totalTravelDistance = 0; // tracks total lifetime travel distance

            int planetNum = 0; //start at Earths number

            string playerLoc = "Earth"; //sets up current location name var and sets Earth for game start
            string destSystem = "";
            double distToDest = 0; //var for travel distance to new coordinates
            double destTravelTime = 0; //var for time spent traveling on a trip

            Console.WriteLine("The Space Game");
            Console.WriteLine("After a lifetime of wandering between planets you have finally decided to pursue your fortune in the interplanetary trade industry.");
            Console.WriteLine("With Earth being your new home you have decided that the best trading planets for your success will be The Great Planet and Alpha Centauri.");
            System.Threading.Thread.Sleep(6000);
            Console.Clear();
            Console.WriteLine("With your life savings(100 credits) and a brand new ship you head out to make your fortune. ");
            Console.WriteLine("Welcome to the beginning of your space trading adventure.");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Rules for the game:");
            Console.WriteLine("You will have 40 years to acquire as much wealth as possible and become the greatest trader of all time.");
            Console.WriteLine("Trade Routes: Plan appropriate and ensure that you find the best routes for moving around the galaxy.");
            Console.WriteLine("Time: This is your greatest enemy, learn to manipulate it to give you the advantage.");
            Console.WriteLine("Game Over Criteria: The game will end if you lose all of your fortune, quit the game, or you survive to 40 years.");
            System.Threading.Thread.Sleep(8000);
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
                        trading(planetNum, myShip.CargoSlots(), myShip.SlotSize(), ref cargoItems, prices);
                    }
                    else if (input == "Travel")
                    {
                        newPlanet(playerLoc, ref destSystem, ref planetNum);
                        if (destSystem != playerLoc)
                        {
                            Moving(planetNum, shipSpeed, ref speed, ref curXC, ref curYC, ref distToDest);
                            totalTravelDistance += distToDest;
                            destTravelTime = travelTime(distToDest, speed);
                            convertTime(destTravelTime, ref tripYears, ref tripWeeks, ref tripDays, ref tripHours);
                            Console.WriteLine($"You have arrived at {destSystem}.");
                            Console.Write("It took: ");
                            Console.Write($"{tripYears} Years, ");
                            Console.Write($"{tripWeeks} Weeks, ");
                            Console.Write($"{tripDays} Days, ");
                            Console.Write($"and {tripHours} Hours.");
                            playerLoc = destSystem;
                            addTime(tripYears, tripWeeks, tripDays, tripHours, //adds travel time to total time
                                ref totalYears, ref totalWeeks, ref totalDays, ref totalHours);
                            tripYears = 0;
                            tripWeeks = 0;
                            tripDays = 0;
                            tripHours = 0;
                            setPrices(planetNum, prices);
                            economicFluctuation(prices);
                        }
                        else
                        {
                            Console.WriteLine("You decided not to go anywhere.");
                        }
                    }
                    else if (input == "Check Status")
                    {
                        player.Status();
                        showCargoInv(myShip.CargoSlots(), cargoItems);
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
                    else if (player.SMoney() == 0)
                    {
                        isGameOver = true;
                        input = "";
                    }

                }
                while (input != "");
            }
            while (!isGameOver);

            player.Status();

            if (player.SMoney() > 100)
            {
                Console.WriteLine($"You made {player.SMoney() - 100}!");
            }
            else if (player.SMoney() < 100)
            {
                Console.WriteLine($"You lost {100 - player.SMoney()}.");
            }
            else
            {
                Console.WriteLine($"You broke even.");
            }
        }

        


        static void newPlanet(string atLocal, ref string destSystem, ref int planetNum)
        { //newPlanet(playerLoc, ref destSystem, ref planetNum);
            bool isGood = false;
            Console.WriteLine("Enter the place you wish to travel to from the list.");
            do
            {
                Console.WriteLine("Please enter the number of the destination.");
                Console.WriteLine($"Enter 0 if you do not wish to move.\n");

                Console.WriteLine("1. Earth"); //Planets list
                Console.WriteLine("2. Alpha Centauri");
                Console.WriteLine("3. My Great Planet");

                int destNum = Utility.GetInt(3);


                if (destNum == 0)
                {
                    destNum = planetNum;
                    destSystem = atLocal;
                    isGood = true;
                }
                else if (destNum == planetNum && !isGood)
                {
                    Console.WriteLine("You are already there!");
                    destNum = planetNum;
                    isGood = true;
                }
                else
                {
                    switch (destNum)
                    {
                        case 1:
                            destSystem = "Earth";
                            isGood = true;
                            planetNum = 0;
                            break;
                        case 2:
                            destSystem = "Alpha Centauri";
                            isGood = true;
                            planetNum = 1;
                            break;
                        case 3:
                            destSystem = "My Great Planet";
                            isGood = true;
                            planetNum = 2;
                            break;
                    }
                }
            }
            while (!isGood);
        }




        static void destX(int destNum, ref double destXC)
        {
            switch (destNum)
            {
                case 0:
                    destXC = 0.0;
                    break;
                case 1:
                    destXC = 0.0;
                    break;
                case 2:
                    destXC = -4.6;
                    break;
                default:
                    {
                        return;
                    }
            }
            return;
        }

        static void Moving(int planetNum, int shipSpeed, ref double speed, ref double curXC, ref double curYC, ref double distToDest)
        {
            double destXC = 0;
            double destYC = 0;
            speed = warpSpeed(shipSpeed);
            destX(planetNum, ref destXC);
            destY(planetNum, ref destYC);
            distToDest = calcDistance(curXC, curYC, destXC, destYC);
            curXC = destXC;
            curYC = destYC;
        }

        static void destY(int destNum, ref double destYC)
        {
            switch (destNum)
            {
                case 0:
                    destYC = 0.0;
                    break;
                case 1:
                    destYC = -4.367;
                    break;
                case 2:
                    destYC = 5;
                    break;
                default:
                    {
                        return;
                    }
            }
            return;
        }

        static double warpSpeed(int maxSpeed)
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
                    Console.WriteLine("Please enter an integer.");
                }
            }
            while (!isGood);

            double speed = Math.Pow(requestedWF, (10 / 3.0)) + Math.Pow((10 - requestedWF), (-11 / 3.0));
            return speed;
        }

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
            Console.WriteLine($"Here is what we have.\n");
        }


        static void trading(int placeNum, int totalSpace, int slotSpace, ref int[,] shipContents, int[] prices)
        {

            bool isDone = false;
            string input = "";
            do
            {
                planetInv(prices);
                showCargoInv(totalSpace, shipContents);
                Console.WriteLine("Would you like to buy or sell?");
                Console.WriteLine("If you would like to leave press \"Enter\".");
                input = Console.ReadLine();
                if (input == "")
                {
                    isDone = true;
                }
                else if (input == "Buy" || input == "buy")
                {
                    BuyThings(totalSpace, slotSpace, shipContents, prices); //Calls the method for buying
                }
                else if (input == "Sell" || input == "sell")
                {
                    sellThings();
                }
                else
                {
                    Console.WriteLine("I don't understand.");
                }
            }
            while (!isDone);
            Console.WriteLine("Good Luck!");
        }

        private static void sellThings()
        {
            Console.WriteLine("Not done.");
        }

        public static void BuyThings(int cargoSlots, int slotSpace, int[,] inventory, int[] prices)
        {
            bool isGood = false;
            int input;
            int cargoWhere;
            int itemAmount;
            int totalPrice;
            string currentItemBuy;
            bool action = false;
            do
            {
                Console.WriteLine("Lets take a look at your ship");
                Console.WriteLine("Enter 25 to check your inventory or 0 to leave.");
                Console.WriteLine("Nice ship, what slot are we using for new cargo?");
                cargoWhere = Utility.GetInt(cargoSlots);
                if (cargoWhere == 25)
                {
                    showCargoInv(cargoSlots, inventory);
                }
                else if (cargoWhere == 0)
                {

                }
                else // this is where buying starts
                {
                    Console.WriteLine("What do you want to buy?");

                    Console.WriteLine($"You want to buy more {Utility.cargoName(inventory[cargoWhere, 0])}.");
                    currentItemBuy = Utility.cargoName(inventory[cargoWhere, 0]);
                    Console.WriteLine("How much to you want to buy?");
                    itemAmount = int.Parse(Console.ReadLine());

                    if ((itemAmount + inventory[cargoWhere, 1]) > slotSpace)
                    {
                        Console.WriteLine("There isn't enough space");
                    }
                    else
                    {
                        totalPrice = itemAmount * prices[inventory[cargoWhere, 0]];
                        Utility.BuySellYN(totalPrice, ref action, 1);
                        if (action)
                        {
                            inventory[cargoWhere, 1] += itemAmount;
                        }
                        else
                        {
                            Console.WriteLine("Mayber another time.");
                        }
                    }
                }
            }
            while (!isGood);

        }



        static void setPrices(int planet, int[] prices)
        {
            switch (planet)
            {
                case 0:
                    prices[0] = 0;
                    prices[1] = 9;
                    prices[2] = 1;
                    prices[3] = 6;
                    prices[4] = 10;
                    prices[5] = 5;
                    prices[6] = 2;
                    prices[7] = 12;
                    prices[8] = 8;
                    prices[9] = 7;
                    break;
                case 1:
                    prices[0] = 0;
                    prices[1] = 5;
                    prices[2] = 10;
                    prices[3] = 3;
                    prices[4] = 3;
                    prices[5] = 4;
                    prices[6] = 12;
                    prices[7] = 4;
                    prices[8] = 6;
                    prices[9] = 8;
                    break;
                case 2:
                    prices[0] = 0;
                    prices[1] = 5;
                    prices[2] = 8;
                    prices[3] = 9;
                    prices[4] = 6;
                    prices[5] = 11;
                    prices[6] = 7;
                    prices[7] = 10;
                    prices[8] = 12;
                    prices[9] = 3;
                    break;
            }
        }
        static void economicFluctuation(int[] prices)
        {
            Random rnd = new Random();
            int rando;
            int counter = 1;
            do
            {
                rando = rnd.Next(1, 6);
                prices[counter] += (rando - 3);
                ++counter;
            }
            while (counter < 10);
        }


        static void planetInv(int[] prices) // Planet Inventory
        {
            Console.WriteLine("Cargo Name		    Cost\n");
            int counter = 1;
            do
            {
                Console.WriteLine($"({counter}){Utility.cargoName(counter)}              {(prices[counter])}");
            }
            while (counter <= 9);
        }




        static void showCargoInv(int cargoSlots, int[,] inventory)
        {
            int counter = 0;
            Console.WriteLine("SHIP CARGO");
            do
            {
                if (inventory[(counter), 0] == 0) // first spot in array is cargo type.  Type 0 is empty.
                {
                    Console.WriteLine($"Container {counter + 1} has nothing in it."); //says container it's on is empty
                }
                else
                {
                    Console.WriteLine($"Container {counter + 1} has {inventory[counter, 1]} units of {Utility.cargoName(inventory[counter, 0])}."); //says container content type and count.
                }
                counter++;
            }
            while (counter <= cargoSlots);
        }
    }


    
}

    


