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
            myShip = new Ship(3, 12, 6, 10, 10); // set ship speed, cargo slots, slot size, fuel tank, and fuel
            Travel myUniverse;
            myUniverse = new Travel(200, 0);
            Player_Stats player;
            player = new Player_Stats(100, 0, 0, 0, 0, 0);
            int[] prices = new int[10];
            Trading MakeMoney = new Trading(prices, 0);
            bool isGameOver = false; //if a game end triggers this will be changed to true
            int input; //Useful for when we want input
            

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
                
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Trade");
                    Console.WriteLine("2. Travel");
                    Console.WriteLine("3. Check Status");
                    Console.WriteLine("0. Quit");
                    input = Utility.GetInt(3);
                    switch (input)
                    {
                        case 1:
                        {
                            vendorGreet(myUniverse.GetPlanetName());
                            trading(myUniverse, prices, player, myShip);
                            break;
                        }
                        case 2:
                        {
                            myUniverse.MovingTo(myShip, player);
                            break;
                        }
                        case 3:
                        {
                            player.Status(myUniverse, myShip);
                            break;
                        }
                        case 0:
                        {
                            isGameOver = true;
                            break;
                        }

                    }
                isGameOver |= Utility.CheckGameOver(myShip, myUniverse, player);
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


        static void trading(Travel myUniverse, int[] prices, Player_Stats player, Ship myShip)
        {

            bool isDone = false;
            string input = "";
            do
            {
                planetInv(prices);
                Utility.ShowCargoInv(myShip);
                Console.WriteLine("Would you like to buy or sell?");
                Console.WriteLine("If you would like to leave press \"Enter\".");
                input = Console.ReadLine();
                if (input == "")
                {
                    isDone = true;
                }
                else if (input == "Buy" || input == "buy")
                {
                    BuyThings(prices, player, myShip); //Calls the method for buying
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

        public static void BuyThings(int[] prices, Player_Stats player, Ship myShip)
        {
            bool isGood = false;
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
                cargoWhere = Utility.GetInt(myShip.CargoSlots());
                if (cargoWhere == 25)
                {
                    Utility.ShowCargoInv(myShip);
                }
                else if (cargoWhere == 0)
                {

                }
                else // this is where buying starts
                {
                    Console.WriteLine("What do you want to buy?");

                    Console.WriteLine($"You want to buy more {Utility.CargoName(myShip.inventory[cargoWhere, 0])}.");
                    currentItemBuy = Utility.CargoName(myShip.inventory[cargoWhere, 0]);
                    Console.WriteLine("How much to you want to buy?");
                    itemAmount = int.Parse(Console.ReadLine());

                    if ((itemAmount + myShip.inventory[cargoWhere, 1]) > myShip.SlotSize())
                    {
                        Console.WriteLine("There isn't enough space");
                    }
                    else
                    {
                        totalPrice = itemAmount * prices[myShip.inventory[cargoWhere, 0]];
                        Utility.BuySellYN(totalPrice, ref action, 1, player);
                        if (action)
                        {
                            myShip.inventory[cargoWhere, 1] += itemAmount;
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
                Console.WriteLine($"({counter}){Utility.CargoName(counter)}              {(prices[counter])}");
            }
            while (counter <= 9);
        }




        
    }


    
}

    


