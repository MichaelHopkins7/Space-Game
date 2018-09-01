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
        
        public void MakePrices(Travel myUniverse)
        {
            int counter = 0;
            for (counter = 0; counter < 10; counter++)
            {
                prices[counter] = (int)(myUniverse.universe[myUniverse.planetNum, (counter + 5)]);
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
        }

        public void NewTrade(Travel myUniverse, Player_Stats player, Ship myShip)
        {

            bool isDone = false;
            string input = "";
            do
            {
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
                    SellThings();
                }
                else
                {
                    Console.WriteLine("I don't understand.");
                }
            }
            while (!isDone);
            Console.WriteLine("Good Luck!");
        }

        private static void SellThings()
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

        public void PlanetInv(int[] prices) // Planet Inventory
        {
            Console.WriteLine("Item Name		    Cost\n");
            int counter = 1;
            do
            {
                Console.WriteLine($"({counter}){Utility.CargoName(counter)}              {(prices[counter])}");
            }
            while (counter <= 9);
        }

        private bool checkInventorySlot(Ship myShip)
        {
            bool isGood;
            int cargoWhere;
            do
            {
                Console.WriteLine("Lets take a look at your ship");
                Utility.ShowCargoInv(myShip);// Check cargo inventory

                Console.WriteLine("Nice ship, what slot are we using for new cargo?");
                cargoWhere = Utility.GetInt(myShip.CargoSlots()); //Verify input is number

                if ((cargoWhere >= myShip.CargoSlots()) || cargoWhere <= 0)//Verify that the slot requested is not full or invalid
                {
                    Console.WriteLine("This is not a usable slot");
                    isGood = false;// return to the main menu        }
                }
                else
                {
                    return true;
                }
            }
            while (!isGood);
            return false;
        }

        public void BuyThings(ref Ship myShip, ref Player_Stats player, Travel myUniverse)
        {
            int cargoWhere;
            int itemAmount;
            int currentItemBuy;
            bool isGood = false;
            bool buy = false;
            do
            {
                Console.WriteLine("Nice ship, what slot are we using for new cargo?");
                Console.WriteLine("Enter the slot number or 0 to show your inventory and planet prices.");
                cargoWhere = Utility.GetInt(myShip.CargoSlots()); ///CargoWhere: where we are placing the new cargo
                if (cargoWhere == 0) // show inventory
                {
                    Utility.ShowCargoInv(myShip);
                }
                else // this is where buying starts
                {
                    if (myShip.inventory[cargoWhere, 0] != 0) //if slot isn't empty need to buy same thing
                    {
                        Console.WriteLine($"You want to buy more {Utility.CargoName(myShip.inventory[cargoWhere, 0])}.");
                        Console.WriteLine($"How much {Utility.CargoName(myShip.inventory[cargoWhere, 0])} do you want to buy?");
                        Console.WriteLine("How much to you want to buy?");
                        itemAmount = Utility.GetInt(myShip.SlotSize());
                        if (itemAmount == 0)
                        {
                            Console.WriteLine("Decided not to buy huh.");
                            isGood = true;
                        }
                        else if ((itemAmount + myShip.inventory[cargoWhere, 1]) > myShip.SlotSize()) //if the amount you want more than fills it you can't buy
                        {
                            Console.WriteLine("There isn't enough space");
                        }
                        else
                        {
                            cost = prices[myShip.inventory[cargoWhere, 0]] * itemAmount;
                            Console.WriteLine($"That will cost {cost}.");
                            Utility.BuySellYN(cost, ref buy, 1, player); //call the buying thing
                            if (buy) //you bought something
                            {
                                Console.WriteLine("Thank you for your business.");
                                isGood = true;
                            }
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
                        else //so you are buying something
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
                                cost = itemAmount * prices[myShip.inventory[cargoWhere, 0]];
                                Utility.BuySellYN(cost, ref buy, 1, player);
                                if (buy)
                                {
                                    myShip.inventory[cargoWhere, 1] += itemAmount;
                                    cost = 0;
                                }
                                else
                                {
                                    Console.WriteLine("Mayber another time.");
                                    cost = 0;
                                }
                            }
                        }
                    }
                }
            }
            while (!isGood);
        }

        public void sellThings(ref Player_Stats player, ref Ship myShip, int[] prices)
        {
            bool isGood = false;
            bool buy = false;
            int input;
            int cAmount;
            int sumTotal;
            do
            {
                buy = false;
                Console.WriteLine($"What cargo would you like to sell?\n");
                Console.WriteLine("Please enter the slot number of the cargo you wish to sell.");
                Console.WriteLine("Enter \"100\" to check your inventory, 101 to look at the planet's");
                Console.WriteLine("pricing or 0 when you are done."); //what does the player want to do.
                input = Utility.GetInt(myShip.CargoSlots() + 2);
                switch (input)
                {
                    case 100:
                        {
                            Utility.ShowCargoInv(myShip); //SHOW ME WHAT YOU GOT
                            break;
                        }
                    case 101:
                        {
                            PlanetInv(prices); //how much are things worth?
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("See ya around traveler."); //leaving
                            isGood = true;
                            break;
                        }
                    default: //done asking questions? time to sell things
                        if (input < 0 || input > myShip.CargoSlots()) //why are you talking nonsense
                        {
                            Console.WriteLine("Uh... ok, well see you later...");
                            isGood = true;
                            break;
                        }
                        else if (myShip.inventory[input, 1] == 0)
                        {
                            Console.WriteLine($"That container is empty.\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Alright that has {myShip.inventory[input, 1]} units of {Utility.CargoName(myShip.inventory[input, 0])}.");
                            Console.WriteLine($"How much would you like to sell?");
                            cAmount = Utility.GetInt(myShip.inventory[input, 1]);
                            if (cAmount > myShip.inventory[input, 1] || cAmount < 0) // are you trying to sell more than you have?
                            {
                                Console.WriteLine("I don't understant.");
                                break;
                            }
                            else if (cAmount == 0)
                            {
                                Console.WriteLine("It's fine if you don't want to sell.");
                                break;
                            }
                            else
                            {
                                sumTotal = prices[myShip.inventory[input, 0]] * cAmount;
                                Console.WriteLine($"I'll give you {sumTotal} credits for that much.");
                                Utility.BuySellYN(sumTotal, ref buy, 1, player);
                                if (isGood)
                                {
                                    Console.WriteLine("Pleasure doing business with you.");
                                    if (cAmount == myShip.inventory[input, 1])
                                    {
                                        myShip.inventory[input, 0] = 0;
                                        myShip.inventory[input, 1] = 0;
                                    }
                                    else
                                    {
                                        myShip.inventory[input, 1] -= cAmount;
                                    }
                                    isGood = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("I can't offer you more than that.");
                                    break;
                                }
                            }
                        }
                }
            }
            while (!isGood);
        }
    }
}
