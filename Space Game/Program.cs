﻿using System;
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
            myShip = new Ship(3, 12, 6, 10, 10); // set ship speed, cargo slots, slot size, fuel tank, and fuel
            Travel myUniverse;
            myUniverse = new Travel(200, 0);
            Player_Stats player;
            player = new Player_Stats(100, 0, 0, 0, 0, 0);
            bool isGameOver = false; //if a game end triggers this will be changed to true
            string input = ""; //Useful for when we want input


            int[,] cargoItems = new int[24, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 },
                { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 },
                { 0, 0 }, { 0, 0 }, { 0, 0 } }; //to store type and amount of cargo in slots
            
            
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
                        vendorGreet(myUniverse.GetPlanetName());
                        trading(planetNum, myShip.CargoSlots(), myShip.SlotSize(), ref cargoItems, prices, player);
                    }
                    else if (input == "Travel")
                    {
                        
                    }
                    else if (input == "Check Status")
                    {
                        player.Status(myUniverse, myShip);
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

            player.Status(myUniverse, myShip);

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
        
        

        

        

        

        

        // Design the vendors for each location
        // Method for labeling each vendor
        static void vendorGreet(string playerAt)
        {
            Console.WriteLine($"Welcome to {playerAt}.");
            Console.WriteLine($"Here is what we have.\n");
        }


        static void trading(int placeNum, int totalSpace, int slotSpace, ref int[,] shipContents, int[] prices, Player_Stats player)
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
                    BuyThings(totalSpace, slotSpace, shipContents, prices, player); //Calls the method for buying
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

        public static void BuyThings(int cargoSlots, int slotSpace, int[,] inventory, int[] prices, Player_Stats player)
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
                        Utility.BuySellYN(totalPrice, ref action, 1, player);
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

    


