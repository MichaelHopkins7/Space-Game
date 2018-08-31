using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Trading
    {
        public int money;

        public Trading()
        {
            money = 100;
        }
        public static bool checkInventorySlot(int cargoSlots, int[,] inventory)
        {
            bool isGood;
            int cargoWhere;
            int newCargo;
            do
            {
                Console.WriteLine("Lets take a look at your ship");
                showCargoInv(cargoSlots, inventory);// Check cargo inventory

                Console.WriteLine("Nice ship, what slot are we using for new cargo?");
                cargoWhere = Utility.GetInt(cargoSlots); //Verify input is number

                if (cargoWhere => 2 || cargoWhere <== 0)//Verify that the slot requested is not full or invalid
                {
                    Console.WriteLine("This is not a usable slot");
                    isgood != True// return to the main menu        }
                }
                else
                {
                    isgood = true
                }
            }
        }

        public static void BuyThings(int cargoSlots, int slotSpace, int[,] inventory, int[] prices, )
        {
            int input;
            int cargoWhere;
            int itemAmount;
            int totalPrice;
            string currentItemBuy;

            do
            {
                checkInventorySlot
                if
                {
                    isGood == true// begin buying process
                }


                Console.WriteLine("Nice ship, what slot are we using for new cargo?");
                cargoWhere = Utility.GetInt(cargoSlots); ///CargoWhere: where we are placing the new cargo
                if (cargoWhere == 100)
                {
                    showCargoInv(cargoSlots, inventory);
                }
                else if (cargoWhere == 0 || cargoWhere is => 10)
                {
                    Console.WriteLine("You cannot access ")
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

    }
}
