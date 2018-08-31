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
                    if (myShip.inventory[cargoWhere, 0] != 0)
                    {
                        Console.WriteLine($"You want to buy more {Utility.cargoName(myShip.inventory[cargoWhere, 0])}.");
                        Console.WriteLine($"How much {Utility.cargoName(myShip.inventory[cargoWhere, 0])} do you want to buy?");
                        Console.WriteLine("How much to you want to buy?");
                        itemAmount = Utility.GetInt(myShip.SlotSize());
                        if (itemAmount == 0)
                        {
                            Console.WriteLine("Decided not to buy huh.");
                            isGood = true;
                        }
                        else if ((itemAmount + myShip.inventory[cargoWhere, 1]) > myShip.SlotSize())
                        {
                            Console.WriteLine("There isn't enough space");
                        }
                        else
                        {
                            cost = prices[myShip.inventory[cargoWhere, 0]] * itemAmount;
                            Console.WriteLine($"That will cost {cost}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("What do you want to buy?");
                        currentItemBuy = Utility.GetInt(9);
                        if (currentItemBuy == 0)
                        {
                            Console.WriteLine("It's ok if you don't want to buy anything.");
                            isGood = true;
                        }
                        else
                        {
                            Console.WriteLine("How much to you want to buy?");
                            itemAmount = Utility.GetInt(myShip.SlotSize());
                            if (itemAmount == 0)
                            {
                                Console.WriteLine("Decided not to buy huh.");
                                isGood = true;
                            }
                            else if ((itemAmount + myShip.inventory[cargoWhere, 1]) > myShip.SlotSize())
                            {
                                Console.WriteLine("There isn't enough space");
                            }
                            else
                            {
                                cost = itemAmount * prices[myShip.inventory[cargoWhere, 0]];
                                Utility.BuySellYN(cost, ref buy, 1, ref player);
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

    }
}
