using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Trading
    {
        private int cost;
        private int[] prices;
        private bool isGood;

        public Trading(int[] prices, int cost)
        {
            this.prices = prices;
            this.cost = cost;
        }
        
        public void MakePrices(double[,] universe, int planetNum)
        {
            int counter = 0;
            for (counter = 0; counter < 10; counter++)
            {
                prices[counter] = (int)(universe[planetNum, (counter + 5)]);
            }
            Random rnd = new Random();
            int rando;
            counter = 1;
            do
            {
                rando = rnd.Next(1, 6);
                prices[counter] += (rando - 3);
                ++counter;
            }
            while (counter < 10);
            return;
        }

        public void NewTrade(Travel myUniverse, Player_Stats player, Ship myShip)
        {

            bool isDone = false;
            string input = "";
            Console.WriteLine($"Welcome to {myUniverse.GetPlanetName(myUniverse.planetNum)}.");
            Console.WriteLine($"Here is what we have.\n");
            PlanetInv(prices);
            do
            {
                Console.WriteLine("Would you like to buy or sell?");
                Console.WriteLine("If you would like to leave press \"Enter\".");
                input = Console.ReadLine();
                if (input == "")
                {
                    isDone = true;
                }
                else if (input == "Buy" || input == "buy")
                {
                    BuyThings(myShip, player, myUniverse); //Calls the methomakepricesd for buying
                }
                else if (input == "Sell" || input == "sell")
                {
                    SellThings(player, myShip);
                }
                else
                {
                    Console.WriteLine("I don't understand.");
                }
            }
            while (!isDone);
            Console.WriteLine("Good Luck!");
            return;
        }

        

        public void PlanetInv(int[] prices) // Planet Inventory
        {
            Console.WriteLine("Cost             Item Name");
            int counter = 1;
            do
            {
                Console.WriteLine($"({counter}.){prices[counter]}               {Utility.CargoName(counter)}");
                counter++;// increments counter loop
            }
            while (counter <= 9);
            return;
        }

        private bool checkInventorySlot(Ship myShip, ref int cargoWhere)
        {
            bool isGood;
            
            do
            {
                Console.WriteLine("Lets take a look at your ship");
                Utility.ShowCargoInv(myShip);// Check cargo inventory

                Console.WriteLine("Nice ship, what slot are we using for new cargo?");
                cargoWhere = Utility.GetInt(myShip.CargoSlots()); //Verify input is number

                if (cargoWhere <= 0)//Verify that the slot requested is not full or invalid
                {
                    Console.WriteLine("This is not a usable slot");
                    isGood = false;// return to the main menu        }
                }
                else
                {
                    cargoWhere--;
                    return true;
                }
            }
            while (!isGood);
            return false;
        }

        public void BuyThings(Ship myShip, Player_Stats player, Travel myUniverse)
        {
            int cargoWhere = 0;
            int itemAmount = 0;
            int currentItemBuy = 0;
            bool isGood = false;
            bool buy = false;
            cost = 0;
            do
            {
                if (checkInventorySlot(myShip, ref cargoWhere))
                {

                    if (myShip.inventory[cargoWhere, 0] != 0) //if slot isn't empty need to buy same thing
                    {
                        Console.WriteLine($"You want to buy more {Utility.CargoName(myShip.inventory[cargoWhere, 0])}.");
                        Console.WriteLine("How much do you want to buy?");
                        itemAmount = Utility.GetInt(myShip.SlotSize());
                        if (itemAmount == 0)
                        {
                            Console.WriteLine("Decided not to buy huh.");
                            isGood = true;
                        }
                        else if ((itemAmount + myShip.inventory[cargoWhere, 1]) > myShip.SlotSize()) //if the amount you want more than fills it you can't buy
                        {
                            Console.WriteLine("There isn't enough space");
                            isGood = true;
                        }
                        else// this is where buying happens when you already have the item
                        {
                            cost = prices[myShip.inventory[cargoWhere, 0]] * itemAmount;
                            Console.WriteLine($"That will cost {cost}.");
                            Utility.BuySellYN(cost, ref buy, 1, player); //call the buying thing
                            if (buy) //you bought something
                            {
                                Console.WriteLine("Thank you for your business.");
                                isGood = true;
                            }
                            cost = 0;
                        }
                    }
                    else //slot is empty, what do you want?
                    {
                        Console.WriteLine("What do you want to buy?");
                        Console.WriteLine("Press 0 to exit.");
                        currentItemBuy = Utility.GetInt(9);
                        if (currentItemBuy == 0) //you want to leave
                        {
                            Console.WriteLine("It's ok if you don't want to buy anything.");
                            isGood = true;
                        }
                        else //initial buying an item, something you don't already own
                        {
                            Console.WriteLine("How much to you want to buy?");
                            itemAmount = Utility.GetInt(myShip.SlotSize());
                            if (itemAmount == 0)
                            {
                                Console.WriteLine("Decided not to buy huh."); // 0 means buy nothing
                                isGood = true;
                            }
                            else if (itemAmount > myShip.SlotSize())
                            {
                                Console.WriteLine("There isn't enough space"); // you can't fit more than slotsize
                            }
                            else
                            {
                                cost = itemAmount * prices[currentItemBuy];
                                Console.WriteLine($"The cost is {cost}.");
                                Utility.BuySellYN(cost, ref buy, 1, player);
                                if (buy)
                                {
                                    myShip.inventory[cargoWhere, 1] = itemAmount;
                                    myShip.inventory[cargoWhere, 0] = currentItemBuy;
                                    cost = 0;
                                    isGood = true;
                                }
                                else
                                {
                                    Console.WriteLine("Mayber another time.");
                                    cost = 0;
                                    isGood = true;
                                }
                            }
                        }
                    }
                }
                
            }
            while (!isGood);
            return;
        }

        public void SellThings(Player_Stats player, Ship myShip)
        {
            bool isGood = false;
            bool buy;
            int input;
            int sellAmount;
            int sumTotal;
            do
            {
                buy = false;
                Console.WriteLine($"What cargo would you like to sell?\n");
                Console.WriteLine("Please enter the slot number of the cargo you wish to sell.");
                Console.WriteLine($"Enter {(myShip.CargoSlots() + 1)} to check your inventory, {myShip.CargoSlots() + 2} to look at the planet's");
                Console.WriteLine("pricing or 0 when you are done."); //what does the player want to do.
                input = Utility.GetInt(myShip.CargoSlots() + 2);
                if (input == (myShip.CargoSlots() + 1))
                {
                    Utility.ShowCargoInv(myShip); //SHOW ME WHAT YOU GOT
                }
                else if (input == myShip.CargoSlots() + 2)
                {
                    PlanetInv(prices); //how much are things worth?
                }
                else if (input == 0)
                {
                    Console.WriteLine("See ya around traveler."); //leaving
                    isGood = true;
                }
                else if (input < 0 || input > myShip.CargoSlots()) //why are you talking nonsense
                {
                    Console.WriteLine("Uh... ok, well see you later...");
                    isGood = true;
                }
                else if (myShip.inventory[(input-1), 1] == 0) // nothing there to sell
                {
                    Console.WriteLine($"That container is empty.\n");
                }
                else
                {
                    input--;
                    Console.WriteLine($"Alright that has {myShip.inventory[(input), 1]} units of {Utility.CargoName(myShip.inventory[(input), 0])}.");
                    Console.WriteLine($"How much would you like to sell?");
                    sellAmount = Utility.GetInt(myShip.inventory[input, 1]);
                    if (sellAmount == 0)
                    {
                        Console.WriteLine("It's fine if you don't want to sell.");
                        isGood = true;
                    }
                    else
                    {
                        sumTotal = prices[myShip.inventory[input, 0]] * sellAmount;
                        Console.WriteLine($"I'll give you {sumTotal} credits for that much.");
                        Utility.BuySellYN(sumTotal, ref buy, 1, player);
                        if (buy)
                        {
                            Console.WriteLine("Pleasure doing business with you.");
                            if (sellAmount == myShip.inventory[input, 1])
                            {
                                myShip.inventory[input, 0] = 0;
                                myShip.inventory[input, 1] = 0;
                            }
                            else
                            {
                                myShip.inventory[input, 1] -= sellAmount;
                            }
                            isGood = true;
                        }
                        else
                        {
                            Console.WriteLine("Well I can't offer you more than that.");
                            isGood = true;
                        }
                    }
                }
            }
            while (!isGood);
            return;
        }
    }
}
