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
        private int fuel;
        private int fuelTank;
        private bool fuelUpgrade = false;
        public int[,] inventory = new int[24, 2] ; //to store type and amount of cargo in slots

        public Ship(int warpSpeed, int shipSlots, int shipSlotCapacity, int fuelNow, int fuelTankSize)
        {
            this.speed = warpSpeed;
            this.slots = shipSlots;
            this.slotCapacity = shipSlotCapacity;
            this.fuel = fuelNow;
            this.fuelTank = fuelTankSize;
            this.inventory = new int[24, 2]{
                { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 },
                { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 },
                { 0, 0 }, { 0, 0 }, { 0, 0 } };
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
        
        public int Fuel()
        {
            return fuel;
        }
        
        public int FuelTank()
        {
            return fuelTank;
        }

        public void UseFuel(double distance)
        {
            int fuelUsed = (int)(Math.Ceiling(distance));
            fuel -= fuelUsed;
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
                    fuelTank = 20;
                    fuel = 20;
                    fuelUpgrade = false;
                    break;
                case 4:
                    speed = 6;
                    slots = 20;
                    slotCapacity = 10;
                    fuelTank = 40;
                    fuel = 40;
                    fuelUpgrade = false;
                    break;
                case 5:
                    speed = 8;
                    slots = 24;
                    slotCapacity = 14;
                    fuelTank = 80;
                    fuel = 80;
                    fuelUpgrade = false;
                    break;
                case 6:
                    fuelTank += (fuelTank / 2);
                    fuel = fuelTank;
                    fuelUpgrade = true;
                    break;
            }
        }

        public void ShipThings(ref Player_Stats player)
        {
            int cost = 0;
            int choice = 0;
            bool buy = false;
            Console.WriteLine("Hello traveler, looking a new ship, some upgrades, or maybe just for fuel?");
            Console.WriteLine("1. Buying a new ship.");
            Console.WriteLine("2. Upgrading my ship's speed.");
            Console.WriteLine("3. Upgrading my ship's cargo space.");
            Console.WriteLine("4. Upgrading my ship's fuel capacity.");
            Console.WriteLine("5. Buy fuel for my ship.");
            Console.WriteLine("0. I was just leaving.");
            Console.WriteLine("Please enter the number of your choice.");
            choice = Utility.GetInt(5);
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("We have a light cargo ship, a space freighter, and an old refitted battle cruiser");
                    Console.WriteLine("The cargo ship is 500 credits, the space freighter is 1000, and the battle cruiser .");
                    Console.WriteLine("is 2000. Enter 1 for the cargo ship, 2 for the space freighter, or 3 for the battle cruiser,");
                    Console.WriteLine("Enter 0 to exit.");
                    choice = Utility.GetInt(3);
                    switch (choice)
                    {
                        case 1:
                            {
                                Utility.BuySellYN(500, ref buy, 1, player);
                                if (buy)
                                {
                                    ShipUpgrade(3);
                                    break;
                                }
                                else { break; }
                            }
                        case 2:
                            {
                                Utility.BuySellYN(1000, ref buy, 1, player);
                                if (buy)
                                {
                                    ShipUpgrade(4);
                                    break;
                                }
                                else { break; }
                            }
                        case 3:
                            {
                                Utility.BuySellYN(2000, ref buy, 1, player);
                                if (buy)
                                {
                                    ShipUpgrade(5);
                                    break;
                                }
                                else { break; }
                            }
                        case 0:
                            {
                                Console.WriteLine("See ya around traveler.");
                                break;
                            }
                    }
                    break;
                case 2:
                    {
                        if (speed%2 == 1 && speed != 3)
                        {
                            Console.WriteLine("I told you once per ship.");
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
                            else 
                            {
                                cost = speed * speed * 15;
                                Console.WriteLine($"That'll be {cost} credits.");
                                Utility.BuySellYN(cost, ref buy, 1, player);
                                if (buy)
                                {
                                    ShipUpgrade(1);
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
                        if (slots == 12)
                        {
                            Console.WriteLine("If we attatch anything to that mess you'll be turning into some light speed shrapnel.");
                        }
                        else if (slotCapacity == 8 || slotCapacity == 12 || slotCapacity == 16)
                        {
                            Console.WriteLine("We can't make any more space on that.");
                        }
                        else
                        { 
                            cost = (slotCapacity + 2) * ((slotCapacity + 2)) * 5;
                            Console.WriteLine($"That'll be {cost} credits.");
                            Utility.BuySellYN(cost, ref buy, 1, player);
                            if (buy)
                            {
                                ShipUpgrade(2);
                                break;
                            }
                            else { break; }
                        }
                        
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Looking to travel to the farthest reaches.");
                        if (fuelUpgrade)
                        {
                            Console.WriteLine("We already did that, you'll need a bigger ship to hold more fuel.");
                        }
                        else
                        {
                            cost = (fuelTank + (fuelTank / 2)) * 10;
                            Console.WriteLine($"It will cost {cost}.");
                            Utility.BuySellYN(cost, ref buy, 1, player);
                            if (buy)
                            {
                                ShipUpgrade(6);
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Need some fuel huh?");
                        if (fuel == fuelTank)
                        {
                            Console.WriteLine("Tank's full already");
                        }
                        else
                        {
                            Console.WriteLine("Ok how much do you want to buy?");
                            Console.WriteLine("Enter 0 if you want a full tank.");
                            choice = Utility.GetInt(fuelTank - fuel);
                            if (choice == 0)
                            {
                                cost = (fuelTank - fuel) * 5;
                                Console.WriteLine($"That will cost {cost}.");
                                Utility.BuySellYN(cost, ref buy, 1, player);
                                if (buy)
                                {
                                    Console.WriteLine("Thanks for your business!");
                                }
                            }
                            else
                            {
                                cost = choice * 5;
                                Console.WriteLine($"That will cost {cost}.");
                                Utility.BuySellYN(cost, ref buy, 1, player);
                                if (buy)
                                {
                                    Console.WriteLine("Thanks for your business!");
                                }
                            }
                        }
                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("See ya around traveler.");
                        break;
                    }
            }
        }
        
    }
}
