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
            while (false);
            return value;
        }

        public static void BuySellYN(ref int money, int val, ref bool action, int buySell)
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
                        if (money > val)
                        {
                            Console.WriteLine("You don't have enough money.");
                            action = false;
                            break;
                        }
                        else
                        {
                            money -= val;
                            action = true;
                            break;
                        }
                    }
                    else
                    {
                        money += val;
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
        }
    }
}
