using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Ship
    {
        private int speed;
        private int slots;
        private int slotCapacity;

        public Ship(int warpSpeed, int shipSlots, int shipSlotCapacity)
        {
            this.speed = warpSpeed;
            this.slots = shipSlots;
            this.slotCapacity = shipSlotCapacity;
        }

        public int Speed()
        {
            return speed;
        }

        public int CargoSlots()
        {
            return this.slots;
        }

        public int SlotSize()
        {
            return slotCapacity;
        }

        private void ShipUpgrade(int choice)
        {
            switch (choice)
            {
                case 1:
                    speed += 1;
                    break;
                case 2:
                    slotCapacity += 2;
                    break;
                case 3:
                    speed = 4;
                    slots = 16;
                    break;
                case 4:
                    speed = 6;
                    slots = 20;
                    slotCapacity = 10;
                    break;
                case 5:
                    speed = 8;
                    slots = 24;
                    break;
            }
        }

        public void newShip(ref int money, ref int cargoSlots, ref int slotSpace, ref int speed)
        {
            int choice = 0;
            bool buy = false;
            Console.WriteLine("Hello traveler, looking for a new ship or maybe just some upgrades?");
            Console.WriteLine("1. Buying a new ship.");
            Console.WriteLine("2. Upgrading my ship's speed.");
            Console.WriteLine("3. Upgrading my ship's cargo space.");
            Console.WriteLine("4. I was just leaving.");
            Console.WriteLine("Please enter the number of your choice.");
            choice = getInt(4);
            if (choice < 1 || choice > 4)
            {
                choice = 0;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("We have a light cargo ship, a space freighter, and an old refitted battle cruiser");
                    Console.WriteLine("The cargo ship is 500 credits, the space freighter is 1000, and the battle cruiser .");
                    Console.WriteLine("is 2000. Enter 1 for the cargo ship, 2 for the space freighter, or 3 for the battle cruiser,");
                    Console.WriteLine("Enter 0 to exit.");
                    choice = getInt(3);
                    switch (choice)
                    {
                        case 1:
                            {
                                buySellYN(ref money, 500, ref buy, 1);
                                if (buy)
                                {
                                    cargoSlots = 16;
                                    slotSpace = 6;
                                    speed = 4;
                                    break;
                                }
                                else { break; }
                            }
                        case 2:
                            {
                                buySellYN(ref money, 1000, ref buy, 1);
                                if (buy)
                                {
                                    cargoSlots = 20;
                                    slotSpace = 10;
                                    speed = 6;
                                    break;
                                }
                                else { break; }
                            }
                        case 3:
                            {
                                buySellYN(ref money, 2000, ref buy, 1);
                                if (buy)
                                {
                                    cargoSlots = 24;
                                    slotSpace = 14;
                                    speed = 8;
                                    break;
                                }
                                else { break; }
                            }
                        case 0:
                            {
                                Console.WriteLine("See ya around traveler.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("If you aren't gonna talk sense then leave.");
                                break;
                            }
                    }
                    break;
                case 2:
                    {
                        if (speed == 5 || speed == 7)
                        {
                            Console.WriteLine("I told you last time that we can only do that once per ship.");
                        }
                        else if (speed == 9)
                        {
                            Console.WriteLine("At Warp 10 things get weird.  Nobody is gonna help you do that.");
                        }
                        else
                        {
                            Console.WriteLine("Cost is gonna depend on how fast your ship already is.");
                            Console.WriteLine("Also we can only modify the engine once on a ship.");
                            Console.WriteLine($"Warp drives are just too finnicky to mess around with more than that.\n");
                            if (speed == 3)
                            {
                                Console.WriteLine("Nothing is gonna help that hunk of junk, just save up for a new ship.");
                            }
                            else if (speed == 4)
                            {
                                Console.WriteLine("That'll be 250 credits.");
                                buySellYN(ref money, 250, ref buy, 1);
                                if (buy)
                                {
                                    ++speed;
                                    break;
                                }
                                else { break; }
                            }
                            else if (speed == 6)
                            {
                                Console.WriteLine("It'll be 500 credits.");
                                buySellYN(ref money, 500, ref buy, 1);
                                if (buy)
                                {
                                    ++speed;
                                    break;
                                }
                                else { break; }
                            }
                            else
                            {
                                Console.WriteLine("It'll be 1000 Credits.");
                                buySellYN(ref money, 1000, ref buy, 1);
                                if (buy)
                                {
                                    ++speed;
                                    break;
                                }
                                else { break; }
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("We can attatch some extra containers to the superstructure of your ship.");
                        Console.WriteLine("Gotta make sure things are attatched properly, don't want things coming");
                        Console.WriteLine("loose during warp travel.  The planet you're approaching when it breaks ");
                        Console.WriteLine("won't appreciate your clever cost cutting.");
                        if (cargoSlots == 12)
                        {
                            Console.WriteLine("If we attatch anything to that mess you'll be turning into some light");
                            Console.WriteLine("speed shrapnel.");
                        }
                        else if (slotSpace == 6)
                        {
                            Console.WriteLine("That'll be 300 credits.");
                            buySellYN(ref money, 300, ref buy, 1);
                            if (buy)
                            {
                                slotSpace += 2;
                                break;
                            }
                            else { break; }
                        }
                        else if (slotSpace == 10)
                        {
                            Console.WriteLine("That'll be 600 credits.");
                            buySellYN(ref money, 600, ref buy, 1);
                            if (buy)
                            {
                                slotSpace += 2;
                                break;
                            }
                            else { break; }
                        }
                        else if (slotSpace == 14)
                        {
                            Console.WriteLine("That'll be 1200 credits.");
                            buySellYN(ref money, 1200, ref buy, 1);
                            if (buy)
                            {
                                slotSpace += 2;
                                break;
                            }
                            else { break; }
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("See ya around traveler.");
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("Uh... ok, well see you later...");
                        break;
                    }
            }
        }

    }
}
