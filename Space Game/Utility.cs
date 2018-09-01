using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Utility
    {
        public static int GetInt(int maxNum)
        {
            int value;
            string input = Console.ReadLine();
            do
            {
                if (int.TryParse(input, out value))
                {
                    if (value > maxNum || value < 0)
                    {
                        Console.WriteLine($"Please enter a valid integer equal to or less than {maxNum}.");
                        input = Console.ReadLine();
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the number of your choice");
                    input = Console.ReadLine();
                }
            }
            while (true);
        }

        public static bool CheckGameOver(Ship myShip, Travel myUniverse, Player_Stats player)
        {
            int counter = 0;
            bool hasCargo = false;
            bool enoughFuel = false;
            do
            {
                if (myShip.inventory[counter, 1] == 0 )
                {
                    hasCargo = false;
                }
                else
                {
                    hasCargo = true;
                    counter = myShip.CargoSlots();
                }
            }
            while (counter < myShip.CargoSlots());

            myUniverse.WhereCanMove(myShip, ref enoughFuel, false);

            if (player.SYears() >= 40)
            {
                return true;
            }
            else if (player.SMoney() == 0 && hasCargo == false)
            {
                return true;
            }
            else if ((player.SMoney() <= 4) && enoughFuel == false)
            {
                return true;
            }
            return false;
        }

        public static void BuySellYN(int val, ref bool action, int buySell, Player_Stats player)
        {
            int choice;
            string purchaseSell;
            if (buySell == 1) { purchaseSell = "Purchase"; } //says buy if buying
            else { purchaseSell = "Sell"; } // says sell if selling
            Console.WriteLine($"1. {purchaseSell}");
            Console.WriteLine("2. Decline");
            choice = GetInt(2);
            switch (choice)
            {
                case 1:
                    if (buySell == 1)
                    {
                        if (player.SMoney() < val)
                        {
                            Console.WriteLine("You don't have enough money.");
                            action = false;
                            break;
                        }
                        else
                        {
                            player.ChangeMoney(-val);
                            action = true;
                            break;
                        }
                    }
                    else
                    {
                        player.ChangeMoney(val);
                        action = true;
                        break;
                    }
                case 2:
                    Console.WriteLine("Well maybe another time.");
                    action = false;
                    break;
                default:
                    Console.WriteLine("Uh... ok, well see you later...");
                    action = false;
                    break;
            }
            return;
        }

        public static string CargoName(int typeNum)
        {
            switch (typeNum)
            {
                case 1:
                    return "Gold";
                case 2:
                    return "Iron";
                case 3:
                    return "Selenium";
                case 4:
                    return "Platinum";
                case 5:
                    return "Titanium";
                case 6:
                    return "Aluminum";
                case 7:
                    return "Rhodium";
                case 8:
                    return "Rhuthenium";
                case 9:
                    return "Iridium";
                default:
                    return "nothing";
            }
        }

        public static void ShowCargoInv(Ship myShip)
        {
            int counter = 0;
            Console.WriteLine("SHIP CARGO");
            do
            {
                if (myShip.inventory[(counter), 0] == 0) // first spot in array is cargo type.  Type 0 is empty.
                {
                    Console.WriteLine($"Container {counter + 1} has nothing in it."); //says container it's on is empty
                }
                else
                {
                    Console.WriteLine($"Container {counter + 1} has {myShip.inventory[counter, 1]} units of {CargoName(myShip.inventory[counter, 0])}."); //says container content type and count.
                }
                counter++;
            }
            while (counter < myShip.CargoSlots());
            return;
        }
    }
}
